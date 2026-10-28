using System;
using UnityEngine;
namespace Hamdoku.Controllers {
    public static class Panel_GameResult_Controller {
        public static void Open(GameContext ctx) {
            var assets = ctx.assetModule;
            var config = assets.GetGameConfig().resultConfig;
            ValidateConfig(config);
            var opened = PanelFactory.TryOpen(ctx, PanelType.GameResult, out Panel_GameResult panel);
            if (opened == UIOpenType.FirstOpen) {
                var localization = ctx.l10NModule;
                panel.Ctor(localization);
                panel.primaryHandle = () => GameController.DialogPrimary(ctx);
                panel.secondaryHandle = () => GameController.DialogSecondary(ctx);
                panel.adHandle = () => GameController.AdUnavailable(ctx);
            }
            var state = ctx.state_Game;
            panel.Init(config, state.dialog == GameDialogType.Result, state.score, state.bestCombo, state.scoreCarry == 0);
            Refresh(ctx);
        }
        public static void ValidateConfig(ResultConfigSO config) {
            if (config == null || config.clearHero == null || config.failHero == null) {
                throw new InvalidOperationException("Result config or original hero sprites are missing.");
            }
            float[] values = { config.clearHeroSize, config.failHeroSize, config.revealFadeSeconds, config.statCountUpSeconds };
            foreach (float value in values) {
                if (float.IsNaN(value) || float.IsInfinity(value) || value <= 0) {
                    throw new InvalidOperationException("Invalid result size or animation duration.");
                }
            }
            float[] anchors = { config.titleAnchorY, config.clearHeroAnchorY, config.failHeroAnchorY, config.messageAnchorY,
                config.statRowAnchorY, config.clearButtonAnchorY, config.failRemainingAnchorY, config.failMessageAnchorY,
                config.failContinueAnchorY, config.failRestartAnchorY };
            foreach (float anchor in anchors) {
                if (float.IsNaN(anchor) || float.IsInfinity(anchor) || anchor < 0 || anchor > 1) {
                    throw new InvalidOperationException("Invalid result layout anchor.");
                }
            }
            if (float.IsNaN(config.revealHeroAt) || float.IsInfinity(config.revealHeroAt) || config.revealHeroAt < 0 ||
                float.IsNaN(config.revealStatsAt) || float.IsInfinity(config.revealStatsAt) || config.revealStatsAt < config.revealHeroAt ||
                float.IsNaN(config.revealButtonAt) || float.IsInfinity(config.revealButtonAt) || config.revealButtonAt < config.revealStatsAt + config.statCountUpSeconds ||
                float.IsNaN(config.failButtonsAt) || float.IsInfinity(config.failButtonsAt) || config.failButtonsAt < 0) {
                throw new InvalidOperationException("Invalid result reveal sequence.");
            }
        }
        public static void Refresh(GameContext ctx) {
            var panels = ctx.panelRepository;
            if (!panels.TryGet(PanelType.GameResult, out Panel_GameResult panel)) {
                return;
            }
            var state = ctx.state_Game;
            var assets = ctx.assetModule;
            var config = assets.GetGameConfig();
            bool won = state.dialog == GameDialogType.Result;
            panel.titleLabel.text = Panel_Game_Controller.Text(ctx, won ? state.mistakes == 0 ? UINameType.Game_Perfect : UINameType.Game_Won : UINameType.Game_Failed);
            panel.messageLabel.text = Panel_Game_Controller.Text(ctx, won ? state.scoreCarry > 0 ? UINameType.Result_Legacy : UINameType.Result_ClearBody : UINameType.Result_FailBody);
            panel.statLabels[0].text = Panel_Game_Controller.Text(ctx, UINameType.Result_Score);
            panel.statLabels[1].text = Panel_Game_Controller.Text(ctx, UINameType.Result_Combo);
            panel.statLabels[2].text = Panel_Game_Controller.Text(ctx, UINameType.Result_Time);
            int seconds = (int)state.elapsed;
            panel.statValues[2].text = string.Format("{0:00}:{1:00}", seconds / 60, seconds % 60);
            int count = 0;
            foreach (var cell in state.cells) {
                if (cell == CellStatus.Hamster) {
                    count++;
                }
            }
            panel.remainingLabel.text = string.Format(Panel_Game_Controller.Text(ctx, UINameType.Result_Remaining), state.puzzle.size - count);
            panel.primaryLabel.text = Panel_Game_Controller.Text(ctx, won ? state.level == config.campaignSizes.Length ? UINameType.Game_Home : UINameType.Game_Next : UINameType.Game_Restart);
            panel.secondaryLabel.text = Panel_Game_Controller.Text(ctx, UINameType.Game_Home);
            panel.secondaryButton.gameObject.SetActive(!won || state.level < config.campaignSizes.Length);
            panel.adLabel.text = Panel_Game_Controller.Text(ctx, UINameType.Result_Ad);
            panel.statusLabel.text = Panel_Game_Controller.Text(ctx, state.notice == UINameType.Game_AdUnavailable ? UINameType.Game_AdUnavailable : UINameType.Result_AdStatus);
            if (won && state.level == config.campaignSizes.Length) {
                panel.messageLabel.text = Panel_Game_Controller.Text(ctx, UINameType.Game_BatchComplete);
            }
        }
        public static void Close(GameContext ctx) {
            var panels = ctx.panelRepository;
            if (panels.TryGet(PanelType.GameResult, out Panel_GameResult panel)) {
                panels.Remove(panel);
                panel.TearDown();
            }
        }
    }
}
