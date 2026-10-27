using System;
namespace Hamdoku {
    [Serializable]
    public sealed class RankingBoardResult {
        public RankingResultStatus status;
        public long seasonId;
        // UTC Unix seconds, anchored to realtimeSinceStartup when received.
        public long serverTimeUtc;
        public long endsAtUtc;
        public RankingEntryModel[] entries;
        public RankingEntryModel me;
        public RankingRewardStatus rewardStatus;
    }
}
