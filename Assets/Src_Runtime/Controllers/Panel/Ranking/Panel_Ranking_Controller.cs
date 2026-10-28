using System;
namespace Hamdoku.Controllers {
    public static class Panel_Ranking_Controller {
        public static void Open(GameContext ctx) {
            var opened = PanelFactory.TryOpen(ctx, PanelType.Ranking, out Panel_Ranking panel);
            if (opened == UIOpenType.FirstOpen) {
                var localization = ctx.l10NModule;
                panel.Ctor(localization);
                panel.backHandle = () => { RankingController.Back(ctx); };
                panel.infoHandle = () => { RankingController.ShowDialog(ctx, RankingDialogType.Rules); };
                panel.collectHandle = () => { RankingController.Collect(ctx); };
                panel.retryHandle = () => { RankingController.Retry(ctx); };
                panel.rewardHandle = () => { RankingController.ShowReward(ctx, 0); };
                panel.giftHandle = rank => { RankingController.ShowReward(ctx, rank); };
            }
            panel.Init();
        }
        public static string Text(GameContext ctx, UINameType id) {
            var localization = ctx.l10NModule;
            if (!localization.TryGet(id, out string text)) {
                throw new InvalidOperationException("Missing ranking UI text: " + id);
            }
            return text;
        }
        public static void Refresh(GameContext ctx) {
            var panels = ctx.panelRepository;
            if (!panels.TryGet(PanelType.Ranking, out Panel_Ranking panel)) {
                return;
            }
            var state = ctx.state_Ranking;
            var assets = ctx.assetModule;
            var config = assets.GetRankingConfig();
            panel.rewardLabel.text = Text(ctx, UINameType.Ranking_Reward);
            panel.titleLabel.text = Text(ctx, UINameType.Home_Ranking);
            panel.collectLabel.text = Text(ctx, UINameType.Ranking_Collect);
            panel.retryLabel.text = Text(ctx, UINameType.Ranking_Retry);
            panel.myLabel.text = Text(ctx, UINameType.Ranking_Me);
            panel.previewLabel.text = state.isPreview ? Text(ctx, UINameType.Ranking_Preview) : string.Empty;
            panel.ShowEntries(state.entries, state.me, config, Text(ctx, UINameType.Ranking_Unknown));
            UINameType message = UINameType.None;
            switch (state.status) {
                case RankingStatus.Loading: message = UINameType.Ranking_Loading; break;
                case RankingStatus.Unavailable: message = UINameType.Ranking_Unavailable; break;
                case RankingStatus.Failed: message = UINameType.Ranking_Failed; break;
                case RankingStatus.Empty: message = UINameType.Ranking_Empty; break;
                case RankingStatus.NotParticipating: message = UINameType.Ranking_NotParticipating; break;
                case RankingStatus.Ended: message = UINameType.Ranking_Ended; break;
            }
            panel.statusLabel.text = message == UINameType.None ? string.Empty : Text(ctx, message);
            panel.retryButton.gameObject.SetActive(state.status == RankingStatus.Unavailable || state.status == RankingStatus.Failed);
            panel.retryButton.interactable = true;
            if (state.endsAtUtc == 0) {
                panel.timeLabel.text = Text(ctx, UINameType.Ranking_TimeUnknown);
            } else if (state.status == RankingStatus.Ended) {
                panel.timeLabel.text = Text(ctx, UINameType.Ranking_EndedShort);
            } else {
                var remaining = TimeSpan.FromSeconds(RankingController.RemainingSeconds(ctx));
                panel.timeLabel.text = string.Format(Text(ctx, UINameType.Ranking_Remaining), remaining.Days, remaining.Hours, remaining.Minutes, remaining.Seconds);
            }
        }
        public static void RefreshSafeArea(GameContext ctx) {
            var panels = ctx.panelRepository;
            if (panels.TryGet(PanelType.Ranking, out Panel_Ranking panel)) {
                panel.ApplySafeArea();
            }
        }
        public static void Close(GameContext ctx) {
            var panels = ctx.panelRepository;
            if (panels.TryGet(PanelType.Ranking, out Panel_Ranking panel)) {
                panels.Remove(panel);
                panel.TearDown();
            }
        }
    }
}
