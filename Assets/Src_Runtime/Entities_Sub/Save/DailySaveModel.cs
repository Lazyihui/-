using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Hamdoku {
    [Serializable]
    [DataContract]
    public sealed class DailySaveModel {
        [DataMember] public List<DailyRecordModel> records;
        [DataMember] public List<int> claimedCostumes;
        [DataMember] public PuzzleSaveModel activePuzzle;
    }
}
