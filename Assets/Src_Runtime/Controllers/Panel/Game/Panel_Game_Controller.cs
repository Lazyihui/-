using System;
using UnityEngine;
namespace Hamdoku.Controllers {
    public static class Panel_Game_Controller {
        public static void Open(GameContext ctx) {
            var opened = PanelFactory.TryOpen(ctx, PanelType.Game, out Panel_Game panel);
            if (opened == UIOpenType.FirstOpen) {
                var localization = ctx.l10NModule;
                panel.Ctor(localization);
                panel.board.inputHandle = (index, twice, drag) => GameController.Input(ctx, index, twice, drag);
                panel.homeHandle = () => GameController.ShowDialog(ctx, GameDialogType.Exit);
                panel.restartHandle = () => GameController.ShowDialog(ctx, GameDialogType.Restart);
                panel.shopHandle = () => GameController.RequestFeature(ctx, HomeRequestType.Shop);
                panel.settingsHandle = () => GameController.RequestFeature(ctx, HomeRequestType.Settings);
                panel.hintHandle = () => GameController.Hint(ctx);
                panel.guideHandle = () => GameController.Guide(ctx);
            }
            panel.Init();
            var state = ctx.state_Game;
            var assets = ctx.assetModule;
            var config = assets.GetGameConfig();
            panel.board.Init(state.puzzle.size, config.doubleTapSeconds, config.dragThreshold);
            Refresh(ctx);
        }
        public static string Text(GameContext ctx, UINameType type) {
            var localization = ctx.l10NModule;
            if (!localization.TryGet(type, out var text)) {
                throw new InvalidOperationException("Missing game text " + type);
            }
            return text;
        }
        public static void Refresh(GameContext ctx) {
            var panels = ctx.panelRepository;
            if (!panels.TryGet(PanelType.Game, out Panel_Game panel)) {
                return;
            }
            var state = ctx.state_Game;
            var puzzle = state.puzzle;
            var module = ctx.puzzleModule;
            var assets = ctx.assetModule;
            var config = assets.GetGameConfig();
            int count = 0;
            for (int i = 0; i < state.cells.Length; i++) {
                bool focus = state.isTutorial && ((state.tutorialStep == 0 && i == config.tutorialPlaceIndex) ||
                    (state.tutorialStep == 1 && i == config.tutorialTapIndex) || (state.tutorialStep == 2 && Array.IndexOf(config.tutorialDragIndices, i) >= 0));
                int region = puzzle.regions[i];
                panel.board.ShowCell(i, config.regionColors[region], config.patterns[region], state.cells[i], focus, module.IsGiven(puzzle, i));
                if (state.cells[i] == CellStatus.Hamster) {
                    count++;
                }
            }
            panel.levelLabel.text = state.isTutorial ? Text(ctx, UINameType.Game_Tutorial) : string.Format(Text(ctx, UINameType.Game_Level), state.level);
            panel.scoreLabel.text = string.Format(Text(ctx, UINameType.Game_Score), state.score);
            panel.countLabel.text = string.Format(Text(ctx, UINameType.Game_Count), count, puzzle.size);
            for (int i = 0; i < panel.hearts.Length; i++) {
                panel.hearts[i].color = i < state.hearts ? Color.white : new Color(1, 1, 1, 0.18f);
            }
            panel.ruleLabels[0].text = Text(ctx, UINameType.Game_RuleRegion);
            panel.ruleLabels[1].text = Text(ctx, UINameType.Game_RuleLine);
            panel.ruleLabels[2].text = Text(ctx, UINameType.Game_RuleAdjacent);
            UINameType instruction = UINameType.Game_Solve;
            if (state.tutorialStep == 0) {
                instruction = UINameType.Game_Place;
            } else if (state.tutorialStep == 1) {
                instruction = UINameType.Game_Tap;
            } else if (state.tutorialStep == 2) {
                instruction = UINameType.Game_Drag;
            }
            panel.instructionLabel.text = state.isTutorial ? Text(ctx, instruction) : string.Empty;
            panel.noticeLabel.text = state.notice == UINameType.None ? string.Empty : Text(ctx, state.notice);
            panel.hintLabel.text = Text(ctx, UINameType.Game_Hint);
            panel.guideLabel.text = Text(ctx, UINameType.Game_Guide);
            var save = ctx.playerSave;
            var streak = save.streak;
            panel.hintCount.text = checked(state.hints + streak.bonusHints).ToString();
            panel.guideCount.text = checked(state.guides + streak.bonusGuides).ToString();
            bool active = state.status == GameStatus.Playing && !state.isTutorial;
            panel.hintButton.interactable = active;
            panel.guideButton.interactable = active;
            RefreshTime(ctx);
        }
        public static void RefreshTime(GameContext ctx) {
            var panels = ctx.panelRepository;
            var state = ctx.state_Game;
            if (panels.TryGet(PanelType.Game, out Panel_Game panel)) {
                int seconds = (int)state.elapsed;
                panel.timeLabel.text = string.Format(Text(ctx, UINameType.Game_Time), seconds / 60, seconds % 60);
            }
        }
        public static void Close(GameContext ctx) {
            var panels = ctx.panelRepository;
            if (panels.TryGet(PanelType.Game, out Panel_Game panel)) {
                panels.Remove(panel);
                panel.TearDown();
            }
        }
    }
}
