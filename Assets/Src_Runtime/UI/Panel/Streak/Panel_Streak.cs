using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Hamdoku {
    public sealed class Panel_Streak : MonoBehaviour, IPanelAsset {
        public RectTransform safeRoot;
        public RectTransform contentRoot;
        public TMP_Text titleLabel;
        public TMP_Text countLabel;
        public TMP_Text currentLabel;
        public TMP_Text bestLabel;
        public TMP_Text continueLabel;
        public TMP_Text noticeLabel;
        public TMP_Text rewardLabel;
        public TMP_Text claimLabel;
        public TMP_Text recoverLabel;
        public TMP_Text recoverButtonLabel;
        public TMP_Text dismissLabel;
        public Button backButton;
        public Button continueButton;
        public Button claimButton;
        public Button recoverButton;
        public Button dismissButton;
        public GameObject rewardRoot;
        public GameObject recoveryRoot;
        public Widget_StreakPlant plant;
        public Widget_StreakDay[] days;
        public Action backHandle;
        public Action continueHandle;
        public Action claimHandle;
        public Action recoverHandle;
        public Action dismissHandle;
        public Action<int> rewardHandle;
        L10NModule localization;

        public PanelType Type {
            get {
                return PanelType.Streak;
            }
        }

        public void Ctor(L10NModule localization) {
            if (safeRoot == null || contentRoot == null || plant == null || days == null || days.Length != 7 ||
                backButton == null || continueButton == null || claimButton == null || recoverButton == null || dismissButton == null) {
                throw new InvalidOperationException("Panel_Streak has missing serialized bindings.");
            }
            this.localization = localization;
            foreach (var text in GetComponentsInChildren<TMP_Text>(true)) {
                localization.TMP_Register(text);
            }
            backButton.onClick.AddListener(ReportBack);
            continueButton.onClick.AddListener(ReportContinue);
            claimButton.onClick.AddListener(ReportClaim);
            recoverButton.onClick.AddListener(ReportRecover);
            dismissButton.onClick.AddListener(ReportDismiss);
            for (int i = 0; i < days.Length; i++) {
                var day = days[i];
                day.Ctor(i + 1);
                day.rewardHandle = ReportReward;
            }
        }

        public void Init() {
            noticeLabel.text = string.Empty;
            rewardRoot.SetActive(false);
            recoveryRoot.SetActive(false);
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

        public void Tick(float deltaTime, StreakConfigSO config) {
            plant.Tick(deltaTime);
            foreach (var day in days) {
                day.Tick(deltaTime, config.stampSeconds);
            }
        }

        void ReportBack() {
            backHandle?.Invoke();
        }

        void ReportContinue() {
            continueHandle?.Invoke();
        }

        void ReportClaim() {
            claimHandle?.Invoke();
        }

        void ReportRecover() {
            recoverHandle?.Invoke();
        }

        void ReportDismiss() {
            dismissHandle?.Invoke();
        }

        void ReportReward(int slot) {
            rewardHandle?.Invoke(slot);
        }

        public void TearDown() {
            backButton.onClick.RemoveListener(ReportBack);
            continueButton.onClick.RemoveListener(ReportContinue);
            claimButton.onClick.RemoveListener(ReportClaim);
            recoverButton.onClick.RemoveListener(ReportRecover);
            dismissButton.onClick.RemoveListener(ReportDismiss);
            foreach (var day in days) {
                day.TearDown();
            }
            foreach (var text in GetComponentsInChildren<TMP_Text>(true)) {
                localization.TMP_Unregister(text);
            }
            backHandle = null;
            continueHandle = null;
            claimHandle = null;
            recoverHandle = null;
            dismissHandle = null;
            rewardHandle = null;
            UnityEngine.Object.Destroy(gameObject);
        }
    }
}
