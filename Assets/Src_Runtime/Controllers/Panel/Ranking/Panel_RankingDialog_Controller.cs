namespace Hamdoku.Controllers {
    public static class Panel_RankingDialog_Controller {
        public static void Open(GameContext ctx) {
            var opened = PanelFactory.TryOpen(ctx, PanelType.RankingDialog, out Panel_RankingDialog panel);
            if (opened == UIOpenType.FirstOpen) {
                var localization = ctx.l10NModule;
                panel.Ctor(localization);
                panel.closeHandle = () => { RankingController.CloseDialog(ctx); };
                panel.claimHandle = () => { RankingController.Claim(ctx); };
            }
            panel.Init();
            Refresh(ctx);
        }
        public static void Refresh(GameContext ctx) {
            var panels = ctx.panelRepository;
            if (!panels.TryGet(PanelType.RankingDialog, out Panel_RankingDialog panel)) {
                return;
            }
            var state = ctx.state_Ranking;
            bool rules = state.dialog == RankingDialogType.Rules;
            panel.titleLabel.text = Panel_Ranking_Controller.Text(ctx, rules ? UINameType.Ranking_Rules : UINameType.Ranking_Reward);
            panel.bodyLabel.text = rules ? Panel_Ranking_Controller.Text(ctx, UINameType.Ranking_RulesBody) :
                string.Format(Panel_Ranking_Controller.Text(ctx, state.rewardRank == 0 ? UINameType.Ranking_MyRewardBody : UINameType.Ranking_RewardBody), state.rewardRank);
            panel.noticeLabel.text = state.notice == UINameType.None ? string.Empty : Panel_Ranking_Controller.Text(ctx, state.notice);
            bool claimed = state.rewardStatus == RankingRewardStatus.Claimed;
            bool pending = state.rewardStatus == RankingRewardStatus.Pending;
            panel.claimLabel.text = Panel_Ranking_Controller.Text(ctx, claimed ? UINameType.Ranking_Claimed : pending ? UINameType.Ranking_Claiming : UINameType.Ranking_Claim);
            panel.claimButton.gameObject.SetActive(!rules);
            panel.claimButton.interactable = state.rewardRank == 0 && state.rewardStatus == RankingRewardStatus.Available;
            panel.closeButton.interactable = !pending;
        }
        public static void RefreshSafeArea(GameContext ctx) {
            var panels = ctx.panelRepository;
            if (panels.TryGet(PanelType.RankingDialog, out Panel_RankingDialog panel)) {
                panel.ApplySafeArea();
            }
        }
        public static void Close(GameContext ctx) {
            var panels = ctx.panelRepository;
            if (panels.TryGet(PanelType.RankingDialog, out Panel_RankingDialog panel)) {
                panels.Remove(panel);
                panel.TearDown();
            }
        }
    }
}
