using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Hamdoku {
    public sealed class Panel_Home : MonoBehaviour, IPanelAsset {
        public UnityEngine.UI.Image profileAvatar;
        public UnityEngine.UI.Image profileFrame;
        public RectTransform safeRoot;
        public RectTransform contentRoot;
        public RectTransform logoRoot;
        public UnityEngine.UI.Image logo;
        public UnityEngine.UI.Image campaignImage;
        public UnityEngine.UI.Image dailyImage;
        public UnityEngine.UI.Image rankingImage;
        public UnityEngine.UI.Image endlessImage;
        public RectTransform sunflower;
        public UnityEngine.UI.Image[] sunflowerSparkles;
        public UnityEngine.UI.Button campaignButton;
        public UnityEngine.UI.Button dailyButton;
        public UnityEngine.UI.Button rankingButton;
        public UnityEngine.UI.Button endlessButton;
        public UnityEngine.UI.Button settingsButton;
        public GameObject dailyLock;
        public GameObject dailyPlay;
        public GameObject rankingLock;
        public GameObject endlessLock;
        public TMP_Text levelLabel;
        public TMP_Text dailyLabel;
        public TMP_Text dailyPlayLabel;
        public TMP_Text dailyDateLabel;
        public TMP_Text rankingLabel;
        public TMP_Text endlessLabel;
        public TMP_Text settingsLabel;
        public TMP_Text streakLabel;
        public TMP_Text dailyLockLabel;
        public TMP_Text rankingLockLabel;
        public TMP_Text endlessLockLabel;
        public TMP_Text noticeLabel;
        public UnityEngine.UI.Button shopButton;
        public UnityEngine.UI.Button profileButton;
        public UnityEngine.UI.Button streakButton;
        public Action shopHandle;
        public Action profileHandle;
        public Action streakHandle;
        public Action campaignHandle;
        public Action dailyHandle;
        public Action rankingHandle;
        public Action endlessHandle;
        public Action settingsHandle;
        L10NModule localization;
        Vector3 logoScale;
        Vector2 logoPosition;
        float idleSeconds;
        HomeConfigSO sunflowerConfig;
        Vector2 sunflowerPosition;
        float sunflowerPhase;

        public PanelType Type {
            get {
                return PanelType.Home;
            }
        }

        public void Ctor(L10NModule localization) {
            this.localization = localization;
            foreach (var text in GetComponentsInChildren<TMP_Text>(true)) {
                localization.TMP_Register(text);
            }
            shopButton.onClick.AddListener(ReportShop);
            profileButton.onClick.AddListener(ReportProfile);
            streakButton.onClick.AddListener(ReportStreak);
            campaignButton.onClick.AddListener(ReportCampaign);
            dailyButton.onClick.AddListener(ReportDaily);
            rankingButton.onClick.AddListener(ReportRanking);
            endlessButton.onClick.AddListener(ReportEndless);
            settingsButton.onClick.AddListener(ReportSettings);
            logoScale = logoRoot.localScale;
            logoPosition = logoRoot.anchoredPosition;
            sunflowerPosition = sunflower.anchoredPosition;
        }

        public void Init() {
            StopAllCoroutines();
            idleSeconds = 0;
            noticeLabel.text = string.Empty;
            logoRoot.localScale = logoScale;
            logoRoot.anchoredPosition = logoPosition;
        }

        public void InitSunflower(HomeConfigSO config) {
            StopAllCoroutines();
            if (sunflowerSparkles.Length != config.sunflowerSparkleCount || config.sunflowerSwaySeconds <= 0) {
                throw new InvalidOperationException("Invalid Home sunflower animation configuration or prefab bindings.");
            }
            sunflowerConfig = config;
            sunflowerPhase = UnityEngine.Random.Range(0, Mathf.PI * 2);
            sunflower.localRotation = Quaternion.identity;
            sunflower.anchoredPosition = sunflowerPosition;
            foreach (var sparkle in sunflowerSparkles) {
                sparkle.color = new Color(config.sunflowerSparkleColor.r, config.sunflowerSparkleColor.g,
                    config.sunflowerSparkleColor.b, 0);
                StartCoroutine(PlaySunflowerSparkle(sparkle));
            }
        }

        void AnimateSunflower() {
            var config = sunflowerConfig;
            float phase = Time.unscaledTime * Mathf.PI * 2 / config.sunflowerSwaySeconds + sunflowerPhase;
            float degrees = config.sunflowerSwayDegrees * (Mathf.Sin(phase) +
                config.sunflowerSwayHarmonicAmount * Mathf.Sin(phase * config.sunflowerSwayHarmonicSpeed +
                    config.sunflowerSwayHarmonicPhase));
            var rotation = Quaternion.Euler(0, 0, degrees);
            Vector3 pivotOffset = Vector3.up * ((config.sunflowerSwayPivotY - sunflower.pivot.y) * sunflower.rect.height);
            // Keep the original RectTransform pivot and compensate around the stem's rotation point.
            sunflower.localRotation = rotation;
            sunflower.anchoredPosition = sunflowerPosition + (Vector2)(pivotOffset - rotation * pivotOffset);
        }

        IEnumerator PlaySunflowerSparkle(UnityEngine.UI.Image sparkle) {
            var config = sunflowerConfig;
            yield return new WaitForSecondsRealtime(UnityEngine.Random.Range(0, config.sunflowerSparkleInitialDelay));
            float halfSize = Mathf.Max(sunflower.rect.width, sunflower.rect.height) * 0.5f;
            float minRadius = halfSize * config.sunflowerSparkleInnerScale;
            float maxRadius = Mathf.Max(minRadius + config.sunflowerSparkleRadiusGap,
                halfSize * config.sunflowerSparkleAreaScale);
            var rect = sparkle.rectTransform;
            while (true) {
                float radius = Mathf.Sqrt(UnityEngine.Random.Range(minRadius * minRadius, maxRadius * maxRadius));
                float angle = UnityEngine.Random.Range(0, Mathf.PI * 2);
                rect.anchoredPosition = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * radius;
                rect.sizeDelta = Vector2.one * UnityEngine.Random.Range(config.sunflowerSparkleSize.x, config.sunflowerSparkleSize.y);
                rect.localRotation = Quaternion.Euler(0, 0, UnityEngine.Random.Range(0, 360));
                yield return FadeSunflowerSparkle(sparkle, 0, 1,
                    UnityEngine.Random.Range(config.sunflowerSparkleFadeIn.x, config.sunflowerSparkleFadeIn.y));
                yield return new WaitForSecondsRealtime(UnityEngine.Random.Range(config.sunflowerSparkleHold.x, config.sunflowerSparkleHold.y));
                yield return FadeSunflowerSparkle(sparkle, 1, 0,
                    UnityEngine.Random.Range(config.sunflowerSparkleFadeOut.x, config.sunflowerSparkleFadeOut.y));
                yield return new WaitForSecondsRealtime(UnityEngine.Random.Range(config.sunflowerSparkleRest.x, config.sunflowerSparkleRest.y));
            }
        }

        IEnumerator FadeSunflowerSparkle(UnityEngine.UI.Image sparkle, float from, float to, float duration) {
            var color = sunflowerConfig.sunflowerSparkleColor;
            float elapsed = 0;
            while (elapsed < duration) {
                color.a = sunflowerConfig.sunflowerSparkleColor.a * Mathf.Lerp(from, to, elapsed / duration);
                sparkle.color = color;
                elapsed += Time.unscaledDeltaTime;
                yield return null;
            }
            color.a = sunflowerConfig.sunflowerSparkleColor.a * to;
            sparkle.color = color;
        }

        public void ShowLocks(bool daily, bool ranking, bool endless, Color tint) {
            dailyLock.SetActive(!daily);
            dailyPlay.SetActive(daily);
            rankingLock.SetActive(!ranking);
            rankingLabel.gameObject.SetActive(ranking);
            endlessLock.SetActive(!endless);
            dailyImage.color = daily ? Color.white : tint;
            rankingImage.color = ranking ? Color.white : tint;
            endlessImage.color = endless ? Color.white : tint;
            // Locked cards remain clickable so the controller can explain the requirement.
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

        public void Tick(float deltaTime, float amount, float speed, float bobHeight, float bobSpeed) {
            idleSeconds += deltaTime;
            logoRoot.anchoredPosition = logoPosition + Vector2.up * Mathf.Sin(idleSeconds * bobSpeed) * bobHeight;
            logoRoot.localScale = logoScale * (1 + Mathf.Sin(idleSeconds * speed) * amount);
            AnimateSunflower();
        }

        void ReportShop() {
            shopHandle?.Invoke();
        }

        void ReportProfile() {
            profileHandle?.Invoke();
        }

        void ReportStreak() {
            streakHandle?.Invoke();
        }

        void ReportCampaign() {
            campaignHandle?.Invoke();
        }

        void ReportDaily() {
            dailyHandle?.Invoke();
        }

        void ReportRanking() {
            rankingHandle?.Invoke();
        }

        void ReportEndless() {
            endlessHandle?.Invoke();
        }

        void ReportSettings() {
            settingsHandle?.Invoke();
        }

        public void TearDown() {
            StopAllCoroutines();
            shopButton.onClick.RemoveListener(ReportShop);
            profileButton.onClick.RemoveListener(ReportProfile);
            streakButton.onClick.RemoveListener(ReportStreak);
            shopHandle = null;
            profileHandle = null;
            streakHandle = null;
            campaignButton.onClick.RemoveListener(ReportCampaign);
            dailyButton.onClick.RemoveListener(ReportDaily);
            rankingButton.onClick.RemoveListener(ReportRanking);
            endlessButton.onClick.RemoveListener(ReportEndless);
            settingsButton.onClick.RemoveListener(ReportSettings);
            foreach (var text in GetComponentsInChildren<TMP_Text>(true)) {
                localization.TMP_Unregister(text);
            }
            campaignHandle = null;
            dailyHandle = null;
            rankingHandle = null;
            endlessHandle = null;
            settingsHandle = null;
            UnityEngine.Object.Destroy(gameObject);
        }
    }
}
