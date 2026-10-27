using System;
using UnityEngine;
namespace Hamdoku.Controllers {
    public static class GameController {
        public static void Open(GameContext ctx, bool tutorial) {
            var state = ctx.state_Game;
            if (state.disposed) {
                throw new InvalidOperationException("Game has been disposed.");
            }
            if (state.isOpen) {
                return;
            }
            var save = ctx.playerSave;
            var assets = ctx.assetModule;
            var config = assets.GetGameConfig();
            var module = ctx.puzzleModule;
            if (save.activePuzzle == null && !tutorial && save.campaignClears >= config.campaignSizes.Length) {
                HomeController.ShowNotice(ctx, UINameType.Game_BatchComplete, 0);
                return;
            }
            if (save.activePuzzle != null) {
                var active = save.activePuzzle;
                module.ValidateSave(active, config, save.campaignClears, save.tutorialCompleted);
                state.puzzle = module.Get(active.puzzleId);
                state.level = active.level;
                state.isTutorial = active.isTutorial;
                state.cells = (CellStatus[])active.cells.Clone();
                state.hearts = active.hearts;
                state.mistakes = active.mistakes;
                state.hints = active.hints;
                state.guides = active.guides;
                state.score = active.score;
                state.elapsed = active.elapsed;
                state.tutorialStep = active.tutorialStep;
                state.status = active.status;
                state.tutorialHintVisible = false;
                if (active.isTutorial && active.status == GameStatus.Won) {
                    state.tutorialStep = 7;
                }
                if (active.isTutorial && active.tutorialFlowVersion == 0 && active.status == GameStatus.Playing) {
                    ResetBoard(ctx);
                }
            } else {
                state.isTutorial = tutorial;
                state.level = tutorial ? 0 : save.campaignClears + 1;
                state.puzzle = tutorial ? config.tutorial : module.Select(config.campaignSizes[state.level - 1], save.previousPuzzleId);
                ResetBoard(ctx);
            }
            var home = ctx.state_Home;
            home.isOpen = false;
            home.pendingRequest = HomeRequestType.None;
            home.noticeType = UINameType.None;
            home.noticeRemaining = 0;
            Panel_Home_Controller.Close(ctx);
            state.notice = UINameType.None;
            state.dialog = GameDialogType.None;
            state.isOpen = true;
            Panel_Game_Controller.Open(ctx);
            if (state.status == GameStatus.Won) {
                if (!state.isTutorial) {
                    ShowDialog(ctx, GameDialogType.Result);
                }
            } else if (state.status == GameStatus.Failed) {
                ShowDialog(ctx, GameDialogType.Failed);
            }
            Persist(ctx);
        }
        static void ResetBoard(GameContext ctx) {
            var state = ctx.state_Game;
            var assets = ctx.assetModule;
            var config = assets.GetGameConfig();
            var puzzle = state.puzzle;
            state.cells = new CellStatus[puzzle.size * puzzle.size];
            foreach (int row in puzzle.preplacedRows) {
                state.cells[row * puzzle.size + puzzle.solutionColumns[row]] = CellStatus.Hamster;
            }
            state.hearts = config.maxHearts;
            state.hints = config.hintsPerLevel;
            state.guides = config.guidesPerLevel;
            state.mistakes = 0;
            state.elapsed = 0;
            state.score = 0;
            state.tutorialStep = 0;
            state.tutorialHintVisible = false;
            state.status = GameStatus.Playing;
            state.dialog = GameDialogType.None;
            state.notice = UINameType.None;
        }
        public static void Input(GameContext ctx, int index, bool twice, bool drag, bool erase = false) {
            var state = ctx.state_Game;
            var settings = ctx.state_Settings;
            if (settings.isOpen || !state.isOpen || state.status != GameStatus.Playing || state.dialog != GameDialogType.None || index < 0 || index >= state.cells.Length) {
                return;
            }
            var puzzle = state.puzzle;
            var assets = ctx.assetModule;
            var config = assets.GetGameConfig();
            var module = ctx.puzzleModule;
            if (module.IsGiven(puzzle, index)) {
                return;
            }
            if (state.isTutorial && !TutorialAllows(ctx, index, twice, drag)) {
                return;
            }
            state.notice = UINameType.None;
            if (twice) {
                if (state.cells[index] == CellStatus.Hamster) {
                    return;
                }
                var conflict = module.Conflict(puzzle, state.cells, index);
                if (conflict != UINameType.None || puzzle.solutionColumns[index / puzzle.size] != index % puzzle.size) {
                    state.mistakes++;
                    state.hearts--;
                    state.notice = conflict == UINameType.None ? UINameType.Game_WrongCell : conflict;
                    Play(ctx, false, true);
                    if (state.hearts == 0) {
                        state.status = GameStatus.Failed;
                        ProfileController.RecordRetry(ctx);
                        ShowDialog(ctx, GameDialogType.Failed);
                    }
                } else {
                    state.cells[index] = CellStatus.Hamster;
                    AddScore(ctx);
                    Play(ctx, true, false);
                }
            } else if (state.cells[index] != CellStatus.Hamster) {
                state.cells[index] = drag ? (erase && !state.isTutorial ? CellStatus.None : CellStatus.Cross) : (state.cells[index] == CellStatus.None ? CellStatus.Cross : CellStatus.None);
                Play(ctx, false, false);
            }
            AdvanceTutorial(ctx);
            FinishIfComplete(ctx);
            Panel_Game_Controller.Refresh(ctx);
            Persist(ctx);
            if (state.status == GameStatus.Won && !state.isTutorial) {
                RankingController.SubmitPending(ctx);
            }
        }
        static void AddScore(GameContext ctx) {
            var state = ctx.state_Game;
            var assets = ctx.assetModule;
            var config = assets.GetGameConfig();
            int count = 0;
            foreach (var cell in state.cells) {
                if (cell == CellStatus.Hamster) {
                    count++;
                }
            }
            if (state.isTutorial) {
                return;
            }
            state.score += config.scoreBase + config.scoreStep * Mathf.Max(0, count - 1);
        }
        public static bool TutorialFocus(GameContext ctx, int index) {
            var state = ctx.state_Game;
            var assets = ctx.assetModule;
            var config = assets.GetGameConfig();
            switch (state.tutorialStep) {
                case 0: return index == config.tutorialPlaceIndices[0];
                case 2: return Array.IndexOf(config.tutorialLineIndices, index) >= 0 || index == config.tutorialPlaceIndices[0];
                case 3: return index == config.tutorialPlaceIndices[1];
                case 4: return Array.IndexOf(config.tutorialDragIndices, index) >= 0 || index == config.tutorialPlaceIndices[0] || index == config.tutorialPlaceIndices[1];
                case 5: return index == config.tutorialPlaceIndices[2];
                default: return true;
            }
        }
        static bool TutorialAllows(GameContext ctx, int index, bool twice, bool drag) {
            var state = ctx.state_Game;
            var assets = ctx.assetModule;
            var config = assets.GetGameConfig();
            switch (state.tutorialStep) {
                case 0: return twice && index == config.tutorialPlaceIndices[0];
                case 2: return !twice && !drag && state.cells[index] == CellStatus.None && Array.IndexOf(config.tutorialLineIndices, index) >= 0;
                case 3: return twice && index == config.tutorialPlaceIndices[1];
                case 4: return !twice && drag && state.cells[index] == CellStatus.None && Array.IndexOf(config.tutorialDragIndices, index) >= 0;
                case 5: return twice && index == config.tutorialPlaceIndices[2];
                case 6: return true;
                default: return false;
            }
        }
        public static void PreviewTutorialHint(GameContext ctx) {
            var state = ctx.state_Game;
            if (!state.isOpen || !state.isTutorial || state.tutorialStep != 6 || state.dialog != GameDialogType.None) {
                return;
            }
            state.tutorialHintVisible = !state.tutorialHintVisible;
            Panel_Game_Controller.Refresh(ctx);
        }
        public static void ConfirmTutorial(GameContext ctx) {
            var state = ctx.state_Game;
            if (!state.isOpen || !state.isTutorial || state.dialog != GameDialogType.None) {
                return;
            }
            if (state.tutorialStep == 1) {
                state.tutorialStep = 2;
                Panel_Game_Controller.Refresh(ctx);
                Persist(ctx);
            } else if (state.tutorialStep == 7) {
                Next(ctx);
            }
        }
        static void AdvanceTutorial(GameContext ctx) {
            var state = ctx.state_Game;
            if (!state.isTutorial) {
                return;
            }
            var assets = ctx.assetModule;
            var config = assets.GetGameConfig();
            if (state.tutorialStep == 0 && state.cells[config.tutorialPlaceIndices[0]] == CellStatus.Hamster) {
                state.tutorialStep = 1;
            } else if (state.tutorialStep == 2 && Array.TrueForAll(config.tutorialLineIndices, index => state.cells[index] == CellStatus.Cross)) {
                state.tutorialStep = 3;
            } else if (state.tutorialStep == 3 && state.cells[config.tutorialPlaceIndices[1]] == CellStatus.Hamster) {
                state.tutorialStep = 4;
            } else if (state.tutorialStep == 4 && Array.TrueForAll(config.tutorialDragIndices, index => state.cells[index] == CellStatus.Cross)) {
                state.tutorialStep = 5;
            } else if (state.tutorialStep == 5 && state.cells[config.tutorialPlaceIndices[2]] == CellStatus.Hamster) {
                state.tutorialStep = 6;
            }
        }
        static void FinishIfComplete(GameContext ctx) {
            var state = ctx.state_Game;
            var module = ctx.puzzleModule;
            if (state.status != GameStatus.Playing || !module.IsComplete(state.puzzle, state.cells)) {
                return;
            }
            state.status = GameStatus.Won;
            var save = ctx.playerSave;
            if (state.isTutorial) {
                var settings = ctx.state_Settings;
                if (!settings.tutorialReview) {
                    save.tutorialCompleted = true;
                }
            } else {
                if (state.level != save.campaignClears + 1) {
                    throw new InvalidOperationException("Campaign cannot award the same level twice.");
                }
                save.campaignClears = state.level;
                save.previousPuzzleId = state.puzzle.id;
                ProfileController.RecordClear(ctx);
                RankingController.RecordClear(ctx);
                StreakController.RecordWin(ctx, DateTime.Today);
            }
            var assets = ctx.assetModule;
            var config = assets.GetGameConfig();
            var audio = ctx.audioModule;
            audio.PlayOneShot(config.clearClip, config.soundVolume);
            if (state.isTutorial) {
                state.tutorialStep = 7;
                for (int i = 0; i < state.cells.Length; i++) {
                    if (state.cells[i] == CellStatus.None) {
                        state.cells[i] = CellStatus.Cross;
                    }
                }
            } else {
                ShowDialog(ctx, GameDialogType.Result);
            }
        }
        public static void Hint(GameContext ctx) {
            var state = ctx.state_Game;
            if (!CanUseItem(state)) {
                return;
            }
            var save = ctx.playerSave;
            var streak = save.streak;
            if (state.hints == 0 && streak.bonusHints == 0) {
                state.notice = UINameType.Game_NoItems;
            } else {
                var puzzle = state.puzzle;
                var module = ctx.puzzleModule;
                for (int row = 0; row < puzzle.size; row++) {
                    int index = row * puzzle.size + puzzle.solutionColumns[row];
                    if (state.cells[index] == CellStatus.Hamster) {
                        continue;
                    }
                    // The supplied hint answer may disagree with a valid alternative partial arrangement.
                    for (int i = 0; i < state.cells.Length; i++) {
                        if (state.cells[i] == CellStatus.Hamster && !module.IsGiven(puzzle, i)) {
                            int otherRow = i / puzzle.size;
                            int otherCol = i % puzzle.size;
                            if (otherRow == row || otherCol == index % puzzle.size || puzzle.regions[i] == puzzle.regions[index] ||
                                (Math.Abs(otherRow - row) <= 1 && Math.Abs(otherCol - index % puzzle.size) <= 1)) {
                                state.cells[i] = CellStatus.None;
                            }
                        }
                    }
                    state.cells[index] = CellStatus.Hamster;
                    if (state.hints > 0) {
                        state.hints--;
                    } else {
                        StreakController.TrySpendHint(ctx);
                    }
                    AddScore(ctx);
                    Play(ctx, true, false);
                    break;
                }
            }
            FinishIfComplete(ctx);
            Panel_Game_Controller.Refresh(ctx);
            Persist(ctx);
        }
        public static void Guide(GameContext ctx) {
            var state = ctx.state_Game;
            if (!CanUseItem(state)) {
                return;
            }
            var save = ctx.playerSave;
            var streak = save.streak;
            if (state.guides == 0 && streak.bonusGuides == 0) {
                state.notice = UINameType.Game_NoItems;
            } else {
                var module = ctx.puzzleModule;
                bool changed = false;
                for (int i = 0; i < state.cells.Length; i++) {
                    if (state.cells[i] == CellStatus.None && module.Conflict(state.puzzle, state.cells, i) != UINameType.None) {
                        state.cells[i] = CellStatus.Cross;
                        changed = true;
                    }
                }
                if (changed) {
                    if (state.guides > 0) {
                        state.guides--;
                    } else {
                        StreakController.TrySpendGuide(ctx);
                    }
                    Play(ctx, false, false);
                }
            }
            Panel_Game_Controller.Refresh(ctx);
            Persist(ctx);
        }
        static bool CanUseItem(GameState state) {
            return state.isOpen && !state.isTutorial && state.status == GameStatus.Playing && state.dialog == GameDialogType.None;
        }
        static void Play(GameContext ctx, bool placed, bool mistake) {
            var assets = ctx.assetModule;
            var config = assets.GetGameConfig();
            var audio = ctx.audioModule;
            audio.PlayOneShot(mistake ? config.mistakeClip : placed ? config.placeClip : config.markClip, config.soundVolume);
            var save = ctx.playerSave;
            var settings = save.settings;
            if (settings.vibration && (placed || mistake)) {
                var vibration = ctx.vibrationModule;
                vibration.Pulse();
            }
            if (placed) {
                var state = ctx.state_Game;
                int count = 0;
                foreach (var cell in state.cells) {
                    if (cell == CellStatus.Hamster) {
                        count++;
                    }
                }
                SettingsController.PlayVoice(ctx, count);
            }
        }
        public static void RequestFeature(GameContext ctx, HomeRequestType type) {
            var state = ctx.state_Game;
            if (!state.isOpen || state.dialog != GameDialogType.None) {
                return;
            }
            if (type != HomeRequestType.Shop && type != HomeRequestType.Settings) {
                throw new ArgumentOutOfRangeException(nameof(type));
            }
            if (type == HomeRequestType.Shop) {
                var featureEvents = ctx.events_Home;
                state.notice = UINameType.None;
                featureEvents.requestHandle?.Invoke(type);
                return;
            }
            var home = ctx.state_Home;
            var events = ctx.events_Home;
            home.pendingRequest = type;
            state.notice = type == HomeRequestType.Settings ? UINameType.None : UINameType.Home_Preparing;
            Panel_Game_Controller.Refresh(ctx);
            events.requestHandle?.Invoke(type);
        }
        public static void ShowDialog(GameContext ctx, GameDialogType type) {
            var state = ctx.state_Game;
            if (!state.isOpen || type == GameDialogType.None) {
                return;
            }
            if (state.dialog != GameDialogType.None && state.dialog != type) {
                return;
            }
            state.dialog = type;
            var panels = ctx.panelRepository;
            if (panels.TryGet(PanelType.Game, out Panel_Game panel)) {
                panel.board.CancelGesture();
            }
            Panel_GameDialog_Controller.Open(ctx);
        }
        public static void DialogPrimary(GameContext ctx) {
            var state = ctx.state_Game;
            var dialog = state.dialog;
            if (!state.isOpen || dialog == GameDialogType.None) {
                return;
            }
            Panel_GameDialog_Controller.Close(ctx);
            state.dialog = GameDialogType.None;
            if (dialog == GameDialogType.Exit) {
                ReturnHome(ctx);
            } else if (dialog == GameDialogType.Restart || dialog == GameDialogType.Failed) {
                ProfileController.RecordRetry(ctx);
                ResetBoard(ctx);
                Panel_Game_Controller.Open(ctx);
                Persist(ctx);
            } else {
                Next(ctx);
            }
        }
        public static void DialogSecondary(GameContext ctx) {
            var state = ctx.state_Game;
            if (!state.isOpen || state.dialog == GameDialogType.None) {
                return;
            }
            var dialog = state.dialog;
            Panel_GameDialog_Controller.Close(ctx);
            state.dialog = GameDialogType.None;
            if (dialog == GameDialogType.Failed || dialog == GameDialogType.Result) {
                ReturnHome(ctx);
            }
        }
        public static void AdUnavailable(GameContext ctx) {
            var state = ctx.state_Game;
            if (state.dialog != GameDialogType.Failed) {
                return;
            }
            state.notice = UINameType.Game_AdUnavailable;
            Panel_GameDialog_Controller.Refresh(ctx);
        }
        static void Next(GameContext ctx) {
            var settings = ctx.state_Settings;
            if (settings.tutorialReview) {
                SettingsController.EndTutorial(ctx);
                return;
            }
            var state = ctx.state_Game;
            var save = ctx.playerSave;
            var assets = ctx.assetModule;
            var config = assets.GetGameConfig();
            save.activePuzzle = null;
            state.isOpen = false;
            Panel_Game_Controller.Close(ctx);
            HomeController.SaveProgress(ctx);
            if (StreakController.OpenAfterGame(ctx)) {
                return;
            }
            if (save.campaignClears >= config.campaignSizes.Length) {
                HomeSystem.Open(ctx);
                HomeController.ShowNotice(ctx, UINameType.Game_BatchComplete, 0);
            } else {
                Open(ctx, false);
            }
        }
        public static void ReturnHome(GameContext ctx) {
            var settings = ctx.state_Settings;
            if (settings.tutorialReview) {
                SettingsController.EndTutorial(ctx);
                return;
            }
            var state = ctx.state_Game;
            if (!state.isOpen) {
                return;
            }
            Persist(ctx);
            if (state.status == GameStatus.Won) {
                var save = ctx.playerSave;
                save.activePuzzle = null;
                HomeController.SaveProgress(ctx);
            }
            state.isOpen = false;
            state.dialog = GameDialogType.None;
            Panel_GameDialog_Controller.Close(ctx);
            Panel_Game_Controller.Close(ctx);
            HomeSystem.Open(ctx);
        }
        public static void PauseForShop(GameContext ctx) {
            var state = ctx.state_Game;
            if (!CanUseItem(state)) {
                throw new InvalidOperationException("Shop requires an active campaign board without a dialog.");
            }
            Persist(ctx);
            state.isOpen = false;
            Panel_Game_Controller.Close(ctx);
        }
        public static void Persist(GameContext ctx) {
            var settings = ctx.state_Settings;
            if (settings.tutorialReview) {
                return;
            }
            var state = ctx.state_Game;
            if (!state.isOpen) {
                return;
            }
            var save = ctx.playerSave;
            save.activePuzzle = new PuzzleSaveModel {
                puzzleId = state.puzzle.id, level = state.level, isTutorial = state.isTutorial,
                cells = (CellStatus[])state.cells.Clone(), hearts = state.hearts, mistakes = state.mistakes,
                hints = state.hints, guides = state.guides, score = state.score, elapsed = state.elapsed,
                tutorialStep = state.tutorialStep, tutorialFlowVersion = 1, status = state.status
            };
            HomeController.SaveProgress(ctx);
        }
        public static void Tick(GameContext ctx, float deltaTime) {
            var state = ctx.state_Game;
            var settings = ctx.state_Settings;
            if (!settings.isOpen && state.status == GameStatus.Playing && state.dialog == GameDialogType.None) {
                state.elapsed += deltaTime;
                Panel_Game_Controller.RefreshTime(ctx);
            }
            var area = Screen.safeArea;
            int width = Screen.width;
            int height = Screen.height;
            if (state.safeArea != area || state.screenWidth != width || state.screenHeight != height) {
                state.safeArea = area;
                state.screenWidth = width;
                state.screenHeight = height;
                var panels = ctx.panelRepository;
                if (panels.TryGet(PanelType.Game, out Panel_Game panel)) {
                    panel.ApplySafeArea(area, width, height);
                }
                if (panels.TryGet(PanelType.GameDialog, out Panel_GameDialog dialog)) {
                    dialog.ApplySafeArea(area, width, height);
                }
            }
        }
        public static void Dispose(GameContext ctx) {
            var state = ctx.state_Game;
            if (state.disposed) {
                return;
            }
            Persist(ctx);
            state.isOpen = false;
            state.disposed = true;
            Panel_GameDialog_Controller.Close(ctx);
            Panel_Game_Controller.Close(ctx);
        }
    }
}
