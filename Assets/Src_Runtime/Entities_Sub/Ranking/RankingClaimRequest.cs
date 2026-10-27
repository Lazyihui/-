using System;
namespace Hamdoku {
    [Serializable]
    public sealed class RankingClaimRequest {
        public long seasonId;
        public string requestToken;
    }
}
