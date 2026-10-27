using System.Runtime.Serialization;
using System;
namespace Hamdoku {
    [Serializable]
    [DataContract]
    public sealed class PuzzleSaveModel {
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
        [DataMember]
        public int score;
        [DataMember]
        public float elapsed;
        [DataMember]
        public int tutorialStep;
        [DataMember]
        public GameStatus status;
    }
}
