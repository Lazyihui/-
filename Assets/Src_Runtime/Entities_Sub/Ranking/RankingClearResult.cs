using System;
namespace Hamdoku {
    [Serializable]
    public sealed class RankingClearResult {
        public RankingResultStatus status;
        public long eventId;
    }
}
