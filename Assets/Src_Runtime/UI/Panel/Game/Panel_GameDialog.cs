using System;
using TMPro;
using UnityEngine;
namespace Hamdoku {
    public sealed class Panel_GameDialog : MonoBehaviour, IPanelAsset {
        public RectTransform safeRoot;
        public RectTransform contentRoot;
        public TMP_Text titleLabel;
        public TMP_Text bodyLabel;
        public TMP_Text primaryLabel;
        public TMP_Text secondaryLabel;
        public TMP_Text adLabel;
        public UnityEngine.UI.Button primaryButton;
        public UnityEngine.UI.Button secondaryButton;
        public UnityEngine.UI.Button adButton;
        public Action primaryHandle;
        public Action secondaryHandle;
        public Action adHandle;
        L10NModule localization;
        public PanelType Type {
            get {
                return PanelType.GameDialog;
            }
        }
        public void Ctor(L10NModule localization) {
            if (safeRoot == null || contentRoot == null || titleLabel == null || bodyLabel == null || primaryLabel == null ||
                secondaryLabel == null || adLabel == null || primaryButton == null || secondaryButton == null || adButton == null) {
                throw new InvalidOperationException("Panel_GameDialog has missing serialized UI bindings.");
            }
            this.localization = localization;
            foreach (var text in GetComponentsInChildren<TMP_Text>(true)) {
                localization.TMP_Register(text);
            }
            primaryButton.onClick.AddListener(ReportPrimary);
            secondaryButton.onClick.AddListener(ReportSecondary);
            adButton.onClick.AddListener(ReportAd);
        }
        public void Init() {
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
        void ReportPrimary() {
            primaryHandle?.Invoke();
        }
        void ReportSecondary() {
            secondaryHandle?.Invoke();
        }
        void ReportAd() {
            adHandle?.Invoke();
        }
        public void TearDown() {
            primaryButton.onClick.RemoveListener(ReportPrimary);
            secondaryButton.onClick.RemoveListener(ReportSecondary);
            adButton.onClick.RemoveListener(ReportAd);
            foreach (var text in GetComponentsInChildren<TMP_Text>(true)) {
                localization.TMP_Unregister(text);
            }
            primaryHandle = null;
            secondaryHandle = null;
            adHandle = null;
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
