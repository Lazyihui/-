using System.Runtime.Serialization;
using System;
namespace Hamdoku {
    [Serializable]
    [DataContract]
    public sealed class RankingClearRequest {
        [DataMember]
        public string clientId;
        [DataMember]
        public long eventId;
        [DataMember]
        public long seasonId;
        [DataMember]
        public int level;
        [DataMember]
        public int puzzleId;
        [DataMember]
        public int heartsRemaining;
        [DataMember]
        public int gameScore;
        [DataMember]
        public long completedAtUtc;
        // No seed conversion until the scoring rule is verified. Server derives awarded seeds from facts.
    }
}
