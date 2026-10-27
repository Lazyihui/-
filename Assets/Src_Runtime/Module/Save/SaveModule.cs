using System.IO;
using UnityEngine;

namespace Hamdoku {
    public sealed class SaveModule {
        public PlayerSaveModel Load(HomeConfigSO config, string directory) {
            string path = GetPath(config, directory);
            if (!File.Exists(path)) {
                return null; // A first installation has no progress yet.
            }
            var data = JsonUtility.FromJson<PlayerSaveModel>(File.ReadAllText(path));
            if (data == null || data.version != config.saveVersion || data.campaignClears < 0 || data.dailyStreak < 0) {
                throw new InvalidDataException("Invalid or unsupported Hamdoku progress: " + path);
            }
            return data;
        }

        public void Save(HomeConfigSO config, string directory, PlayerSaveModel data) {
            string path = GetPath(config, directory);
            if (data.version != config.saveVersion || data.campaignClears < 0 || data.dailyStreak < 0) {
                throw new InvalidDataException("Invalid Hamdoku progress.");
            }
            Directory.CreateDirectory(directory);
            string temporary = path + ".tmp";
            File.WriteAllText(temporary, JsonUtility.ToJson(data, true));
            if (File.Exists(path)) {
                File.Replace(temporary, path, null);
            } else {
                File.Move(temporary, path);
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
