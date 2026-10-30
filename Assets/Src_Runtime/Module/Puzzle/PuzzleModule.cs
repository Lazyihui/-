using System;
using System.Collections.Generic;
using System.IO;
namespace Hamdoku {
    public sealed class PuzzleModule {
        readonly Dictionary<int, PuzzleSO> puzzles = new Dictionary<int, PuzzleSO>();
        readonly Dictionary<int, List<PuzzleSO>> pools = new Dictionary<int, List<PuzzleSO>>();
        readonly Dictionary<int, PuzzleSO> fixedPuzzles = new Dictionary<int, PuzzleSO>();
        public void Initialize(PuzzleRulesSO config, CampaignConfigSO campaignConfig, PuzzlePresentationSO presentation, IReadOnlyList<PuzzleSO> allPuzzles) {
            if (config == null || campaignConfig == null || presentation == null || allPuzzles == null || campaignConfig.campaignSizes == null || campaignConfig.campaignSizes.Length == 0 || config.maxHearts <= 0 ||
                config.doubleTapSeconds <= 0 || config.dragThreshold <= 0 || config.hintsPerLevel < 0 || config.guidesPerLevel < 0 ||
                presentation.placeClip == null || presentation.markClip == null || presentation.mistakeClip == null || presentation.clearClip == null) {
                throw new InvalidDataException("Invalid puzzle rules, campaign or presentation configuration.");
            }
            puzzles.Clear();
            foreach (var puzzle in allPuzzles) {
                ValidatePuzzle(puzzle);
                puzzles.Add(puzzle.id, puzzle);
            }
            float[] tutorialDurations = { config.tutorialCrossSettleSeconds, config.tutorialIdleHintSeconds,
                presentation.tutorialCardFadeSeconds, presentation.tutorialDimFadeSeconds, presentation.tutorialFingerPressSeconds,
                presentation.tutorialFingerReleaseSeconds, presentation.tutorialFingerRestSeconds, presentation.tutorialFingerDragSeconds,
                presentation.tutorialRippleSeconds, presentation.tutorialMarkSeconds, presentation.tutorialPlaceSeconds, presentation.tutorialCelebrateSeconds };
            foreach (float duration in tutorialDurations) {
                if (float.IsNaN(duration) || float.IsInfinity(duration) || duration <= 0) {
                    throw new InvalidDataException("Invalid tutorial animation duration.");
                }
            }
            if (float.IsNaN(presentation.tutorialHandScale) || float.IsInfinity(presentation.tutorialHandScale) || presentation.tutorialHandScale <= 0 ||
                float.IsNaN(presentation.tutorialRippleFrom) || presentation.tutorialRippleFrom <= 0 ||
                float.IsNaN(presentation.tutorialRippleTo) || float.IsInfinity(presentation.tutorialRippleTo) || presentation.tutorialRippleTo <= presentation.tutorialRippleFrom ||
                float.IsNaN(presentation.tutorialRippleAlpha) || presentation.tutorialRippleAlpha <= 0 || presentation.tutorialRippleAlpha > 1) {
                throw new InvalidDataException("Invalid tutorial finger configuration.");
            }
            float[] flowDurations = { presentation.clearAutoCrossDelay, presentation.clearAutoCrossSweepStep,
                presentation.clearAutoCrossHold, presentation.clearCelebrationDelay, presentation.resultDelay, presentation.clearGlowSeconds,
                presentation.gainSeconds, presentation.comboSeconds, presentation.comboFontSize, presentation.comboRiseRatio };
            foreach (float duration in flowDurations) {
                if (float.IsNaN(duration) || float.IsInfinity(duration) || duration <= 0) {
                    throw new InvalidDataException("Invalid main game flow configuration.");
                }
            }
            if (config.startRevealLevels < 0 || config.clearAutoCrossLevels < 0 || config.scoreBase <= 0 || config.scoreStep < 0) {
                throw new InvalidDataException("Invalid reveal or scoring configuration.");
            }
            ValidateCampaignConfig(campaignConfig);
            pools.Clear();
            fixedPuzzles.Clear();
            var tutorial = Get(config.tutorialPuzzleId);
            ValidatePuzzle(tutorial);
            int tutorialCells = tutorial.size * tutorial.size;
            if (config.tutorialPlaceIndex < 0 || config.tutorialPlaceIndex >= tutorialCells ||
                config.tutorialTapIndex < 0 || config.tutorialTapIndex >= tutorialCells || config.tutorialDragIndices == null ||
                config.tutorialDragIndices.Length == 0 || tutorial.solutionColumns[config.tutorialPlaceIndex / tutorial.size] != config.tutorialPlaceIndex % tutorial.size ||
                presentation.regionColors == null || presentation.patterns == null || presentation.regionColors.Length < tutorial.size || presentation.patterns.Length < tutorial.size) {
                throw new InvalidDataException("Invalid tutorial or palette configuration.");
            }
            if (config.tutorialPlaceIndices == null || config.tutorialPlaceIndices.Length != 3 ||
                presentation.tutorialPlaceTextTypes == null || presentation.tutorialPlaceTextTypes.Length != 3 ||
                config.tutorialLineIndices == null || config.tutorialLineIndices.Length == 0 ||
                presentation.tutorialColors == null || presentation.tutorialColors.Length < tutorial.size) {
                throw new InvalidDataException("Missing original tutorial flow configuration.");
            }
            foreach (int index in config.tutorialPlaceIndices) {
                if (index < 0 || index >= tutorialCells || tutorial.solutionColumns[index / tutorial.size] != index % tutorial.size) {
                    throw new InvalidDataException("Invalid tutorial placement target.");
                }
            }
            foreach (int index in config.tutorialLineIndices) {
                if (index < 0 || index >= tutorialCells || tutorial.solutionColumns[index / tutorial.size] == index % tutorial.size) {
                    throw new InvalidDataException("Invalid tutorial line target.");
                }
            }
            foreach (int index in config.tutorialDragIndices) {
                if (index < 0 || index >= tutorialCells || tutorial.solutionColumns[index / tutorial.size] == index % tutorial.size) {
                    throw new InvalidDataException("Invalid tutorial drag target.");
                }
            }
            var campaignIds = new HashSet<int>();
            foreach (int puzzleId in campaignConfig.puzzleIds) {
                if (!campaignIds.Add(puzzleId)) {
                    throw new InvalidDataException("Duplicate campaign puzzle ID: " + puzzleId);
                }
                var puzzle = Get(puzzleId);
                ValidatePuzzle(puzzle);
                if (presentation.regionColors.Length < puzzle.size || presentation.patterns.Length < puzzle.size) {
                    throw new InvalidDataException("Game palette or patterns do not cover puzzle size.");
                }
                if (puzzle.grade < 1 || puzzle.grade > (6) || puzzle.identityId <= 0 || puzzle.fixedLevel < 0 || puzzle.fixedLevel > campaignConfig.campaignSizes.Length) {
                    throw new InvalidDataException("Invalid campaign map metadata: " + puzzle.id);
                }
                if (puzzle.fixedLevel > 0) {
                    if (Array.IndexOf(campaignConfig.campaignFixedLevels, puzzle.fixedLevel) < 0 || puzzle.size != campaignConfig.campaignSizes[puzzle.fixedLevel - 1]) {
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
            for (int key = 0; key < campaignConfig.campaignCursorSlots; key++) {
                if (pools.TryGetValue(key, out var pool)) {
                    pool.Sort((left, right) => left.id.CompareTo(right.id));
                }
            }
            for (int level = 1; level <= campaignConfig.campaignSizes.Length; level++) {
                if (Array.IndexOf(campaignConfig.campaignFixedLevels, level) >= 0) {
                    if (!fixedPuzzles.ContainsKey(level)) {
                        throw new InvalidDataException("Missing original fixed campaign map: " + level);
                    }
                    continue;
                }
                int maximum = level >= campaignConfig.campaignExpertStartLevel && level % campaignConfig.campaignHardInterval == 0 ? campaignConfig.campaignExpertGrade :
                    level >= campaignConfig.campaignHardStartLevel && level % campaignConfig.campaignHardInterval == 0 ? campaignConfig.campaignHardGrade : campaignConfig.campaignGradeCeilings[level - 1];
                for (int grade = 1; grade <= maximum; grade++) {
                    int key = CampaignSize(campaignConfig, level, grade) * 10 + grade;
                    if (!pools.TryGetValue(key, out var list)) {
                        throw new InvalidDataException("Missing campaign pool " + key);
                    }
                    // Source entry IDs preserve the bank order independently of SO reference order.
                    list.Sort((left, right) => left.id.CompareTo(right.id));
                }
            }
        }

        void ValidateCampaignConfig(CampaignConfigSO config) {
            int count = config.campaignSizes.Length;
            if (count > 300 || config.puzzleIds == null || config.puzzleIds.Length == 0 || config.campaignGradeCeilings == null || config.campaignGradeCeilings.Length != count ||
                config.campaignSkillCeilings == null || config.campaignSkillCeilings.Length != count ||
                config.campaignFixedLevels == null || config.campaignRewardStep <= 0 || config.campaignRewardHints < 0 ||
                config.campaignRewardGuides < 0 || (config.campaignRewardHints == 0 && config.campaignRewardGuides == 0) ||
                config.campaignInitialSkill != 1 || config.campaignAdaptiveStartLevel != 6 ||
                config.campaignCleanClearsToPromote <= 0 || config.campaignLaterPromotionStartLevel < 1 ||
                config.campaignLaterCleanClearsToPromote <= 0 || config.campaignTransformStartLevel < 1 || config.campaignFailureThreshold <= 0 ||
                config.campaignReliefStartLevel < 1 || config.campaignLaterFailureThreshold <= 0 ||
                config.campaignHistoryLimit <= 0 || config.campaignCursorSlots < 123 || config.campaignExpertSizes == null || config.campaignExpertSizes.Length != count ||
                config.campaignExpertGrade != 6 || config.campaignHardGrade != 5 || config.campaignHardInterval <= 0 ||
                config.campaignHardStartLevel < 1 || config.campaignExpertStartLevel < 1 || config.campaignMinimumSkillStartLevel < 1 || config.campaignLaterMinimumSkill != 2) {
                throw new InvalidDataException("Invalid campaign configuration.");
            }
            for (int i = 0; i < count; i++) {
                if (config.campaignGradeCeilings[i] < 1 || config.campaignGradeCeilings[i] > 4 ||
                    config.campaignSkillCeilings[i] < config.campaignGradeCeilings[i] || config.campaignSkillCeilings[i] > 6) {
                    throw new InvalidDataException("Unsupported campaign grade configuration.");
                }
            }
            int previousFixed = 0;
            foreach (int level in config.campaignFixedLevels) {
                if (level <= previousFixed || level > count) {
                    throw new InvalidDataException("Fixed campaign levels must be unique, sorted and in range.");
                }
                previousFixed = level;
            }
        }
        public void RegisterDaily(DailyConfigSO config) {
            if (config == null || config.dayToPuzzle == null || config.seasons == null || config.seasons.Length == 0) {
                throw new InvalidDataException("Missing daily configuration.");
            }
            foreach (int id in config.dayToPuzzle) {
                Get(id);
            }
        }
        public PuzzleSO Get(int id) {
            if (!puzzles.TryGetValue(id, out var puzzle)) {
                throw new InvalidDataException("Unknown saved puzzle " + id);
            }
            return puzzle;
        }
        public PuzzleBoardModel Materialize(int id, int transform) {
            if (transform < 0 || transform > 7) {
                throw new InvalidDataException("Invalid board transform.");
            }
            var source = Get(id);
            int n = source.size;
            var board = new PuzzleBoardModel {
                id = id, size = n, grade = source.grade, fixedLevel = source.fixedLevel,
                identityId = source.identityId, transform = transform,
                regions = new int[n * n], solutionColumns = new int[n],
                preplacedRows = new int[source.preplacedRows.Length]
            };
            for (int row = 0; row < n; row++) {
                for (int col = 0; col < n; col++) {
                    int target = TransformIndex(n, transform, row * n + col);
                    board.regions[target] = source.regions[row * n + col];
                }
                int answer = TransformIndex(n, transform, row * n + source.solutionColumns[row]);
                board.solutionColumns[answer / n] = answer % n;
            }
            for (int i = 0; i < source.preplacedRows.Length; i++) {
                int row = source.preplacedRows[i];
                int target = TransformIndex(n, transform, row * n + source.solutionColumns[row]);
                board.preplacedRows[i] = target / n;
            }
            return board;
        }

        static int TransformIndex(int size, int transform, int index) {
            int row = index / size;
            int col = index % size;
            if (transform > 3) {
                col = size - 1 - col;
            }
            for (int i = 0; i < (transform & 3); i++) {
                int previousRow = row;
                row = col;
                col = size - 1 - previousRow;
            }
            return row * size + col;
        }

        public static int CampaignSize(CampaignConfigSO config, int level, int grade) {
            return grade == config.campaignExpertGrade ? config.campaignExpertSizes[level - 1] : config.campaignSizes[level - 1];
        }
        public static int CampaignMaximumGrade(CampaignConfigSO config, int level) {
            bool hard = level >= config.campaignHardStartLevel && level % config.campaignHardInterval == 0;
            return hard ? level >= config.campaignExpertStartLevel ? config.campaignExpertGrade : config.campaignHardGrade : config.campaignGradeCeilings[level - 1];
        }
        public CampaignSelectionModel SelectCampaign(CampaignConfigSO config, CampaignSaveModel campaign, int level, int grade) {
            if (level < 1 || level > config.campaignSizes.Length || grade < 1 || grade > CampaignMaximumGrade(config, level)) {
                throw new InvalidDataException("Unsupported campaign selection.");
            }
            if (fixedPuzzles.TryGetValue(level, out var fixedPuzzle)) {
                return new CampaignSelectionModel { puzzle = fixedPuzzle };
            }
            int key = CampaignSize(config, level, grade) * 10 + grade;
            var list = pools[key];
            int position = campaign.cursorPositions[key];
            var recent = new HashSet<int>();
            foreach (int id in campaign.recentPuzzleIds) {
                recent.Add(Get(id).identityId);
            }
            PuzzleSO selected = null;
            // Original Assign scans one bank cycle at most, accepting the last map if all are recent.
            // The source assigns the current cycle before advancing it when the chosen map ends a pool.
            for (int i = 0; i < list.Count; i++) {
                selected = list[position];
                position = (position + 1) % list.Count;
                if (!recent.Contains(selected.identityId)) {
                    break;
                }
            }
            int cycle = campaign.cursorCycles[key];
            int transform = level >= config.campaignTransformStartLevel ? cycle : 0;
            int nextCycle = level >= config.campaignTransformStartLevel && position == 0 ? (cycle + 1) % 8 : cycle;
            return new CampaignSelectionModel {
                puzzle = selected, poolKey = key, nextPosition = position, transform = transform, nextCycle = nextCycle
            };
        }

        public void ValidateCampaign(CampaignSaveModel campaign, CampaignConfigSO config, int tutorialId, int clears) {
            SaveModule.ValidateCampaign(campaign);
            SaveModule.ValidateCampaignCycles(campaign);
            if (clears < 0 || clears > config.campaignSizes.Length || campaign.skill > config.campaignSkillCeilings[config.campaignSkillCeilings.Length - 1] ||
                campaign.cursorPositions.Length != config.campaignCursorSlots || campaign.previousLevel < 0 || campaign.previousLevel > clears ||
                // A zero skill is the unset value when no previous difficulty record exists.
                campaign.previousRecordedSkill < 0 || (campaign.previousRecordedSkill == 0 && (campaign.previousLevel > 0 || campaign.previousRetried)) ||
                campaign.previousRecordedSkill > config.campaignSkillCeilings[config.campaignSkillCeilings.Length - 1] ||
                campaign.recentPuzzleIds.Count > config.campaignHistoryLimit || campaign.claimedRewardLevel > clears ||
                campaign.claimedRewardLevel % config.campaignRewardStep != 0) {
                throw new InvalidDataException("Campaign selection state conflicts with its configuration.");
            }
            for (int key = 0; key < campaign.cursorPositions.Length; key++) {
                int position = campaign.cursorPositions[key];
                if (position < 0 || (pools.TryGetValue(key, out var list) ? position >= list.Count : position != 0 || campaign.cursorCycles[key] != 0)) {
                    throw new InvalidDataException("Invalid saved campaign cursor: " + key);
                }
            }
            foreach (int id in campaign.recentPuzzleIds) {
                if (id == tutorialId) {
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
                if (col < 0 || col >= size || Conflict(puzzle.size, puzzle.regions, answer, row * size + col) != UINameType.None) {
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
        public UINameType Conflict(PuzzleBoardModel puzzle, CellStatus[] cells, int index) {
            return Conflict(puzzle.size, puzzle.regions, cells, index);
        }
        static UINameType Conflict(int size, int[] regions, CellStatus[] cells, int index) {
            int row = index / size;
            int col = index % size;
            for (int i = 0; i < cells.Length; i++) {
                if (i == index || cells[i] != CellStatus.Hamster) {
                    continue;
                }
                if (i / size == row || i % size == col) {
                    return UINameType.Game_ConflictLine;
                }
                if (regions[i] == regions[index]) {
                    return UINameType.Game_ConflictRegion;
                }
                if (Math.Abs(i / size - row) <= 1 && Math.Abs(i % size - col) <= 1) {
                    return UINameType.Game_ConflictAdjacent;
                }
            }
            return UINameType.None;
        }
        public bool IsComplete(PuzzleBoardModel puzzle, CellStatus[] cells) {
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
        public bool IsGiven(PuzzleBoardModel puzzle, int index) {
            foreach (int row in puzzle.preplacedRows) {
                if (index == row * puzzle.size + puzzle.solutionColumns[row]) {
                    return true;
                }
            }
            return false;
        }
        public void ValidateSave(PuzzleSaveModel save, PuzzleRulesSO config, CampaignConfigSO campaignConfig, int campaignClears, bool tutorialCompleted) {
            var source = Get(save.puzzleId);
            if (save.campaignTransform < 0 || save.campaignTransform > 7 ||
                ((save.isTutorial || save.dailyDay > 0 || save.level < campaignConfig.campaignTransformStartLevel || source.fixedLevel > 0) && save.campaignTransform != 0)) {
                throw new InvalidDataException("Saved board transform conflicts with its assignment.");
            }
            var puzzle = Materialize(save.puzzleId, save.campaignTransform);
            if (save.isTutorial != (puzzle.id == config.tutorialPuzzleId) || save.cells == null || save.cells.Length != puzzle.size * puzzle.size ||
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
            } else if (save.dailyDay == 0 && (save.level < 1 || save.level > campaignConfig.campaignSizes.Length ||
                puzzle.size != (puzzle.fixedLevel > 0 ? campaignConfig.campaignSizes[save.level - 1] : CampaignSize(campaignConfig, save.level, puzzle.grade)) ||
                save.level != campaignClears + (save.status == GameStatus.Won ? 0 : 1))) {
                throw new InvalidDataException("Campaign progress conflicts with active puzzle.");
            }
            if (!save.isTutorial && save.dailyDay == 0) {
                if (save.campaignSelectionVersion < 0 || save.campaignSelectionVersion > 1 || save.campaignFailures < 0 ||
                    (save.status == GameStatus.Failed && save.campaignSelectionVersion == 1 && save.campaignFailures == 0) ||
                    (save.campaignSelectionVersion == 0 && (save.level >= campaignConfig.campaignAdaptiveStartLevel || puzzle.grade != 1 || puzzle.fixedLevel != 0)) ||
                    (save.campaignSelectionVersion == 1 && (save.campaignGrade != puzzle.grade ||
                    (puzzle.fixedLevel > 0 ? puzzle.fixedLevel != save.level : Array.IndexOf(campaignConfig.campaignFixedLevels, save.level) >= 0 ||
                    puzzle.grade > CampaignMaximumGrade(campaignConfig, save.level))))) {
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
        static void ValidateFlowSave(PuzzleSaveModel save, PuzzleBoardModel puzzle, PuzzleRulesSO config) {
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
