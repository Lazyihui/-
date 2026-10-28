using System;
using System.Runtime.Serialization;

namespace Hamdoku {
    [Serializable]
    [DataContract]
    public sealed class DailyRecordModel {
        [DataMember] public int day;
        [DataMember] public bool cleared;
        [DataMember] public bool perfect;
        [DataMember] public float bestSeconds;
        [DataMember] public int attempts;
    }
}
