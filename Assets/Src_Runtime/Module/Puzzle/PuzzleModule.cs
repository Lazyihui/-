using System;
using System.Collections.Generic;
using System.IO;
namespace Hamdoku {
    public sealed class PuzzleModule {
        readonly Dictionary<int, PuzzleSO> puzzles = new Dictionary<int, PuzzleSO>();
        readonly Dictionary<int, List<PuzzleSO>> pools = new Dictionary<int, List<PuzzleSO>>();
        readonly Dictionary<int, PuzzleSO> fixedPuzzles = new Dictionary<int, PuzzleSO>();
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
            float[] flowDurations = { config.clearAutoCrossDelay, config.clearAutoCrossSweepStep,
                config.clearAutoCrossHold, config.clearCelebrationDelay, config.resultDelay, config.clearGlowSeconds,
                config.gainSeconds, config.comboSeconds, config.comboFontSize, config.comboRiseRatio };
            foreach (float duration in flowDurations) {
                if (float.IsNaN(duration) || float.IsInfinity(duration) || duration <= 0) {
                    throw new InvalidDataException("Invalid main game flow configuration.");
                }
            }
            if (config.startRevealLevels < 0 || config.clearAutoCrossLevels < 0 || config.scoreBase <= 0 || config.scoreStep < 0) {
                throw new InvalidDataException("Invalid reveal or scoring configuration.");
            }
            ValidateCampaignConfig(config);
            pools.Clear();
            fixedPuzzles.Clear();
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
                if (puzzle.grade < 1 || puzzle.grade > 2 || puzzle.identityId <= 0 || puzzle.fixedLevel < 0 || puzzle.fixedLevel > config.campaignSizes.Length) {
                    throw new InvalidDataException("Invalid campaign map metadata: " + puzzle.id);
                }
                if (puzzle.fixedLevel > 0) {
                    if (puzzle.size != config.campaignSizes[puzzle.fixedLevel - 1]) {
                        throw new InvalidDataException("Fixed map size does not match campaign configuration.");
                    }
                    fixedPuzzles.Add(puzzle.fixedLevel, puzzle);
                    continue;
                }
                int key = puzzle.size * 10 + puzzle.grade;
                if (!pools.TryGetValue(key, out var list)) {
                    list = new List<PuzzleSO>();
                    pools.Add(key, list);
                }
                list.Add(puzzle);
            }
            for (int level = 1; level <= config.campaignSizes.Length; level++) {
                if (level == 10 || level == 20) {
                    if (!fixedPuzzles.ContainsKey(level)) {
                        throw new InvalidDataException("Missing original fixed campaign map: " + level);
                    }
                    continue;
                }
                for (int grade = 1; grade <= config.campaignGradeCeilings[level - 1]; grade++) {
                    int key = config.campaignSizes[level - 1] * 10 + grade;
                    if (!pools.TryGetValue(key, out var list)) {
                        throw new InvalidDataException("Missing campaign pool " + key);
                    }
                    // Source entry IDs preserve the bank order independently of SO reference order.
                    list.Sort((left, right) => left.id.CompareTo(right.id));
                }
            }
        }

        void ValidateCampaignConfig(GameConfigSO config) {
            int count = config.campaignSizes.Length;
            if (count > 20 || config.campaignGradeCeilings == null || config.campaignGradeCeilings.Length != count ||
                config.campaignSkillCeilings == null || config.campaignSkillCeilings.Length != count ||
                config.campaignInitialSkill != 1 || config.campaignAdaptiveStartLevel != 6 ||
                config.campaignCleanClearsToPromote <= 0 || config.campaignFailureThreshold <= 0 ||
                config.campaignHistoryLimit <= 0 || config.campaignCursorSlots < 103) {
                throw new InvalidDataException("Invalid first-twenty campaign configuration.");
            }
            for (int i = 0; i < count; i++) {
                if (config.campaignGradeCeilings[i] < 1 || config.campaignGradeCeilings[i] > 2 ||
                    config.campaignSkillCeilings[i] < config.campaignGradeCeilings[i] || config.campaignSkillCeilings[i] > 2) {
                    throw new InvalidDataException("Unsupported campaign grade configuration.");
                }
            }
        }
        public void RegisterDaily(DailyConfigSO config) {
            if (config == null || config.puzzles == null || config.dayToPuzzle == null || config.seasons == null || config.seasons.Length == 0) {
                throw new InvalidDataException("Missing daily configuration.");
            }
            foreach (var puzzle in config.puzzles) {
                ValidatePuzzle(puzzle);
                puzzles.Add(puzzle.id, puzzle);
            }
            foreach (int index in config.dayToPuzzle) {
                if (index < 1 || index > config.puzzles.Length) {
                    throw new InvalidDataException("Invalid original daily map assignment.");
                }
            }
        }
        public PuzzleSO Get(int id) {
            if (!puzzles.TryGetValue(id, out var puzzle)) {
                throw new InvalidDataException("Unknown saved puzzle " + id);
            }
            return puzzle;
        }
        public CampaignSelectionModel SelectCampaign(GameConfigSO config, CampaignSaveModel campaign, int level, int grade) {
            if (level < 1 || level > config.campaignSizes.Length || grade < 1 || grade > config.campaignGradeCeilings[level - 1]) {
                throw new InvalidDataException("Unsupported campaign selection.");
            }
            if (fixedPuzzles.TryGetValue(level, out var fixedPuzzle)) {
                return new CampaignSelectionModel { puzzle = fixedPuzzle };
            }
            int key = config.campaignSizes[level - 1] * 10 + grade;
            var list = pools[key];
            int position = campaign.cursorPositions[key];
            var recent = new HashSet<int>();
            foreach (int id in campaign.recentPuzzleIds) {
                recent.Add(Get(id).identityId);
            }
            PuzzleSO selected = null;
            // Original Assign scans one bank cycle at most, accepting the last map if all are recent.
            // Transform stays zero before level 51; rotating early maps would change original behavior.
            for (int i = 0; i < list.Count; i++) {
                selected = list[position];
                position = (position + 1) % list.Count;
                if (!recent.Contains(selected.identityId)) {
                    break;
                }
            }
            return new CampaignSelectionModel { puzzle = selected, poolKey = key, nextPosition = position };
        }

        public void ValidateCampaign(CampaignSaveModel campaign, GameConfigSO config, int clears) {
            SaveModule.ValidateCampaign(campaign);
            if (clears < 0 || clears > config.campaignSizes.Length || campaign.skill > config.campaignSkillCeilings[config.campaignSkillCeilings.Length - 1] ||
                campaign.cleanStreak >= config.campaignCleanClearsToPromote || campaign.cursorPositions.Length != config.campaignCursorSlots ||
                campaign.recentPuzzleIds.Count > config.campaignHistoryLimit) {
                throw new InvalidDataException("Campaign selection state conflicts with its configuration.");
            }
            for (int key = 0; key < campaign.cursorPositions.Length; key++) {
                int position = campaign.cursorPositions[key];
                if (position < 0 || (pools.TryGetValue(key, out var list) ? position >= list.Count : position != 0)) {
                    throw new InvalidDataException("Invalid saved campaign cursor: " + key);
                }
            }
            foreach (int id in campaign.recentPuzzleIds) {
                if (Get(id) == config.tutorial) {
                    throw new InvalidDataException("Tutorial map cannot appear in campaign history.");
                }
            }
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
            } else if (save.dailyDay == 0 && (save.level < 1 || save.level > config.campaignSizes.Length ||
                puzzle.size != config.campaignSizes[save.level - 1] ||
                save.level != campaignClears + (save.status == GameStatus.Won ? 0 : 1))) {
                throw new InvalidDataException("Campaign progress conflicts with active puzzle.");
            }
            if (!save.isTutorial && save.dailyDay == 0) {
                if (save.campaignSelectionVersion < 0 || save.campaignSelectionVersion > 1 || save.campaignFailures < 0 ||
                    (save.status == GameStatus.Failed && save.campaignSelectionVersion == 1 && save.campaignFailures == 0) ||
                    (save.campaignSelectionVersion == 0 && (save.level >= config.campaignAdaptiveStartLevel || puzzle.grade != 1 || puzzle.fixedLevel != 0)) ||
                    (save.campaignSelectionVersion == 1 && (save.campaignGrade != puzzle.grade ||
                    (puzzle.fixedLevel > 0 ? puzzle.fixedLevel != save.level : save.level == 10 || save.level == 20 ||
                    puzzle.grade > config.campaignGradeCeilings[save.level - 1])))) {
                    throw new InvalidDataException("Saved campaign assignment conflicts with its map.");
                }
            }
            for (int i = 0; i < save.cells.Length; i++) {
                if (save.cells[i] < CellStatus.None || save.cells[i] > CellStatus.Hamster ||
                    (save.cells[i] == CellStatus.Hamster && Conflict(puzzle, save.cells, i) != UINameType.None) ||
                    (save.cells[i] == CellStatus.Hamster && puzzle.solutionColumns[i / puzzle.size] != i % puzzle.size) ||
                    (IsGiven(puzzle, i) && save.cells[i] != CellStatus.Hamster)) {
                    throw new InvalidDataException("Invalid saved cell state.");
                }
            }
            ValidateFlowSave(save, puzzle, config);
            bool complete = IsComplete(puzzle, save.cells);
            if ((save.status == GameStatus.Won) != complete || (save.status == GameStatus.Failed) != (save.hearts == 0)) {
                throw new InvalidDataException("Invalid saved game status.");
            }
        }
        static void ValidateFlowSave(PuzzleSaveModel save, PuzzleSO puzzle, GameConfigSO config) {
            if (save.flowVersion != 1 || save.initialIndices == null || save.cellGains == null ||
                save.cellGains.Length != save.cells.Length || save.scoreCarry < 0 || save.combo < 0 ||
                save.combo > save.bestCombo || save.bestCombo > puzzle.size ||
                (save.clearPending && (save.isTutorial || save.status != GameStatus.Won)) ||
                (save.clearCrossApplied && (save.isTutorial || save.status != GameStatus.Won)) ||
                (save.clearSweepNeeded && (save.isTutorial || save.status != GameStatus.Won))) {
                throw new InvalidDataException("Invalid saved game flow.");
            }
            if (save.dailyDay == 0 && save.clearCrossApplied && save.level <= config.clearAutoCrossLevels && Array.IndexOf(save.cells, CellStatus.None) >= 0) {
                throw new InvalidDataException("Saved clear crosses are incomplete.");
            }
            long total = save.scoreCarry;
            int placed = 0;
            for (int i = 0; i < save.cellGains.Length; i++) {
                int gain = save.cellGains[i];
                if (save.cells[i] == CellStatus.Hamster) {
                    placed++;
                }
                if (gain < 0 || (gain > 0 && (save.isTutorial || save.cells[i] != CellStatus.Hamster ||
                    gain < config.scoreBase || (config.scoreStep > 0 && (gain - config.scoreBase) % config.scoreStep != 0) ||
                    (long)gain > config.scoreBase + (long)config.scoreStep * (puzzle.size - 1)))) {
                    throw new InvalidDataException("Invalid saved cell gain.");
                }
                total += gain;
            }
            if (total != save.score || save.bestCombo > placed) {
                throw new InvalidDataException("Saved score does not match the cell ledger.");
            }
            for (int i = 0; i < save.initialIndices.Length; i++) {
                int index = save.initialIndices[i];
                if (save.isTutorial || index < 0 || index >= save.cells.Length || save.cells[index] != CellStatus.Hamster ||
                    save.cellGains[index] != config.scoreBase || Array.IndexOf(save.initialIndices, index) != i) {
                    throw new InvalidDataException("Invalid saved opening reveal.");
                }
            }
            if (save.initialIndices.Length > 0 && save.combo > placed - save.initialIndices.Length) {
                throw new InvalidDataException("Opening reveal cannot contribute to combo.");
            }
        }
    }
}
