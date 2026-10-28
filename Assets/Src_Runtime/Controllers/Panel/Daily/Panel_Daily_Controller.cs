using System;
using System.Text;
using UnityEngine;

namespace Hamdoku.Controllers {
    public static class Panel_Daily_Controller {
        public static void Open(GameContext ctx) {
            var opened = PanelFactory.TryOpen(ctx, PanelType.Daily, out Panel_Daily panel);
            if (opened == UIOpenType.FirstOpen) {
                var localization = ctx.l10NModule;
                panel.Ctor(localization);
                panel.dayHandle = day => DailyController.SelectDay(ctx, day);
                panel.actionHandle = action => Action(ctx, action);
            }
            panel.Init();
            Refresh(ctx);
            Tick(ctx, 0);
        }

        public static string Text(GameContext ctx, UINameType id) {
            var localization = ctx.l10NModule;
            if (!localization.TryGet(id, out string text)) {
                throw new InvalidOperationException("Missing daily text: " + id);
            }
            return text;
        }

        static UnityEngine.UI.Button Button(Panel_Daily panel, DailyActionType action) {
            return panel.buttons[(int)action - 1];
        }

        public static void Action(GameContext ctx, DailyActionType action) {
            var panels = ctx.panelRepository;
            if (!panels.TryGet(PanelType.Daily, out Panel_Daily panel)) {
                return;
            }
            switch (action) {
                case DailyActionType.Back: DailyController.Close(ctx); break;
                case DailyActionType.PreviousReward: DailyController.ChangeReward(ctx, -1); break;
                case DailyActionType.NextReward: DailyController.ChangeReward(ctx, 1); break;
                case DailyActionType.PreviousSeason: DailyController.ChangeSeason(ctx, -1); break;
                case DailyActionType.NextSeason: DailyController.ChangeSeason(ctx, 1); break;
                case DailyActionType.Claim: DailyController.Claim(ctx); break;
                case DailyActionType.Start: DailyController.Start(ctx); break;
                case DailyActionType.History: panel.ShowOverlay(1); Refresh(ctx); break;
                case DailyActionType.Info: panel.ShowOverlay(2); Refresh(ctx); break;
                case DailyActionType.Zoom: panel.ShowOverlay(3); Refresh(ctx); break;
                case DailyActionType.CloseOverlay: panel.ShowOverlay(0); break;
            }
        }

        public static void Refresh(GameContext ctx) {
            var panels = ctx.panelRepository;
            if (!panels.TryGet(PanelType.Daily, out Panel_Daily panel)) {
                return;
            }
            var state = ctx.state_Daily;
            var save = ctx.playerSave;
            var data = save.daily;
            var assets = ctx.assetModule;
            var config = assets.GetDailyConfig();
            var profile = assets.GetProfileConfig();
            var season = config.seasons[state.seasonIndex];
            var month = new DateTime(season.id / 100, season.id % 100, 1);
            int first = DailyController.Day(month);
            int dayCount = DateTime.DaysInMonth(month.Year, month.Month);
            int today = DailyController.Day(DateTime.Today);
            int units = Math.Min(season.pieces.Length, DailyController.Units(data, season.id));
            panel.titleLabel.text = string.Format(Text(ctx, UINameType.Daily_Title), month.Month);
            var remaining = month.AddMonths(1) - DateTime.Now;
            panel.timerLabel.text = remaining.TotalSeconds > 0 && first <= today ?
                string.Format(Text(ctx, UINameType.Daily_Timer), remaining.Days, remaining.Hours, remaining.Minutes, remaining.Seconds) :
                Text(ctx, first > today ? UINameType.Daily_NotStarted : UINameType.Daily_Ended);
            panel.artTitleLabel.text = Text(ctx, season.title);
            panel.ShowPieces(season, units, state.shownUnits);
            state.shownUnits = units;
            int costume = season.costumeIds[state.rewardIndex];
            int price = season.rewardPieces[state.rewardIndex];
            int available = DailyController.AvailablePieces(data, season);
            bool claimed = data.claimedCostumes.BinarySearch(costume) >= 0;
            panel.rewardFace.sprite = profile.avatars[0];
            panel.rewardImage.sprite = profile.costumes[costume];
            var fit = profile.costumeFits[costume * profile.avatars.Length];
            Rect box = profile.costumeRects[costume];
            Vector2 pivot = profile.costumeHeadPivot;
            Vector2 size = box.size * fit.scale;
            Vector2 center = pivot + fit.offset + (box.center - pivot) * fit.scale;
            var rewardRect = panel.rewardImage.rectTransform;
            rewardRect.anchorMin = center - size * .5f;
            rewardRect.anchorMax = center + size * .5f;
            rewardRect.pivot = new Vector2((pivot.x + fit.offset.x - rewardRect.anchorMin.x) / size.x,
                (pivot.y + fit.offset.y - rewardRect.anchorMin.y) / size.y);
            rewardRect.offsetMin = Vector2.zero;
            rewardRect.offsetMax = Vector2.zero;
            rewardRect.localRotation = Quaternion.Euler(0, 0, fit.rotation);
            panel.rewardNameLabel.text = string.Format(Text(ctx, UINameType.Daily_Limited), month.Month, Text(ctx, profile.costumeNames[costume]));
            panel.rewardProgressLabel.text = Math.Min(price, available) + " / " + price;
            panel.rewardBar.fillAmount = Mathf.Clamp01((float)available / price);
            panel.rewardHintLabel.text = claimed ? Text(ctx, UINameType.Daily_Claimed) :
                string.Format(Text(ctx, UINameType.Daily_Remaining), Math.Max(0, price - available));
            panel.rewardDotsLabel.text = string.Format(Text(ctx, UINameType.Daily_RewardPage), state.rewardIndex + 1, season.costumeIds.Length);
            panel.claimLabel.text = Text(ctx, claimed ? UINameType.Daily_Claimed : UINameType.Daily_Claim);
            bool current = season.id == DateTime.Today.Year * 100 + DateTime.Today.Month;
            Button(panel, DailyActionType.Claim).interactable = !claimed && available >= price && current;
            Button(panel, DailyActionType.Claim).gameObject.SetActive(!claimed && available >= price && current);
            int clear = 0;
            int perfect = 0;
            var history = new StringBuilder();
            for (int i = 0; i < panel.dayButtons.Length; i++) {
                bool visible = i < dayCount;
                panel.dayButtons[i].gameObject.SetActive(visible);
                if (!visible) {
                    continue;
                }
                int day = first + i;
                var record = DailyController.Record(data, day);
                bool won = record != null && record.cleared;
                bool perfectWin = won && record.perfect;
                clear += won && !perfectWin ? 1 : 0;
                perfect += perfectWin ? 1 : 0;
                panel.dayDiscs[i].color = day > today ? config.futureDayColor : day == state.selectedDay ? config.selectedDayColor : config.availableDayColor;
                panel.dayLabels[i].text = (i + 1).ToString();
                panel.dayLabels[i].color = day > today ? config.futureNumberColor : config.availableNumberColor;
                panel.dayStamps[i].gameObject.SetActive(won);
                panel.dayStamps[i].sprite = perfectWin ? config.perfectStamp : config.clearStamp;
                panel.dayLabels[i].gameObject.SetActive(!won);
                panel.dayButtons[i].interactable = day <= today;
                if (record != null) {
                    history.AppendFormat(Text(ctx, UINameType.Daily_HistoryRow), month.Month, i + 1,
                        Text(ctx, record.perfect ? UINameType.Daily_Perfect : record.cleared ? UINameType.Daily_Clear : UINameType.Daily_Attempted),
                        won ? Time(record.bestSeconds) : "—");
                    history.AppendLine();
                }
            }
            panel.clearLabel.text = string.Format(Text(ctx, UINameType.Daily_ClearCount), clear);
            panel.perfectLabel.text = string.Format(Text(ctx, UINameType.Daily_PerfectCount), perfect);
            var selected = DailyController.Record(data, state.selectedDay);
            var selectedDate = DailyController.Date(state.selectedDay);
            panel.statsLabel.text = string.Format(Text(ctx, UINameType.Daily_Stats), selectedDate.ToString("MM.dd"),
                selected != null && selected.cleared ? Time(selected.bestSeconds) : "—", Text(ctx, UINameType.Daily_RankUnavailable));
            var active = data.activePuzzle;
            bool resume = active != null && active.dailyDay == state.selectedDay && active.status != GameStatus.Won && active.status != GameStatus.Failed;
            UINameType start = resume ? UINameType.Daily_Continue : state.selectedDay > today ? UINameType.Daily_Future :
                selected != null ? UINameType.Daily_Retry : state.selectedDay < today ? UINameType.Daily_Makeup : UINameType.Daily_Start;
            panel.startLabel.text = Text(ctx, start);
            Button(panel, DailyActionType.Start).interactable = state.selectedDay <= today;
            Button(panel, DailyActionType.PreviousSeason).interactable = state.seasonIndex > 0;
            Button(panel, DailyActionType.NextSeason).interactable = state.seasonIndex + 1 < config.seasons.Length;
            panel.noticeLabel.text = state.notice == UINameType.None ? string.Empty : Text(ctx, state.notice);
            panel.noticeRoot.SetActive(state.notice != UINameType.None);
            panel.historyLabel.text = history.Length == 0 ? Text(ctx, UINameType.Daily_NoRecords) : history.ToString();
            panel.overlayTitle.text = string.Format(Text(ctx, UINameType.Daily_HistoryTitle), month.Year, month.Month);
            if (panel.infoRoot.activeSelf) {
                panel.overlayTitle.text = Text(ctx, UINameType.Home_Daily);
            } else if (panel.zoomRoot.activeSelf) {
                panel.overlayTitle.text = Text(ctx, season.title);
            }
            panel.infoLabel.text = Text(ctx, UINameType.Daily_Rules);
            panel.closeLabel.text = Text(ctx, UINameType.Daily_Close);
            panel.zoomImage.sprite = season.artwork;
        }

        public static string Time(float seconds) {
            int whole = Mathf.FloorToInt(seconds);
            return (whole / 60).ToString("00") + ":" + (whole % 60).ToString("00");
        }

        public static void Tick(GameContext ctx, float deltaTime) {
            var panels = ctx.panelRepository;
            if (!panels.TryGet(PanelType.Daily, out Panel_Daily panel)) {
                return;
            }
            var state = ctx.state_Daily;
            var assets = ctx.assetModule;
            Rect area = Screen.safeArea;
            int width = Screen.width;
            int height = Screen.height;
            if (state.safeArea != area || state.screenWidth != width || state.screenHeight != height || deltaTime == 0) {
                state.safeArea = area;
                state.screenWidth = width;
                state.screenHeight = height;
                panel.ApplySafeArea(area, width, height);
            }
            var config = assets.GetDailyConfig();
            panel.Tick(deltaTime, config);
        }

        public static void Close(GameContext ctx) {
            var panels = ctx.panelRepository;
            if (panels.TryGet(PanelType.Daily, out Panel_Daily panel)) {
                panels.Remove(panel);
                panel.TearDown();
            }
        }
    }
}
