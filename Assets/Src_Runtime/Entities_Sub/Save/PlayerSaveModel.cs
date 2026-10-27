using System;
using UnityEngine;

namespace Hamdoku {
    [Serializable]
    public sealed class PlayerSaveModel {
        public int version;
        public int campaignClears;
        public bool tutorialCompleted;
        public SystemLanguage language;
        public int dailyStreak;
    }
}
