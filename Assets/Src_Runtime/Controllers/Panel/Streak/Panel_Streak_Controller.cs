using System;
using UnityEngine;

namespace Hamdoku.Controllers {
    public static class Panel_Streak_Controller {
        public static void Open(GameContext ctx) {
            var opened = PanelFactory.TryOpen(ctx, PanelType.Streak, out Panel_Streak panel);
            if (opened == UIOpenType.FirstOpen) {
                var localization = ctx.l10NModule;
                panel.Ctor(localization);
                panel.backHandle = () => StreakController.Close(ctx);
                panel.continueHandle = () => StreakController.Continue(ctx);
                panel.claimHandle = () => StreakController.ClaimRewards(ctx);
                panel.recoverHandle = () => StreakController.RequestRecovery(ctx);
                panel.dismissHandle = () => StreakController.DismissRecovery(ctx);
                panel.rewardHandle = slot => StreakController.PreviewReward(ctx, slot);
            }
            panel.Init();
            Refresh(ctx, true);
            RefreshSafeArea(ctx, true);
        }

        public static void Refresh(GameContext ctx, bool stamp = false) {
            var panels = ctx.panelRepository;
            if (!panels.TryGet(PanelType.Streak, out Panel_Streak panel)) {
                return;
            }
            var save = ctx.playerSave;
            var data = save.streak;
            var state = ctx.state_Streak;
            var assets = ctx.assetModule;
            var config = assets.GetStreakConfig();
            int today = state.displayedDay;
            bool wonToday = StreakController.HasWin(data, today);
            int displayedSlot = StreakController.Slot(save.dailyStreak + (wonToday ? 0 : 1), config);
            int firstDay = today - Math.Max(1, displayedSlot) + 1;
            panel.titleLabel.text = Text(ctx, UINameType.Streak_Title);
            panel.countLabel.text = save.dailyStreak.ToString();
            panel.currentLabel.text = Text(ctx, UINameType.Streak_Current);
            panel.bestLabel.text = string.Format(Text(ctx, UINameType.Streak_Best), data.bestDays);
            panel.continueLabel.text = Text(ctx, UINameType.Streak_Continue);
            panel.claimLabel.text = Text(ctx, UINameType.Streak_Claim);
            for (int i = 0; i < panel.days.Length; i++) {
                int day = firstDay + i;
                var date = StreakController.DateFromDay(day);
                int weekday = ((int)date.DayOfWeek + 6) % 7;
                var id = (UINameType)((int)UINameType.Streak_Monday + weekday);
                bool hasReward = config.rewardHints[i] > 0 || config.rewardGuides[i] > 0;
                var gift = !hasReward ? null : i + 1 == config.cycleDays ? config.bigGift : config.smallGift;
                panel.days[i].Show(Text(ctx, id), StreakController.HasWin(data, day), day == today,
                    gift, config, stamp && day == today);
            }
            int companions = 0;
            for (int i = 1; i < config.companionDays.Length; i++) {
                if (save.dailyStreak >= config.companionDays[i]) {
                    companions++;
                }
            }
            int butterflies = save.dailyStreak >= config.companionDays[5] ? 2 :
                save.dailyStreak >= config.companionDays[3] ? 1 : 0;
            int headDay = Math.Max(2, Math.Min((config.cycleDays + 1) / 2, config.cycleDays - 1));
            int petals = save.dailyStreak >= config.cycleDays ? config.petalCount :
                Mathf.Clamp(Mathf.RoundToInt((float)(save.dailyStreak - headDay + 1) * config.petalCount / (config.cycleDays - headDay + 1)), 0, config.petalCount);
            panel.plant.Init(config, StreakController.PlantCut(save.dailyStreak, config), companions, butterflies,
                save.dailyStreak >= config.companionDays[0], petals);
            bool pending = data.pendingHints > 0 || data.pendingGuides > 0;
            panel.rewardRoot.SetActive(pending);
            panel.rewardLabel.text = pending ? string.Format(Text(ctx, UINameType.Streak_Reward), data.pendingHints, data.pendingGuides) : string.Empty;
            bool recover = StreakController.CanRecover(ctx);
            panel.recoveryRoot.SetActive(recover);
            panel.recoverLabel.text = recover ? string.Format(Text(ctx, UINameType.Streak_Recover), data.runDays) : string.Empty;
            panel.recoverButtonLabel.text = Text(ctx, UINameType.Streak_RecoverButton);
            panel.dismissLabel.text = Text(ctx, UINameType.Streak_GiveUp);
            // Recovery and pending rewards occupy the same supplemental area.
            // Previously earned rewards remain claimable after dismissing recovery.
            panel.rewardRoot.SetActive(pending && !recover);
            if (state.notice == UINameType.Streak_RewardPreview) {
                int index = state.previewSlot - 1;
                panel.noticeLabel.text = string.Format(Text(ctx, state.notice), state.previewSlot,
                    config.rewardHints[index], config.rewardGuides[index]);
            } else {
                panel.noticeLabel.text = state.notice == UINameType.None ? string.Empty : Text(ctx, state.notice);
            }
        }

        static string Text(GameContext ctx, UINameType id) {
            var localization = ctx.l10NModule;
            if (!localization.TryGet(id, out var text)) {
                throw new InvalidOperationException("Missing streak text: " + id);
            }
            return text;
        }

        public static void RefreshSafeArea(GameContext ctx, bool force) {
            var state = ctx.state_Streak;
            Rect area = Screen.safeArea;
            int width = Screen.width;
            int height = Screen.height;
            if (!force && state.safeArea == area && state.screenWidth == width && state.screenHeight == height) {
                return;
            }
            state.safeArea = area;
            state.screenWidth = width;
            state.screenHeight = height;
            var panels = ctx.panelRepository;
            if (panels.TryGet(PanelType.Streak, out Panel_Streak panel)) {
                panel.ApplySafeArea(area, width, height);
            }
        }

        public static void Tick(GameContext ctx, float deltaTime) {
            RefreshSafeArea(ctx, false);
            var panels = ctx.panelRepository;
            var assets = ctx.assetModule;
            if (panels.TryGet(PanelType.Streak, out Panel_Streak panel)) {
                panel.Tick(deltaTime, assets.GetStreakConfig());
            }
        }

        public static void Close(GameContext ctx) {
            var panels = ctx.panelRepository;
            if (panels.TryGet(PanelType.Streak, out Panel_Streak panel)) {
                panels.Remove(panel);
                panel.TearDown();
            }
        }
    }
}
