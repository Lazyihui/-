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
                panel.board.dragHandle = (index, erase) => GameController.Input(ctx, index, false, true, erase);
                panel.board.eraseHandle = index => {
                    var state = ctx.state_Game;
                    return !state.isTutorial && state.cells[index] == CellStatus.Cross;
                };
                panel.tutorialHintHandle = () => GameController.PreviewTutorialHint(ctx);
                panel.tutorialConfirmHandle = () => GameController.ConfirmTutorial(ctx);
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
        static string Instruction(GameContext ctx, UINameType type) {
            string text = Text(ctx, type);
            if (type == UINameType.Game_Place || type == UINameType.Game_Tap) {
                var state = ctx.state_Game;
                var assets = ctx.assetModule;
                var config = assets.GetGameConfig();
                int index = type == UINameType.Game_Place ? config.tutorialPlaceIndex : config.tutorialTapIndex;
                int size = state.puzzle.size;
                text = string.Format(text, index / size + 1, index % size + 1);
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
            var save = ctx.playerSave;
            var preferences = save.settings;
            var settingsConfig = assets.GetSettingsConfig();
            int count = 0;
            for (int i = 0; i < state.cells.Length; i++) {
                int region = puzzle.regions[i];
                Color color = state.isTutorial ? config.tutorialColors[region] : config.regionColors[region];
                panel.board.ShowCell(i, color, state.isTutorial || !preferences.pattern ? null : config.patterns[region], state.cells[i], state.isTutorial && ((state.tutorialStep < 6 && state.tutorialStep != 1 && GameController.TutorialFocus(ctx, i)) || (state.tutorialHintVisible && state.cells[i] != CellStatus.Hamster && puzzle.solutionColumns[i / puzzle.size] == i % puzzle.size)), module.IsGiven(puzzle, i));
                panel.board.ShowRegionBorder(i, preferences.border && !state.isTutorial, puzzle.regions, puzzle.size, settingsConfig.borderColor, settingsConfig.borderWidth);
                panel.board.DimCell(i, state.isTutorial && state.tutorialStep != 1 && state.tutorialStep < 6 && !GameController.TutorialFocus(ctx, i));
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
            panel.instructionLabel.text = string.Empty;
            if (state.isTutorial) {
                int step = state.tutorialStep;
                UINameType rule = step == 0 ? UINameType.Game_Place : step == 1 ? UINameType.Game_TutorialRegion :
                    step == 2 ? UINameType.Game_TutorialLine : step == 3 || step == 5 ? UINameType.Game_TutorialOnly :
                    step == 4 ? UINameType.Game_TutorialAdjacent : step == 7 ? UINameType.Game_TutorialDone : UINameType.Game_Solve;
                UINameType action = step == 2 ? UINameType.Game_Tap : step == 4 ? UINameType.Game_Drag : step == 6 ? UINameType.Game_TutorialHint : UINameType.None;
                panel.tutorialRule.text = Text(ctx, rule);
                if (step == 3 || step == 5) {
                    panel.tutorialRule.text += "\n" + Text(ctx, UINameType.Game_Place);
                }
                panel.tutorialAction.text = action == UINameType.None ? string.Empty : Text(ctx, action);
                panel.tutorialConfirmLabel.text = Text(ctx, step == 7 ? UINameType.Game_TutorialStart : UINameType.Game_TutorialConfirm);
                int target = step == 0 ? config.tutorialPlaceIndices[0] : step == 3 ? config.tutorialPlaceIndices[1] : step == 5 ? config.tutorialPlaceIndices[2] : -1;
                int[] path = step == 2 ? Array.FindAll(config.tutorialLineIndices, index => state.cells[index] == CellStatus.None) : step == 4 ? config.tutorialDragIndices : null;
                panel.ShowTutorial(true, step, target, path);
                var settings = ctx.state_Settings;
                panel.homeButton.gameObject.SetActive(settings.tutorialReview);
            } else {
                panel.ShowTutorial(false, 0, -1, null);
            }
            panel.noticeLabel.text = state.notice == UINameType.None ? string.Empty : Instruction(ctx, state.notice);
            panel.hintLabel.text = Text(ctx, UINameType.Game_Hint);
            panel.guideLabel.text = Text(ctx, UINameType.Game_Guide);
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
