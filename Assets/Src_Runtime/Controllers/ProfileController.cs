using System;
using System.Globalization;
using System.IO;
using UnityEngine;

namespace Hamdoku.Controllers {
    public static class ProfileController {
        public static void InitializeSave(GameContext ctx, PlayerSaveModel loaded) {
            var save = ctx.playerSave;
            var assets = ctx.assetModule;
            var config = assets.GetProfileConfig();
            save.profile = loaded == null || loaded.version < 5 ? new ProfileSaveModel {
                nickname = "Player" + save.ranking.clientId.Substring(0, 6), costumeId = -1,
                firstRecordedDay = (int)(DateTime.Today.Ticks / TimeSpan.TicksPerDay) + 1,
                trackedThroughLevel = save.campaignClears, historyKnown = loaded == null
            } : loaded.profile;
            var profile = save.profile;
            ValidateVisualConfig(config);
            if (loaded == null || loaded.version < 7) {
                // Earlier local saves incorrectly allowed rank reward frames without a rank result.
                if (profile.frameId >= 0 && profile.frameId < config.frameRankWins.Length && config.frameRankWins[profile.frameId] > 0) {
                    profile.frameId = 0;
                }
                profile.seenAvatars = OwnedMask(config, save, ProfileTabType.Avatar);
                profile.seenFrames = OwnedMask(config, save, ProfileTabType.Frame);
                profile.seenCostumes = 0;
            }
            if (loaded == null || loaded.version < 5) {
                profile.firstRecordedDay = (int)(DateTime.Today.Ticks / TimeSpan.TicksPerDay) + 1;
                if (loaded != null && loaded.activePuzzle != null && !loaded.activePuzzle.isTutorial && loaded.activePuzzle.status != GameStatus.Won) {
                    profile.retriedLevel = save.campaignClears + 1;
                }
            }
            if (config.avatars.Length <= config.clubAvatarStart || config.nameMaxChars < 1 || config.mottos.Length == 0 ||
                config.frames.Length != config.frameUnlockClears.Length || config.frames.Length != config.frameRankWins.Length ||
                config.avatars.Length != config.avatarUnlockClears.Length || config.costumes.Length != config.costumeNames.Length) {
                throw new InvalidOperationException("Invalid profile configuration.");
            }
            SaveModule.ValidateProfile(profile);
            if (!Available(config, save, ProfileTabType.Avatar, profile.avatarId) ||
                !Available(config, save, ProfileTabType.Frame, profile.frameId) || !Available(config, save, ProfileTabType.Costume, profile.costumeId) ||
                profile.mottoId < 0 || profile.mottoId > config.mottos.Length || profile.nickname.Length > config.nameMaxChars ||
                profile.trackedThroughLevel != save.campaignClears) {
                throw new InvalidDataException("Profile selection or progress is inconsistent with configuration.");
            }
            RecordLogin(ctx);
        }

        public static bool RecordLogin(GameContext ctx) {
            var save = ctx.playerSave;
            var data = save.profile;
            int day = (int)(DateTime.Today.Ticks / TimeSpan.TicksPerDay) + 1;
            if (data.lastLoginDay >= day) {
                return false;
            }
            data.loginStreak = data.lastLoginDay == day - 1 ? data.loginStreak + 1 : 1;
            data.bestLoginStreak = Math.Max(data.bestLoginStreak, data.loginStreak);
            data.lastLoginDay = day;
            return true;
        }

        public static void RecordClear(GameContext ctx) {
            var save = ctx.playerSave;
            var profile = save.profile;
            var game = ctx.state_Game;
            if (game.isTutorial || profile.trackedThroughLevel >= game.level) {
                return;
            }
            if (profile.trackedThroughLevel + 1 != game.level || save.campaignClears != game.level) {
                throw new InvalidOperationException("Profile clears must be recorded once in campaign order.");
            }
            profile.trackedThroughLevel = game.level;
            profile.consecutiveClears++;
            profile.bestConsecutiveClears = Math.Max(profile.bestConsecutiveClears, profile.consecutiveClears);
            var assets = ctx.assetModule;
            var config = assets.GetPuzzleRules();
            if (game.hearts == config.maxHearts) {
                profile.threeSeedClears++;
            }
            if (profile.retriedLevel != game.level) {
                profile.firstTryClears++;
            }
            profile.retriedLevel = 0;
        }

        public static void RecordRetry(GameContext ctx) {
            var game = ctx.state_Game;
            if (game.isTutorial || game.status == GameStatus.Won) {
                return;
            }
            var save = ctx.playerSave;
            var profile = save.profile;
            profile.retriedLevel = game.level;
            profile.consecutiveClears = 0;
        }

        public static bool Available(ProfileConfigSO config, PlayerSaveModel save, ProfileTabType tab, int id) {
            if (tab == ProfileTabType.Avatar) {
                return id >= 0 && id < config.avatars.Length && id != config.hiddenAvatarId && config.avatars[id] != null && id < config.clubAvatarStart &&
                    config.avatarUnlockClears[id] >= 0 && save.campaignClears >= config.avatarUnlockClears[id];
            }
            if (tab == ProfileTabType.Frame) {
                return id >= 0 && id < config.frames.Length && config.frames[id] != null && id != config.clubFrameId &&
                    config.frameUnlockClears[id] >= 0 && save.campaignClears >= config.frameUnlockClears[id] && config.frameRankWins[id] == 0;
            }
            return tab == ProfileTabType.Costume && (id == -1 ||
                (id >= 0 && id < config.costumes.Length && config.costumes[id] != null &&
                save.daily != null && save.daily.claimedCostumes.BinarySearch(id) >= 0));
        }

        public static bool AvailableForSession(GameContext ctx, ProfileConfigSO config, PlayerSaveModel save, ProfileTabType tab, int id) {
            var home = ctx.state_Home;
            if (!home.testUnlockAll) {
                return Available(config, save, tab, id);
            }
            if (tab == ProfileTabType.Avatar) {
                return id >= 0 && id < config.avatars.Length && config.avatars[id] != null && id != config.hiddenAvatarId;
            }
            if (tab == ProfileTabType.Frame) {
                return id >= 0 && id < config.frames.Length && config.frames[id] != null;
            }
            return tab == ProfileTabType.Costume && (id == -1 || (id >= 0 && id < config.costumes.Length && config.costumes[id] != null));
        }

        public static void ValidateVisualConfig(ProfileConfigSO config) {
            int frames = config.frames.Length;
            int avatars = config.avatars.Length;
            int costumes = config.costumes.Length;
            if (avatars > 32 || frames > 32 || costumes > 32 || config.hands == null || config.hands.Length != avatars ||
                config.costumeFits == null || config.costumeFits.Length != costumes * avatars ||
                config.costumeSeasons == null || config.costumeSeasons.Length != costumes ||
                config.costumeRects == null || config.costumeRects.Length != costumes ||
                config.costumeSourceIds == null || config.costumeSourceIds.Length != costumes ||
                config.crownFrames == null || config.crownFrames.Length != frames ||
                config.frameOpenings == null || config.frameOpenings.Length != frames ||
                config.badgeCenters == null || config.badgeCenters.Length != frames ||
                config.badgeColors == null || config.badgeColors.Length != frames ||
                config.frameAuras == null || config.frameAuras.Length != frames ||
                config.frameAuraTiers == null || config.frameAuraTiers.Length != frames ||
                config.tabOn == null || config.tabOff == null || config.newDotPulseSeconds <= 0 ||
                config.auraAlpha == null || config.auraAlpha.Length != 3 || config.auraSpeed == null || config.auraSpeed.Length != 3 ||
                config.auraHueBase == null || config.auraHueBase.Length != 3 || config.auraHueRange == null || config.auraHueRange.Length != 3) {
                throw new InvalidOperationException("Profile visual configuration is incomplete.");
            }
            for (int i = 0; i < frames; i++) {
                if (config.frames[i] != null && (config.frameOpenings[i] <= 0 || config.frameAuraTiers[i] < 0 || config.frameAuraTiers[i] >= 3)) {
                    throw new InvalidOperationException("Invalid profile frame layout: " + i);
                }
            }
            foreach (var fit in config.costumeFits) {
                if (fit.scale <= 0) {
                    throw new InvalidOperationException("Invalid profile costume fit.");
                }
            }
        }

        public static uint OwnedMask(ProfileConfigSO config, PlayerSaveModel save, ProfileTabType tab) {
            int count = tab == ProfileTabType.Avatar ? config.avatars.Length : tab == ProfileTabType.Frame ? config.frames.Length : config.costumes.Length;
            uint mask = 0;
            for (int i = 0; i < count; i++) {
                if (Available(config, save, tab, i)) {
                    mask |= 1u << i;
                }
            }
            return mask;
        }

        public static uint NewMask(ProfileConfigSO config, PlayerSaveModel save, ProfileTabType tab) {
            var profile = save.profile;
            uint seen = tab == ProfileTabType.Avatar ? profile.seenAvatars : tab == ProfileTabType.Frame ? profile.seenFrames : profile.seenCostumes;
            return OwnedMask(config, save, tab) & ~seen;
        }

        static void MarkVisitedSeen(GameContext ctx) {
            var state = ctx.state_Profile;
            var save = ctx.playerSave;
            var profile = save.profile;
            var assets = ctx.assetModule;
            var config = assets.GetProfileConfig();
            if ((state.visitedTabs & 1) != 0) {
                profile.seenAvatars |= OwnedMask(config, save, ProfileTabType.Avatar);
            }
            if ((state.visitedTabs & 2) != 0) {
                profile.seenFrames |= OwnedMask(config, save, ProfileTabType.Frame);
            }
            if ((state.visitedTabs & 4) != 0) {
                profile.seenCostumes |= OwnedMask(config, save, ProfileTabType.Costume);
            }
            HomeController.SaveProgress(ctx);
        }

        public static void Open(GameContext ctx) {
            var state = ctx.state_Profile;
            var home = ctx.state_Home;
            if (state.isOpen || !home.isOpen || home.disposed) {
                return;
            }
            state.isOpen = true;
            state.tab = ProfileTabType.Avatar;
            state.visitedTabs = 1;
            state.dialog = ProfileDialogType.None;
            state.notice = UINameType.None;
            home.isOpen = false;
            home.pendingRequest = HomeRequestType.None;
            home.noticeType = UINameType.None;
            home.noticeRemaining = 0;
            Panel_Home_Controller.Close(ctx);
            Panel_Profile_Controller.Open(ctx);
            Panel_Profile_Controller.Refresh(ctx);
        }

        public static void Back(GameContext ctx) {
            var state = ctx.state_Profile;
            if (state.dialog != ProfileDialogType.None) {
                ShowDialog(ctx, ProfileDialogType.None);
                return;
            }
            state.isOpen = false;
            MarkVisitedSeen(ctx);
            Panel_Profile_Controller.Close(ctx);
            HomeSystem.Open(ctx);
        }

        public static void SetTab(GameContext ctx, ProfileTabType tab) {
            var state = ctx.state_Profile;
            if (!state.isOpen || state.dialog != ProfileDialogType.None || tab < ProfileTabType.Avatar || tab > ProfileTabType.Costume) {
                return;
            }
            state.tab = tab;
            state.visitedTabs |= 1 << ((int)tab - 1);
            state.notice = UINameType.None;
            Panel_Profile_Controller.Refresh(ctx);
        }

        public static void Select(GameContext ctx, ProfileTabType tab, int id) {
            var state = ctx.state_Profile;
            if (!state.isOpen || state.tab != tab || state.dialog != ProfileDialogType.None) {
                return;
            }
            var assets = ctx.assetModule;
            var config = assets.GetProfileConfig();
            var save = ctx.playerSave;
            var profile = save.profile;
            if (!AvailableForSession(ctx, config, save, tab, id)) {
                UINameType message = UINameType.Profile_RewardLocked;
                int requirement = 0;
                if ((tab == ProfileTabType.Avatar && id >= config.clubAvatarStart) || (tab == ProfileTabType.Frame && id == config.clubFrameId)) {
                    message = UINameType.Profile_MemberUnavailable;
                } else if (tab == ProfileTabType.Avatar && id >= 0 && id < config.avatarUnlockClears.Length && config.avatarUnlockClears[id] > 0) {
                    message = UINameType.Profile_LevelLocked;
                    requirement = config.avatarUnlockClears[id];
                } else if (tab == ProfileTabType.Frame && id >= 0 && id < config.frames.Length) {
                    requirement = config.frameUnlockClears[id];
                    if (requirement > 0) {
                        message = UINameType.Profile_LevelLocked;
                    } else if (config.frameRankWins[id] > 0) {
                        requirement = config.frameRankWins[id];
                        message = UINameType.Profile_RankLocked;
                    }
                }
                if (tab == ProfileTabType.Costume && id >= 0 && id < config.costumeSeasons.Length) {
                    message = UINameType.Profile_SeasonLocked;
                    requirement = config.costumeSeasons[id];
                }
                Notice(ctx, message, requirement);
                return;
            }
            if (tab == ProfileTabType.Avatar) {
                profile.avatarId = id;
            } else if (tab == ProfileTabType.Frame) {
                profile.frameId = id;
            } else {
                profile.costumeId = id;
            }
            if (Available(config, save, tab, id)) {
                if (tab == ProfileTabType.Avatar) {
                    state.savedAvatarId = id;
                } else if (tab == ProfileTabType.Frame) {
                    state.savedFrameId = id;
                } else {
                    state.savedCostumeId = id;
                }
            }
            state.notice = UINameType.None;
            HomeController.SaveProgress(ctx);
            Panel_Profile_Controller.Refresh(ctx);
        }

        public static void ShowDialog(GameContext ctx, ProfileDialogType dialog) {
            var state = ctx.state_Profile;
            if (!state.isOpen) {
                return;
            }
            state.dialog = dialog;
            state.notice = UINameType.None;
            Panel_Profile_Controller.Refresh(ctx);
            if (dialog == ProfileDialogType.Name) {
                var panels = ctx.panelRepository;
                var save = ctx.playerSave;
                var assets = ctx.assetModule;
                if (panels.TryGet(PanelType.Profile, out Panel_Profile panel)) {
                    panel.BeginName(save.profile.nickname, assets.GetProfileConfig().nameMaxChars);
                }
            }
        }

        public static void SaveName(GameContext ctx, string value) {
            var state = ctx.state_Profile;
            if (!state.isOpen || state.dialog != ProfileDialogType.Name) {
                return;
            }
            var assets = ctx.assetModule;
            var config = assets.GetProfileConfig();
            var panels = ctx.panelRepository;
            value = value == null ? string.Empty : value.Trim();
            bool valid = value.Length > 0 && value.Length <= config.nameMaxChars;
            foreach (char character in value) {
                var category = char.GetUnicodeCategory(character);
                valid &= char.IsLetterOrDigit(character) || category == UnicodeCategory.SpaceSeparator;
            }
            if (!panels.TryGet(PanelType.Profile, out Panel_Profile panel)) {
                return;
            }
            valid &= panel.nameLabel.font.HasCharacters(value);
            // Both supported language fonts must be able to display the saved name.
            foreach (var font in assets.L10NFont_GetAll()) {
                valid &= font.font.HasCharacters(value);
            }
            if (!valid) {
                Notice(ctx, UINameType.Profile_InvalidName, config.nameMaxChars);
                return;
            }
            var save = ctx.playerSave;
            var profile = save.profile;
            profile.nickname = value;
            HomeController.SaveProgress(ctx);
            ShowDialog(ctx, ProfileDialogType.None);
        }

        public static void SetMotto(GameContext ctx, int id) {
            var state = ctx.state_Profile;
            var assets = ctx.assetModule;
            if (!state.isOpen || state.dialog != ProfileDialogType.Motto || id < 0 || id > assets.GetProfileConfig().mottos.Length) {
                return;
            }
            var save = ctx.playerSave;
            var profile = save.profile;
            profile.mottoId = id;
            HomeController.SaveProgress(ctx);
            ShowDialog(ctx, ProfileDialogType.None);
        }

        public static void CopyUid(GameContext ctx) {
            var state = ctx.state_Profile;
            if (!state.isOpen || state.dialog != ProfileDialogType.None) {
                return;
            }
            var save = ctx.playerSave;
            GUIUtility.systemCopyBuffer = save.ranking.clientId;
            Notice(ctx, UINameType.Profile_Copied, 0);
        }

        public static void Notice(GameContext ctx, UINameType message, int argument = 0) {
            var state = ctx.state_Profile;
            var assets = ctx.assetModule;
            state.notice = message;
            state.noticeArgument = argument;
            state.noticeRemaining = assets.GetProfileConfig().noticeSeconds;
            Panel_Profile_Controller.Refresh(ctx);
        }

        public static void Tick(GameContext ctx, float deltaTime) {
            if (RecordLogin(ctx)) {
                HomeController.SaveProgress(ctx);
                Panel_Profile_Controller.Refresh(ctx);
            }
            var state = ctx.state_Profile;
            if (state.dialog == ProfileDialogType.None && state.noticeRemaining > 0) {
                state.noticeRemaining -= deltaTime;
                if (state.noticeRemaining <= 0) {
                    state.notice = UINameType.None;
                    Panel_Profile_Controller.Refresh(ctx);
                }
            }
        }
    }
}
