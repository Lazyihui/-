using System.Runtime.Serialization;
using System;
namespace Hamdoku {
    [Serializable]
    [DataContract]
    public sealed class RankingSaveModel {
        [DataMember]
        public int version;
        [DataMember]
        public long claimSeasonId;
        [DataMember]
        public string claimRequestToken;
        [DataMember]
        public string clientId;
        [DataMember]
        public long nextEventId;
        [DataMember]
        public long lastRecordedLevel;
        [DataMember]
        public System.Collections.Generic.List<RankingClearRequest> pendingClears;
    }
}
