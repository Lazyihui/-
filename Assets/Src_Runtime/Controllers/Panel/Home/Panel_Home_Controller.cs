using System;
using System.Globalization;
using UnityEngine;

namespace Hamdoku.Controllers {
    public static class Panel_Home_Controller {
        public static void Open(GameContext ctx) {
            var openType = PanelFactory.TryOpen(ctx, PanelType.Home, out Panel_Home panel);
            if (openType == UIOpenType.FirstOpen) {
                var localization = ctx.l10NModule;
                panel.Ctor(localization);
                panel.campaignHandle = () => {
                    HomeController.RequestCampaign(ctx);
                };
                panel.dailyHandle = () => {
                    HomeController.Request(ctx, HomeRequestType.Daily);
                };
                panel.rankingHandle = () => {
                    HomeController.Request(ctx, HomeRequestType.Ranking);
                };
                panel.endlessHandle = () => {
                    HomeController.Request(ctx, HomeRequestType.Endless);
                };
                panel.settingsHandle = () => {
                    HomeController.Request(ctx, HomeRequestType.Settings);
                };
            }
            panel.Init();
            Refresh(ctx);
            RefreshSafeArea(ctx, true);
        }

        public static void Refresh(GameContext ctx) {
            var panels = ctx.panelRepository;
            if (!panels.TryGet(PanelType.Home, out Panel_Home panel)) {
                return;
            }
            var state = ctx.state_Home;
            var save = ctx.playerSave;
            var assets = ctx.assetModule;
            var config = assets.GetHomeConfig();
            int level = save.campaignClears + 1;
            bool hard = level >= config.hardLevelStart && level % config.hardLevelInterval == 0;
            panel.logo.sprite = hard ? config.logoHard : config.logoNormal;
            panel.campaignImage.sprite = hard ? config.levelHard : config.levelNormal;
            panel.levelLabel.text = string.Format(Text(ctx, UINameType.Home_Level), level);
            panel.dailyLabel.text = Text(ctx, UINameType.Home_Daily);
            panel.dailyPlayLabel.text = Text(ctx, UINameType.Home_Play);
            panel.rankingLabel.text = Text(ctx, UINameType.Home_Ranking);
            panel.endlessLabel.text = Text(ctx, UINameType.Home_Endless);
            panel.settingsLabel.text = Text(ctx, UINameType.Home_Settings);
            panel.streakLabel.text = string.Format(Text(ctx, UINameType.Home_Streak), save.dailyStreak);
            panel.dailyDateLabel.text = DateTime.Now.ToString(Text(ctx, UINameType.Home_DailyDate),
                save.language == SystemLanguage.English ? CultureInfo.GetCultureInfo("en-US") : CultureInfo.GetCultureInfo("zh-CN"));
            panel.dailyLockLabel.text = string.Format(Text(ctx, UINameType.Home_Lock), config.dailyUnlockClears);
            panel.rankingLockLabel.text = string.Format(Text(ctx, UINameType.Home_Lock), config.rankingUnlockClears);
            panel.endlessLockLabel.text = string.Format(Text(ctx, UINameType.Home_Lock), config.endlessUnlockClears);
            panel.ShowLocks(state.dailyUnlocked, state.rankingUnlocked, state.endlessUnlocked, config.lockedTint);
            RefreshNotice(ctx);
        }

        public static string Text(GameContext ctx, UINameType id) {
            var localization = ctx.l10NModule;
            if (!localization.TryGet(id, out string text)) {
                throw new InvalidOperationException("Missing UI text: " + id);
            }
            return text;
        }

        public static void RefreshNotice(GameContext ctx) {
            var panels = ctx.panelRepository;
            if (!panels.TryGet(PanelType.Home, out Panel_Home panel)) {
                return;
            }
            var state = ctx.state_Home;
            panel.noticeLabel.text = state.noticeType == UINameType.None ? string.Empty :
                string.Format(Text(ctx, state.noticeType), state.noticeRequirement);
        }

        public static void RefreshSafeArea(GameContext ctx, bool force) {
            var state = ctx.state_Home;
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
            if (panels.TryGet(PanelType.Home, out Panel_Home panel)) {
                panel.ApplySafeArea(area, width, height);
            }
        }

        public static void Tick(GameContext ctx, float deltaTime) {
            var panels = ctx.panelRepository;
            var assets = ctx.assetModule;
            var config = assets.GetHomeConfig();
            if (panels.TryGet(PanelType.Home, out Panel_Home panel)) {
                panel.Tick(deltaTime, config.idleBreatheAmount, config.idleBreatheSpeed);
            }
            RefreshSafeArea(ctx, false);
        }

        public static void Close(GameContext ctx) {
            var panels = ctx.panelRepository;
            if (panels.TryGet(PanelType.Home, out Panel_Home panel)) {
                panels.Remove(panel);
                if (panel != null) {
                    panel.TearDown();
                }
            }
        }
    }
}
