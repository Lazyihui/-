using System;
namespace Hamdoku {
    public sealed class RankingModule {
        bool disposed;
        // Future transport must invoke callbacks on Unity's main thread.
        // Unconfigured service is an explicit result; these methods never simulate success.
        public void FetchBoard(RankingBoardRequest request, Action<RankingBoardResult> completed) {
            CheckAvailable();
            completed(new RankingBoardResult { status = RankingResultStatus.ServiceUnavailable });
        }
        public void SubmitClear(RankingClearRequest request, Action<RankingClearResult> completed) {
            CheckAvailable();
            completed(new RankingClearResult { status = RankingResultStatus.ServiceUnavailable, eventId = request.eventId });
        }
        public void ClaimReward(RankingClaimRequest request, Action<RankingClaimResult> completed) {
            CheckAvailable();
            completed(new RankingClaimResult { status = RankingResultStatus.ServiceUnavailable, seasonId = request.seasonId, requestToken = request.requestToken });
        }
        void CheckAvailable() {
            if (disposed) {
                throw new ObjectDisposedException(nameof(RankingModule));
            }
        }
        public void Dispose() {
            disposed = true;
        }
    }
}
