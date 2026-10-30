using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using UnityEditor;
using UnityEditor.AddressableAssets;
using UnityEngine;

namespace Hamdoku.Editor {
    public static class PuzzleImportEM {
        [MenuItem("Hamdoku/Puzzle Import/1 Preview Migration")]
        public static void Preview() {
            Run(PuzzleImportConst.SourceRoot, "preview");
        }

        [MenuItem("Hamdoku/Puzzle Import/2 Execute Migration")]
        public static void Execute() {
            Run(PuzzleImportConst.SourceRoot, "execute");
        }

        [MenuItem("Hamdoku/Puzzle Import/3 Validate Migration")]
        public static void Validate() {
            Run(PuzzleImportConst.SourceRoot, "validate");
        }

        public static PuzzleImportReportModel Run(string sourceRoot, string operation) {
            if (operation != "preview" && operation != "execute" && operation != "validate") {
                throw new ArgumentOutOfRangeException(nameof(operation));
            }
            var report = new PuzzleImportReportModel {
                operation = operation, sourceRoot = Path.GetFullPath(sourceRoot),
                timestampUtc = DateTime.UtcNow.ToString("O", CultureInfo.InvariantCulture)
            };
            var entries = new List<PuzzleImportEntryModel>();
            try {
                var dailySchedule = new List<int>();
                int firstDay = ReadSources(report, entries, dailySchedule);
                var campaign = AssetDatabase.LoadAssetAtPath<CampaignConfigSO>("Assets/Res_Runtime/Config/CampaignConfig.asset");
                var daily = AssetDatabase.LoadAssetAtPath<DailyConfigSO>("Assets/Res_Runtime/Config/DailyConfig.asset");
                var rules = AssetDatabase.LoadAssetAtPath<PuzzleRulesSO>("Assets/Res_Runtime/Config/PuzzleRules.asset");
                if (campaign == null || daily == null || rules == null || AddressableAssetSettingsDefaultObject.Settings == null) {
                    report.missing.Add("Formal campaign, daily, puzzle rules or Addressables configuration.");
                }
                var activeIds = campaign == null ? Array.Empty<int>() : ActiveCampaignIds(campaign, entries, report);
                if (daily != null && (daily.firstDay != firstDay || !daily.dayToPuzzle.SequenceEqual(dailySchedule))) {
                    report.configurationChanges.Add("Daily firstDay / date-to-map ID schedule.");
                }
                if (rules != null && rules.tutorialPuzzleId != 1) {
                    report.configurationChanges.Add("Tutorial puzzle ID must reference source tutorial 1.");
                }
                InspectAssets(entries, report);
                InspectConfiguration(report);
                InspectSourceChanges(report);
                bool blocked = report.conflicts.Count > 0 || report.missing.Count > 0;
                if (operation == "execute" && !blocked) {
                    CheckInputsStillMatch(report, entries);
                    string backup = Backup(report, entries);
                    Apply(entries);
                    if (!campaign.puzzleIds.SequenceEqual(activeIds)) {
                        campaign.puzzleIds = activeIds;
                        EditorUtility.SetDirty(campaign);
                    }
                    if (daily.firstDay != firstDay || !daily.dayToPuzzle.SequenceEqual(dailySchedule)) {
                        daily.firstDay = firstDay;
                        daily.dayToPuzzle = dailySchedule.ToArray();
                        EditorUtility.SetDirty(daily);
                    }
                    if (rules.tutorialPuzzleId != 1) {
                        rules.tutorialPuzzleId = 1;
                        EditorUtility.SetDirty(rules);
                    }
                    AssetDatabase.SaveAssets();
                    PuzzleConfigSetupEM.Register();
                    report.observations.Add("Before-write backup: " + backup);
                    var verification = Run(sourceRoot, "validate");
                    if (!verification.succeeded) {
                        throw new InvalidDataException("Post-import validation failed. See validate.json and the before-write backup.");
                    }
                    report.succeeded = true;
                    WriteReport(report, "receipt");
                } else {
                    report.succeeded = !blocked && (operation == "preview" ||
                        (report.added.Count == 0 && report.updated.Count == 0 && report.configurationChanges.Count == 0));
                }
            } catch (Exception error) {
                report.succeeded = false;
                report.conflicts.Add(error.GetType().Name + ": " + error.Message);
            } finally {
                EditorUtility.ClearProgressBar();
                WriteReport(report, operation);
            }
            string summary = string.Format("[PuzzleImport] {0}: success={1}; source maps={2}; added={3}, updated={4}, unchanged={5}, conflicts={6}, missing={7}. Report: {8}/{0}.json",
                operation, report.succeeded, entries.Count, report.added.Count, report.updated.Count, report.unchanged.Count,
                report.conflicts.Count, report.missing.Count, PuzzleImportConst.ReportRoot);
            Debug.Log(summary);
            return report;
        }

        static int ReadSources(PuzzleImportReportModel report, List<PuzzleImportEntryModel> entries, List<int> dailySchedule) {
            string binaryPath = "05_data/TextAsset_raw/CampaignDdaMaps__resources.assets__696.bin";
            string full = SourcePath(report, binaryPath);
            RecordSource(report, binaryPath);
            var identities = new Dictionary<string, int>();
            using (var reader = new BinaryReader(File.OpenRead(full))) {
                if (Encoding.ASCII.GetString(reader.ReadBytes(4)) != "HDDA" || reader.ReadByte() != 1) {
                    throw new InvalidDataException("Unsupported original DDA bank header/version.");
                }
                int count = reader.ReadInt32();
                if (count <= 0 || count > 100000) {
                    throw new InvalidDataException("Invalid original DDA record count.");
                }
                var fixedLevels = new HashSet<int>();
                for (int i = 0; i < count; i++) {
                    int fixedLevel = reader.ReadInt32();
                    int size = reader.ReadByte();
                    int grade = reader.ReadByte();
                    byte[] identity = reader.ReadBytes(8);
                    if (identity.Length != 8 || size < 4 || size > 12 || grade < 1 || grade > 6 || fixedLevel < -1 ||
                        (fixedLevel > 0 && !fixedLevels.Add(fixedLevel))) {
                        throw new InvalidDataException("Invalid DDA metadata at entry " + i);
                    }
                    string hex = BitConverter.ToString(identity).Replace("-", string.Empty).ToLowerInvariant();
                    int id = PuzzleImportConst.CampaignIdOffset + i;
                    if (!identities.TryGetValue(hex, out int identityId)) {
                        identityId = id;
                        identities.Add(hex, identityId);
                    }
                    byte[] regions = reader.ReadBytes(size * size);
                    byte[] solution = reader.ReadBytes(size);
                    if (regions.Length != size * size || solution.Length != size) {
                        throw new EndOfStreamException("Truncated DDA record " + i);
                    }
                    var entry = new PuzzleImportEntryModel {
                        id = id, identityId = identityId, size = size, grade = grade, fixedLevel = fixedLevel,
                        regions = Array.ConvertAll(regions, value => (int)value),
                        solutionColumns = Array.ConvertAll(solution, value => (int)value), preplacedRows = Array.Empty<int>(),
                        source = "DDA entry " + i + "; grade " + grade + "; " + hex,
                        path = PuzzleImportConst.AssetRoot + "/Campaign/" + (fixedLevel > 0 ? "Fixed" : "Grade" + grade) + "/Puzzle_" + id + ".asset"
                    };
                    ValidateData(entry);
                    entries.Add(entry);
                }
                if (reader.BaseStream.Position != reader.BaseStream.Length) {
                    throw new InvalidDataException("Unrecognized trailing bytes in original DDA bank.");
                }
                report.campaignMaps = count;
            }
            int sentinelMaps = entries.Count(entry => entry.fixedLevel == -1);
            report.observations.Add("Original fixedLevel=-1 sentinel retained on " + sentinelMaps + " records; no sentinel is converted into a playable fixed level.");
            var tutorial = ReadJson<PuzzleImportSourceEntryModel>(report, "05_data/Configs/Tutorial_4x4__sharedassets1.assets__11.json");
            var tutorialEntry = new PuzzleImportEntryModel {
                id = 1, size = tutorial.size, regions = tutorial.regionIds,
                solutionColumns = Columns(tutorial), preplacedRows = PreplacedRows(tutorial),
                source = "Tutorial_4x4__sharedassets1.assets__11.json",
                path = PuzzleImportConst.AssetRoot + "/Tutorial/Puzzle_1.asset"
            };
            ValidateData(tutorialEntry);
            entries.Add(tutorialEntry);
            report.tutorialMaps = 1;
            var daily = ReadJson<PuzzleImportSourceModel>(report, "05_data/Configs/DailyDatabase__resources.assets__1465.json");
            if (daily.entries == null || daily.seasons == null || daily.entries.Length == 0 || daily.seasons.Length == 0) {
                throw new InvalidDataException("Incomplete original daily database.");
            }
            var dailyIds = new HashSet<int>();
            foreach (var data in daily.entries) {
                if (data.puzzleId <= 0 || !dailyIds.Add(data.puzzleId)) {
                    throw new InvalidDataException("Duplicate/invalid original daily puzzle ID.");
                }
                int id = checked(PuzzleImportConst.DailyIdOffset + data.puzzleId);
                var entry = new PuzzleImportEntryModel {
                    id = id, identityId = id, size = data.size, regions = data.regionIds,
                    solutionColumns = Columns(data), preplacedRows = Array.Empty<int>(),
                    source = "DailyDatabase entry " + data.puzzleId + "; original static export",
                    path = PuzzleImportConst.AssetRoot + "/Daily/Puzzle_" + id + ".asset"
                };
                ValidateData(entry);
                entries.Add(entry);
            }
            foreach (var season in daily.seasons) {
                if (season.dayToPuzzleId == null || season.dayToPuzzleId.Length == 0) {
                    throw new InvalidDataException("Missing original daily date schedule.");
                }
                foreach (int id in season.dayToPuzzleId) {
                    if (!dailyIds.Contains(id)) {
                        throw new InvalidDataException("Daily schedule references unknown source map " + id);
                    }
                    dailySchedule.Add(checked(PuzzleImportConst.DailyIdOffset + id));
                }
            }
            report.dailyMaps = daily.entries.Length;
            var legacy = ReadJson<PuzzleImportSourceModel>(report, "05_data/Configs/CampaignDatabase__sharedassets1.assets__10.json");
            if (legacy.entries == null || legacy.entries.Length == 0) {
                throw new InvalidDataException("Missing original legacy campaign entries.");
            }
            for (int i = 0; i < legacy.entries.Length; i++) {
                var entry = legacy.entries[i];
                ValidateData(new PuzzleImportEntryModel {
                    id = i + 1, size = entry.size, regions = entry.regions,
                    solutionColumns = entry.solCols, preplacedRows = entry.preRows
                });
            }
            report.legacyCampaignEntries = legacy.entries.Length;
            report.observations.Add("Legacy campaign database entries=" + legacy.entries.Length + "; no per-level duplicate SO generated. Runtime continues using the active DDA pool/fixed-map configuration.");
            return (int)(DateTime.ParseExact(daily.seasonStartDate, "yyyy-MM-dd", CultureInfo.InvariantCulture).Ticks / TimeSpan.TicksPerDay);
        }

        static int[] Columns(PuzzleImportSourceEntryModel data) {
            if (data.solution == null || data.solution.Length != data.size) {
                throw new InvalidDataException("Missing source answer coordinates.");
            }
            int[] columns = Enumerable.Repeat(-1, data.size).ToArray();
            foreach (var point in data.solution) {
                if (point == null || point.y < 0 || point.y >= data.size || columns[point.y] != -1) {
                    throw new InvalidDataException("Duplicate/invalid source answer row.");
                }
                columns[point.y] = point.x;
            }
            return columns;
        }

        static int[] PreplacedRows(PuzzleImportSourceEntryModel data) {
            if (data.preplaced == null) {
                throw new InvalidDataException("Missing source preplaced array.");
            }
            var columns = Columns(data);
            var rows = new List<int>();
            foreach (var point in data.preplaced) {
                if (point == null || point.y < 0 || point.y >= data.size || point.x != columns[point.y] || rows.Contains(point.y)) {
                    throw new InvalidDataException("Invalid source preplaced position.");
                }
                rows.Add(point.y);
            }
            return rows.ToArray();
        }

        static void ValidateData(PuzzleImportEntryModel entry) {
            int n = entry.size;
            if (entry.id <= 0 || n < 4 || n > 12 || entry.regions == null || entry.regions.Length != n * n ||
                entry.solutionColumns == null || entry.solutionColumns.Length != n || entry.preplacedRows == null ||
                entry.regions.Any(region => region < 0 || region >= n)) {
                throw new InvalidDataException("Invalid map dimensions/regions: " + entry.id);
            }
            var columns = new HashSet<int>();
            var regions = new HashSet<int>();
            for (int row = 0; row < n; row++) {
                int col = entry.solutionColumns[row];
                if (col < 0 || col >= n || !columns.Add(col) || !regions.Add(entry.regions[row * n + col]) ||
                    (row > 0 && Math.Abs(col - entry.solutionColumns[row - 1]) <= 1)) {
                    throw new InvalidDataException("Invalid map solution: " + entry.id);
                }
            }
            if (entry.preplacedRows.Any(row => row < 0 || row >= n) || entry.preplacedRows.Distinct().Count() != entry.preplacedRows.Length) {
                throw new InvalidDataException("Invalid preplaced rows: " + entry.id);
            }
        }

        static int[] ActiveCampaignIds(CampaignConfigSO config, List<PuzzleImportEntryModel> entries, PuzzleImportReportModel report) {
            report.activeCampaignLevels = config.campaignSizes.Length;
            var desired = new HashSet<int>();
            int ceiling = config.campaignGradeCeilings.Max();
            var sizes = new HashSet<int>(config.campaignSizes);
            foreach (var entry in entries) {
                if (entry.id < PuzzleImportConst.CampaignIdOffset || entry.id >= PuzzleImportConst.DailyIdOffset) {
                    continue;
                }
                // Original bank 0x33c740c skips negative fixed markers; only zero enters a book.
                if (entry.fixedLevel > 0 ? config.campaignFixedLevels.Contains(entry.fixedLevel) : entry.fixedLevel == 0 &&
                    (entry.grade <= ceiling && sizes.Contains(entry.size) ||
                    entry.grade == config.campaignHardGrade && entry.size == 10 ||
                    entry.grade == config.campaignExpertGrade && config.campaignExpertSizes.Contains(entry.size))) {
                    desired.Add(entry.id);
                }
            }
            var result = new List<int>();
            foreach (int id in config.puzzleIds) {
                if (desired.Remove(id)) {
                    result.Add(id);
                } else {
                    report.conflicts.Add("Active campaign contains duplicate or out-of-scope map ID " + id);
                }
            }
            result.AddRange(desired.OrderBy(id => id));
            if (!config.puzzleIds.SequenceEqual(result)) {
                report.configurationChanges.Add("Active campaign map membership; playable level range remains " + config.campaignSizes.Length + ".");
            }
            foreach (int level in config.campaignFixedLevels) {
                var fixedMap = entries.Find(entry => entry.fixedLevel == level);
                if (level < 1 || level > config.campaignSizes.Length || fixedMap == null || fixedMap.size != config.campaignSizes[level - 1]) {
                    report.conflicts.Add("Active fixed-map configuration disagrees with original source at level " + level);
                }
            }
            return result.ToArray();
        }

        static void InspectAssets(List<PuzzleImportEntryModel> entries, PuzzleImportReportModel report) {
            var existing = new Dictionary<int, PuzzleSO>();
            foreach (string guid in AssetDatabase.FindAssets("t:PuzzleSO", new[] { "Assets/Res_Runtime" })) {
                string path = AssetDatabase.GUIDToAssetPath(guid);
                var puzzle = AssetDatabase.LoadAssetAtPath<PuzzleSO>(path);
                if (puzzle == null || existing.ContainsKey(puzzle.id)) {
                    report.conflicts.Add("Missing script or duplicate existing puzzle ID at " + path);
                } else {
                    existing.Add(puzzle.id, puzzle);
                }
            }
            var ids = new HashSet<int>();
            var settings = AddressableAssetSettingsDefaultObject.Settings;
            foreach (var entry in entries) {
                if (!ids.Add(entry.id)) {
                    report.conflicts.Add("Source ID collision " + entry.id);
                    continue;
                }
                if (existing.TryGetValue(entry.id, out var puzzle)) {
                    if (EditorUtility.IsDirty(puzzle)) {
                        report.conflicts.Add("Unsaved map edits must be saved or reverted before import: " + AssetDatabase.GetAssetPath(puzzle));
                    }
                    entry.existing = puzzle;
                    entry.existingPath = AssetDatabase.GetAssetPath(puzzle);
                    entry.existingGuid = AssetDatabase.AssetPathToGUID(entry.existingPath);
                    entry.existingHash = Hash(entry.existingPath);
                    if (AssetDatabase.LoadAllAssetsAtPath(entry.existingPath).OfType<PuzzleSO>().Count() != 1) {
                        report.conflicts.Add("Map is not an independent SO: " + entry.existingPath);
                    }
                    if (entry.existingPath != entry.path && File.Exists(entry.path)) {
                        report.conflicts.Add("Canonical target is occupied: " + entry.path);
                    }
                    var registered = settings == null ? null : settings.FindAssetEntry(entry.existingGuid);
                    entry.changed = !Matches(entry, puzzle) || entry.existingPath != entry.path || registered == null ||
                        !registered.labels.Contains(AAConst.LABEL_DEFAULT) || registered.address != entry.path;
                    (entry.changed ? report.updated : report.unchanged).Add(entry.path);
                } else if (File.Exists(entry.path) || File.Exists(entry.path + ".meta")) {
                    report.conflicts.Add("Unrecognized asset or orphan meta occupies target: " + entry.path);
                } else {
                    report.added.Add(entry.path);
                }
            }
            foreach (var pair in existing) {
                if (!ids.Contains(pair.Key)) {
                    report.observations.Add("Unmanaged map retained: " + AssetDatabase.GetAssetPath(pair.Value));
                }
            }
        }

        static bool Matches(PuzzleImportEntryModel source, PuzzleSO target) {
            return target.id == source.id && target.size == source.size && target.grade == source.grade &&
                target.fixedLevel == source.fixedLevel && target.identityId == source.identityId && target.source == source.source &&
                target.regions != null && target.regions.SequenceEqual(source.regions) &&
                target.solutionColumns != null && target.solutionColumns.SequenceEqual(source.solutionColumns) &&
                target.preplacedRows != null && target.preplacedRows.SequenceEqual(source.preplacedRows);
        }

        static void InspectConfiguration(PuzzleImportReportModel report) {
            var paths = new[] {
                "Assets/Res_Runtime/Config/GameConfig.asset",
                "Assets/Res_Runtime/Config/PuzzleRules.asset",
                "Assets/Res_Runtime/Config/CampaignConfig.asset",
                "Assets/Res_Runtime/Config/PuzzlePresentation.asset",
                "Assets/Res_Runtime/Config/ResultConfig.asset"
            };
            var settings = AddressableAssetSettingsDefaultObject.Settings;
            foreach (string path in paths) {
                var asset = AssetDatabase.LoadMainAssetAtPath(path);
                if (asset == null) {
                    report.missing.Add("Formal configuration: " + path);
                    continue;
                }
                if (EditorUtility.IsDirty(asset)) {
                    report.conflicts.Add("Unsaved configuration edits must be saved or reverted before import: " + path);
                }
                var registered = settings == null ? null : settings.FindAssetEntry(AssetDatabase.AssetPathToGUID(path));
                if (registered == null || registered.address != path || !registered.labels.Contains(AAConst.LABEL_DEFAULT)) {
                    report.configurationChanges.Add("Repair formal configuration registration: " + path);
                }
            }
            var daily = AssetDatabase.LoadMainAssetAtPath("Assets/Res_Runtime/Config/DailyConfig.asset");
            if (daily != null && EditorUtility.IsDirty(daily)) {
                report.conflicts.Add("Unsaved daily configuration edits must be saved or reverted before import.");
            }
            if (settings == null) {
                return;
            }
            if (EditorUtility.IsDirty(settings) || settings.groups.Any(group => group != null && EditorUtility.IsDirty(group))) {
                report.conflicts.Add("Unsaved Addressables edits must be saved or reverted before import.");
            }
            if (settings.FindGroup("Gameplay") == null) {
                report.missing.Add("Formal Gameplay Addressables group.");
            }
        }

        static void Apply(List<PuzzleImportEntryModel> entries) {
            AssetDatabase.StartAssetEditing();
            try {
                for (int i = 0; i < entries.Count; i++) {
                    var entry = entries[i];
                    if (entry.existing != null && !entry.changed) {
                        continue;
                    }
                    if (entry.existing != null && entry.existingPath == entry.path && Matches(entry, entry.existing)) {
                        // Registration-only repair must not reserialize a user's unchanged map asset.
                        continue;
                    }
                    if (i % 256 == 0) {
                        EditorUtility.DisplayProgressBar("Puzzle migration", entry.path, (float)i / entries.Count);
                    }
                    Directory.CreateDirectory(Path.GetDirectoryName(entry.path));
                    var puzzle = entry.existing;
                    if (puzzle == null) {
                        puzzle = ScriptableObject.CreateInstance<PuzzleSO>();
                        AssetDatabase.CreateAsset(puzzle, entry.path);
                    } else if (entry.existingPath != entry.path) {
                        string error = AssetDatabase.MoveAsset(entry.existingPath, entry.path);
                        if (!string.IsNullOrEmpty(error)) {
                            throw new IOException(error);
                        }
                    }
                    puzzle.id = entry.id;
                    puzzle.size = entry.size;
                    puzzle.grade = entry.grade;
                    puzzle.fixedLevel = entry.fixedLevel;
                    puzzle.identityId = entry.identityId;
                    puzzle.regions = (int[])entry.regions.Clone();
                    puzzle.solutionColumns = (int[])entry.solutionColumns.Clone();
                    puzzle.preplacedRows = (int[])entry.preplacedRows.Clone();
                    puzzle.source = entry.source;
                    EditorUtility.SetDirty(puzzle);
                }
            } finally {
                AssetDatabase.StopAssetEditing();
            }
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }

        static string Backup(PuzzleImportReportModel report, List<PuzzleImportEntryModel> entries) {
            string root = PuzzleImportConst.ReportRoot + "/Backups/" + DateTime.UtcNow.ToString("yyyyMMddTHHmmssfff", CultureInfo.InvariantCulture);
            var paths = entries.Where(entry => entry.existing != null && entry.changed).Select(entry => entry.existingPath).ToList();
            paths.AddRange(new[] { "Assets/Res_Runtime/Config/CampaignConfig.asset", "Assets/Res_Runtime/Config/DailyConfig.asset", "Assets/Res_Runtime/Config/PuzzleRules.asset" });
            paths.AddRange(Directory.GetFiles("Assets/AddressableAssetsData", "*.asset", SearchOption.AllDirectories));
            foreach (string path in paths.Distinct()) {
                foreach (string source in new[] { path, path + ".meta" }) {
                    if (!File.Exists(source)) {
                        continue;
                    }
                    string target = Path.Combine(root, source);
                    Directory.CreateDirectory(Path.GetDirectoryName(target));
                    File.Copy(source, target, false);
                }
            }
            WriteReport(report, root.Substring(PuzzleImportConst.ReportRoot.Length + 1) + "/plan");
            return root;
        }

        static void CheckInputsStillMatch(PuzzleImportReportModel report, List<PuzzleImportEntryModel> entries) {
            foreach (string record in report.sourceHashes) {
                int separator = record.IndexOf('|');
                string relative = record.Substring(0, separator);
                if (Hash(SourcePath(report, relative)) != record.Substring(separator + 1)) {
                    throw new IOException("Source changed during migration planning: " + relative);
                }
            }
            foreach (var entry in entries) {
                if (entry.existing != null && (Hash(entry.existingPath) != entry.existingHash ||
                    AssetDatabase.AssetPathToGUID(entry.existingPath) != entry.existingGuid)) {
                    throw new IOException("Existing asset changed during migration planning: " + entry.existingPath);
                }
            }
        }

        static T ReadJson<T>(PuzzleImportReportModel report, string relative) {
            RecordSource(report, relative);
            return JsonUtility.FromJson<T>(File.ReadAllText(SourcePath(report, relative)));
        }

        static string SourcePath(PuzzleImportReportModel report, string relative) {
            string path = Path.GetFullPath(Path.Combine(report.sourceRoot, relative));
            if (!path.StartsWith(report.sourceRoot.TrimEnd(Path.DirectorySeparatorChar) + Path.DirectorySeparatorChar, StringComparison.OrdinalIgnoreCase) || !File.Exists(path)) {
                report.missing.Add(relative);
                throw new FileNotFoundException("Missing original source", path);
            }
            return path;
        }

        static void RecordSource(PuzzleImportReportModel report, string relative) {
            report.sourceHashes.Add(relative + "|" + Hash(SourcePath(report, relative)));
        }

        static string Hash(string path) {
            using (var algorithm = SHA256.Create()) {
                using (var stream = File.OpenRead(path)) {
                    return BitConverter.ToString(algorithm.ComputeHash(stream)).Replace("-", string.Empty).ToLowerInvariant();
                }
            }
        }

        static void InspectSourceChanges(PuzzleImportReportModel report) {
            string receipt = PuzzleImportConst.ReportRoot + "/receipt.json";
            if (!File.Exists(receipt)) {
                return;
            }
            var previous = JsonUtility.FromJson<PuzzleImportReportModel>(File.ReadAllText(receipt));
            foreach (string record in report.sourceHashes) {
                if (!previous.sourceHashes.Contains(record)) {
                    report.changedSources.Add(record.Substring(0, record.IndexOf('|')));
                }
            }
        }

        static void WriteReport(PuzzleImportReportModel report, string name) {
            string path = PuzzleImportConst.ReportRoot + "/" + name + ".json";
            Directory.CreateDirectory(Path.GetDirectoryName(path));
            File.WriteAllText(path, JsonUtility.ToJson(report, true));
        }
    }
}
