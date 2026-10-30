namespace Hamdoku.Controllers {
    public static class Panel_GameDialog_Controller {
        public static void Open(GameContext ctx) {
            var opened = PanelFactory.TryOpen(ctx, PanelType.GameDialog, out Panel_GameDialog panel);
            if (opened == UIOpenType.FirstOpen) {
                var localization = ctx.l10NModule;
                panel.Ctor(localization);
                panel.primaryHandle = () => GameController.DialogPrimary(ctx);
                panel.secondaryHandle = () => GameController.DialogSecondary(ctx);
                panel.adHandle = () => GameController.AdUnavailable(ctx);
            }
            panel.Init();
            Refresh(ctx);
        }
        public static void Refresh(GameContext ctx) {
            var panels = ctx.panelRepository;
            if (!panels.TryGet(PanelType.GameDialog, out Panel_GameDialog panel)) {
                return;
            }
            var state = ctx.state_Game;
            UINameType title;
            UINameType body;
            UINameType primary;
            UINameType secondary;
            bool failed = state.dialog == GameDialogType.Failed;
            if (state.dialog == GameDialogType.Result) {
                title = state.isTutorial ? UINameType.Game_TutorialDone : state.mistakes == 0 ? UINameType.Game_Perfect : UINameType.Game_Won;
                body = UINameType.Game_Score;
                primary = state.isTutorial ? UINameType.Game_Start : UINameType.Game_Next;
                secondary = UINameType.Game_Home;
            } else if (failed) {
                title = UINameType.Game_Failed;
                body = state.notice == UINameType.Game_AdUnavailable ? state.notice : UINameType.Game_FailedBody;
                primary = UINameType.Game_Restart;
                secondary = UINameType.Game_Home;
            } else if (state.dialog == GameDialogType.Restart) {
                title = UINameType.Game_RestartTitle;
                body = UINameType.Game_RestartBody;
                primary = UINameType.Game_Restart;
                secondary = UINameType.Game_Cancel;
            } else {
                title = UINameType.Game_ExitTitle;
                body = UINameType.Game_ExitBody;
                primary = UINameType.Game_Home;
                secondary = UINameType.Game_Cancel;
            }
            if (state.mode == GameModeType.Endless && (state.dialog == GameDialogType.Exit || state.dialog == GameDialogType.Restart)) {
                body = state.dialog == GameDialogType.Exit ? UINameType.Endless_ExitBody : UINameType.Endless_RestartBody;
            }
            panel.titleLabel.text = Panel_Game_Controller.Text(ctx, title);
            panel.bodyLabel.text = string.Format(Panel_Game_Controller.Text(ctx, body), state.score);
            panel.primaryLabel.text = Panel_Game_Controller.Text(ctx, primary);
            panel.secondaryLabel.text = Panel_Game_Controller.Text(ctx, secondary);
            panel.adLabel.text = Panel_Game_Controller.Text(ctx, UINameType.Game_Ad);
            panel.adButton.gameObject.SetActive(failed);
            var assets = ctx.assetModule;
            var campaignConfig = assets.GetCampaignConfig();
            if (state.dailyDay > 0) {
                panel.primaryLabel.text = Panel_Game_Controller.Text(ctx, state.dialog == GameDialogType.Result || state.dialog == GameDialogType.Exit ? UINameType.Daily_Return : UINameType.Daily_Retry);
                panel.secondaryLabel.text = Panel_Game_Controller.Text(ctx, state.dialog == GameDialogType.Result || failed ? UINameType.Daily_Return : UINameType.Game_Cancel);
            }
            if (state.dailyDay == 0 && state.dialog == GameDialogType.Result && !state.isTutorial && state.level == campaignConfig.campaignSizes.Length) {
                panel.primaryLabel.text = Panel_Game_Controller.Text(ctx, UINameType.Game_Home);
                panel.bodyLabel.text += "\n\n" + Panel_Game_Controller.Text(ctx, UINameType.Game_BatchComplete);
            }
        }
        public static void Close(GameContext ctx) {
            var panels = ctx.panelRepository;
            if (panels.TryGet(PanelType.GameDialog, out Panel_GameDialog panel)) {
                panels.Remove(panel);
                panel.TearDown();
            }
        }
    }
}
