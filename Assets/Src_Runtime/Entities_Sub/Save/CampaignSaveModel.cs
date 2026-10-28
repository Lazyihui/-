using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Hamdoku {
    [Serializable]
    [DataContract]
    public sealed class CampaignSaveModel {
        [DataMember] public int skill;
        [DataMember] public int cleanStreak;
        [DataMember] public int sessionDay;
        [DataMember] public int[] cursorPositions;
        [DataMember] public List<int> recentPuzzleIds;
    }
}
