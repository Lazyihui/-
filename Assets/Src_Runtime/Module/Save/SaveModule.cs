using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Hamdoku {
    public sealed class SaveModule {
        public PlayerSaveModel Load(HomeConfigSO config, string directory) {
            string path = GetPath(config, directory);
            if (!File.Exists(path)) {
                return null; // A first installation has no progress yet.
            }
            PlayerSaveModel data;
            var serializer = new DataContractJsonSerializer(typeof(PlayerSaveModel));
            try {
                using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(File.ReadAllText(path)))) {
                    data = (PlayerSaveModel)serializer.ReadObject(stream);
                }
            } catch (SerializationException error) {
                throw new InvalidDataException("Invalid Hamdoku progress JSON: " + path, error);
            }
            if (data == null || (data.version != config.saveVersion &&
                !(config.saveVersion == 2 && data.version == 1) &&
                !(config.saveVersion == 3 && (data.version == 1 || data.version == 2)) &&
                !(config.saveVersion == 4 && data.version >= 1 && data.version <= 3)) ||
                data.campaignClears < 0 || data.dailyStreak < 0 || data.previousPuzzleId < 0) {
                throw new InvalidDataException("Invalid or unsupported Hamdoku progress: " + path);
            }
            if (data.version >= 3) {
                ValidateStreak(data.streak);
            }
            if (data.version >= 4) {
                ValidateRanking(data.ranking, data.campaignClears);
            }
            return data;
        }

        public void Save(HomeConfigSO config, string directory, PlayerSaveModel data) {
            string path = GetPath(config, directory);
            if (data.version != config.saveVersion || data.campaignClears < 0 || data.dailyStreak < 0 || data.previousPuzzleId < 0) {
                throw new InvalidDataException("Invalid Hamdoku progress.");
            }
            if (data.version >= 3) {
                ValidateStreak(data.streak);
            }
            if (data.version >= 4) {
                ValidateRanking(data.ranking, data.campaignClears);
            }
            Directory.CreateDirectory(directory);
            string temporary = path + ".tmp";
            var serializer = new DataContractJsonSerializer(typeof(PlayerSaveModel));
            using (var stream = File.Create(temporary)) {
                serializer.WriteObject(stream, data);
            }
            if (File.Exists(path)) {
                File.Replace(temporary, path, null);
            } else {
                File.Move(temporary, path);
            }
        }

        void ValidateStreak(StreakSaveModel data) {
            if (data == null || data.winDays == null || data.runDays < 0 || data.bestDays < data.runDays ||
                data.lastWinDay < 0 || data.lastWinDay > 3652059 || data.pendingHints < 0 || data.pendingGuides < 0 ||
                data.bonusHints < 0 || data.bonusGuides < 0 || data.pendingSlot < 0 || data.pendingSlot > 7 ||
                data.recoveryDismissedDay < 0 || data.recoveryDismissedDay > 3652059 ||
                ((data.pendingHints > 0 || data.pendingGuides > 0) != (data.pendingSlot > 0))) {
                throw new InvalidDataException("Invalid streak progress.");
            }
            int previous = 0;
            foreach (int day in data.winDays) {
                if (day <= previous || day > 3652059) {
                    throw new InvalidDataException("Streak win dates must be valid, unique and sorted.");
                }
                previous = day;
            }
            if ((data.winDays.Count == 0 && (data.lastWinDay != 0 || data.runDays != 0)) ||
                (data.winDays.Count > 0 && (previous != data.lastWinDay || data.runDays == 0))) {
                throw new InvalidDataException("Streak counter and dated wins disagree.");
            }
            int run = 0;
            int next = data.lastWinDay;
            for (int i = data.winDays.Count - 1; i >= 0 && data.winDays[i] == next; i--) {
                run++;
                next--;
            }
            if (run != data.runDays) {
                throw new InvalidDataException("Streak length does not match consecutive dated wins.");
            }
        }

        void ValidateRanking(RankingSaveModel data, int clears) {
            if (data == null || data.version != 1 || !System.Guid.TryParseExact(data.clientId, "N", out _) || data.nextEventId <= 0 ||
                data.lastRecordedLevel < 0 || data.lastRecordedLevel > clears || data.pendingClears == null || data.claimSeasonId < 0 ||
                (data.claimSeasonId > 0 && !System.Guid.TryParseExact(data.claimRequestToken, "N", out _))) {
                throw new InvalidDataException("Invalid ranking progress.");
            }
            long previousId = 0;
            int previousLevel = 0;
            foreach (var item in data.pendingClears) {
                if (item == null || item.clientId != data.clientId || item.eventId <= previousId || item.eventId >= data.nextEventId ||
                    item.level <= previousLevel || item.level > data.lastRecordedLevel || item.puzzleId <= 0 || item.heartsRemaining < 0 ||
                    item.gameScore < 0 || item.completedAtUtc <= 0 || item.seasonId < 0) {
                    throw new InvalidDataException("Invalid pending ranking clear event.");
                }
                previousId = item.eventId;
                previousLevel = item.level;
            }
        }

        string GetPath(HomeConfigSO config, string directory) {
            if (config.saveVersion <= 0 || string.IsNullOrWhiteSpace(config.saveFileName) ||
                Path.GetFileName(config.saveFileName) != config.saveFileName) {
                throw new InvalidDataException("Invalid save configuration.");
            }
            return Path.Combine(directory, config.saveFileName);
        }
    }
}
