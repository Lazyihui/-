namespace Hamdoku.Editor {
    public sealed class PuzzleImportEntryModel {
        public int id;
        public int size;
        public int grade;
        public int fixedLevel;
        public int identityId;
        public int[] regions;
        public int[] solutionColumns;
        public int[] preplacedRows;
        public string source;
        public string path;
        public string existingPath;
        public string existingGuid;
        public string existingHash;
        public PuzzleSO existing;
        public bool changed;
    }
}
