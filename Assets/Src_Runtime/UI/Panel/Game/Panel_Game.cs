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
        public TMP_Text gainLabel;
        public TMP_Text comboLabel;
        public UnityEngine.UI.Image[] comboSparkles;
        public UnityEngine.UI.Image[] comboConfetti;
        public UnityEngine.UI.Image comboCelebration;
        int feedbackCombo;
        int celebrationTheme;
        Vector3 celebrationFrom;
        float feedbackStarted = float.NegativeInfinity;
        Vector3 gainFrom;
        Vector3 comboFrom;

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
        PuzzlePresentationSO tutorialConfig;
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
                gainLabel == null || comboLabel == null || countLabel == null || timeLabel == null || instructionLabel == null || noticeLabel == null ||
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
            tutorialDimAlpha = tutorialDim.color.a;
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
            ClearFeedback();
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
        public void ConfigureTutorial(PuzzlePresentationSO config, bool animated, int tutorialSize) {
            if (comboSparkles == null || comboSparkles.Length != 4 || comboConfetti == null || comboConfetti.Length != 32 ||
                comboCelebration == null || config.comboStart < 1 || config.comboMaxTier < config.comboStart ||
                config.comboColors == null || config.comboColors.Length != config.comboMaxTier - config.comboStart + 1 ||
                config.comboConfettiStart < config.comboStart || config.comboPopSeconds <= 0 || config.comboSeconds <= 0 ||
                config.comboConfettiSeconds <= 0 || config.comboHoldRatio <= 0 || config.comboHoldRatio >= 1 ||
                config.comboCelebrationSeconds <= 0 || config.comboCelebrationFrameSeconds <= 0 ||
                config.comboCelebrationFrameCounts == null || config.comboCelebrationFrameCounts.Length != 6 ||
                config.comboCelebrationFrames == null) {
                throw new InvalidOperationException("Missing or invalid game feedback configuration / prefab bindings.");
            }
            int frames = 0;
            foreach (int count in config.comboCelebrationFrameCounts) {
                if (count < 1) {
                    throw new InvalidOperationException("Invalid combo celebration frame count.");
                }
                frames += count;
            }
            if (frames != config.comboCelebrationFrames.Length) {
                throw new InvalidOperationException("Combo celebration frame counts do not match the bound sprites.");
            }
            foreach (var sprite in config.comboCelebrationFrames) {
                if (sprite == null) {
                    throw new InvalidOperationException("Missing combo celebration sprite.");
                }
            }
            foreach (var image in comboSparkles) {
                ValidateEffectImage(image);
            }
            foreach (var image in comboConfetti) {
                ValidateEffectImage(image);
            }
            tutorialConfig = config;
            board.ConfigureTutorial(config, animated);
            float cellSize = board.gridRoot.rect.width / tutorialSize;
            tutorialFinger.rectTransform.sizeDelta = Vector2.one * cellSize * config.tutorialHandScale;
            tutorialRipple.rectTransform.sizeDelta = Vector2.one * cellSize;
        }
        static void ValidateEffectImage(UnityEngine.UI.Image image) {
            if (image == null || image.sprite == null || image.raycastTarget) {
                throw new InvalidOperationException("Missing combo effect image or decoration intercepts input.");
            }
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
                    board.CelebrateCharacters();
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
        public void ClearFeedback() {
            feedbackStarted = float.NegativeInfinity;
            gainLabel.text = string.Empty;
            comboLabel.text = string.Empty;
            gainLabel.alpha = 0;
            comboLabel.alpha = 0;
            feedbackCombo = 0;
            comboLabel.rectTransform.localScale = Vector3.one;
            if (comboCelebration != null) {
                comboCelebration.enabled = false;
            }
            if (comboSparkles != null) {
                foreach (var image in comboSparkles) {
                    image.enabled = false;
                }
            }
            if (comboConfetti != null) {
                foreach (var image in comboConfetti) {
                    image.enabled = false;
                }
            }
        }
        public void ShowGain(int index, string gain, string combo, int comboCount) {
            ClearFeedback();
            feedbackCombo = comboCount;
            gainLabel.text = gain;
            gainLabel.alpha = 1;
            comboLabel.alpha = 1;
            comboLabel.text = combo;
            gainFrom = contentRoot.InverseTransformPoint(board.CellPosition(index));
            comboFrom = contentRoot.InverseTransformPoint(board.gridRoot.TransformPoint(board.gridRoot.rect.center));
            gainLabel.rectTransform.localPosition = gainFrom;
            comboLabel.rectTransform.localPosition = comboFrom;
            comboLabel.fontSize = tutorialConfig.comboFontSize;
            if (comboCount >= tutorialConfig.comboStart) {
                int tier = Mathf.Min(comboCount, tutorialConfig.comboMaxTier);
                comboLabel.color = tutorialConfig.comboColors[tier - tutorialConfig.comboStart];
                celebrationTheme = (comboCount - tutorialConfig.comboStart) % tutorialConfig.comboCelebrationFrameCounts.Length;
                celebrationFrom = gainFrom;
            }
            feedbackStarted = Time.unscaledTime;
            UpdateFeedback();
        }
        void UpdateFeedback() {
            if (tutorialConfig == null || float.IsNegativeInfinity(feedbackStarted)) {
                return;
            }
            float elapsed = Time.unscaledTime - feedbackStarted;
            float lifetime = Mathf.Max(tutorialConfig.gainSeconds, tutorialConfig.comboSeconds,
                tutorialConfig.comboConfettiSeconds, tutorialConfig.comboCelebrationSeconds);
            if (elapsed >= lifetime) {
                ClearFeedback();
                return;
            }
            float gainProgress = Mathf.Clamp01(elapsed / tutorialConfig.gainSeconds);
            Vector3 target = contentRoot.InverseTransformPoint(scoreLabel.transform.position);
            gainLabel.rectTransform.localPosition = Vector3.Lerp(gainFrom, target, Mathf.SmoothStep(0, 1, gainProgress));
            gainLabel.alpha = 1 - gainProgress;
            float comboProgress = Mathf.Clamp01(elapsed / tutorialConfig.comboSeconds);
            comboLabel.rectTransform.localPosition = comboFrom + Vector3.up * (comboProgress * tutorialConfig.comboRiseRatio * board.gridRoot.rect.height / board.Size);
            float fade = Mathf.Clamp01((comboProgress - tutorialConfig.comboHoldRatio) / (1 - tutorialConfig.comboHoldRatio));
            comboLabel.alpha = feedbackCombo >= tutorialConfig.comboStart ? 1 - fade : 0;
            float pop = Mathf.Clamp01(elapsed / tutorialConfig.comboPopSeconds);
            float scale = pop < 0.6f ? Mathf.Lerp(0.35f, tutorialConfig.comboPeakScale, Mathf.Sin(pop / 0.6f * Mathf.PI * 0.5f)) :
                Mathf.Lerp(tutorialConfig.comboPeakScale, 1, Mathf.SmoothStep(0, 1, (pop - 0.6f) / 0.4f));
            comboLabel.rectTransform.localScale = Vector3.one * scale;
            AnimateCombo(elapsed, comboProgress, fade);
            if (gainProgress >= 1) {
                gainLabel.text = string.Empty;
            }
            if (comboProgress >= 1) {
                comboLabel.text = string.Empty;
            }
        }
        void AnimateCombo(float elapsed, float progress, float fade) {
            var config = tutorialConfig;
            bool active = feedbackCombo >= config.comboStart && progress < 1;
            int tier = Mathf.Min(feedbackCombo, config.comboMaxTier);
            float width = Mathf.Max(comboLabel.preferredWidth, config.comboFontSize * 3);
            Vector3 center = comboLabel.rectTransform.localPosition;
            for (int i = 0; i < comboSparkles.Length; i++) {
                var image = comboSparkles[i];
                float phase = Mathf.Clamp01(progress * 1.6f - i * 0.12f);
                image.enabled = active && phase > 0 && phase < 1;
                image.rectTransform.localPosition = center + new Vector3((i % 2 == 0 ? -1 : 1) * width * 0.52f,
                    (i < 2 ? 1 : -1) * config.comboFontSize * 0.48f, 0);
                image.rectTransform.localScale = Vector3.one * Mathf.Sin(phase * Mathf.PI);
                image.rectTransform.localRotation = Quaternion.Euler(0, 0, phase * 100 + i * 30);
                image.rectTransform.sizeDelta = Vector2.one * config.comboSparkleSize;
                image.color = new Color(1, 0.92f, 0.6f, 1 - fade);
            }
            float life = elapsed / config.comboConfettiSeconds;
            int count = feedbackCombo >= config.comboConfettiStart ? Mathf.Min(comboConfetti.Length, 16 + (tier - config.comboConfettiStart) * 4) : 0;
            for (int i = 0; i < comboConfetti.Length; i++) {
                var image = comboConfetti[i];
                image.enabled = i < count && life >= 0 && life < 1;
                float angle = (25 + i * 137.508f % 130) * Mathf.Deg2Rad;
                float speed = config.comboConfettiSpeed * (0.65f + (i % 5) * 0.1f);
                image.rectTransform.localPosition = comboFrom + new Vector3((i % 8 / 7f - 0.5f) * width + Mathf.Cos(angle) * speed * elapsed,
                    config.comboFontSize * 0.65f + Mathf.Sin(angle) * speed * elapsed - config.comboConfettiGravity * elapsed * elapsed * 0.5f, 0);
                image.rectTransform.localRotation = Quaternion.Euler(0, 0, i * 37 + elapsed * config.comboConfettiSpin * (i % 2 == 0 ? 1 : -1));
                image.rectTransform.localScale = new Vector3(Mathf.Cos(elapsed * 9 + i), 1, 1);
                Color color = config.comboColors[i % config.comboColors.Length];
                color.a = 1 - Mathf.Clamp01((life - 0.55f) / 0.45f);
                image.color = color;
            }
            float celebration = elapsed / config.comboCelebrationSeconds;
            comboCelebration.enabled = feedbackCombo >= config.comboStart && celebration >= 0 && celebration < 1;
            if (comboCelebration.enabled) {
                int offset = 0;
                for (int i = 0; i < celebrationTheme; i++) {
                    offset += config.comboCelebrationFrameCounts[i];
                }
                int frame = Mathf.FloorToInt(elapsed / config.comboCelebrationFrameSeconds) % config.comboCelebrationFrameCounts[celebrationTheme];
                comboCelebration.sprite = config.comboCelebrationFrames[offset + frame];
                float size = board.gridRoot.rect.width / board.Size * config.comboCelebrationSize;
                comboCelebration.rectTransform.sizeDelta = Vector2.one * size;
                comboCelebration.rectTransform.localPosition = celebrationFrom + Vector3.up * size * config.comboCelebrationRise * celebration;
                comboCelebration.rectTransform.localScale = Vector3.one * Mathf.Sin(Mathf.Clamp01(celebration * 3) * Mathf.PI * 0.5f);
                comboCelebration.color = new Color(1, 1, 1, 1 - Mathf.Clamp01((celebration - 0.7f) / 0.3f));
            }
        }
        void Update() {
            UpdateFeedback();
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
            ClearFeedback();
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
