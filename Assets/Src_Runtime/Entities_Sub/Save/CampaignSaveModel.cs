using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Hamdoku {
    [Serializable]
    [DataContract]
    public sealed class CampaignSaveModel {
        [DataMember] public int claimedRewardLevel;
        [DataMember] public int previousLevel;
        [DataMember] public bool previousRetried;
        [DataMember] public int previousRecordedSkill;
        [DataMember] public bool pendingDemotion;
        [DataMember] public bool expertRelief;
        [DataMember] public int skill;
        [DataMember] public int cleanStreak;
        [DataMember] public int sessionDay;
        [DataMember] public int[] cursorPositions;
        [DataMember] public int[] cursorCycles;
        [DataMember] public List<int> recentPuzzleIds;
    }
}
