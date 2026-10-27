using System;
using System.Collections.Generic;
using UnityEngine;
namespace Hamdoku.Controllers {
    public static class RankingController {
        public static void InitializeSave(GameContext ctx) {
            var save = ctx.playerSave;
            if (save.ranking == null) {
                save.ranking = new RankingSaveModel {
                    version = 1, clientId = Guid.NewGuid().ToString("N"), nextEventId = 1,
                    lastRecordedLevel = save.campaignClears, pendingClears = new List<RankingClearRequest>()
                };
            }
        }
        public static void Open(GameContext ctx) {
            var state = ctx.state_Ranking;
            if (state.disposed) {
                throw new ObjectDisposedException(nameof(RankingState));
            }
            if (state.isOpen) {
                return;
            }
            var home = ctx.state_Home;
            if (!home.isOpen || !home.rankingUnlocked) {
                return;
            }
            Enter(ctx, false);
            Refresh(ctx);
            SubmitPending(ctx);
        }
        static void Enter(GameContext ctx, bool preview) {
            var assets = ctx.assetModule;
            var config = assets.GetRankingConfig();
            if (config.visibleRows != 3 || config.refreshSeconds <= 0 || config.avatars == null || config.avatars.Length == 0 ||
                config.costumes == null || config.costumes.Length == 0 || config.medals == null || config.medals.Length != 3 ||
                config.gifts == null || config.gifts.Length != 3 || config.rowColors == null || config.rowColors.Length != 3) {
                throw new InvalidOperationException("Ranking config requires three visible rows, three podium assets and valid avatar/costume mappings.");
            }
            foreach (var sprite in config.avatars) {
                if (sprite == null) {
                    throw new InvalidOperationException("Ranking avatar mapping contains an unbound sprite.");
                }
            }
            for (int i = 0; i < 3; i++) {
                if (config.medals[i] == null || config.gifts[i] == null) {
                    throw new InvalidOperationException("Ranking medal or gift is unbound.");
                }
            }
            var state = ctx.state_Ranking;
            state.isOpen = true;
            state.isPreview = preview;
            state.dialog = RankingDialogType.None;
            state.notice = UINameType.None;
            state.claimToken = null;
            state.nextRefreshAt = 0;
            var home = ctx.state_Home;
            home.isOpen = false;
            home.pendingRequest = HomeRequestType.None;
            home.noticeType = UINameType.None;
            home.noticeRemaining = 0;
            Panel_Home_Controller.Close(ctx);
            Panel_Ranking_Controller.Open(ctx);
        }
        public static void Refresh(GameContext ctx) {
            var state = ctx.state_Ranking;
            if (!state.isOpen || state.disposed || state.isPreview || state.status == RankingStatus.Loading || state.claimToken != null) {
                return;
            }
            long requestId = ++state.requestId;
            state.status = RankingStatus.Loading;
            state.notice = UINameType.None;
            state.entries = null;
            state.me = null;
            state.seasonId = 0;
            state.endsAtUtc = 0;
            state.rewardStatus = RankingRewardStatus.None;
            Panel_Ranking_Controller.Refresh(ctx);
            var module = ctx.rankingModule;
            module.FetchBoard(new RankingBoardRequest { requestId = requestId }, result => {
                if (!state.isOpen || state.disposed || state.isPreview || state.requestId != requestId) {
                    return;
                }
                ApplyResult(ctx, result);
            });
        }
        public static void Retry(GameContext ctx) {
            var state = ctx.state_Ranking;
            if (!state.isOpen || (state.status != RankingStatus.Failed && state.status != RankingStatus.Unavailable)) {
                return;
            }
            if (state.isPreview) {
                // Preview only the retry's loading transition. An explicit editor scenario supplies the next result.
                state.status = RankingStatus.Loading;
                Panel_Ranking_Controller.Refresh(ctx);
                return;
            }
            Refresh(ctx);
            SubmitPending(ctx);
        }
        static void ValidateEntry(RankingEntryModel entry, RankingConfigSO config) {
            if (entry == null || entry.playerId <= 0 || entry.rank <= 0 || entry.seeds < 0 || string.IsNullOrWhiteSpace(entry.displayName) ||
                entry.avatarId < 0 || entry.avatarId >= config.avatars.Length || entry.costumeId < 0 || entry.costumeId >= config.costumes.Length ||
                (entry.costumeId > 0 && config.costumes[entry.costumeId] == null)) {
                throw new InvalidOperationException("Invalid ranking entry or unconfigured avatar/costume.");
            }
        }
        static void ApplyResult(GameContext ctx, RankingBoardResult result) {
            var state = ctx.state_Ranking;
            if (result == null || result.status == RankingResultStatus.None) {
                throw new InvalidOperationException("Ranking request returned no result.");
            }
            if (result.status != RankingResultStatus.Success) {
                state.status = result.status == RankingResultStatus.ServiceUnavailable ? RankingStatus.Unavailable : RankingStatus.Failed;
                Panel_Ranking_Controller.Refresh(ctx);
                return;
            }
            if (result.seasonId <= 0 || result.serverTimeUtc <= 0 || result.endsAtUtc <= 0 || result.entries == null ||
                result.rewardStatus == RankingRewardStatus.Pending || !Enum.IsDefined(typeof(RankingRewardStatus), result.rewardStatus)) {
                throw new InvalidOperationException("Invalid authoritative ranking snapshot.");
            }
            var assets = ctx.assetModule;
            var config = assets.GetRankingConfig();
            var ids = new HashSet<long>();
            int previousRank = 0;
            foreach (var entry in result.entries) {
                ValidateEntry(entry, config);
                if (!ids.Add(entry.playerId) || entry.rank <= previousRank) {
                    throw new InvalidOperationException("Ranking entries must have unique players and ascending ranks.");
                }
                previousRank = entry.rank;
            }
            if (result.me != null) {
                ValidateEntry(result.me, config);
            }
            state.seasonId = result.seasonId;
            state.serverTimeUtc = result.serverTimeUtc;
            state.endsAtUtc = result.endsAtUtc;
            state.receivedAt = Time.realtimeSinceStartupAsDouble;
            state.entries = result.entries;
            state.me = result.me;
            state.rewardStatus = result.rewardStatus;
            state.status = result.endsAtUtc <= result.serverTimeUtc ? RankingStatus.Ended : result.entries.Length == 0 ? RankingStatus.Empty :
                result.me == null ? RankingStatus.NotParticipating : RankingStatus.Ready;
            Panel_Ranking_Controller.Refresh(ctx);
        }
        public static long RemainingSeconds(GameContext ctx) {
            var state = ctx.state_Ranking;
            if (state.endsAtUtc == 0) {
                return 0;
            }
            return Math.Max(0, state.endsAtUtc - state.serverTimeUtc - (long)(Time.realtimeSinceStartupAsDouble - state.receivedAt));
        }
        public static void Tick(GameContext ctx) {
            var state = ctx.state_Ranking;
            double now = Time.realtimeSinceStartupAsDouble;
            if (now < state.nextRefreshAt) {
                return;
            }
            var assets = ctx.assetModule;
            state.nextRefreshAt = now + assets.GetRankingConfig().refreshSeconds;
            bool endedNow = state.endsAtUtc > 0 && RemainingSeconds(ctx) == 0 && state.status != RankingStatus.Ended;
            if (endedNow) {
                state.status = RankingStatus.Ended;
            }
            Panel_Ranking_Controller.Refresh(ctx);
            Panel_RankingDialog_Controller.Refresh(ctx);
            Panel_Ranking_Controller.RefreshSafeArea(ctx);
            Panel_RankingDialog_Controller.RefreshSafeArea(ctx);
            if (endedNow && !state.isPreview && state.claimToken == null) {
                state.status = RankingStatus.None;
                Refresh(ctx);
            }
        }
        public static void Resume(GameContext ctx) {
            var state = ctx.state_Ranking;
            if (state.isOpen && !state.isPreview && state.claimToken == null) {
                state.requestId++;
                state.status = RankingStatus.None;
                Refresh(ctx);
                SubmitPending(ctx);
            }
        }
        public static void ShowDialog(GameContext ctx, RankingDialogType dialog) {
            var state = ctx.state_Ranking;
            if (!state.isOpen || state.disposed) {
                return;
            }
            state.dialog = dialog;
            state.notice = UINameType.None;
            Panel_RankingDialog_Controller.Open(ctx);
        }
        public static void ShowReward(GameContext ctx, int rank) {
            var state = ctx.state_Ranking;
            state.rewardRank = rank;
            ShowDialog(ctx, RankingDialogType.Reward);
        }
        public static void CloseDialog(GameContext ctx) {
            var state = ctx.state_Ranking;
            if (state.claimToken != null) {
                return;
            }
            state.dialog = RankingDialogType.None;
            Panel_RankingDialog_Controller.Close(ctx);
        }
        public static void Claim(GameContext ctx) {
            var state = ctx.state_Ranking;
            if (!state.isOpen || state.dialog != RankingDialogType.Reward || state.rewardRank != 0 ||
                state.rewardStatus != RankingRewardStatus.Available || state.claimToken != null) {
                return;
            }
            if (state.isPreview) {
                state.notice = UINameType.Ranking_PreviewNoClaim;
                Panel_RankingDialog_Controller.Refresh(ctx);
                return;
            }
            long generation = state.requestId;
            long season = state.seasonId;
            var save = ctx.playerSave;
            var ranking = save.ranking;
            if (ranking.claimSeasonId != season || string.IsNullOrEmpty(ranking.claimRequestToken)) {
                ranking.claimSeasonId = season;
                ranking.claimRequestToken = Guid.NewGuid().ToString("N");
                HomeController.SaveProgress(ctx);
            }
            string token = ranking.claimRequestToken;
            state.claimToken = token;
            state.rewardStatus = RankingRewardStatus.Pending;
            Panel_RankingDialog_Controller.Refresh(ctx);
            var module = ctx.rankingModule;
            module.ClaimReward(new RankingClaimRequest { seasonId = season, requestToken = token }, result => {
                if (!state.isOpen || state.disposed || state.requestId != generation || state.seasonId != season || state.claimToken != token) {
                    return;
                }
                if (result == null || result.seasonId != season || result.requestToken != token || result.status == RankingResultStatus.None) {
                    throw new InvalidOperationException("Mismatched ranking claim response.");
                }
                state.claimToken = null;
                if (result.status == RankingResultStatus.Success) {
                    if (result.rewardStatus != RankingRewardStatus.Claimed) {
                        throw new InvalidOperationException("Claim success must acknowledge a delivered reward.");
                    }
                    state.rewardStatus = result.rewardStatus;
                    state.notice = UINameType.Ranking_Claimed;
                } else {
                    state.rewardStatus = RankingRewardStatus.Available;
                    state.notice = result.status == RankingResultStatus.ServiceUnavailable ? UINameType.Ranking_Unavailable : UINameType.Ranking_Failed;
                }
                Panel_RankingDialog_Controller.Refresh(ctx);
            });
        }
        public static void RecordClear(GameContext ctx) {
            var game = ctx.state_Game;
            var save = ctx.playerSave;
            var ranking = save.ranking;
            if (game.isTutorial || game.status != GameStatus.Won || game.level <= ranking.lastRecordedLevel) {
                return;
            }
            var state = ctx.state_Ranking;
            ranking.pendingClears.Add(new RankingClearRequest {
                clientId = ranking.clientId, eventId = ranking.nextEventId++, seasonId = !state.isPreview && RemainingSeconds(ctx) > 0 ? state.seasonId : 0,
                level = game.level, puzzleId = game.puzzle.id, heartsRemaining = game.hearts, gameScore = game.score,
                completedAtUtc = DateTimeOffset.UtcNow.ToUnixTimeSeconds()
            });
            ranking.lastRecordedLevel = game.level;
            // GameController.Input persists this queue and campaign progress together after completion.
        }
        public static void SubmitPending(GameContext ctx) {
            var state = ctx.state_Ranking;
            var save = ctx.playerSave;
            var ranking = save.ranking;
            if (state.disposed || state.isPreview || state.reportPending || ranking.pendingClears.Count == 0) {
                return;
            }
            var item = ranking.pendingClears[0];
            state.reportPending = true;
            state.reportEventId = item.eventId;
            var module = ctx.rankingModule;
            module.SubmitClear(item, result => {
                if (state.disposed || !state.reportPending || state.reportEventId != item.eventId) {
                    return;
                }
                state.reportPending = false;
                if (result == null || result.eventId != item.eventId || result.status == RankingResultStatus.None) {
                    throw new InvalidOperationException("Mismatched ranking report response.");
                }
                if (result.status == RankingResultStatus.Success) {
                    ranking.pendingClears.RemoveAt(0);
                    HomeController.SaveProgress(ctx);
                    SubmitPending(ctx);
                }
                // Failure remains durable; retry on the next explicit entry/resume, never add local rank points.
            });
        }
        public static void Back(GameContext ctx) {
            var state = ctx.state_Ranking;
            if (!state.isOpen) {
                return;
            }
            Close(ctx);
            HomeSystem.Open(ctx);
        }
        public static void Collect(GameContext ctx) {
            var state = ctx.state_Ranking;
            if (!state.isOpen || state.claimToken != null) {
                return;
            }
            Close(ctx);
            HomeSystem.Open(ctx);
            HomeController.RequestCampaign(ctx);
        }
        public static void Close(GameContext ctx) {
            var state = ctx.state_Ranking;
            state.isOpen = false;
            if (state.isPreview) {
                state.seasonId = 0;
                state.endsAtUtc = 0;
            }
            state.isPreview = false;
            state.requestId++;
            state.status = RankingStatus.None;
            state.dialog = RankingDialogType.None;
            state.claimToken = null;
            Panel_RankingDialog_Controller.Close(ctx);
            Panel_Ranking_Controller.Close(ctx);
        }
        public static void Dispose(GameContext ctx) {
            var state = ctx.state_Ranking;
            if (state.disposed) {
                return;
            }
            Close(ctx);
            state.disposed = true;
            var module = ctx.rankingModule;
            module.Dispose();
        }
#if UNITY_EDITOR
        public static void OpenPreview(GameContext ctx, RankingPreviewSO preview, RankingPreviewType scenario) {
            var state = ctx.state_Ranking;
            var game = ctx.state_Game;
            var streak = ctx.state_Streak;
            if (state.disposed || game.isOpen || streak.isOpen || preview == null || scenario == RankingPreviewType.None) {
                throw new InvalidOperationException("Ranking preview requires a ready Home and an explicit fixture.");
            }
            Close(ctx);
            Enter(ctx, true);
            var entries = new RankingEntryModel[preview.entries.Length];
            for (int i = 0; i < entries.Length; i++) {
                entries[i] = JsonUtility.FromJson<RankingEntryModel>(JsonUtility.ToJson(preview.entries[i]));
            }
            long now = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            ApplyResult(ctx, new RankingBoardResult {
                status = RankingResultStatus.Success, seasonId = 1, serverTimeUtc = now,
                endsAtUtc = scenario == RankingPreviewType.Ended || scenario == RankingPreviewType.RewardAvailable || scenario == RankingPreviewType.Claimed ? now : now + preview.remainingSeconds,
                entries = scenario == RankingPreviewType.Empty ? new RankingEntryModel[0] : entries,
                me = scenario == RankingPreviewType.NotParticipating || scenario == RankingPreviewType.Empty ? null : JsonUtility.FromJson<RankingEntryModel>(JsonUtility.ToJson(preview.me)),
                rewardStatus = scenario == RankingPreviewType.RewardAvailable ? RankingRewardStatus.Available : scenario == RankingPreviewType.Claimed ? RankingRewardStatus.Claimed : RankingRewardStatus.Locked
            });
            if (scenario == RankingPreviewType.Loading || scenario == RankingPreviewType.Failed) {
                state.status = scenario == RankingPreviewType.Loading ? RankingStatus.Loading : RankingStatus.Failed;
                state.entries = null;
                state.me = null;
                state.endsAtUtc = 0;
            }
            Panel_Ranking_Controller.Refresh(ctx);
        }
#endif
    }
}
