namespace Hamdoku {
    public sealed class RankingState {
        public bool isOpen;
        public bool disposed;
        public bool isPreview;
        public long requestId;
        public long seasonId;
        public long serverTimeUtc;
        public long endsAtUtc;
        public double receivedAt;
        public double nextRefreshAt;
        public RankingStatus status;
        public RankingRewardStatus rewardStatus;
        public RankingEntryModel[] entries;
        public RankingEntryModel me;
        public RankingDialogType dialog;
        public int rewardRank;
        public UINameType notice;
        public string claimToken;
        public bool reportPending;
        public long reportEventId;
    }
}
