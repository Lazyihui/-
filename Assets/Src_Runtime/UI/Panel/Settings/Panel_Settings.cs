using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Hamdoku {
    public sealed class Panel_Settings : MonoBehaviour, IPanelAsset {
        public RectTransform safeRoot;
        public RectTransform contentRoot;
        public RectTransform closeRoot;
        public RectTransform groupRoot;
        public RectTransform accountRoot;
        public RectTransform dashRoot;
        public RectTransform restartRoot;
        public RectTransform tutorialRoot;
        public RectTransform linksRoot;
        public TMP_Text restartLabel;
        public TMP_Text title;
        public TMP_Text[] rowLabels;
        public TMP_Text[] switchLabels;
        public Image[] tracks;
        public RectTransform[] knobs;
        public TMP_Text voiceValue;
        public TMP_Text languageValue;
        public TMP_Text saveLabel;
        public TMP_Text tutorialLabel;
        public TMP_Text[] linkLabels;
        public TMP_Text versionLabel;
        public Button[] buttons;
        public SettingsActionType[] actions;
        public GameObject dialogRoot;
        public TMP_Text dialogTitle;
        public TMP_Text dialogBody;
        public Button chineseButton;
        public Button englishButton;
        public Button startButton;
        public TMP_Text chineseLabel;
        public TMP_Text englishLabel;
        public TMP_Text startLabel;
        public TMP_Text closeLabel;
        public Action<SettingsActionType> actionHandle;
        L10NModule localization;
        Rect previousSafeArea;
        Vector2Int previousScreen;
        public PanelType Type {
            get {
                return PanelType.Settings;
            }
        }
        public void Ctor(L10NModule localization) {
            if (safeRoot == null || contentRoot == null || closeRoot == null || groupRoot == null || accountRoot == null || dashRoot == null ||
                restartRoot == null || tutorialRoot == null || linksRoot == null || restartLabel == null || rowLabels.Length != 7 || tracks.Length != 5 || knobs.Length != 5 || switchLabels.Length != 5 ||
                buttons.Length != actions.Length || dialogRoot == null || chineseButton == null || englishButton == null || startButton == null) {
                throw new InvalidOperationException("Panel_Settings requires complete serialized bindings.");
            }
            this.localization = localization;
            foreach (var text in GetComponentsInChildren<TMP_Text>(true)) {
                localization.TMP_Register(text);
            }
            for (int i = 0; i < buttons.Length; i++) {
                var action = actions[i];
                buttons[i].onClick.AddListener(() => actionHandle?.Invoke(action));
            }
        }
        public void Init() {
            ApplySafeArea(Screen.safeArea, Screen.width, Screen.height);
        }
        public void ShowLayout(bool inGame, bool canRestart, SettingsConfigSO config) {
            accountRoot.gameObject.SetActive(!inGame);
            restartRoot.gameObject.SetActive(canRestart);
            float groupHeight = config.rowH * rowLabels.Length + config.groupPadV * 2;
            float groupTop = config.padTop + config.titleH + config.gapTitleGroup;
            float accountTop = groupTop + groupHeight + config.gapGroupAccount;
            float dashTop = groupTop + groupHeight + (!inGame ? config.gapGroupAccount + config.accountBlockH : 0) + config.gapGroupDash;
            float buttonTop = dashTop + config.dashThickness + config.gapDashBtn;
            float tutorialTop = buttonTop + (canRestart ? config.btnH + config.gapBtnBtn : 0);
            float linksTop = tutorialTop + config.btnH + config.gapBtnLinks;
            float versionTop = linksTop + config.linkRowH + config.gapLinksVersion;
            float height = versionTop + config.versionH + config.padBottom;
            contentRoot.sizeDelta = new Vector2(config.panelWidth, height);
            float top = height * .5f;
            SetY(title.rectTransform, top - config.padTop - config.titleH * .5f);
            SetY(closeRoot, top + config.closeOffset.y - config.closeSize * .5f);
            SetY(groupRoot, top - groupTop - groupHeight * .5f);
            SetY(accountRoot, top - accountTop - config.accountBlockH * .5f);
            SetY(dashRoot, top - dashTop - config.dashThickness * .5f);
            SetY(restartRoot, top - buttonTop - config.btnH * .5f);
            SetY(tutorialRoot, top - tutorialTop - config.btnH * .5f);
            SetY(linksRoot, top - linksTop - config.linkRowH * .5f);
            SetY(versionLabel.rectTransform, top - versionTop - config.versionH * .5f);
            ApplySafeArea(Screen.safeArea, Screen.width, Screen.height);
        }
        static void SetY(RectTransform rect, float y) {
            var position = rect.anchoredPosition;
            position.y = y;
            rect.anchoredPosition = position;
        }
        public void ApplySafeArea(Rect area, int width, int height) {
            safeRoot.anchorMin = new Vector2(area.xMin / width, area.yMin / height);
            safeRoot.anchorMax = new Vector2(area.xMax / width, area.yMax / height);
            safeRoot.offsetMin = Vector2.zero;
            safeRoot.offsetMax = Vector2.zero;
            Canvas.ForceUpdateCanvases();
            var size = safeRoot.rect.size;
            var authored = contentRoot.sizeDelta;
            contentRoot.localScale = Vector3.one * Mathf.Min(1, Mathf.Min(size.x * .94f / authored.x, size.y * .94f / authored.y));
            previousSafeArea = area;
            previousScreen = new Vector2Int(width, height);
        }
        public void RefreshSafeArea() {
            if (previousSafeArea != Screen.safeArea || previousScreen.x != Screen.width || previousScreen.y != Screen.height) {
                ApplySafeArea(Screen.safeArea, Screen.width, Screen.height);
            }
        }
        public void ShowSwitch(int index, bool enabled, SettingsConfigSO config) {
            tracks[index].color = enabled ? config.trackOnColor : config.trackOffColor;
            float travel = (config.toggleSize.x - config.knobSize) * .5f - config.knobInset;
            knobs[index].anchoredPosition = new Vector2(enabled ? travel : -travel, 0);
            var text = switchLabels[index];
            text.text = enabled ? "ON" : "OFF";
            text.rectTransform.anchoredPosition = new Vector2(enabled ? -config.toggleTextX : config.toggleTextX, 0);
        }
        public void TearDown() {
            foreach (var button in buttons) {
                button.onClick.RemoveAllListeners();
            }
            foreach (var text in GetComponentsInChildren<TMP_Text>(true)) {
                localization.TMP_Unregister(text);
            }
            actionHandle = null;
            localization = null;
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
