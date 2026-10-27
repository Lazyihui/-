using System;
using TMPro;
using UnityEngine;

namespace Hamdoku {
    public sealed class Panel_Home : MonoBehaviour, IPanelAsset {
        public RectTransform safeRoot;
        public RectTransform contentRoot;
        public RectTransform logoRoot;
        public UnityEngine.UI.Image logo;
        public UnityEngine.UI.Image campaignImage;
        public UnityEngine.UI.Image dailyImage;
        public UnityEngine.UI.Image rankingImage;
        public UnityEngine.UI.Image endlessImage;
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
        public Action campaignHandle;
        public Action dailyHandle;
        public Action rankingHandle;
        public Action endlessHandle;
        public Action settingsHandle;
        L10NModule localization;
        Vector3 logoScale;
        float idleSeconds;

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
            campaignButton.onClick.AddListener(ReportCampaign);
            dailyButton.onClick.AddListener(ReportDaily);
            rankingButton.onClick.AddListener(ReportRanking);
            endlessButton.onClick.AddListener(ReportEndless);
            settingsButton.onClick.AddListener(ReportSettings);
            logoScale = logoRoot.localScale;
        }

        public void Init() {
            idleSeconds = 0;
            noticeLabel.text = string.Empty;
        }

        public void ShowLocks(bool daily, bool ranking, bool endless, Color tint) {
            dailyLock.SetActive(!daily);
            dailyPlay.SetActive(daily);
            rankingLock.SetActive(!ranking);
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

        public void Tick(float deltaTime, float amount, float speed) {
            idleSeconds += deltaTime;
            logoRoot.localScale = logoScale * (1 + Mathf.Sin(idleSeconds * speed) * amount);
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
