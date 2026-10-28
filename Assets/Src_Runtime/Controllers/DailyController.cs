using System;
using System.Collections.Generic;
using System.IO;

namespace Hamdoku.Controllers {
    public static class DailyController {
        public static int Day(DateTime date) {
            return (int)(date.Date.Ticks / TimeSpan.TicksPerDay);
        }

        public static DateTime Date(int day) {
            return new DateTime((long)day * TimeSpan.TicksPerDay);
        }

        public static int RecordIndex(DailySaveModel data, int day) {
            int low = 0;
            int high = data.records.Count - 1;
            while (low <= high) {
                int middle = low + (high - low) / 2;
                int value = data.records[middle].day;
                if (value == day) {
                    return middle;
                }
                if (value < day) {
                    low = middle + 1;
                } else {
                    high = middle - 1;
                }
            }
            return ~low;
        }

        public static DailyRecordModel Record(DailySaveModel data, int day) {
            int index = RecordIndex(data, day);
            return index < 0 ? null : data.records[index];
        }

        public static void Initialize(GameContext ctx, PlayerSaveModel loaded) {
            var assets = ctx.assetModule;
            var config = assets.GetDailyConfig();
            ValidateConfig(config, assets.GetProfileConfig());
            var save = ctx.playerSave;
            var module = ctx.puzzleModule;
            module.RegisterDaily(config);
            save.daily = loaded == null || loaded.version < 10 ? new DailySaveModel {
                records = new List<DailyRecordModel>(), claimedCostumes = new List<int>()
            } : loaded.daily;
            var data = save.daily;
            SaveModule.ValidateDaily(data);
            foreach (var record in data.records) {
                Puzzle(config, record.day);
            }
            var profile = assets.GetProfileConfig();
            foreach (int id in data.claimedCostumes) {
                if (id < 0 || id >= profile.costumes.Length) {
                    throw new InvalidDataException("Unknown daily costume reward.");
                }
                int seasonIndex = SeasonIndex(config, profile.costumeSeasons[id]);
                if (seasonIndex < 0) {
                    throw new InvalidDataException("Claimed costume has no daily season.");
                }
                var season = config.seasons[seasonIndex];
                int reward = Array.IndexOf(season.costumeIds, id);
                if (reward < 0 || AvailablePieces(data, season) < 0) {
                    throw new InvalidDataException("Claimed costume exceeds earned daily pieces.");
                }
            }
            if (data.activePuzzle != null) {
                var active = data.activePuzzle;
                var record = Record(data, active.dailyDay);
                if (active.dailyDay <= 0 || Puzzle(config, active.dailyDay).id != active.puzzleId || record == null ||
                    (active.status == GameStatus.Won && !record.cleared)) {
                    throw new InvalidDataException("Daily board and dated entry disagree.");
                }
                module.ValidateSave(active, assets.GetGameConfig(), save.campaignClears, save.tutorialCompleted);
            }
        }

        public static PuzzleSO Puzzle(DailyConfigSO config, int day) {
            int index = day - config.firstDay;
            if (index < 0) {
                throw new InvalidDataException("Daily date is outside the original local database.");
            }
            return config.puzzles[config.dayToPuzzle[index % config.dayToPuzzle.Length] - 1];
        }

        public static void ValidateConfig(DailyConfigSO config, ProfileConfigSO profile) {
            if (config == null || config.firstDay <= 0 || config.dayToPuzzle == null || config.dayToPuzzle.Length == 0 ||
                config.puzzles == null || config.puzzles.Length == 0 || config.seasons == null || config.seasons.Length == 0 ||
                config.revealSeconds <= 0 || config.noticeSeconds <= 0 || config.revealScale <= 0 ||
                config.availableDayColor.a <= 0 || config.futureDayColor.a <= 0 || config.selectedDayColor.a <= 0 ||
                config.availableNumberColor.a <= 0 || config.futureNumberColor.a <= 0 || config.background == null || config.card == null ||
                config.calendarCard == null || config.circle == null || config.clearStamp == null || config.perfectStamp == null ||
                config.back == null || config.history == null || config.clock == null || config.start == null) {
                throw new InvalidDataException("Incomplete daily challenge assets.");
            }
            int previous = 0;
            foreach (var season in config.seasons) {
                if (season == null || season.id <= previous || season.artwork == null || season.lines == null ||
                    season.pieces == null || season.pieces.Length == 0 || season.pieces.Length > 35 || season.lockedPieces == null ||
                    season.lockedPieces.Length != season.pieces.Length || season.pieceRects == null || season.pieceRects.Length != season.pieces.Length ||
                    season.revealOrder == null || season.revealOrder.Length != season.pieces.Length || season.costumeIds == null ||
                    season.costumeIds.Length == 0 || season.rewardPieces == null || season.rewardPieces.Length != season.costumeIds.Length) {
                    throw new InvalidDataException("Incomplete daily season configuration.");
                }
                var order = new HashSet<int>();
                for (int i = 0; i < season.pieces.Length; i++) {
                    if (season.pieces[i] == null || season.lockedPieces[i] == null || season.revealOrder[i] < 0 ||
                        season.revealOrder[i] >= season.pieces.Length || !order.Add(season.revealOrder[i]) ||
                        season.pieceRects[i].width <= 0 || season.pieceRects[i].height <= 0) {
                        throw new InvalidDataException("Invalid daily puzzle piece.");
                    }
                }
                int total = 0;
                for (int i = 0; i < season.costumeIds.Length; i++) {
                    int id = season.costumeIds[i];
                    if (id < 0 || id >= profile.costumes.Length || profile.costumes[id] == null ||
                        profile.costumeSeasons[id] != season.id || season.rewardPieces[i] <= 0) {
                        throw new InvalidDataException("Daily outfit reward does not match ProfileConfig.");
                    }
                    total += season.rewardPieces[i];
                }
                if (total > season.pieces.Length) {
                    throw new InvalidDataException("Daily outfit prices exceed the puzzle piece budget.");
                }
                previous = season.id;
            }
        }

        public static int SeasonIndex(DailyConfigSO config, int id) {
            int low = 0;
            int high = config.seasons.Length - 1;
            while (low <= high) {
                int middle = (low + high) / 2;
                if (config.seasons[middle].id == id) {
                    return middle;
                }
                if (config.seasons[middle].id < id) {
                    low = middle + 1;
                } else {
                    high = middle - 1;
                }
            }
            return -1;
        }

        public static int Units(DailySaveModel data, int seasonId) {
            var first = new DateTime(seasonId / 100, seasonId % 100, 1);
            int from = Day(first);
            int to = Day(first.AddMonths(1));
            int index = RecordIndex(data, from);
            if (index < 0) {
                index = ~index;
            }
            int units = 0;
            for (int i = index; i < data.records.Count && data.records[i].day < to; i++) {
                var record = data.records[i];
                units += record.perfect ? 2 : record.cleared ? 1 : 0;
            }
            return units;
        }

        public static int Threshold(DailySeasonSO season, int reward) {
            return season.rewardPieces[reward];
        }

        public static int AvailablePieces(DailySaveModel data, DailySeasonSO season) {
            int pieces = Math.Min(Units(data, season.id), season.pieces.Length);
            for (int i = 0; i < season.costumeIds.Length; i++) {
                if (data.claimedCostumes.BinarySearch(season.costumeIds[i]) >= 0) {
                    pieces -= season.rewardPieces[i];
                }
            }
            return pieces;
        }

        public static void Open(GameContext ctx, int selectedDay = 0) {
            var state = ctx.state_Daily;
            var assets = ctx.assetModule;
            var config = assets.GetDailyConfig();
            var today = selectedDay > 0 ? Date(selectedDay) : DateTime.Today;
            int index = SeasonIndex(config, today.Year * 100 + today.Month);
            if (index < 0) {
                HomeSystem.Open(ctx);
                HomeController.ShowNotice(ctx, UINameType.Daily_SeasonUnavailable, 0);
                return;
            }
            state.seasonIndex = index;
            var save = ctx.playerSave;
            var data = save.daily;
            state.selectedDay = selectedDay > 0 ? selectedDay :
                data.activePuzzle != null && data.activePuzzle.status == GameStatus.Playing ? data.activePuzzle.dailyDay : Day(today);
            var selectedDate = Date(state.selectedDay);
            state.seasonIndex = SeasonIndex(config, selectedDate.Year * 100 + selectedDate.Month);
            state.rewardIndex = 0;
            if (selectedDay == 0) {
                state.shownUnits = Units(data, config.seasons[state.seasonIndex].id);
            }
            state.notice = UINameType.None;
            state.isOpen = true;
            var home = ctx.state_Home;
            home.isOpen = false;
            home.pendingRequest = HomeRequestType.None;
            Panel_Home_Controller.Close(ctx);
            Panel_Daily_Controller.Open(ctx);
        }

        public static void Close(GameContext ctx) {
            var state = ctx.state_Daily;
            state.isOpen = false;
            Panel_Daily_Controller.Close(ctx);
            HomeSystem.Open(ctx);
        }

        public static void Dispose(GameContext ctx) {
            var state = ctx.state_Daily;
            state.isOpen = false;
            Panel_Daily_Controller.Close(ctx);
        }

        public static void SelectDay(GameContext ctx, int dayOfMonth) {
            var state = ctx.state_Daily;
            var assets = ctx.assetModule;
            var config = assets.GetDailyConfig();
            var season = config.seasons[state.seasonIndex];
            int count = DateTime.DaysInMonth(season.id / 100, season.id % 100);
            if (!state.isOpen || dayOfMonth < 1 || dayOfMonth > count) {
                return;
            }
            state.selectedDay = Day(new DateTime(season.id / 100, season.id % 100, dayOfMonth));
            state.notice = UINameType.None;
            Panel_Daily_Controller.Refresh(ctx);
        }

        public static void ChangeSeason(GameContext ctx, int direction) {
            var state = ctx.state_Daily;
            var assets = ctx.assetModule;
            var config = assets.GetDailyConfig();
            int next = state.seasonIndex + direction;
            if (next < 0 || next >= config.seasons.Length) {
                return;
            }
            state.seasonIndex = next;
            state.notice = UINameType.None;
            state.rewardIndex = 0;
            var season = config.seasons[next];
            state.selectedDay = Day(new DateTime(season.id / 100, season.id % 100, 1));
            var save = ctx.playerSave;
            state.shownUnits = Units(save.daily, season.id);
            Panel_Daily_Controller.Refresh(ctx);
        }

        public static void ChangeReward(GameContext ctx, int direction) {
            var state = ctx.state_Daily;
            var assets = ctx.assetModule;
            var config = assets.GetDailyConfig();
            var season = config.seasons[state.seasonIndex];
            state.rewardIndex = (state.rewardIndex + direction + season.costumeIds.Length) % season.costumeIds.Length;
            Panel_Daily_Controller.Refresh(ctx);
        }

        public static void Start(GameContext ctx) {
            var state = ctx.state_Daily;
            if (!state.isOpen || state.selectedDay > Day(DateTime.Today)) {
                Notice(ctx, UINameType.Daily_Future);
                return;
            }
            var save = ctx.playerSave;
            var data = save.daily;
            var active = data.activePuzzle;
            if (active != null && active.dailyDay == state.selectedDay && active.status != GameStatus.Won) {
                if (active.status == GameStatus.Failed) {
                    Notice(ctx, UINameType.Daily_AdUnavailable);
                    return;
                }
            } else {
                if (state.selectedDay != Day(DateTime.Today) || Record(data, state.selectedDay) != null) {
                    Notice(ctx, UINameType.Daily_AdUnavailable);
                    return;
                }
                if (active != null && active.status == GameStatus.Playing) {
                    Notice(ctx, UINameType.Daily_ResumeOther);
                    return;
                }
                data.activePuzzle = null;
                int index = RecordIndex(data, state.selectedDay);
                data.records.Insert(~index, new DailyRecordModel { day = state.selectedDay, attempts = 1 });
            }
            int day = state.selectedDay;
            var assets = ctx.assetModule;
            var config = assets.GetDailyConfig();
            var season = config.seasons[state.seasonIndex];
            state.shownUnits = Units(data, season.id);
            state.isOpen = false;
            Panel_Daily_Controller.Close(ctx);
            GameController.Open(ctx, false, day);
        }

        public static void Complete(GameContext ctx) {
            var game = ctx.state_Game;
            var save = ctx.playerSave;
            var data = save.daily;
            var record = Record(data, game.dailyDay);
            if (record == null) {
                throw new InvalidDataException("Daily completion has no dated attempt.");
            }
            bool first = !record.cleared;
            record.cleared = true;
            record.perfect |= game.mistakes == 0;
            if (first || game.elapsed < record.bestSeconds) {
                record.bestSeconds = game.elapsed;
            }
            StreakController.RecordWin(ctx, DateTime.Today);
        }

        public static void Claim(GameContext ctx) {
            var state = ctx.state_Daily;
            var assets = ctx.assetModule;
            var config = assets.GetDailyConfig();
            var season = config.seasons[state.seasonIndex];
            var save = ctx.playerSave;
            var data = save.daily;
            int id = season.costumeIds[state.rewardIndex];
            if (data.claimedCostumes.BinarySearch(id) >= 0) {
                Notice(ctx, UINameType.Daily_Claimed);
                return;
            }
            int today = Day(DateTime.Today);
            var date = Date(today);
            if (season.id != date.Year * 100 + date.Month || AvailablePieces(data, season) < Threshold(season, state.rewardIndex)) {
                Notice(ctx, UINameType.Daily_RewardLocked);
                return;
            }
            data.claimedCostumes.Insert(~data.claimedCostumes.BinarySearch(id), id);
            HomeController.SaveProgress(ctx);
            Notice(ctx, UINameType.Daily_RewardClaimed);
        }

        public static void Notice(GameContext ctx, UINameType message) {
            var state = ctx.state_Daily;
            var assets = ctx.assetModule;
            state.notice = message;
            state.noticeRemaining = assets.GetDailyConfig().noticeSeconds;
            Panel_Daily_Controller.Refresh(ctx);
        }

        public static void Tick(GameContext ctx, float deltaTime) {
            var state = ctx.state_Daily;
            if (!state.isOpen) {
                return;
            }
            state.refreshElapsed += deltaTime;
            if (state.noticeRemaining > 0) {
                state.noticeRemaining -= deltaTime;
                if (state.noticeRemaining <= 0) {
                    state.notice = UINameType.None;
                }
            }
            if (state.refreshElapsed >= 1) {
                state.refreshElapsed = 0;
                Panel_Daily_Controller.Refresh(ctx);
            }
            Panel_Daily_Controller.Tick(ctx, deltaTime);
        }
    }
}
