using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
namespace Hamdoku {
    public sealed class Panel_GameResult : MonoBehaviour, IPanelAsset {
        public RectTransform rewardProgressRoot;
        public TMP_Text rewardProgressLabel;
        public UnityEngine.UI.Image[] rewardTicks;
        public RectTransform safeRoot;
        public RectTransform contentRoot;
        public TMP_Text titleLabel;
        public Image hero;
        public TMP_Text messageLabel;
        public TMP_Text remainingLabel;
        public TMP_Text statusLabel;
        public TMP_Text[] statLabels;
        public TMP_Text[] statValues;
        public TMP_Text primaryLabel;
        public TMP_Text secondaryLabel;
        public TMP_Text adLabel;
        public Button primaryButton;
        public Button secondaryButton;
        public Button adButton;
        public CanvasGroup heroGroup;
        public CanvasGroup statsGroup;
        public CanvasGroup buttonsGroup;
        public Action primaryHandle;
        public Action secondaryHandle;
        public Action adHandle;
        L10NModule localization;
        ResultConfigSO config;
        float started;
        bool won;
        int score;
        int bestCombo;
        bool comboKnown;
        public PanelType Type {
            get {
                return PanelType.GameResult;
            }
        }
        public void Ctor(L10NModule localization) {
            if (safeRoot == null || contentRoot == null || titleLabel == null || hero == null || messageLabel == null ||
                remainingLabel == null || statusLabel == null || primaryLabel == null || secondaryLabel == null || adLabel == null ||
                primaryButton == null || secondaryButton == null || adButton == null || heroGroup == null || statsGroup == null || buttonsGroup == null ||
                statLabels == null || statValues == null || statLabels.Length != 3 || statValues.Length != 3 ||
                rewardProgressRoot == null || rewardProgressLabel == null || rewardTicks == null || rewardTicks.Length == 0 || Array.Exists(rewardTicks, tick => tick == null)) {
                throw new InvalidOperationException("Panel_GameResult has missing serialized bindings.");
            }
            this.localization = localization;
            foreach (var text in GetComponentsInChildren<TMP_Text>(true)) {
                localization.TMP_Register(text);
            }
            primaryButton.onClick.AddListener(ReportPrimary);
            secondaryButton.onClick.AddListener(ReportSecondary);
            adButton.onClick.AddListener(ReportAd);
        }
        public void Init(ResultConfigSO config, bool won, int score, int bestCombo, bool comboKnown, bool rewardMode = false, Sprite clearSprite = null) {
            this.config = config;
            this.won = won;
            this.score = score;
            this.bestCombo = bestCombo;
            this.comboKnown = comboKnown;
            started = Time.unscaledTime;
            if (won && !rewardMode && clearSprite == null) {
                throw new InvalidOperationException("A selected clear illustration is required.");
            }
            hero.sprite = rewardMode ? config.rewardHero : won ? clearSprite : config.failHero;
            hero.preserveAspect = true;
            Position(hero.rectTransform, rewardMode ? config.rewardHeroAnchorY : won ? config.clearHeroAnchorY : config.failHeroAnchorY);
            hero.rectTransform.sizeDelta = Vector2.one * (rewardMode ? config.rewardHeroSize : won ? config.clearHeroSize : config.failHeroSize);
            Position(titleLabel.rectTransform, config.titleAnchorY);
            Position(messageLabel.rectTransform, rewardMode ? config.rewardMessageAnchorY : won ? config.messageAnchorY + config.rewardContentLiftY : config.failMessageAnchorY);
            if (won && !rewardMode) {
                // Preserve the authored size and move tall variants above the caption's full bounds.
                var heroRect = hero.rectTransform;
                var messageRect = messageLabel.rectTransform;
                var spriteRect = hero.sprite.rect;
                float imageHeight = heroRect.sizeDelta.y * Mathf.Min(1, spriteRect.height / spriteRect.width);
                float imageBottom = heroRect.anchoredPosition.y - imageHeight * .5f;
                float messageTop = messageRect.anchoredPosition.y + messageRect.rect.height * .5f;
                float lift = Mathf.Max(0, messageTop + config.clearHeroTextGap - imageBottom);
                heroRect.anchoredPosition += new Vector2(0, lift);
            }
            Position((RectTransform)statsGroup.transform, config.statRowAnchorY + (won ? config.rewardContentLiftY : 0));
            Position(remainingLabel.rectTransform, config.failRemainingAnchorY);
            Position(primaryButton.GetComponent<RectTransform>(), won ? config.clearButtonAnchorY : config.failRestartAnchorY);
            Position(adButton.GetComponent<RectTransform>(), rewardMode ? config.failContinueAnchorY + .08f : config.failContinueAnchorY);
            statsGroup.gameObject.SetActive(won && !rewardMode);
            remainingLabel.gameObject.SetActive(!won && !rewardMode);
            adButton.gameObject.SetActive(!won || rewardMode);
            statusLabel.gameObject.SetActive(!won || rewardMode);
            if (rewardMode) {
                Position(statusLabel.rectTransform, config.failContinueAnchorY + .015f);
            } else {
                statusLabel.rectTransform.anchoredPosition = new Vector2(0, -653);
            }
            rewardProgressRoot.gameObject.SetActive(won && !rewardMode);
            ApplySafeArea(Screen.safeArea, Screen.width, Screen.height);
            Update();
        }
        public void ShowRewardProgress(int filled, int total) {
            if (total != rewardTicks.Length || filled < 0 || filled > total) {
                throw new InvalidOperationException("Reward progress does not match authored ticks.");
            }
            for (int i = 0; i < rewardTicks.Length; i++) {
                rewardTicks[i].color = i < filled ? config.rewardTickColor : config.rewardTickColorEmpty;
            }
        }
        void Position(RectTransform rect, float anchorY) {
            rect.anchoredPosition = new Vector2(0, (anchorY - .5f) * contentRoot.sizeDelta.y);
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
        void Update() {
            if (config == null) {
                return;
            }
            float elapsed = Time.unscaledTime - started;
            heroGroup.alpha = Mathf.Clamp01((elapsed - (won ? config.revealHeroAt : 0)) / config.revealFadeSeconds);
            float heroScale = Mathf.Lerp(.86f, 1, Mathf.SmoothStep(0, 1, heroGroup.alpha));
            hero.transform.localScale = Vector3.one * heroScale;
            statsGroup.alpha = Mathf.Clamp01((elapsed - config.revealStatsAt) / config.revealFadeSeconds);
            float progress = Mathf.Clamp01((elapsed - config.revealStatsAt) / config.statCountUpSeconds);
            ShowStatistics(progress);
            float buttonAt = won ? config.revealButtonAt : config.failButtonsAt;
            buttonsGroup.alpha = Mathf.Clamp01((elapsed - buttonAt) / config.revealFadeSeconds);
            buttonsGroup.interactable = elapsed >= buttonAt + config.revealFadeSeconds;
            buttonsGroup.blocksRaycasts = buttonsGroup.interactable;
        }
        public void SetStatistics(int score, int bestCombo, bool comboKnown) {
            this.score = score;
            this.bestCombo = bestCombo;
            this.comboKnown = comboKnown;
            float elapsed = Time.unscaledTime - started;
            ShowStatistics(Mathf.Clamp01((elapsed - config.revealStatsAt) / config.statCountUpSeconds));
        }
        void ShowStatistics(float progress) {
            statValues[0].text = Mathf.RoundToInt(score * progress).ToString();
            statValues[1].text = comboKnown ? Mathf.RoundToInt(bestCombo * progress).ToString() : "—";
        }
        void ReportPrimary() {
            if (buttonsGroup.interactable) {
                buttonsGroup.interactable = false;
                primaryHandle?.Invoke();
            }
        }
        void ReportSecondary() {
            if (buttonsGroup.interactable) {
                buttonsGroup.interactable = false;
                secondaryHandle?.Invoke();
            }
        }
        void ReportAd() {
            if (buttonsGroup.interactable) {
                adHandle?.Invoke();
            }
        }
        public void TearDown() {
            foreach (var text in GetComponentsInChildren<TMP_Text>(true)) {
                localization.TMP_Unregister(text);
            }
            primaryButton.onClick.RemoveListener(ReportPrimary);
            secondaryButton.onClick.RemoveListener(ReportSecondary);
            adButton.onClick.RemoveListener(ReportAd);
            primaryHandle = null;
            secondaryHandle = null;
            adHandle = null;
            config = null;
            Destroy(gameObject);
        }
    }
}
