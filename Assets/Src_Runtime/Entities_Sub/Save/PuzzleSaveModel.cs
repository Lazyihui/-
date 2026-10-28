using System.Runtime.Serialization;
using System;
namespace Hamdoku {
    [Serializable]
    [DataContract]
    public sealed class PuzzleSaveModel {
        [DataMember] public int dailyDay;
        [DataMember] public int campaignSelectionVersion;
        [DataMember] public int campaignGrade;
        [DataMember] public int campaignTransform;
        [DataMember] public bool campaignFirstGame;
        [DataMember] public bool campaignTouched;
        [DataMember] public bool campaignUsedItem;
        [DataMember] public int campaignFailures;
        [DataMember]
        public int puzzleId;
        [DataMember]
        public int level;
        [DataMember]
        public bool isTutorial;
        [DataMember]
        public CellStatus[] cells;
        [DataMember]
        public int hearts;
        [DataMember]
        public int mistakes;
        [DataMember]
        public int hints;
        [DataMember]
        public int guides;
        [DataMember] public int flowVersion;
        [DataMember] public int[] initialIndices;
        [DataMember] public int[] cellGains;
        [DataMember] public int scoreCarry;
        [DataMember] public int combo;
        [DataMember] public int bestCombo;
        [DataMember] public bool clearPending;
        [DataMember] public bool clearCrossApplied;
        [DataMember] public bool clearSweepNeeded;
        [DataMember]
        public int score;
        [DataMember]
        public float elapsed;
        [DataMember]
        public int tutorialStep;
        [DataMember]
        public int tutorialFlowVersion;
        [DataMember]
        public GameStatus status;
    }
}
