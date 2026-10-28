using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Hamdoku {
    public sealed class Panel_Daily : MonoBehaviour, IPanelAsset {
        public RectTransform safeRoot;
        public RectTransform contentRoot;
        public TMP_Text titleLabel;
        public TMP_Text timerLabel;
        public TMP_Text artTitleLabel;
        public TMP_Text rewardNameLabel;
        public TMP_Text rewardProgressLabel;
        public TMP_Text rewardHintLabel;
        public TMP_Text rewardDotsLabel;
        public TMP_Text clearLabel;
        public TMP_Text perfectLabel;
        public TMP_Text statsLabel;
        public TMP_Text startLabel;
        public TMP_Text claimLabel;
        public TMP_Text noticeLabel;
        public GameObject noticeRoot;
        public UnityEngine.UI.Image rewardImage;
        public UnityEngine.UI.Image rewardFace;
        public UnityEngine.UI.Image rewardBar;
        public UnityEngine.UI.Image puzzleLines;
        public UnityEngine.UI.Image[] pieces;
        public UnityEngine.UI.Image[] dayDiscs;
        public UnityEngine.UI.Image[] dayStamps;
        public TMP_Text[] dayLabels;
        public UnityEngine.UI.Button[] dayButtons;
        public UnityEngine.UI.Button[] buttons;
        public GameObject overlayRoot;
        public GameObject historyRoot;
        public GameObject infoRoot;
        public GameObject zoomRoot;
        public TMP_Text overlayTitle;
        public TMP_Text historyLabel;
        public TMP_Text infoLabel;
        public TMP_Text closeLabel;
        public UnityEngine.UI.Image zoomImage;
        public Action<int> dayHandle;
        public Action<DailyActionType> actionHandle;
        L10NModule localization;
        UnityAction[] dayListeners;
        UnityAction[] actionListeners;
        float[] revealTimes;
        bool[] revealed;
        int displayedSeason;

        public PanelType Type {
            get {
                return PanelType.Daily;
            }
        }

        public void Ctor(L10NModule source) {
            localization = source;
            foreach (var text in GetComponentsInChildren<TMP_Text>(true)) {
                localization.TMP_Register(text);
            }
            dayListeners = new UnityAction[dayButtons.Length];
            for (int i = 0; i < dayButtons.Length; i++) {
                int day = i + 1;
                dayListeners[i] = () => dayHandle?.Invoke(day);
                dayButtons[i].onClick.AddListener(dayListeners[i]);
            }
            actionListeners = new UnityAction[buttons.Length];
            for (int i = 0; i < buttons.Length; i++) {
                var action = (DailyActionType)(i + 1);
                actionListeners[i] = () => actionHandle?.Invoke(action);
                buttons[i].onClick.AddListener(actionListeners[i]);
            }
            revealTimes = new float[pieces.Length];
            revealed = new bool[pieces.Length];
        }

        public void Init() {
            ShowOverlay(0);
        }

        public void ShowOverlay(int mode) {
            overlayRoot.SetActive(mode != 0);
            historyRoot.SetActive(mode == 1);
            infoRoot.SetActive(mode == 2);
            zoomRoot.SetActive(mode == 3);
        }

        public void ShowPieces(DailySeasonSO season, int units, int previousUnits) {
            bool changed = displayedSeason != season.id;
            displayedSeason = season.id;
            puzzleLines.sprite = season.lines;
            for (int i = 0; i < pieces.Length; i++) {
                var image = pieces[i];
                image.gameObject.SetActive(i < season.pieces.Length);
                if (i >= season.pieces.Length) {
                    continue;
                }
                int index = season.revealOrder[i];
                Rect rect = season.pieceRects[index];
                var transform = image.rectTransform;
                transform.anchorMin = rect.min;
                transform.anchorMax = rect.max;
                transform.offsetMin = Vector2.zero;
                transform.offsetMax = Vector2.zero;
                bool show = i < units;
                image.sprite = show ? season.pieces[index] : season.lockedPieces[index];
                if (changed || !show) {
                    revealTimes[i] = changed && show && i >= previousUnits ? 0 : -1;
                    transform.localScale = Vector3.one;
                } else if (!revealed[i]) {
                    revealTimes[i] = 0;
                }
                revealed[i] = show;
            }
        }

        public void Tick(float deltaTime, DailyConfigSO config) {
            for (int i = 0; i < pieces.Length; i++) {
                if (revealTimes[i] < 0 || !pieces[i].gameObject.activeSelf) {
                    continue;
                }
                revealTimes[i] += deltaTime;
                float t = Mathf.Clamp01(revealTimes[i] / config.revealSeconds);
                pieces[i].rectTransform.localScale = Vector3.one * (1 + config.revealScale * Mathf.Sin(t * Mathf.PI));
                if (t >= 1) {
                    revealTimes[i] = -1;
                }
            }
        }

        public void ApplySafeArea(Rect area, int width, int height) {
            safeRoot.anchorMin = new Vector2(area.xMin / width, area.yMin / height);
            safeRoot.anchorMax = new Vector2(area.xMax / width, area.yMax / height);
            safeRoot.offsetMin = Vector2.zero;
            safeRoot.offsetMax = Vector2.zero;
            Canvas.ForceUpdateCanvases();
            Vector2 available = safeRoot.rect.size;
            Vector2 authored = contentRoot.sizeDelta;
            contentRoot.localScale = Vector3.one * Mathf.Min(available.x / authored.x, available.y / authored.y);
        }

        public void TearDown() {
            for (int i = 0; i < dayButtons.Length; i++) {
                dayButtons[i].onClick.RemoveListener(dayListeners[i]);
            }
            for (int i = 0; i < buttons.Length; i++) {
                buttons[i].onClick.RemoveListener(actionListeners[i]);
            }
            foreach (var text in GetComponentsInChildren<TMP_Text>(true)) {
                localization.TMP_Unregister(text);
            }
            dayHandle = null;
            actionHandle = null;
            Destroy(gameObject);
        }
    }
}
