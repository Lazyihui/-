using System;
using UnityEngine;

namespace Hamdoku.Controllers {
    public static class HomeController {
        public static void InitializeSave(GameContext ctx) {
            var state = ctx.state_Home;
            if (state.saveInitialized) {
                return;
            }
            var assets = ctx.assetModule;
            var config = assets.GetHomeConfig();
            var saves = ctx.saveModule;
            var save = ctx.playerSave;
            var localization = ctx.l10NModule;
            var loaded = saves.Load(config, Application.persistentDataPath);
            save.version = config.saveVersion;
            save.campaignClears = loaded == null ? 0 : loaded.campaignClears;
            save.tutorialCompleted = loaded != null && loaded.tutorialCompleted;
            save.language = loaded == null ? config.defaultLanguage : loaded.language;
            save.dailyStreak = loaded == null ? 0 : loaded.dailyStreak;
            localization.AddAll(assets.L10N_GetAll(), assets.L10NFont_GetAll());
            localization.Language_Set(save.language);
            if (loaded == null) {
                SaveProgress(ctx);
            }
            state.saveInitialized = true;
        }

        public static void SaveProgress(GameContext ctx) {
            var assets = ctx.assetModule;
            var saves = ctx.saveModule;
            var save = ctx.playerSave;
            saves.Save(assets.GetHomeConfig(), Application.persistentDataPath, save);
        }

        public static void SetTutorialCompleted(GameContext ctx) {
            var save = ctx.playerSave;
            save.tutorialCompleted = true;
            SaveProgress(ctx);
        }

        public static void SetLanguage(GameContext ctx, SystemLanguage language) {
            var localization = ctx.l10NModule;
            var save = ctx.playerSave;
            localization.Language_Set(language);
            save.language = language;
            SaveProgress(ctx);
            Refresh(ctx);
        }

        public static void RecordCampaignClear(GameContext ctx, int completedLevel) {
            var save = ctx.playerSave;
            if (completedLevel != save.campaignClears + 1) {
                throw new InvalidOperationException("Campaign clears must advance from the current level.");
            }
            save.campaignClears = completedLevel;
            SaveProgress(ctx);
            Refresh(ctx);
        }

        public static void Open(GameContext ctx) {
            var state = ctx.state_Home;
            if (state.disposed) {
                throw new InvalidOperationException("Home has been disposed.");
            }
            Refresh(ctx);
            Panel_Home_Controller.Open(ctx);
            state.isOpen = true;
            var save = ctx.playerSave;
            if (!save.tutorialCompleted) {
                Request(ctx, HomeRequestType.Tutorial, false);
            }
        }

        public static void Refresh(GameContext ctx) {
            var state = ctx.state_Home;
            var save = ctx.playerSave;
            var assets = ctx.assetModule;
            var config = assets.GetHomeConfig();
            state.dailyUnlocked = save.campaignClears >= config.dailyUnlockClears;
            state.rankingUnlocked = save.campaignClears >= config.rankingUnlockClears;
            state.endlessUnlocked = save.campaignClears >= config.endlessUnlockClears;
            state.displayedDate = DateTime.Today.DayOfYear;
            Panel_Home_Controller.Refresh(ctx);
        }

        public static void RequestCampaign(GameContext ctx) {
            var save = ctx.playerSave;
            Request(ctx, save.tutorialCompleted ? HomeRequestType.Campaign : HomeRequestType.Tutorial);
        }

        public static void Request(GameContext ctx, HomeRequestType type, bool playSound = true) {
            var state = ctx.state_Home;
            if (!state.isOpen || state.disposed) {
                return;
            }
            var assets = ctx.assetModule;
            var config = assets.GetHomeConfig();
            var audio = ctx.audioModule;
            var events = ctx.events_Home;
            if (playSound) {
                audio.PlayOneShot(config.buttonClip, config.buttonVolume);
            }
            UINameType lockedMessage = UINameType.None;
            int requirement = 0;
            if (type == HomeRequestType.Daily && !state.dailyUnlocked) {
                lockedMessage = UINameType.Home_DailyLocked;
                requirement = config.dailyUnlockClears;
            } else if (type == HomeRequestType.Ranking && !state.rankingUnlocked) {
                lockedMessage = UINameType.Home_RankingLocked;
                requirement = config.rankingUnlockClears;
            } else if (type == HomeRequestType.Endless && !state.endlessUnlocked) {
                lockedMessage = UINameType.Home_EndlessLocked;
                requirement = config.endlessUnlockClears;
            }
            if (lockedMessage != UINameType.None) {
                ShowNotice(ctx, lockedMessage, requirement);
                return;
            }
            state.pendingRequest = type;
            ShowNotice(ctx, UINameType.Home_Preparing, 0);
            events.requestHandle?.Invoke(type);
        }

        public static void ShowNotice(GameContext ctx, UINameType type, int requirement) {
            var state = ctx.state_Home;
            var assets = ctx.assetModule;
            state.noticeType = type;
            state.noticeRequirement = requirement;
            state.noticeRemaining = assets.GetHomeConfig().noticeSeconds;
            Panel_Home_Controller.RefreshNotice(ctx);
        }

        public static void Tick(GameContext ctx, float deltaTime) {
            var state = ctx.state_Home;
            Panel_Home_Controller.Tick(ctx, deltaTime);
            if (state.displayedDate != DateTime.Today.DayOfYear) {
                Refresh(ctx);
            }
            if (state.noticeRemaining > 0) {
                state.noticeRemaining -= deltaTime;
                if (state.noticeRemaining <= 0) {
                    state.noticeType = UINameType.None;
                    Panel_Home_Controller.RefreshNotice(ctx);
                }
            }
        }

        public static void Fail(GameContext ctx, Exception error) {
            var state = ctx.state_Home;
            var events = ctx.events_Loading;
            state.isOpen = false;
            Panel_Home_Controller.Close(ctx);
            Debug.LogException(error);
            events.errorHandle?.Invoke(error);
        }

        public static void Dispose(GameContext ctx) {
            var state = ctx.state_Home;
            var events = ctx.events_Home;
            if (state.disposed) {
                return;
            }
            state.isOpen = false;
            state.disposed = true;
            Panel_Home_Controller.Close(ctx);
            events.requestHandle = null;
        }
    }
}
