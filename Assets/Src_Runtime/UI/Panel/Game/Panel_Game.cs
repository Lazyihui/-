using System;
using TMPro;
using UnityEngine;
namespace Hamdoku {
    public sealed class Panel_Game : MonoBehaviour, IPanelAsset {
        public RectTransform safeRoot;
        public RectTransform contentRoot;
        public Widget_Board board;
        public TMP_Text levelLabel;
        public TMP_Text scoreLabel;
        public TMP_Text countLabel;
        public TMP_Text timeLabel;
        public TMP_Text instructionLabel;
        public TMP_Text noticeLabel;
        public TMP_Text hintLabel;
        public TMP_Text guideLabel;
        public TMP_Text hintCount;
        public TMP_Text guideCount;
        public TMP_Text[] ruleLabels;
        public UnityEngine.UI.Image[] hearts;
        public UnityEngine.UI.Button homeButton;
        public UnityEngine.UI.Button restartButton;
        public UnityEngine.UI.Button shopButton;
        public UnityEngine.UI.Button settingsButton;
        public UnityEngine.UI.Button hintButton;
        public UnityEngine.UI.Button guideButton;
        public Action homeHandle;
        public Action restartHandle;
        public Action shopHandle;
        public Action settingsHandle;
        public Action hintHandle;
        public Action guideHandle;
        L10NModule localization;
        public PanelType Type {
            get {
                return PanelType.Game;
            }
        }
        public void Ctor(L10NModule localization) {
            if (safeRoot == null || contentRoot == null || board == null || levelLabel == null || scoreLabel == null ||
                countLabel == null || timeLabel == null || instructionLabel == null || noticeLabel == null ||
                hintLabel == null || guideLabel == null || hintCount == null || guideCount == null ||
                homeButton == null || restartButton == null || shopButton == null || settingsButton == null || hintButton == null || guideButton == null ||
                ruleLabels == null || ruleLabels.Length != 3 || hearts == null || hearts.Length == 0) {
                throw new InvalidOperationException("Panel_Game has missing serialized UI bindings.");
            }
            this.localization = localization;
            foreach (var text in GetComponentsInChildren<TMP_Text>(true)) {
                localization.TMP_Register(text);
            }
            homeButton.onClick.AddListener(ReportHome);
            restartButton.onClick.AddListener(ReportRestart);
            shopButton.onClick.AddListener(ReportShop);
            settingsButton.onClick.AddListener(ReportSettings);
            hintButton.onClick.AddListener(ReportHint);
            guideButton.onClick.AddListener(ReportGuide);
        }
        public void Init() {
            board.CancelGesture();
            ApplySafeArea(Screen.safeArea, Screen.width, Screen.height);
        }
        public void ApplySafeArea(Rect area, int width, int height) {
            safeRoot.anchorMin = new Vector2(area.xMin / width, area.yMin / height);
            safeRoot.anchorMax = new Vector2(area.xMax / width, area.yMax / height);
            safeRoot.offsetMin = Vector2.zero;
            safeRoot.offsetMax = Vector2.zero;
            Canvas.ForceUpdateCanvases();
            var available = safeRoot.rect.size;
            var authored = contentRoot.sizeDelta;
            contentRoot.localScale = Vector3.one * Mathf.Min(available.x / authored.x, available.y / authored.y);
        }
        void ReportHome() {
            homeHandle?.Invoke();
        }
        void ReportRestart() {
            restartHandle?.Invoke();
        }
        void ReportShop() {
            shopHandle?.Invoke();
        }
        void ReportSettings() {
            settingsHandle?.Invoke();
        }
        void ReportHint() {
            hintHandle?.Invoke();
        }
        void ReportGuide() {
            guideHandle?.Invoke();
        }
        public void TearDown() {
            board.TearDown();
            homeButton.onClick.RemoveListener(ReportHome);
            restartButton.onClick.RemoveListener(ReportRestart);
            shopButton.onClick.RemoveListener(ReportShop);
            settingsButton.onClick.RemoveListener(ReportSettings);
            hintButton.onClick.RemoveListener(ReportHint);
            guideButton.onClick.RemoveListener(ReportGuide);
            foreach (var text in GetComponentsInChildren<TMP_Text>(true)) {
                localization.TMP_Unregister(text);
            }
            homeHandle = null;
            restartHandle = null;
            shopHandle = null;
            settingsHandle = null;
            hintHandle = null;
            guideHandle = null;
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
