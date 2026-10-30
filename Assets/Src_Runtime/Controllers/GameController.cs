using System;
using UnityEngine;
namespace Hamdoku.Controllers {
    public static class GameController {
        public static void Open(GameContext ctx, bool tutorial, int dailyDay = 0) {
            var state = ctx.state_Game;
            if (state.disposed) {
                throw new InvalidOperationException("Game has been disposed.");
            }
            if (state.isOpen) {
                return;
            }
            var endless = ctx.state_Endless;
            if (state.mode == GameModeType.Endless && endless.isActive) {
                state.isOpen = true;
                Panel_Game_Controller.Open(ctx);
                return;
            }
            state.mode = tutorial ? GameModeType.Tutorial : dailyDay > 0 ? GameModeType.Daily : GameModeType.Campaign;
            var save = ctx.playerSave;
            var assets = ctx.assetModule;
            var config = assets.GetPuzzleRules();
            var campaignConfig = assets.GetCampaignConfig();
            var module = ctx.puzzleModule;
            state.dailyDay = dailyDay;
            state.rewardReturnHome = false;
            var savedPuzzle = dailyDay > 0 ? save.daily.activePuzzle : save.activePuzzle;
            if (dailyDay == 0 && savedPuzzle == null && !tutorial && save.campaignClears >= campaignConfig.campaignSizes.Length) {
                HomeController.ShowNotice(ctx, UINameType.Game_BatchComplete, 0);
                return;
            }
            if (savedPuzzle != null) {
                var active = savedPuzzle;
                module.ValidateSave(active, config, campaignConfig, save.campaignClears, save.tutorialCompleted);
                state.puzzle = module.Materialize(active.puzzleId, active.campaignTransform);
                state.campaignSelectionVersion = active.campaignSelectionVersion;
                state.campaignGrade = active.campaignGrade;
                state.campaignFirstGame = active.campaignFirstGame;
                state.campaignTouched = active.campaignTouched;
                state.campaignUsedItem = active.campaignUsedItem;
                state.campaignFailures = active.campaignFailures;
                if (!active.isTutorial && active.campaignFirstGame) {
                    state.firstGameAvailable = false;
                }
                state.level = active.level;
                state.isTutorial = active.isTutorial;
                state.mode = active.isTutorial ? GameModeType.Tutorial : dailyDay > 0 ? GameModeType.Daily : GameModeType.Campaign;
                state.cells = (CellStatus[])active.cells.Clone();
                state.hearts = active.hearts;
                state.mistakes = active.mistakes;
                state.hints = active.hints;
                state.guides = active.guides;
                state.flowVersion = active.flowVersion;
                state.initialIndices = (int[])active.initialIndices.Clone();
                state.cellGains = (int[])active.cellGains.Clone();
                state.scoreCarry = active.scoreCarry;
                state.combo = active.combo;
                state.bestCombo = active.bestCombo;
                state.clearPending = active.clearPending;
                state.clearCrossApplied = active.clearCrossApplied;
                state.clearSweepNeeded = active.clearSweepNeeded;
                state.clearElapsed = 0;
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
                if (dailyDay > 0) {
                    state.puzzle = module.Materialize(DailyController.Puzzle(assets.GetDailyConfig(), module, dailyDay).id, 0);
                    state.level = DailyController.Date(dailyDay).Day;
                    state.campaignSelectionVersion = 0;
                    state.campaignGrade = 0;
                    state.campaignFirstGame = false;
                    state.campaignTouched = false;
                    state.campaignUsedItem = false;
                    state.campaignFailures = 0;
                } else if (tutorial) {
                    state.puzzle = module.Materialize(config.tutorialPuzzleId, 0);
                    state.campaignSelectionVersion = 0;
                    state.campaignGrade = 0;
                    state.campaignFirstGame = false;
                    state.campaignTouched = false;
                    state.campaignUsedItem = false;
                    state.campaignFailures = 0;
                } else {
                    CampaignController.Select(ctx);
                }
                ResetBoard(ctx);
            }
            state.tutorialTransitionPending = false;
            state.tutorialTransitionRemaining = 0;
            state.tutorialIdleElapsed = 0;
            state.tutorialHintUsed = false;
            if (state.isTutorial && state.status == GameStatus.Playing) {
                AdvanceTutorial(ctx);
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
                if (!state.isTutorial && !state.clearPending) {
                    ShowDialog(ctx, GameDialogType.Result);
                }
            } else if (state.status == GameStatus.Failed) {
                ShowDialog(ctx, GameDialogType.Failed);
            }
            Persist(ctx);
        }
        public static void OpenEndlessBoard(GameContext ctx, PuzzleBoardModel board) {
            var state = ctx.state_Game;
            var endless = ctx.state_Endless;
            if (!endless.isActive || state.disposed) {
                return;
            }
            state.mode = GameModeType.Endless;
            state.isTutorial = false;
            state.dailyDay = 0;
            state.level = checked(endless.cleared + 1);
            state.puzzle = board;
            state.campaignSelectionVersion = 0;
            state.campaignGrade = 0;
            state.campaignFirstGame = false;
            state.campaignTouched = false;
            state.campaignUsedItem = false;
            state.campaignFailures = 0;
            ResetBoard(ctx);
            var home = ctx.state_Home;
            home.isOpen = false;
            home.pendingRequest = HomeRequestType.None;
            home.noticeType = UINameType.None;
            home.noticeRemaining = 0;
            Panel_Home_Controller.Close(ctx);
            state.isOpen = true;
            Panel_Game_Controller.Open(ctx);
        }
        static void ResetBoard(GameContext ctx) {
            var state = ctx.state_Game;
            state.resultHeroId = 0;
            var assets = ctx.assetModule;
            var config = assets.GetPuzzleRules();
            var puzzle = state.puzzle;
            state.cells = new CellStatus[puzzle.size * puzzle.size];
            foreach (int row in puzzle.preplacedRows) {
                state.cells[row * puzzle.size + puzzle.solutionColumns[row]] = CellStatus.Hamster;
            }
            state.hearts = config.maxHearts;
            // Original endless reads the persistent item inventory at each StartPuzzle.
            // It does not replenish the campaign's per-board allowance.
            state.hints = state.mode == GameModeType.Endless ? 0 : config.hintsPerLevel;
            state.guides = state.mode == GameModeType.Endless ? 0 : config.guidesPerLevel;
            state.mistakes = 0;
            state.elapsed = 0;
            state.score = 0;
            GameFlowController.Reset(ctx);
            state.tutorialStep = 0;
            state.tutorialHintVisible = false;
            state.tutorialHintUsed = false;
            state.tutorialIdleElapsed = 0;
            state.tutorialTransitionPending = false;
            state.tutorialTransitionRemaining = 0;
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
            var module = ctx.puzzleModule;
            if (module.IsGiven(puzzle, index)) {
                return;
            }
            if (state.isTutorial && !TutorialAllows(ctx, index, twice, drag)) {
                return;
            }
            var previousCell = state.cells[index];
            state.notice = UINameType.None;
            if (twice) {
                if (state.cells[index] == CellStatus.Hamster) {
                    return;
                }
                var conflict = module.Conflict(puzzle, state.cells, index);
                if (conflict != UINameType.None || puzzle.solutionColumns[index / puzzle.size] != index % puzzle.size) {
                    state.combo = 0;
                    state.mistakes++;
                    state.hearts--;
                    state.notice = conflict == UINameType.None ? UINameType.Game_WrongCell : conflict;
                    Panel_Game_Controller.ShowWrong(ctx, index);
                    Play(ctx, false, true);
                    if (state.hearts == 0) {
                        CampaignController.Fail(ctx);
                        state.status = GameStatus.Failed;
                        if (state.mode == GameModeType.Campaign) {
                            ProfileController.RecordRetry(ctx);
                        }
                        if (state.mode == GameModeType.Endless) {
                            EndlessController.Fail(ctx);
                        } else {
                            ShowDialog(ctx, GameDialogType.Failed);
                        }
                    }
                } else {
                    state.cells[index] = CellStatus.Hamster;
                    GameFlowController.AddScore(ctx, index);
                    Play(ctx, true, false);
                }
            } else if (state.cells[index] != CellStatus.Hamster) {
                state.cells[index] = drag ? (erase && !state.isTutorial ? CellStatus.None : CellStatus.Cross) : (state.cells[index] == CellStatus.None ? CellStatus.Cross : CellStatus.None);
                Play(ctx, false, false);
            }
            if (state.isTutorial && state.cells[index] != previousCell) {
                state.tutorialIdleElapsed = 0;
                state.tutorialHintVisible = false;
            }
            if (state.cells[index] != previousCell || state.mistakes > 0) {
                CampaignController.Touch(ctx);
            }
            AdvanceTutorial(ctx);
            FinishIfComplete(ctx);
            Panel_Game_Controller.Refresh(ctx);
            Persist(ctx);
            if (state.status == GameStatus.Won && state.mode == GameModeType.Campaign) {
                RankingController.SubmitPending(ctx);
            }
        }
        public static bool TutorialFocus(GameContext ctx, int index) {
            var state = ctx.state_Game;
            var assets = ctx.assetModule;
            var config = assets.GetPuzzleRules();
            switch (state.tutorialStep) {
                case 0: return index == config.tutorialPlaceIndices[0];
                case 2: return Array.IndexOf(config.tutorialLineIndices, index) >= 0 || index == config.tutorialPlaceIndices[0];
                case 3: return state.puzzle.regions[index] == state.puzzle.regions[config.tutorialPlaceIndices[1]];
                case 4: return Array.IndexOf(config.tutorialDragIndices, index) >= 0 || index == config.tutorialPlaceIndices[0] || index == config.tutorialPlaceIndices[1];
                case 5: return state.puzzle.regions[index] == state.puzzle.regions[config.tutorialPlaceIndices[2]];
                default: return true;
            }
        }
        static bool TutorialAllows(GameContext ctx, int index, bool twice, bool drag) {
            var state = ctx.state_Game;
            var assets = ctx.assetModule;
            var config = assets.GetPuzzleRules();
            if (state.tutorialTransitionPending) {
                return false;
            }
            switch (state.tutorialStep) {
                case 0: return twice && index == config.tutorialPlaceIndices[0];
                case 2: return !twice && state.cells[index] == CellStatus.None && Array.IndexOf(config.tutorialLineIndices, index) >= 0;
                case 3: return twice && index == config.tutorialPlaceIndices[1];
                case 4: return !twice && state.cells[index] == CellStatus.None && Array.IndexOf(config.tutorialDragIndices, index) >= 0;
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
            state.tutorialHintUsed = true;
            state.tutorialIdleElapsed = 0;
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
            var config = assets.GetPuzzleRules();
            if (state.tutorialStep == 0 && state.cells[config.tutorialPlaceIndices[0]] == CellStatus.Hamster) {
                state.tutorialStep = 1;
            } else if (state.tutorialStep == 2 && Array.TrueForAll(config.tutorialLineIndices, index => state.cells[index] == CellStatus.Cross)) {
                BeginTutorialSettle(ctx);
            } else if (state.tutorialStep == 3 && state.cells[config.tutorialPlaceIndices[1]] == CellStatus.Hamster) {
                state.tutorialStep = 4;
            } else if (state.tutorialStep == 4 && Array.TrueForAll(config.tutorialDragIndices, index => state.cells[index] == CellStatus.Cross)) {
                BeginTutorialSettle(ctx);
            } else if (state.tutorialStep == 5 && state.cells[config.tutorialPlaceIndices[2]] == CellStatus.Hamster) {
                state.tutorialStep = 6;
            }
        }
        static void BeginTutorialSettle(GameContext ctx) {
            var state = ctx.state_Game;
            var assets = ctx.assetModule;
            var config = assets.GetPuzzleRules();
            if (!state.tutorialTransitionPending) {
                state.tutorialTransitionPending = true;
                state.tutorialTransitionRemaining = config.tutorialCrossSettleSeconds;
            }
        }
        public static void CompleteForTesting(GameContext ctx) {
            var state = ctx.state_Game;
            var settings = ctx.state_Settings;
            if (!state.isOpen || settings.isOpen || state.status != GameStatus.Playing || state.dialog != GameDialogType.None) {
                return;
            }
            var puzzle = state.puzzle;
            for (int i = 0; i < state.cells.Length; i++) {
                int row = i / puzzle.size;
                int column = i % puzzle.size;
                if (column == puzzle.solutionColumns[row]) {
                    if (state.cells[i] != CellStatus.Hamster) {
                        state.cells[i] = CellStatus.Hamster;
                        GameFlowController.AddScore(ctx, i);
                    }
                } else if (state.cells[i] == CellStatus.Hamster) {
                    state.cells[i] = CellStatus.None;
                }
            }
            state.tutorialTransitionPending = false;
            CampaignController.Touch(ctx);
            FinishIfComplete(ctx);
            Panel_Game_Controller.Refresh(ctx);
            Persist(ctx);
            if (state.status == GameStatus.Won && state.mode == GameModeType.Campaign) {
                RankingController.SubmitPending(ctx);
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
            } else if (state.mode == GameModeType.Endless) {
                EndlessController.Complete(ctx);
            } else if (state.dailyDay > 0) {
                DailyController.Complete(ctx);
            } else {
                if (state.level != save.campaignClears + 1) {
                    throw new InvalidOperationException("Campaign cannot award the same level twice.");
                }
                CampaignController.Complete(ctx);
                save.campaignClears = state.level;
                save.previousPuzzleId = state.puzzle.id;
                ProfileController.RecordClear(ctx);
                RankingController.RecordClear(ctx);
                StreakController.RecordWin(ctx, DateTime.Today);
            }
            var assets = ctx.assetModule;
            var presentation = assets.GetPuzzlePresentation();
            var audio = ctx.audioModule;
            if (state.isTutorial) {
                audio.PlayOneShot(presentation.clearClip, presentation.soundVolume);
            }
            if (state.isTutorial) {
                state.tutorialStep = 7;
                for (int i = 0; i < state.cells.Length; i++) {
                    if (state.cells[i] == CellStatus.None) {
                        state.cells[i] = CellStatus.Cross;
                    }
                }
            } else if (state.mode != GameModeType.Endless) {
                GameFlowController.BeginClear(ctx);
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
                    CampaignController.UseItem(ctx);
                    GameFlowController.AddScore(ctx, index);
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
                    CampaignController.UseItem(ctx);
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
            var presentation = assets.GetPuzzlePresentation();
            var audio = ctx.audioModule;
            audio.PlayOneShot(mistake ? presentation.mistakeClip : placed ? presentation.placeClip : presentation.markClip, presentation.soundVolume);
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
                SettingsController.PlayVoice(ctx, state.isTutorial ? count : state.combo);
            }
        }
        public static void RequestFeature(GameContext ctx, HomeRequestType type) {
            var state = ctx.state_Game;
            if (!state.isOpen || state.clearPending || state.dialog != GameDialogType.None) {
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
            if (!state.isOpen || state.clearPending || type == GameDialogType.None) {
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
            if (!state.isTutorial && state.dailyDay == 0 && (type == GameDialogType.Result || type == GameDialogType.Failed || type == GameDialogType.Reward)) {
                Panel_GameResult_Controller.Open(ctx);
            } else {
                Panel_GameDialog_Controller.Open(ctx);
            }
        }
        public static void DialogPrimary(GameContext ctx) {
            var state = ctx.state_Game;
            var dialog = state.dialog;
            if (!state.isOpen || dialog == GameDialogType.None) {
                return;
            }
            var endless = ctx.state_Endless;
            if (state.mode == GameModeType.Endless && dialog == GameDialogType.Failed && endless.recordPending) {
                EndlessController.TryPersistRecord(ctx);
                Panel_GameResult_Controller.Refresh(ctx);
                return;
            }
            if (dialog == GameDialogType.Result && state.mode == GameModeType.Campaign && CampaignController.PendingReward(ctx) > 0) {
                OpenReward(ctx, false);
                return;
            }
            if (dialog == GameDialogType.Reward) {
                if (!CampaignController.ClaimReward(ctx)) {
                    return;
                }
                Panel_GameResult_Controller.Close(ctx);
                state.dialog = GameDialogType.None;
                if (state.rewardReturnHome) {
                    ReturnHome(ctx);
                } else {
                    Next(ctx);
                }
                return;
            }
            Panel_GameDialog_Controller.Close(ctx);
            Panel_GameResult_Controller.Close(ctx);
            state.dialog = GameDialogType.None;
            if (dialog == GameDialogType.Exit) {
                ReturnHome(ctx);
            } else if (dialog == GameDialogType.Restart || dialog == GameDialogType.Failed) {
                Restart(ctx);
            } else {
                Next(ctx);
            }
        }
        public static void Restart(GameContext ctx) {
            var state = ctx.state_Game;
            if (state.mode == GameModeType.Endless && state.isOpen && state.dialog == GameDialogType.None) {
                EndlessController.Retry(ctx);
                return;
            }
            if (!state.isOpen || state.dialog != GameDialogType.None ||
                (state.status != GameStatus.Playing && state.status != GameStatus.Failed)) {
                return;
            }
            if (state.dailyDay > 0) {
                state.notice = UINameType.Daily_AdUnavailable;
                Panel_Game_Controller.Refresh(ctx);
                return;
            }
            ProfileController.RecordRetry(ctx);
            if (state.status != GameStatus.Failed) {
                CampaignController.Fail(ctx);
            }
            ResetBoard(ctx);
            Panel_Game_Controller.Open(ctx);
            Persist(ctx);
        }
        public static void DialogSecondary(GameContext ctx) {
            var state = ctx.state_Game;
            if (!state.isOpen || state.dialog == GameDialogType.None) {
                return;
            }
            var dialog = state.dialog;
            if (dialog == GameDialogType.Reward) {
                return;
            }
            var endless = ctx.state_Endless;
            if (state.mode == GameModeType.Endless && dialog == GameDialogType.Failed && endless.recordPending) {
                if (!EndlessController.TryPersistRecord(ctx)) {
                    Panel_GameResult_Controller.Refresh(ctx);
                    return;
                }
            }
            if (dialog == GameDialogType.Result && state.mode == GameModeType.Campaign && CampaignController.PendingReward(ctx) > 0) {
                OpenReward(ctx, true);
                return;
            }
            Panel_GameDialog_Controller.Close(ctx);
            Panel_GameResult_Controller.Close(ctx);
            state.dialog = GameDialogType.None;
            if (dialog == GameDialogType.Failed || dialog == GameDialogType.Result) {
                ReturnHome(ctx);
            }
        }
        public static void AdUnavailable(GameContext ctx) {
            var state = ctx.state_Game;
            if (state.dialog != GameDialogType.Failed && state.dialog != GameDialogType.Reward) {
                return;
            }
            state.notice = UINameType.Game_AdUnavailable;
            Panel_GameDialog_Controller.Refresh(ctx);
            Panel_GameResult_Controller.Refresh(ctx);
        }
        static void OpenReward(GameContext ctx, bool returnHome) {
            var state = ctx.state_Game;
            state.rewardReturnHome = returnHome;
            Panel_GameResult_Controller.Close(ctx);
            state.dialog = GameDialogType.Reward;
            state.notice = UINameType.None;
            Panel_GameResult_Controller.Open(ctx);
        }
        static void Next(GameContext ctx) {
            var settings = ctx.state_Settings;
            if (settings.tutorialReview) {
                SettingsController.EndTutorial(ctx);
                return;
            }
            var state = ctx.state_Game;
            if (state.dailyDay > 0) {
                ReturnHome(ctx);
                return;
            }
            var save = ctx.playerSave;
            var assets = ctx.assetModule;
            var campaignConfig = assets.GetCampaignConfig();
            save.activePuzzle = null;
            state.isOpen = false;
            Panel_Game_Controller.Close(ctx);
            HomeController.SaveProgress(ctx);
            if (StreakController.OpenAfterGame(ctx)) {
                return;
            }
            if (save.campaignClears >= campaignConfig.campaignSizes.Length) {
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
            if (!state.isOpen || state.clearPending) {
                return;
            }
            if (state.mode == GameModeType.Endless) {
                if (!EndlessController.TryPersistRecord(ctx)) {
                    ShowDialog(ctx, GameDialogType.Failed);
                    return;
                }
                EndlessController.Close(ctx);
                state.isOpen = false;
                state.mode = GameModeType.None;
                state.dialog = GameDialogType.None;
                Panel_GameDialog_Controller.Close(ctx);
                Panel_GameResult_Controller.Close(ctx);
                Panel_Game_Controller.Close(ctx);
                HomeSystem.Open(ctx);
                return;
            }
            Persist(ctx);
            if (state.status == GameStatus.Won) {
                var save = ctx.playerSave;
                if (state.dailyDay > 0) {
                    save.daily.activePuzzle = null;
                } else {
                    save.activePuzzle = null;
                }
                HomeController.SaveProgress(ctx);
            }
            state.isOpen = false;
            state.dialog = GameDialogType.None;
            Panel_GameDialog_Controller.Close(ctx);
            Panel_GameResult_Controller.Close(ctx);
            Panel_Game_Controller.Close(ctx);
            if (state.dailyDay > 0) {
                int completedDay = state.dailyDay;
                state.dailyDay = 0;
                DailyController.Open(ctx, completedDay);
            } else {
                HomeSystem.Open(ctx);
            }
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
        public static PuzzleSaveModel CapturePuzzle(GameContext ctx) {
            var state = ctx.state_Game;
            return new PuzzleSaveModel {
                dailyDay = state.dailyDay,
                campaignSelectionVersion = state.campaignSelectionVersion, campaignGrade = state.campaignGrade,
                campaignTransform = state.puzzle.transform,
                campaignFirstGame = state.campaignFirstGame, campaignTouched = state.campaignTouched,
                campaignUsedItem = state.campaignUsedItem, campaignFailures = state.campaignFailures,
                puzzleId = state.puzzle.id, level = state.level, isTutorial = state.isTutorial,
                cells = (CellStatus[])state.cells.Clone(), hearts = state.hearts, mistakes = state.mistakes,
                hints = state.hints, guides = state.guides, score = state.score, elapsed = state.elapsed,
                flowVersion = state.flowVersion, initialIndices = (int[])state.initialIndices.Clone(),
                cellGains = (int[])state.cellGains.Clone(), scoreCarry = state.scoreCarry,
                combo = state.combo, bestCombo = state.bestCombo,
                clearPending = state.clearPending, clearCrossApplied = state.clearCrossApplied, clearSweepNeeded = state.clearSweepNeeded,
                tutorialStep = state.tutorialStep, tutorialFlowVersion = 1, status = state.status
            };
        }
        public static void RestoreEndlessBoard(GameContext ctx, PuzzleBoardModel board, PuzzleSaveModel active) {
            var state = ctx.state_Game;
            state.mode = GameModeType.Endless;
            state.puzzle = board;
            state.isTutorial = false;
            state.dailyDay = 0;
            state.level = active.level;
            state.dialog = GameDialogType.None;
            state.notice = UINameType.None;
            state.tutorialTransitionPending = false;
            state.tutorialHintVisible = false;
            state.cells = (CellStatus[])active.cells.Clone();
            state.hearts = active.hearts;
            state.mistakes = active.mistakes;
            state.hints = active.hints;
            state.guides = active.guides;
            state.flowVersion = active.flowVersion;
            state.initialIndices = (int[])active.initialIndices.Clone();
            state.cellGains = (int[])active.cellGains.Clone();
            state.scoreCarry = active.scoreCarry;
            state.combo = active.combo;
            state.bestCombo = active.bestCombo;
            state.clearPending = active.clearPending;
            state.clearCrossApplied = active.clearCrossApplied;
            state.clearSweepNeeded = active.clearSweepNeeded;
            state.clearElapsed = 0;
            state.score = active.score;
            state.elapsed = active.elapsed;
            state.tutorialStep = 0;
            state.status = active.status;
            state.isOpen = true;
            Panel_Game_Controller.Open(ctx);
        }
        public static void Persist(GameContext ctx) {
            var settings = ctx.state_Settings;
            if (settings.tutorialReview) {
                return;
            }
            var state = ctx.state_Game;
            if (!state.isOpen || state.mode == GameModeType.Endless) {
                return;
            }
            var save = ctx.playerSave;
            var active = CapturePuzzle(ctx);
            if (state.dailyDay > 0) {
                save.daily.activePuzzle = active;
            } else {
                save.activePuzzle = active;
            }
            HomeController.SaveProgress(ctx);
        }
        public static void Tick(GameContext ctx, float deltaTime) {
            GameFlowController.Tick(ctx, deltaTime);
            var state = ctx.state_Game;
            var settings = ctx.state_Settings;
            if (!settings.isOpen && state.status == GameStatus.Playing && state.dialog == GameDialogType.None) {
                state.elapsed += deltaTime;
                if (state.isTutorial) {
                    var assets = ctx.assetModule;
                    var config = assets.GetPuzzleRules();
                    if (state.tutorialTransitionPending) {
                        state.tutorialTransitionRemaining -= deltaTime;
                        if (state.tutorialTransitionRemaining <= 0) {
                            state.tutorialTransitionRemaining = 0;
                            state.tutorialTransitionPending = false;
                            state.tutorialStep++;
                            Panel_Game_Controller.Refresh(ctx);
                            Persist(ctx);
                        }
                    } else if (state.tutorialStep == 6 && !state.tutorialHintUsed) {
                        bool alreadyNudging = state.tutorialIdleElapsed >= config.tutorialIdleHintSeconds;
                        state.tutorialIdleElapsed += deltaTime;
                        if (!alreadyNudging && state.tutorialIdleElapsed >= config.tutorialIdleHintSeconds) {
                            Panel_Game_Controller.Refresh(ctx);
                        }
                    }
                }
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
                if (panels.TryGet(PanelType.GameResult, out Panel_GameResult result)) {
                    result.ApplySafeArea(area, width, height);
                }
            }
        }
        public static void Dispose(GameContext ctx) {
            var state = ctx.state_Game;
            if (state.disposed) {
                return;
            }
            Persist(ctx);
            EndlessController.Close(ctx);
            state.isOpen = false;
            state.disposed = true;
            Panel_GameDialog_Controller.Close(ctx);
            Panel_GameResult_Controller.Close(ctx);
            Panel_Game_Controller.Close(ctx);
        }
    }
}
