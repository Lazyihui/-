using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
namespace Hamdoku.Controllers {
    public static class EndlessController {
        public static void Initialize(GameContext ctx, PlayerSaveModel loaded) {
            var assets = ctx.assetModule;
            var config = assets.GetEndlessConfig();
            if (config.startSize < 4 || config.maxSize > 12 || config.maxSize < config.startSize || config.stepEvery < 1 ||
                config.generationAttempts < 1 || config.repairStepsPerCell < 1 || config.hardCandidates < 1 ||
                float.IsNaN(config.advanceSeconds) || float.IsInfinity(config.advanceSeconds) || config.advanceSeconds <= 0 ||
                float.IsNaN(config.failureSeconds) || float.IsInfinity(config.failureSeconds) || config.failureSeconds <= 0) {
                throw new InvalidDataException("Invalid endless configuration.");
            }
            var save = ctx.playerSave;
            save.endless = loaded == null || loaded.version < 13 ? new EndlessSaveModel() : loaded.endless;
            SaveModule.ValidateEndless(save.endless);
        }
        public static void Open(GameContext ctx) {
            var state = ctx.state_Endless;
            var game = ctx.state_Game;
            var home = ctx.state_Home;
            if (state.isActive || game.isOpen || !home.isOpen || !home.endlessUnlocked || game.disposed) {
                return;
            }
            var save = ctx.playerSave;
            var assets = ctx.assetModule;
            state.recordPending = false;
            state.isActive = true;
            state.isTestRun = save.campaignClears < assets.GetHomeConfig().endlessUnlockClears;
            state.cleared = 0;
            state.found = 0;
            state.elapsed = 0;
            state.advanceRemaining = 0;
            state.failureRemaining = 0;
            state.bestBeforeRun = save.endless.bestFound;
            Generate(ctx);
        }
        static void Generate(GameContext ctx) {
            var state = ctx.state_Endless;
            var assets = ctx.assetModule;
            var config = assets.GetEndlessConfig();
            var generator = ctx.puzzleGeneratorModule;
            int size = Math.Min(config.maxSize, checked(config.startSize + state.cleared / config.stepEvery));
            bool hard = size >= 6 && state.cleared % config.stepEvery >= (config.stepEvery + 1) / 2;
            int seed = UnityEngine.Random.Range(0, int.MaxValue);
            int attempts = config.generationAttempts;
            int repair = config.repairStepsPerCell;
            int candidates = config.hardCandidates;
            state.generationFailed = false;
            state.generationCancellation = new CancellationTokenSource();
            var cancellation = state.generationCancellation.Token;
            state.generationTask = Task.Run(() => generator.Generate(size, seed, attempts, repair, hard ? 2 : 1, hard, candidates, cancellation), cancellation);
            var game = ctx.state_Game;
            if (game.isOpen) {
                game.notice = UINameType.Endless_Generating;
                Panel_Game_Controller.Refresh(ctx);
            } else {
                HomeController.ShowNotice(ctx, UINameType.Endless_Generating, 0);
            }
        }
        public static void Tick(GameContext ctx, float deltaTime) {
            var state = ctx.state_Endless;
            if (!state.isActive) {
                return;
            }
            var game = ctx.state_Game;
            var settings = ctx.state_Settings;
            var shop = ctx.state_Shop;
            if (settings.tutorialReview || settings.isOpen || shop.isOpen || game.dialog == GameDialogType.Exit || game.dialog == GameDialogType.Restart) {
                return;
            }
            var task = state.generationTask;
            if (task != null) {
                if (!task.IsCompleted) {
                    if (!game.isOpen) {
                        var home = ctx.state_Home;
                        var assets = ctx.assetModule;
                        home.noticeRemaining = assets.GetHomeConfig().noticeSeconds;
                    }
                    return;
                }
                state.generationTask = null;
                state.generationCancellation.Dispose();
                state.generationCancellation = null;
                if (task.IsFaulted || task.IsCanceled) {
                    state.generationFailed = true;
                    if (task.Exception != null) {
                        Debug.LogException(task.Exception.GetBaseException());
                    }
                    if (game.isOpen) {
                        game.notice = UINameType.Endless_GenerationFailed;
                        Panel_Game_Controller.Refresh(ctx);
                    } else {
                        state.isActive = false;
                        HomeController.ShowNotice(ctx, UINameType.Endless_GenerationFailed, 0);
                    }
                    return;
                }
                GameController.OpenEndlessBoard(ctx, task.Result.board);
                return;
            }
            if (!game.isOpen) {
                return;
            }
            if (game.status == GameStatus.Playing && game.dialog == GameDialogType.None) {
                state.elapsed += deltaTime;
            }
            if (state.advanceRemaining > 0) {
                state.advanceRemaining = Math.Max(0, state.advanceRemaining - deltaTime);
                if (state.advanceRemaining == 0) {
                    Generate(ctx);
                }
            }
            if (state.failureRemaining > 0) {
                state.failureRemaining = Math.Max(0, state.failureRemaining - deltaTime);
                if (state.failureRemaining == 0) {
                    GameController.ShowDialog(ctx, GameDialogType.Failed);
                }
            }
        }
        public static void Complete(GameContext ctx) {
            var state = ctx.state_Endless;
            var game = ctx.state_Game;
            var assets = ctx.assetModule;
            state.cleared = checked(state.cleared + 1);
            state.found = checked(state.found + game.puzzle.size);
            state.advanceRemaining = assets.GetEndlessConfig().advanceSeconds;
            var presentation = assets.GetPuzzlePresentation();
            var audio = ctx.audioModule;
            audio.PlayOneShot(presentation.clearClip, presentation.soundVolume);
            Panel_Game_Controller.CelebrateClear(ctx);
        }
        public static void Fail(GameContext ctx) {
            var state = ctx.state_Endless;
            var assets = ctx.assetModule;
            state.failureRemaining = assets.GetEndlessConfig().failureSeconds;
            var save = ctx.playerSave;
            state.recordPending = !state.isTestRun && state.found > save.endless.bestFound;
            TryPersistRecord(ctx);
        }
        public static bool TryPersistRecord(GameContext ctx) {
            var state = ctx.state_Endless;
            if (!state.recordPending) {
                return true;
            }
            var save = ctx.playerSave;
            var record = save.endless;
            int previous = record.bestFound;
            record.bestFound = Math.Max(previous, state.found);
            try {
                HomeController.SaveProgress(ctx);
            } catch (IOException error) {
                record.bestFound = previous;
                var game = ctx.state_Game;
                game.notice = UINameType.Endless_SaveFailed;
                Debug.LogWarning("Endless record save failed: " + error.Message);
                return false;
            } catch (UnauthorizedAccessException error) {
                record.bestFound = previous;
                var game = ctx.state_Game;
                game.notice = UINameType.Endless_SaveFailed;
                Debug.LogWarning("Endless record save failed: " + error.Message);
                return false;
            }
            state.recordPending = false;
            var gameState = ctx.state_Game;
            gameState.notice = UINameType.None;
            return true;
        }
        public static void SuspendTutorial(GameContext ctx) {
            var state = ctx.state_Endless;
            var game = ctx.state_Game;
            state.suspendedPuzzle = GameController.CapturePuzzle(ctx);
            state.suspendedBoard = game.puzzle;
        }
        public static void ResumeTutorial(GameContext ctx) {
            var state = ctx.state_Endless;
            GameController.RestoreEndlessBoard(ctx, state.suspendedBoard, state.suspendedPuzzle);
            state.suspendedBoard = null;
            state.suspendedPuzzle = null;
        }
        public static void Retry(GameContext ctx) {
            var state = ctx.state_Endless;
            var game = ctx.state_Game;
            if (!TryPersistRecord(ctx)) {
                return;
            }
            CancelGeneration(state);
            state.cleared = 0;
            state.found = 0;
            state.elapsed = 0;
            state.advanceRemaining = 0;
            state.failureRemaining = 0;
            var save = ctx.playerSave;
            state.bestBeforeRun = save.endless.bestFound;
            game.status = GameStatus.Won;
            game.dialog = GameDialogType.None;
            game.clearPending = false;
            Generate(ctx);
        }
        public static void Close(GameContext ctx) {
            var state = ctx.state_Endless;
            TryPersistRecord(ctx);
            CancelGeneration(state);
            state.isActive = false;
            state.suspendedBoard = null;
            state.suspendedPuzzle = null;
            state.advanceRemaining = 0;
            state.failureRemaining = 0;
        }
        static void CancelGeneration(EndlessState state) {
            var task = state.generationTask;
            var cancellation = state.generationCancellation;
            if (cancellation != null) {
                cancellation.Cancel();
                cancellation.Dispose();
                state.generationCancellation = null;
            }
            if (task != null) {
                // Observe late faults after exit without retaining a Context or changing state.
                task.ContinueWith(completed => { var error = completed.Exception; }, TaskContinuationOptions.OnlyOnFaulted);
                state.generationTask = null;
            }
        }
    }
}
