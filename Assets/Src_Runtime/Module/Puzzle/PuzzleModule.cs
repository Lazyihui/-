using System;
using System.Collections.Generic;
using System.IO;
namespace Hamdoku {
    public sealed class PuzzleModule {
        readonly Dictionary<int, PuzzleSO> puzzles = new Dictionary<int, PuzzleSO>();
        readonly Dictionary<int, List<PuzzleSO>> sizes = new Dictionary<int, List<PuzzleSO>>();
        public void Initialize(GameConfigSO config) {
            if (config == null || config.campaignSizes == null || config.campaignSizes.Length == 0 || config.maxHearts <= 0 ||
                config.doubleTapSeconds <= 0 || config.dragThreshold <= 0 || config.hintsPerLevel < 0 || config.guidesPerLevel < 0 ||
                config.placeClip == null || config.markClip == null || config.mistakeClip == null || config.clearClip == null) {
                throw new InvalidDataException("Invalid GameConfigSO.");
            }
            puzzles.Clear();
            float[] tutorialDurations = { config.tutorialCrossSettleSeconds, config.tutorialIdleHintSeconds,
                config.tutorialCardFadeSeconds, config.tutorialDimFadeSeconds, config.tutorialFingerPressSeconds,
                config.tutorialFingerReleaseSeconds, config.tutorialFingerRestSeconds, config.tutorialFingerDragSeconds,
                config.tutorialRippleSeconds, config.tutorialMarkSeconds, config.tutorialPlaceSeconds, config.tutorialCelebrateSeconds };
            foreach (float duration in tutorialDurations) {
                if (float.IsNaN(duration) || float.IsInfinity(duration) || duration <= 0) {
                    throw new InvalidDataException("Invalid tutorial animation duration.");
                }
            }
            if (float.IsNaN(config.tutorialHandScale) || float.IsInfinity(config.tutorialHandScale) || config.tutorialHandScale <= 0 ||
                float.IsNaN(config.tutorialRippleFrom) || config.tutorialRippleFrom <= 0 ||
                float.IsNaN(config.tutorialRippleTo) || float.IsInfinity(config.tutorialRippleTo) || config.tutorialRippleTo <= config.tutorialRippleFrom ||
                float.IsNaN(config.tutorialRippleAlpha) || config.tutorialRippleAlpha <= 0 || config.tutorialRippleAlpha > 1) {
                throw new InvalidDataException("Invalid tutorial finger configuration.");
            }
            sizes.Clear();
            ValidatePuzzle(config.tutorial);
            int tutorialCells = config.tutorial.size * config.tutorial.size;
            if (config.tutorialPlaceIndex < 0 || config.tutorialPlaceIndex >= tutorialCells ||
                config.tutorialTapIndex < 0 || config.tutorialTapIndex >= tutorialCells || config.tutorialDragIndices == null ||
                config.tutorialDragIndices.Length == 0 || config.tutorial.solutionColumns[config.tutorialPlaceIndex / config.tutorial.size] != config.tutorialPlaceIndex % config.tutorial.size ||
                config.regionColors == null || config.patterns == null || config.regionColors.Length < config.tutorial.size || config.patterns.Length < config.tutorial.size) {
                throw new InvalidDataException("Invalid tutorial or palette configuration.");
            }
            if (config.tutorialPlaceIndices == null || config.tutorialPlaceIndices.Length != 3 ||
                config.tutorialPlaceTextTypes == null || config.tutorialPlaceTextTypes.Length != 3 ||
                config.tutorialLineIndices == null || config.tutorialLineIndices.Length == 0 ||
                config.tutorialColors == null || config.tutorialColors.Length < config.tutorial.size) {
                throw new InvalidDataException("Missing original tutorial flow configuration.");
            }
            foreach (int index in config.tutorialPlaceIndices) {
                if (index < 0 || index >= tutorialCells || config.tutorial.solutionColumns[index / config.tutorial.size] != index % config.tutorial.size) {
                    throw new InvalidDataException("Invalid tutorial placement target.");
                }
            }
            foreach (int index in config.tutorialLineIndices) {
                if (index < 0 || index >= tutorialCells || config.tutorial.solutionColumns[index / config.tutorial.size] == index % config.tutorial.size) {
                    throw new InvalidDataException("Invalid tutorial line target.");
                }
            }
            foreach (int index in config.tutorialDragIndices) {
                if (index < 0 || index >= tutorialCells || config.tutorial.solutionColumns[index / config.tutorial.size] == index % config.tutorial.size) {
                    throw new InvalidDataException("Invalid tutorial drag target.");
                }
            }
            puzzles.Add(config.tutorial.id, config.tutorial);
            foreach (var puzzle in config.puzzles) {
                ValidatePuzzle(puzzle);
                if (config.regionColors.Length < puzzle.size || config.patterns.Length < puzzle.size) {
                    throw new InvalidDataException("Game palette or patterns do not cover puzzle size.");
                }
                puzzles.Add(puzzle.id, puzzle);
                if (!sizes.TryGetValue(puzzle.size, out var list)) {
                    list = new List<PuzzleSO>();
                    sizes.Add(puzzle.size, list);
                }
                list.Add(puzzle);
            }
            foreach (int size in config.campaignSizes) {
                if (!sizes.ContainsKey(size)) {
                    throw new InvalidDataException("Missing campaign pool for size " + size);
                }
            }
        }
        public PuzzleSO Get(int id) {
            if (!puzzles.TryGetValue(id, out var puzzle)) {
                throw new InvalidDataException("Unknown saved puzzle " + id);
            }
            return puzzle;
        }
        public PuzzleSO Select(int size, int previousId) {
            var list = sizes[size];
            int start = UnityEngine.Random.Range(0, list.Count);
            for (int i = 0; i < list.Count; i++) {
                var puzzle = list[(start + i) % list.Count];
                if (puzzle.id != previousId || list.Count == 1) {
                    return puzzle;
                }
            }
            throw new InvalidOperationException("No campaign puzzle available.");
        }
        public void ValidatePuzzle(PuzzleSO puzzle) {
            if (puzzle == null || puzzle.id <= 0 || puzzle.size < 4 || puzzle.size > 12 ||
                puzzle.regions == null || puzzle.regions.Length != puzzle.size * puzzle.size ||
                puzzle.solutionColumns == null || puzzle.solutionColumns.Length != puzzle.size || puzzle.preplacedRows == null) {
                throw new InvalidDataException("Invalid puzzle asset.");
            }
            int size = puzzle.size;
            for (int i = 0; i < puzzle.regions.Length; i++) {
                if (puzzle.regions[i] < 0 || puzzle.regions[i] >= size) {
                    throw new InvalidDataException("Invalid region ID.");
                }
            }
            var answer = new CellStatus[size * size];
            for (int row = 0; row < size; row++) {
                int col = puzzle.solutionColumns[row];
                if (col < 0 || col >= size || Conflict(puzzle, answer, row * size + col) != UINameType.None) {
                    throw new InvalidDataException("Invalid puzzle solution.");
                }
                answer[row * size + col] = CellStatus.Hamster;
            }
            var rows = new HashSet<int>();
            foreach (int row in puzzle.preplacedRows) {
                if (row < 0 || row >= size || !rows.Add(row)) {
                    throw new InvalidDataException("Invalid preplaced row.");
                }
            }
        }
        public UINameType Conflict(PuzzleSO puzzle, CellStatus[] cells, int index) {
            int size = puzzle.size;
            int row = index / size;
            int col = index % size;
            for (int i = 0; i < cells.Length; i++) {
                if (i == index || cells[i] != CellStatus.Hamster) {
                    continue;
                }
                if (i / size == row || i % size == col) {
                    return UINameType.Game_ConflictLine;
                }
                if (puzzle.regions[i] == puzzle.regions[index]) {
                    return UINameType.Game_ConflictRegion;
                }
                if (Math.Abs(i / size - row) <= 1 && Math.Abs(i % size - col) <= 1) {
                    return UINameType.Game_ConflictAdjacent;
                }
            }
            return UINameType.None;
        }
        public bool IsComplete(PuzzleSO puzzle, CellStatus[] cells) {
            int count = 0;
            for (int i = 0; i < cells.Length; i++) {
                if (cells[i] == CellStatus.Hamster) {
                    count++;
                    if (Conflict(puzzle, cells, i) != UINameType.None) {
                        return false;
                    }
                }
            }
            return count == puzzle.size;
        }
        public bool IsGiven(PuzzleSO puzzle, int index) {
            foreach (int row in puzzle.preplacedRows) {
                if (index == row * puzzle.size + puzzle.solutionColumns[row]) {
                    return true;
                }
            }
            return false;
        }
        public void ValidateSave(PuzzleSaveModel save, GameConfigSO config, int campaignClears, bool tutorialCompleted) {
            var puzzle = Get(save.puzzleId);
            if (save.isTutorial != (puzzle == config.tutorial) || save.cells == null || save.cells.Length != puzzle.size * puzzle.size ||
                save.hearts < 0 || save.hearts > config.maxHearts || save.mistakes < 0 || save.hints < 0 || save.hints > config.hintsPerLevel ||
                save.guides < 0 || save.guides > config.guidesPerLevel || save.score < 0 || float.IsNaN(save.elapsed) || float.IsInfinity(save.elapsed) || save.elapsed < 0 ||
                save.tutorialStep < 0 || save.tutorialStep > 7 || save.tutorialFlowVersion < 0 || save.tutorialFlowVersion > 1 || save.status < GameStatus.Playing || save.status > GameStatus.Failed) {
                throw new InvalidDataException("Invalid active puzzle progress.");
            }
            if (save.isTutorial) {
                if (save.level != 0 || (tutorialCompleted && save.status != GameStatus.Won)) {
                    throw new InvalidDataException("Tutorial progress conflicts with player progress.");
                }
                if (save.tutorialFlowVersion == 1) {
                    int step = save.tutorialStep;
                    if ((save.status == GameStatus.Won) != (step == 7) ||
                        (step >= 1 && save.cells[config.tutorialPlaceIndices[0]] != CellStatus.Hamster) ||
                        (step >= 3 && step < 6 && !Array.TrueForAll(config.tutorialLineIndices, index => save.cells[index] == CellStatus.Cross)) ||
                        (step >= 4 && save.cells[config.tutorialPlaceIndices[1]] != CellStatus.Hamster) ||
                        (step == 5 && !Array.TrueForAll(config.tutorialDragIndices, index => save.cells[index] == CellStatus.Cross)) ||
                        (step >= 6 && save.cells[config.tutorialPlaceIndices[2]] != CellStatus.Hamster)) {
                        throw new InvalidDataException("Tutorial step conflicts with saved board.");
                    }
                }
            } else if (save.level < 1 || save.level > config.campaignSizes.Length ||
                puzzle.size != config.campaignSizes[save.level - 1] ||
                save.level != campaignClears + (save.status == GameStatus.Won ? 0 : 1)) {
                throw new InvalidDataException("Campaign progress conflicts with active puzzle.");
            }
            for (int i = 0; i < save.cells.Length; i++) {
                if (save.cells[i] < CellStatus.None || save.cells[i] > CellStatus.Hamster ||
                    (save.cells[i] == CellStatus.Hamster && Conflict(puzzle, save.cells, i) != UINameType.None) ||
                    (save.cells[i] == CellStatus.Hamster && puzzle.solutionColumns[i / puzzle.size] != i % puzzle.size) ||
                    (IsGiven(puzzle, i) && save.cells[i] != CellStatus.Hamster)) {
                    throw new InvalidDataException("Invalid saved cell state.");
                }
            }
            bool complete = IsComplete(puzzle, save.cells);
            if ((save.status == GameStatus.Won) != complete || (save.status == GameStatus.Failed) != (save.hearts == 0)) {
                throw new InvalidDataException("Invalid saved game status.");
            }
        }
    }
}
