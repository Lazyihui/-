using System;
namespace Hamdoku.Editor {
    [Serializable]
    public sealed class PuzzleImportSourceEntryModel {
        public int size;
        public int puzzleId;
        public int[] regionIds;
        public int[] regions;
        public int[] solCols;
        public int[] preRows;
        public PuzzleImportPointModel[] solution;
        public PuzzleImportPointModel[] preplaced;
    }
}
