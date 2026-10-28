using System;
using UnityEngine;
namespace Hamdoku.Controllers {
    public static class Panel_GameResult_Controller {
        public static void Open(GameContext ctx) {
            var assets = ctx.assetModule;
            var config = assets.GetResultConfig();
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
            panel.Init(config, state.dialog == GameDialogType.Result || state.dialog == GameDialogType.Reward, state.score, state.bestCombo, state.scoreCarry == 0, state.dialog == GameDialogType.Reward, state.dialog == GameDialogType.Result ? SelectHero(ctx, config) : null);
            Refresh(ctx);
        }
        public static void ValidateConfig(ResultConfigSO config) {
            if (config == null || config.clearHero == null || config.failHero == null || config.rewardHero == null) {
                throw new InvalidOperationException("Result config or original hero sprites are missing.");
            }
            if (config.clearHeroes == null || config.clearHeroes.Length != 7 || Array.Exists(config.clearHeroes, sprite => sprite == null) ||
                config.clearHeroes[0] != config.clearHero) {
                throw new InvalidOperationException("All seven original clear illustrations must be bound in ID order.");
            }
            int[][] pools = { config.perfectHeroIds, config.hardFirstHeroIds, config.retryHeroIds, config.highHeroIds,
                config.midHeroIds, config.lowHeroIds, config.allHeroIds };
            foreach (var pool in pools) {
                if (pool == null || pool.Length == 0 || Array.Exists(pool, id => id < 1 || id > config.clearHeroes.Length)) {
                    throw new InvalidOperationException("A result illustration pool is empty or contains an invalid ID.");
                }
                for (int i = 0; i < pool.Length; i++) {
                    if (Array.IndexOf(pool, pool[i]) != i) {
                        throw new InvalidOperationException("A result illustration pool contains duplicate IDs.");
                    }
                }
            }
            float[] selectionValues = { config.heroBandHigh, config.heroBandMid, config.heroRankMid, config.heroRankSharp,
                config.heroTimePower, config.heroTimeScale, config.heroScoreWeight, config.heroTimeWeight, config.clearHeroTextGap };
            foreach (float value in selectionValues) {
                if (float.IsNaN(value) || float.IsInfinity(value) || value <= 0) {
                    throw new InvalidOperationException("Invalid result illustration selection configuration.");
                }
            }
            if (config.heroBandMid >= config.heroBandHigh || config.heroBandHigh > 100 || config.heroRankMid > 1 ||
                Mathf.Abs(config.heroScoreWeight + config.heroTimeWeight - 1) > .0001f || config.heroPickSalt < 0) {
                throw new InvalidOperationException("Invalid result illustration bands, weights or salt.");
            }
            float[] values = { config.clearHeroSize, config.failHeroSize, config.rewardHeroSize, config.revealFadeSeconds, config.statCountUpSeconds };
            foreach (float value in values) {
                if (float.IsNaN(value) || float.IsInfinity(value) || value <= 0) {
                    throw new InvalidOperationException("Invalid result size or animation duration.");
                }
            }
            float[] anchors = { config.titleAnchorY, config.clearHeroAnchorY, config.failHeroAnchorY, config.messageAnchorY,
                config.statRowAnchorY, config.clearButtonAnchorY, config.failRemainingAnchorY, config.failMessageAnchorY,
                config.failContinueAnchorY, config.failRestartAnchorY, config.rewardHeroAnchorY, config.rewardMessageAnchorY, config.rewardContentLiftY };
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
        public static Sprite SelectHero(GameContext ctx, ResultConfigSO config) {
            var state = ctx.state_Game;
            var puzzle = state.puzzle;
            if (state.resultHeroId != 0 && state.resultHeroPuzzleId == puzzle.id && state.resultHeroLevel == state.level) {
                if (state.resultHeroId < 1 || state.resultHeroId > config.clearHeroes.Length) {
                    throw new InvalidOperationException("Invalid selected result illustration ID.");
                }
                return config.clearHeroes[state.resultHeroId - 1];
            }
            var assets = ctx.assetModule;
            var rules = assets.GetPuzzleRules();
            var home = assets.GetHomeConfig();
            bool retried = state.campaignFailures > 0;
            bool hard = state.level >= home.hardLevelStart && state.level % home.hardLevelInterval == 0;
            int[] pool;
            if (state.mistakes == 0 && !state.campaignUsedItem && !retried) {
                pool = config.perfectHeroIds;
            } else if (retried) {
                pool = config.retryHeroIds;
            } else if (hard) {
                pool = config.hardFirstHeroIds;
            } else if (state.scoreCarry > 0) {
                // Legacy score ledgers cannot support the original score/time estimate.
                pool = config.allHeroIds;
            } else {
                // Original offline model only; this is never presented as a measured player ranking.
                int size = puzzle.size;
                double maximum = (double)rules.scoreBase * size + (double)rules.scoreStep * size * (size - 1) / 2;
                if (maximum <= 0) {
                    throw new InvalidOperationException("Result illustration scoring requires a positive maximum score.");
                }
                double ratio = Math.Min(1, Math.Max(0, state.score) / maximum);
                double expected = Math.Pow(size, config.heroTimePower) * config.heroTimeScale;
                double speed = expected / (expected + Math.Max(1, state.elapsed));
                double key = Math.Round((ratio * config.heroScoreWeight + speed * config.heroTimeWeight) * 1000000);
                float model = (float)(100 / (1 + Math.Exp(-((float)key / 1000000 - config.heroRankMid) * config.heroRankSharp)));
                pool = model >= config.heroBandHigh ? config.highHeroIds : model >= config.heroBandMid ? config.midHeroIds : config.lowHeroIds;
            }
            int id = PickHeroId(pool, puzzle.id, state.level, config.heroPickSalt, state.lastResultHeroId);
            state.resultHeroId = id;
            state.resultHeroPuzzleId = puzzle.id;
            state.resultHeroLevel = state.level;
            state.lastResultHeroId = id;
            return config.clearHeroes[id - 1];
        }
        public static int PickHeroId(int[] pool, int seed, int spin, int salt, int lastId) {
            if (pool == null || pool.Length == 0) {
                throw new InvalidOperationException("Cannot choose an illustration from an empty pool.");
            }
            uint hash;
            unchecked {
                int mixedSalt = spin * 7 + salt;
                hash = (uint)(seed * 73856093) ^ (uint)((mixedSalt + 1) * 19349663);
                hash ^= hash >> 13;
                hash *= 2246822507u;
            }
            int index = (int)(((hash & 0x7fffffffu) ^ (hash >> 16)) % (uint)pool.Length);
            if (pool.Length > 1 && pool[index] == lastId) {
                index = (index + 1) % pool.Length;
            }
            return pool[index];
        }
        public static void Refresh(GameContext ctx) {
            var panels = ctx.panelRepository;
            if (!panels.TryGet(PanelType.GameResult, out Panel_GameResult panel)) {
                return;
            }
            var state = ctx.state_Game;
            var assets = ctx.assetModule;
            var campaignConfig = assets.GetCampaignConfig();
            bool won = state.dialog == GameDialogType.Result;
            bool reward = state.dialog == GameDialogType.Reward;
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
            panel.primaryLabel.text = Panel_Game_Controller.Text(ctx, won ? state.level == campaignConfig.campaignSizes.Length ? UINameType.Game_Home : UINameType.Game_Next : UINameType.Game_Restart);
            panel.secondaryLabel.text = Panel_Game_Controller.Text(ctx, UINameType.Game_Home);
            panel.secondaryButton.gameObject.SetActive(!won || state.level < campaignConfig.campaignSizes.Length);
            panel.adLabel.text = Panel_Game_Controller.Text(ctx, UINameType.Result_Ad);
            panel.statusLabel.text = Panel_Game_Controller.Text(ctx, state.notice == UINameType.Game_AdUnavailable ? UINameType.Game_AdUnavailable : UINameType.Result_AdStatus);
            if (won && state.level == campaignConfig.campaignSizes.Length) {
                panel.messageLabel.text = Panel_Game_Controller.Text(ctx, UINameType.Game_BatchComplete);
            }
            int total = campaignConfig.campaignRewardStep;
            int filled = state.level % total;
            if (filled == 0) {
                filled = total;
            }
            panel.ShowRewardProgress(filled, total);
            panel.rewardProgressLabel.text = string.Format(Panel_Game_Controller.Text(ctx, UINameType.Result_RewardProgress), filled, total);
            if (reward) {
                int milestone = CampaignController.PendingReward(ctx);
                panel.titleLabel.text = Panel_Game_Controller.Text(ctx, UINameType.Result_RewardTitle);
                panel.messageLabel.text = string.Format(Panel_Game_Controller.Text(ctx, UINameType.Result_RewardBody), milestone, campaignConfig.campaignRewardHints, campaignConfig.campaignRewardGuides);
                panel.primaryLabel.text = Panel_Game_Controller.Text(ctx, UINameType.Result_RewardClaim);
                panel.secondaryButton.gameObject.SetActive(false);
                panel.adLabel.text = Panel_Game_Controller.Text(ctx, UINameType.Result_RewardAd);
                panel.statusLabel.text = Panel_Game_Controller.Text(ctx, UINameType.Result_RewardUnavailable);
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
