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
        public GameObject tutorialRoot;
        public UnityEngine.UI.Image tutorialDim;
        public TMP_Text tutorialRule;
        public TMP_Text tutorialAction;
        public TMP_Text tutorialConfirmLabel;
        public UnityEngine.UI.Button tutorialConfirm;
        public UnityEngine.UI.Image tutorialFinger;
        public UnityEngine.UI.Image tutorialRipple;
        public UnityEngine.UI.Button tutorialActionButton;
        public UnityEngine.UI.Image tutorialHintIcon;
        public Action tutorialHintHandle;
        public Action tutorialConfirmHandle;
        int tutorialStep = -1;
        int tutorialTarget;
        int[] tutorialPath;
        float tutorialStarted;
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
                ruleLabels == null || ruleLabels.Length != 3 || hearts == null || hearts.Length == 0 ||
                tutorialRoot == null || tutorialDim == null || tutorialRule == null || tutorialAction == null ||
                tutorialConfirmLabel == null || tutorialConfirm == null || tutorialFinger == null || tutorialRipple == null ||
                tutorialActionButton == null || tutorialHintIcon == null) {
                throw new InvalidOperationException("Panel_Game has missing serialized UI bindings.");
            }
            this.localization = localization;
            foreach (var text in GetComponentsInChildren<TMP_Text>(true)) {
                localization.TMP_Register(text);
            }
            tutorialActionButton.onClick.AddListener(ReportTutorialHint);
            tutorialConfirm.onClick.AddListener(ReportTutorialConfirm);
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
        public void ShowTutorial(bool visible, int step, int target, int[] path) {
            tutorialRoot.SetActive(visible);
            tutorialDim.gameObject.SetActive(visible && step != 1 && step < 6);
            var frame = board.gridRoot.parent.GetComponent<UnityEngine.UI.Image>();
            frame.color = visible && step != 1 && step < 6 ? new Color(0.32f, 0.32f, 0.32f, 1) : Color.white;
            scoreLabel.gameObject.SetActive(!visible);
            homeButton.gameObject.SetActive(!visible);
            shopButton.gameObject.SetActive(!visible);
            settingsButton.gameObject.SetActive(!visible);
            restartButton.gameObject.SetActive(!visible);
            hintButton.transform.parent.gameObject.SetActive(!visible);
            ruleLabels[0].transform.parent.parent.gameObject.SetActive(!visible);
            levelLabel.rectTransform.anchoredPosition = new Vector2(visible ? 0 : -100, 55);
            if (!visible) {
                tutorialStep = -1;
                return;
            }
            if (tutorialStep != step) {
                tutorialStarted = Time.unscaledTime;
                tutorialStep = step;
                board.CancelGesture();
            }
            tutorialTarget = target;
            tutorialPath = path;
            tutorialActionButton.interactable = step == 6;
            tutorialHintIcon.gameObject.SetActive(step == 6);
            tutorialConfirm.gameObject.SetActive(step == 1 || step == 7);
            tutorialAction.transform.parent.gameObject.SetActive(step == 2 || step == 4 || step == 6);
            tutorialFinger.gameObject.SetActive(target >= 0 || path != null);
            tutorialRipple.gameObject.SetActive(target >= 0 || path != null);
            Update();
        }
        void Update() {
            if (!tutorialRoot.activeSelf || !tutorialFinger.gameObject.activeSelf) {
                return;
            }
            float time = Time.unscaledTime - tutorialStarted;
            int index = tutorialTarget;
            if (tutorialPath != null && tutorialPath.Length > 0) {
                index = tutorialPath[Mathf.FloorToInt(time / 1.3f) % tutorialPath.Length];
            }
            Vector3 point = board.CellPosition(index);
            if (tutorialStep == 4 && tutorialPath != null) {
                float travel = Mathf.Repeat(time / 2.4f, 1) * (tutorialPath.Length - 1);
                int from = Mathf.FloorToInt(travel);
                point = Vector3.Lerp(board.CellPosition(tutorialPath[from]), board.CellPosition(tutorialPath[Mathf.Min(from + 1, tutorialPath.Length - 1)]), travel - from);
            }
            tutorialFinger.rectTransform.position = point;
            tutorialRipple.rectTransform.position = point;
            float pulse = Mathf.Repeat(time * (tutorialTarget >= 0 ? 2.5f : 1.5f), 1);
            tutorialFinger.rectTransform.localScale = Vector3.one * Mathf.Lerp(0.9f, 1, pulse);
            tutorialRipple.rectTransform.localScale = Vector3.one * Mathf.Lerp(0.4f, 1.2f, pulse);
            tutorialRipple.color = new Color(1, 1, 1, (1 - pulse) * 0.6f);
        }
        void ReportTutorialHint() {
            tutorialHintHandle?.Invoke();
        }
        void ReportTutorialConfirm() {
            tutorialConfirmHandle?.Invoke();
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
            tutorialActionButton.onClick.RemoveListener(ReportTutorialHint);
            tutorialHintHandle = null;
            tutorialConfirm.onClick.RemoveListener(ReportTutorialConfirm);
            tutorialConfirmHandle = null;
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
