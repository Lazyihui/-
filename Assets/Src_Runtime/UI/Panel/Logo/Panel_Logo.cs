using System;
using UnityEngine;
using TMPro;

namespace Hamdoku {
    public sealed class Panel_Logo : MonoBehaviour {
        [SerializeField] public RectTransform safeRoot;
        [SerializeField] public RectTransform contentRoot;
        [SerializeField] public Widget_LogoIntro logoIntro;
        public TMP_Text quoteLabel;
        public TMP_Text authorLabel;
        public TMP_Text copyrightLabel;
        public UnityEngine.UI.Image[] seedFills;
        public UnityEngine.UI.Image[] seedEmpties;
        public RectTransform seedMark;
        L10NModule localization;
        LogoConfigSO config;
        float progress;
        float visualTime;
        float popAge;
        int presentedCount;
        public Action completedHandle;
        public Action<AudioClip, float> audioHandle;

        public void Ctor(L10NModule localization) {
            if (safeRoot == null || contentRoot == null || logoIntro == null) {
                throw new InvalidOperationException("Panel_Logo must bind SafeRoot, ContentRoot and Widget_LogoIntro.");
            }
            if (quoteLabel == null || authorLabel == null || copyrightLabel == null || seedFills == null || seedMark == null) {
                throw new InvalidOperationException("Panel_Logo must bind its authored quote, copyright and seed row.");
            }
            this.localization = localization;
            localization.TMP_Register(quoteLabel);
            localization.TMP_Register(authorLabel);
            localization.TMP_Register(copyrightLabel);
            logoIntro.completedHandle = () => {
                completedHandle?.Invoke();
            };
            logoIntro.audioHandle = (clip, volume) => {
                audioHandle?.Invoke(clip, volume);
            };
        }

        public void Init(LogoConfigSO config) {
            if (config.seedCount <= 0 || config.seedCount != seedFills.Length || seedEmpties.Length != seedFills.Length || config.minShowSeconds <= 0 || config.seedPopSeconds <= 0) {
                throw new InvalidOperationException("Invalid loading screen seed or timing configuration.");
            }
            this.config = config;
            progress = 0;
            visualTime = 0;
            popAge = 0;
            presentedCount = 0;
            logoIntro.Init(config);
            PresentSeeds();
        }

        public void Tick(float deltaTime) {
            logoIntro.Tick(deltaTime);
            visualTime += deltaTime;
            popAge += deltaTime;
            PresentSeeds();
        }

        public void SetText(string quote, string author, string copyright) {
            quoteLabel.text = quote;
            authorLabel.text = author;
            copyrightLabel.text = copyright;
        }

        public void SetProgress(float value) {
            progress = Mathf.Clamp01(value);
            int count = Mathf.FloorToInt(progress * seedFills.Length);
            if (count > presentedCount) {
                popAge = 0;
                presentedCount = count;
            }
            PresentSeeds();
        }

        void PresentSeeds() {
            int filled = Mathf.FloorToInt(progress * seedFills.Length);
            int active = Mathf.Max(0, filled - 1);
            for (int i = 0; i < seedFills.Length; i++) {
                var image = seedFills[i];
                image.enabled = i < filled;
                seedEmpties[i].enabled = i >= filled;
                float pulse = 1;
                if (i == active && filled > 0) {
                    float pop = Mathf.Clamp01(popAge / config.seedPopSeconds);
                    pulse = Mathf.Lerp(config.seedPopScale, 1, pop) + Mathf.Sin(visualTime * Mathf.PI * 2) * config.seedIdlePulse;
                }
                image.rectTransform.localScale = Vector3.one * pulse;
            }
            seedMark.gameObject.SetActive(filled > 0 && progress < 1);
            if (filled > 0) {
                seedMark.anchoredPosition = new Vector2(seedFills[active].rectTransform.parent.localPosition.x, seedMark.anchoredPosition.y);
            }
        }

        public void ApplySafeArea(Rect area, int width, int height) {
            if (width <= 0 || height <= 0) {
                throw new InvalidOperationException("Logo viewport must have a positive size.");
            }
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
            if (logoIntro != null) {
                logoIntro.TearDown();
            }
            if (localization != null) {
                localization.TMP_Unregister(quoteLabel);
                localization.TMP_Unregister(authorLabel);
                localization.TMP_Unregister(copyrightLabel);
                localization = null;
            }
            completedHandle = null;
            audioHandle = null;
        }
    }
}
