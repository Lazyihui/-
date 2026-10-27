using System;
using System.Runtime.Serialization;

namespace Hamdoku {
    [Serializable]
    [DataContract]
    public sealed class ProfileSaveModel {
        [DataMember] public string nickname;
        [DataMember] public int avatarId;
        [DataMember] public int frameId;
        [DataMember] public int mottoId;
        // -1 is the original unequipped costume state.
        [DataMember] public int costumeId;
        [DataMember] public int firstRecordedDay;
        [DataMember] public bool historyKnown;
        [DataMember] public int consecutiveClears;
        [DataMember] public int bestConsecutiveClears;
        [DataMember] public int firstTryClears;
        [DataMember] public int threeSeedClears;
        [DataMember] public int trackedThroughLevel;
        [DataMember] public int retriedLevel;
        [DataMember] public int lastLoginDay;
        [DataMember] public int loginStreak;
        [DataMember] public int bestLoginStreak;
    }
}
