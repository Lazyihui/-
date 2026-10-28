using System;
using System.Collections.Generic;
namespace Hamdoku.Editor {
    [Serializable]
    public sealed class PuzzleImportReportModel {
        public string operation;
        public string sourceRoot;
        public string timestampUtc;
        public bool succeeded;
        public int campaignMaps;
        public int dailyMaps;
        public int tutorialMaps;
        public int legacyCampaignEntries;
        public int activeCampaignLevels;
        public List<string> added = new List<string>();
        public List<string> updated = new List<string>();
        public List<string> unchanged = new List<string>();
        public List<string> conflicts = new List<string>();
        public List<string> missing = new List<string>();
        public List<string> configurationChanges = new List<string>();
        public List<string> sourceHashes = new List<string>();
        public List<string> changedSources = new List<string>();
        public List<string> observations = new List<string>();
    }
}
