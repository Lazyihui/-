using System;
using System.IO;

namespace Hamdoku.Controllers {
    public static class StreakController {
        public static int DayNumber(DateTime date) {
            return checked((int)(date.Date.Ticks / TimeSpan.TicksPerDay) + 1);
        }

        public static DateTime DateFromDay(int day) {
            return new DateTime((long)(day - 1) * TimeSpan.TicksPerDay);
        }

        public static void Initialize(GameContext ctx, PlayerSaveModel loaded) {
            var save = ctx.playerSave;
            // Legacy saves have a counter but no dated evidence. Preserve the best,
            // rather than manufacturing consecutive wins or reward eligibility.
            save.streak = loaded != null && loaded.streak != null ? loaded.streak : new StreakSaveModel {
                bestDays = save.dailyStreak
            };
            var state = ctx.state_Streak;
            var data = save.streak;
            state.pagePending = data.pagePending;
            RefreshDay(ctx, DateTime.Today);
        }

        public static bool HasWin(StreakSaveModel data, int day) {
            return data.winDays.BinarySearch(day) >= 0;
        }

        public static int Slot(int streak, StreakConfigSO config) {
            return streak <= 0 ? 0 : (streak - 1) % config.cycleDays + 1;
        }

        public static int PlantCut(int streak, StreakConfigSO config) {
            if (streak >= config.cycleDays) {
                return 5;
            }
            int headDay = Math.Max(2, Math.Min((config.cycleDays + 1) / 2, config.cycleDays - 1));
            if (streak >= headDay) {
                return 4;
            }
            if (streak < 2) {
                return 1;
            }
            return streak == headDay - 1 && headDay > 3 ? 3 : 2;
        }

        public static void RefreshDay(GameContext ctx, DateTime today) {
            var save = ctx.playerSave;
            var data = save.streak;
            var state = ctx.state_Streak;
            int day = DayNumber(today);
            bool changed = state.displayedDay != day;
            // A backwards device clock must not award or rewrite dated progress.
            save.dailyStreak = data.lastWinDay <= day && data.lastWinDay >= day - 1 ? data.runDays : 0;
            state.displayedDay = day;
            if (changed && state.isOpen) {
                state.notice = UINameType.None;
                state.previewSlot = 0;
                Panel_Streak_Controller.Refresh(ctx);
            }
        }

        // Called only after an authoritative victory. The caller persists this
        // together with the completed board, so a restart cannot award twice.
        public static bool RecordWin(GameContext ctx, DateTime date) {
            var state = ctx.state_Streak;
            var save = ctx.playerSave;
            var data = save.streak;
            int day = DayNumber(date);
            if (day <= data.lastWinDay || HasWin(data, day)) {
                return false;
            }
            var assets = ctx.assetModule;
            var config = assets.GetStreakConfig();
            data.runDays = data.lastWinDay == day - 1 ? checked(data.runDays + 1) : 1;
            data.lastWinDay = day;
            data.bestDays = Math.Max(data.bestDays, data.runDays);
            data.winDays.Add(day);
            save.dailyStreak = data.runDays;
            int slot = Slot(data.runDays, config);
            int rewardIndex = slot - 1;
            if (config.rewardHints[rewardIndex] > 0 || config.rewardGuides[rewardIndex] > 0) {
                data.pendingHints = checked(data.pendingHints + config.rewardHints[rewardIndex]);
                data.pendingGuides = checked(data.pendingGuides + config.rewardGuides[rewardIndex]);
                data.pendingSlot = slot;
            }
            state.pagePending = true;
            data.pagePending = true;
            state.displayedDay = day;
            return true;
        }

        public static void Open(GameContext ctx) {
            var state = ctx.state_Streak;
            if (state.disposed) {
                throw new InvalidOperationException("Streak has been disposed.");
            }
            if (state.isOpen) {
                Panel_Streak_Controller.Refresh(ctx);
                return;
            }
            RefreshDay(ctx, DateTime.Today);
            state.notice = UINameType.None;
            state.previewSlot = 0;
            state.pagePending = false;
            state.isOpen = true;
            Panel_Streak_Controller.Open(ctx);
            var save = ctx.playerSave;
            var data = save.streak;
            if (data.pagePending) {
                data.pagePending = false;
                HomeController.SaveProgress(ctx);
            }
        }

        public static void Close(GameContext ctx) {
            var state = ctx.state_Streak;
            state.isOpen = false;
            state.notice = UINameType.None;
            state.previewSlot = 0;
            state.continueCampaign = false;
            Panel_Streak_Controller.Close(ctx);
            HomeController.Refresh(ctx);
        }

        public static void Continue(GameContext ctx) {
            var state = ctx.state_Streak;
            if (!state.isOpen) {
                return;
            }
            var save = ctx.playerSave;
            var data = save.streak;
            if (data.pendingHints > 0 || data.pendingGuides > 0) {
                ClaimRewards(ctx);
                return;
            }
            bool continueCampaign = state.continueCampaign;
            Close(ctx);
            if (continueCampaign) {
                var assets = ctx.assetModule;
                var campaignConfig = assets.GetCampaignConfig();
                if (save.campaignClears < campaignConfig.campaignSizes.Length) {
                    HomeController.RequestCampaign(ctx);
                } else {
                    HomeController.ShowNotice(ctx, UINameType.Game_BatchComplete, 0);
                }
            }
        }

        public static bool OpenAfterGame(GameContext ctx) {
            var state = ctx.state_Streak;
            if (!state.pagePending) {
                return false;
            }
            state.continueCampaign = true;
            HomeController.Open(ctx);
            return true;
        }

        public static void ClaimRewards(GameContext ctx) {
            var state = ctx.state_Streak;
            var save = ctx.playerSave;
            var data = save.streak;
            if (!state.isOpen || (data.pendingHints == 0 && data.pendingGuides == 0)) {
                return;
            }
            data.bonusHints = checked(data.bonusHints + data.pendingHints);
            data.bonusGuides = checked(data.bonusGuides + data.pendingGuides);
            data.pendingHints = 0;
            data.pendingGuides = 0;
            data.pendingSlot = 0;
            HomeController.SaveProgress(ctx);
            state.notice = UINameType.Streak_Claimed;
            state.previewSlot = 0;
            Panel_Streak_Controller.Refresh(ctx);
        }

        public static void PreviewReward(GameContext ctx, int slot) {
            var state = ctx.state_Streak;
            if (!state.isOpen) {
                return;
            }
            var assets = ctx.assetModule;
            var config = assets.GetStreakConfig();
            if (slot < 1 || slot > config.cycleDays || (config.rewardHints[slot - 1] == 0 && config.rewardGuides[slot - 1] == 0)) {
                throw new ArgumentOutOfRangeException(nameof(slot));
            }
            state.previewSlot = slot;
            state.notice = UINameType.Streak_RewardPreview;
            Panel_Streak_Controller.Refresh(ctx);
        }

        public static bool CanRecover(GameContext ctx) {
            var save = ctx.playerSave;
            var data = save.streak;
            var state = ctx.state_Streak;
            var assets = ctx.assetModule;
            var config = assets.GetStreakConfig();
            int missed = state.displayedDay - data.lastWinDay - 1;
            return config.recoveryEnabled && data.runDays >= config.recoveryMinStreak &&
                missed >= 1 && missed <= config.recoveryMaxGapDays && data.recoveryDismissedDay != state.displayedDay;
        }

        public static void RequestRecovery(GameContext ctx) {
            var state = ctx.state_Streak;
            if (!state.isOpen || !CanRecover(ctx)) {
                return;
            }
            // No ad SDK is connected. Opening this action never restores wins.
            state.notice = UINameType.Streak_RecoveryUnavailable;
            state.previewSlot = 0;
            Panel_Streak_Controller.Refresh(ctx);
        }

        public static void DismissRecovery(GameContext ctx) {
            var state = ctx.state_Streak;
            if (!state.isOpen || !CanRecover(ctx)) {
                return;
            }
            var save = ctx.playerSave;
            var data = save.streak;
            data.recoveryDismissedDay = state.displayedDay;
            state.notice = UINameType.None;
            HomeController.SaveProgress(ctx);
            Panel_Streak_Controller.Refresh(ctx);
        }

        public static bool TrySpendHint(GameContext ctx) {
            var save = ctx.playerSave;
            var data = save.streak;
            if (data.bonusHints == 0) {
                return false;
            }
            data.bonusHints--;
            return true;
        }

        public static bool TrySpendGuide(GameContext ctx) {
            var save = ctx.playerSave;
            var data = save.streak;
            if (data.bonusGuides == 0) {
                return false;
            }
            data.bonusGuides--;
            return true;
        }

        public static void Tick(GameContext ctx, float deltaTime) {
            var state = ctx.state_Streak;
            int today = DayNumber(DateTime.Today);
            if (state.displayedDay != today) {
                RefreshDay(ctx, DateTime.Today);
                state.notice = UINameType.None;
                state.previewSlot = 0;
                Panel_Streak_Controller.Refresh(ctx);
                HomeController.SaveProgress(ctx);
                HomeController.Refresh(ctx);
            }
            Panel_Streak_Controller.Tick(ctx, deltaTime);
        }

        public static void Dispose(GameContext ctx) {
            var state = ctx.state_Streak;
            if (state.disposed) {
                return;
            }
            state.isOpen = false;
            state.disposed = true;
            Panel_Streak_Controller.Close(ctx);
        }

        public static void ValidateConfig(StreakConfigSO config) {
            if (config.cycleDays != 7 || config.rewardHints == null || config.rewardGuides == null ||
                config.rewardHints.Length != config.cycleDays || config.rewardGuides.Length != config.cycleDays ||
                config.plants == null || config.plants.Length != 6 || config.companionDays == null || config.companionDays.Length != 7 ||
                config.introSeconds <= 0 || config.swaySeconds <= 0 || config.butterflySeconds <= 0 || config.butterflyFlapSeconds <= 0 ||
                config.stampSeconds <= 0 || config.plantReferencePixels <= 0 || config.petalCount <= 0 || config.recoveryMaxGapDays < 0 || config.recoveryMinStreak < 1) {
                throw new InvalidDataException("Invalid StreakConfigSO.");
            }
            for (int i = 0; i < config.cycleDays; i++) {
                if (config.rewardHints[i] < 0 || config.rewardGuides[i] < 0) {
                    throw new InvalidDataException("Invalid streak reward configuration.");
                }
            }
            foreach (var plant in config.plants) {
                if (plant == null) {
                    throw new InvalidDataException("Missing streak plant sprite.");
                }
            }
            if (config.smallGift == null || config.bigGift == null || config.check == null || config.aura == null ||
                config.petal == null || config.flowerHead == null || config.butterflies == null || config.butterflies.Length != 4) {
                throw new InvalidDataException("Missing streak presentation assets.");
            }
            foreach (var sprite in config.butterflies) {
                if (sprite == null) {
                    throw new InvalidDataException("Missing streak butterfly sprite.");
                }
            }
        }
    }
}
