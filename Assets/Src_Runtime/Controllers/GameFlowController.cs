using System;
using System.Collections.Generic;
using UnityEngine;
namespace Hamdoku.Controllers {
    public static class GameFlowController {
        public static void UpgradeSave(GameContext ctx, PlayerSaveModel loaded) {
            var save = ctx.playerSave;
            var active = save.activePuzzle;
            if (active == null || loaded == null || loaded.version >= 9) {
                return;
            }
            active.flowVersion = 1;
            active.initialIndices = Array.Empty<int>();
            active.cellGains = new int[active.cells == null ? 0 : active.cells.Length];
            active.scoreCarry = active.score;
            active.combo = 0;
            active.bestCombo = 0;
            active.clearPending = false;
            active.clearCrossApplied = false;
            active.clearSweepNeeded = false;
        }
        public static void Reset(GameContext ctx) {
            var state = ctx.state_Game;
            var assets = ctx.assetModule;
            var config = assets.GetPuzzleRules();
            var puzzle = state.puzzle;
            state.flowVersion = 1;
            state.cellGains = new int[state.cells.Length];
            state.scoreCarry = 0;
            state.combo = 0;
            state.bestCombo = 0;
            state.clearPending = false;
            state.clearSweepNeeded = false;
            state.clearCrossApplied = false;
            state.clearElapsed = 0;
            if (state.isTutorial) {
                state.initialIndices = Array.Empty<int>();
                return;
            }
            // An explicit original placement takes precedence over the early-level random reveal.
            var indices = new int[puzzle.preplacedRows.Length];
            for (int i = 0; i < indices.Length; i++) {
                int row = puzzle.preplacedRows[i];
                indices[i] = row * puzzle.size + puzzle.solutionColumns[row];
            }
            if (indices.Length == 0 && state.dailyDay == 0 && state.level <= config.startRevealLevels) {
                int row = UnityEngine.Random.Range(0, puzzle.size);
                indices = new[] { row * puzzle.size + puzzle.solutionColumns[row] };
            }
            state.initialIndices = indices;
            foreach (int index in indices) {
                state.cells[index] = CellStatus.Hamster;
                state.cellGains[index] = config.scoreBase;
                state.score = checked(state.score + config.scoreBase);
            }
        }
        public static void AddScore(GameContext ctx, int index) {
            var state = ctx.state_Game;
            if (state.isTutorial || state.cellGains[index] != 0) {
                return;
            }
            var assets = ctx.assetModule;
            var config = assets.GetPuzzleRules();
            int gain = checked(config.scoreBase + config.scoreStep * state.combo);
            state.cellGains[index] = gain;
            state.score = checked(state.score + gain);
            state.combo++;
            state.bestCombo = Math.Max(state.bestCombo, state.combo);
            Panel_Game_Controller.ShowGain(ctx, index, gain);
        }
        public static void BeginClear(GameContext ctx) {
            var state = ctx.state_Game;
            var assets = ctx.assetModule;
            var config = assets.GetPuzzleRules();
            state.clearSweepNeeded = state.dailyDay == 0 && state.level <= config.clearAutoCrossLevels && Array.IndexOf(state.cells, CellStatus.None) >= 0;
            state.clearPending = true;
            state.clearCrossApplied = false;
            state.clearElapsed = 0;
        }
        public static void Tick(GameContext ctx, float deltaTime) {
            var state = ctx.state_Game;
            if (!state.isOpen || !state.clearPending) {
                return;
            }
            var assets = ctx.assetModule;
            var presentation = assets.GetPuzzlePresentation();
            bool autoCross = state.clearSweepNeeded;
            float previous = state.clearElapsed;
            state.clearElapsed += deltaTime;
            if (!state.clearCrossApplied && state.clearElapsed >= (autoCross ? presentation.clearAutoCrossDelay : 0)) {
                state.clearCrossApplied = true;
                var indices = new List<int>();
                for (int i = 0; autoCross && i < state.cells.Length; i++) {
                    if (state.cells[i] == CellStatus.None) {
                        state.cells[i] = CellStatus.Cross;
                        indices.Add(i);
                    }
                }
                Panel_Game_Controller.Refresh(ctx);
                if (autoCross) {
                    Panel_Game_Controller.SweepClear(ctx, indices.ToArray());
                }
                GameController.Persist(ctx);
            }
            float finishAt = presentation.clearCelebrationDelay + (autoCross ? presentation.clearAutoCrossDelay + presentation.clearAutoCrossHold : 0);
            if (previous < finishAt && state.clearElapsed >= finishAt) {
                var audio = ctx.audioModule;
                audio.PlayOneShot(presentation.clearClip, presentation.soundVolume);
                Panel_Game_Controller.CelebrateClear(ctx);
            }
            if (state.clearElapsed >= finishAt + presentation.resultDelay) {
                state.clearPending = false;
            state.clearSweepNeeded = false;
                GameController.ShowDialog(ctx, GameDialogType.Result);
                GameController.Persist(ctx);
            }
        }
    }
}

