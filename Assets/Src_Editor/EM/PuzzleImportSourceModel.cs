using System;
namespace Hamdoku.Editor {
    [Serializable]
    public sealed class PuzzleImportSourceModel {
        public PuzzleImportSourceEntryModel[] entries;
        public PuzzleImportSeasonModel[] seasons;
        public string seasonStartDate;
    }
}
