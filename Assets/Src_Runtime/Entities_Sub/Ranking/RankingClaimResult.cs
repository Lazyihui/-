using System;
namespace Hamdoku {
    [Serializable]
    public sealed class RankingClaimResult {
        public RankingResultStatus status;
        public long seasonId;
        public string requestToken;
        public RankingRewardStatus rewardStatus;
        // Actual inventory delivery requires a confirmed backend reward contract.
    }
}
