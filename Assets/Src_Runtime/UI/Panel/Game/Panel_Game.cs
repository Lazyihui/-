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
        public Sprite tutorialFingerOpen;
        public Sprite tutorialFingerPressed;
        public UnityEngine.UI.Image tutorialRipple;
        public UnityEngine.UI.Button tutorialActionButton;
        public UnityEngine.UI.Image tutorialHintIcon;
        public Action tutorialHintHandle;
        public Action tutorialConfirmHandle;
        int tutorialStep = -1;
        int tutorialTarget;
        int[] tutorialPath;
        float tutorialStarted;
        float tutorialCardStarted;
        bool tutorialNudge;
        bool tutorialSettling;
        float tutorialDimAlpha;
        float tutorialDimFrom;
        float tutorialDimTarget;
        GameConfigSO tutorialConfig;
        Vector3 tutorialRuleScale;
        Vector3 tutorialActionScale;
        Vector3 tutorialConfirmScale;
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
                tutorialActionButton == null || tutorialHintIcon == null || tutorialFinger.sprite == null || tutorialRipple.sprite == null ||
                tutorialFingerOpen == null || tutorialFingerPressed == null) {
                throw new InvalidOperationException("Panel_Game has missing serialized UI bindings.");
            }
            this.localization = localization;
            tutorialRuleScale = tutorialRule.transform.parent.localScale;
            tutorialActionScale = tutorialAction.transform.parent.localScale;
            tutorialConfirmScale = tutorialConfirm.transform.localScale;
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
        public void ConfigureTutorial(GameConfigSO config, bool animated) {
            tutorialConfig = config;
            tutorialDimAlpha = tutorialDim.color.a;
            board.ConfigureTutorial(config, animated);
            float cellSize = board.gridRoot.rect.width / config.tutorial.size;
            tutorialFinger.rectTransform.sizeDelta = Vector2.one * cellSize * config.tutorialHandScale;
            tutorialRipple.rectTransform.sizeDelta = Vector2.one * cellSize;
        }
        public void ShowTutorial(bool visible, int step, int target, int[] path, bool settling = false, bool nudge = false) {
            tutorialRoot.SetActive(visible);
            tutorialDim.gameObject.SetActive(visible);
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
                tutorialCardStarted = Time.unscaledTime;
                tutorialDimFrom = tutorialStep < 0 ? 0 : tutorialDim.color.a;
                tutorialDimTarget = step != 1 && step < 6 ? tutorialDimAlpha : 0;
                if (step == 7) {
                    board.CelebrateTutorial(tutorialConfig.tutorialCelebrateSeconds);
                }
            }
            if (tutorialStep != step || tutorialTarget != target || tutorialNudge != nudge || tutorialSettling != settling) {
                tutorialStarted = Time.unscaledTime;
            }
            if (tutorialStep != step || tutorialSettling != settling) {
                tutorialStep = step;
                board.CancelGesture();
            }
            tutorialSettling = settling;
            tutorialNudge = nudge;
            tutorialTarget = target;
            tutorialPath = path;
            tutorialActionButton.interactable = step == 6;
            tutorialHintIcon.gameObject.SetActive(step == 6);
            tutorialConfirm.gameObject.SetActive(step == 1 || step == 7);
            tutorialAction.transform.parent.gameObject.SetActive(step == 2 || step == 4 || step == 6);
            bool showFinger = !settling && (target >= 0 || path != null || nudge);
            tutorialFinger.gameObject.SetActive(showFinger);
            tutorialRipple.gameObject.SetActive(showFinger);
            Update();
        }
        void Update() {
            if (!tutorialRoot.activeSelf || tutorialConfig == null) {
                return;
            }
            float cardElapsed = Time.unscaledTime - tutorialCardStarted;
            float alpha = Mathf.SmoothStep(0, 1, cardElapsed / tutorialConfig.tutorialCardFadeSeconds);
            tutorialRule.alpha = alpha;
            tutorialAction.alpha = alpha;
            tutorialConfirmLabel.alpha = alpha;
            float cardScale = Mathf.Lerp(0.94f, 1, alpha);
            tutorialRule.transform.parent.localScale = tutorialRuleScale * cardScale;
            tutorialAction.transform.parent.localScale = tutorialActionScale * cardScale;
            tutorialConfirm.transform.localScale = tutorialConfirmScale * cardScale;
            var dim = tutorialDim.color;
            dim.a = Mathf.Lerp(tutorialDimFrom, tutorialDimTarget, Mathf.SmoothStep(0, 1, cardElapsed / tutorialConfig.tutorialDimFadeSeconds));
            tutorialDim.color = dim;
            if (!tutorialFinger.gameObject.activeSelf) {
                return;
            }
            float time = Time.unscaledTime - tutorialStarted;
            float press = tutorialConfig.tutorialFingerPressSeconds;
            float release = tutorialConfig.tutorialFingerReleaseSeconds;
            float rest = tutorialConfig.tutorialFingerRestSeconds;
            Vector3 point;
            float rippleElapsed;
            bool pressing;
            if (tutorialStep == 4 && tutorialPath != null) {
                float phase = Mathf.Repeat(time, press + tutorialConfig.tutorialFingerDragSeconds + release + rest);
                float travel = Mathf.Clamp01((phase - press) / tutorialConfig.tutorialFingerDragSeconds) * (tutorialPath.Length - 1);
                int from = Mathf.FloorToInt(travel);
                point = Vector3.Lerp(board.CellPosition(tutorialPath[from]), board.CellPosition(tutorialPath[Mathf.Min(from + 1, tutorialPath.Length - 1)]), travel - from);
                pressing = phase < press + tutorialConfig.tutorialFingerDragSeconds;
                rippleElapsed = phase;
            } else {
                if (tutorialNudge) {
                    var card = (RectTransform)tutorialActionButton.transform;
                    point = card.TransformPoint(new Vector3(card.rect.center.x, card.rect.yMax * 0.75f, 0));
                } else {
                    point = board.CellPosition(tutorialTarget);
                }
                int count = tutorialStep == 0 || tutorialStep == 3 || tutorialStep == 5 ? 2 : 1;
                float phase = Mathf.Repeat(time, count * (press + release) + rest);
                int tap = Mathf.Min(count - 1, Mathf.FloorToInt(phase / (press + release)));
                rippleElapsed = phase - tap * (press + release);
                pressing = phase < count * (press + release) && rippleElapsed < press;
            }
            tutorialFinger.rectTransform.position = point;
            tutorialRipple.rectTransform.position = point;
            tutorialFinger.sprite = pressing ? tutorialFingerPressed : tutorialFingerOpen;
            float fingerScale = Mathf.MoveTowards(tutorialFinger.rectTransform.localScale.x, pressing ? 0.94f : 1,
                Time.unscaledDeltaTime * 0.06f / (pressing ? press : release));
            tutorialFinger.rectTransform.localScale = Vector3.one * fingerScale;
            float pulse = Mathf.Clamp01(rippleElapsed / tutorialConfig.tutorialRippleSeconds);
            tutorialRipple.rectTransform.localScale = Vector3.one * Mathf.Lerp(tutorialConfig.tutorialRippleFrom, tutorialConfig.tutorialRippleTo, pulse);
            tutorialRipple.color = new Color(1, 1, 1, (1 - pulse) * tutorialConfig.tutorialRippleAlpha);
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
