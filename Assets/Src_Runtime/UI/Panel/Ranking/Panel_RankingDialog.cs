using System;
using TMPro;
using UnityEngine;
namespace Hamdoku {
    public sealed class Panel_RankingDialog : MonoBehaviour, IPanelAsset {
        public RectTransform safeRoot;
        public RectTransform contentRoot;
        public TMP_Text titleLabel;
        public TMP_Text bodyLabel;
        public TMP_Text noticeLabel;
        public TMP_Text claimLabel;
        public UnityEngine.UI.Button closeButton;
        public UnityEngine.UI.Button claimButton;
        public Action closeHandle;
        public Action claimHandle;
        L10NModule localization;
        public PanelType Type {
            get {
                return PanelType.RankingDialog;
            }
        }
        public void Ctor(L10NModule localization) {
            this.localization = localization;
            foreach (var text in GetComponentsInChildren<TMP_Text>(true)) {
                localization.TMP_Register(text);
            }
            closeButton.onClick.AddListener(ReportClose);
            claimButton.onClick.AddListener(ReportClaim);
        }
        public void Init() {
            ApplySafeArea();
        }
        public void ApplySafeArea() {
            Rect area = Screen.safeArea;
            safeRoot.anchorMin = new Vector2(area.xMin / Screen.width, area.yMin / Screen.height);
            safeRoot.anchorMax = new Vector2(area.xMax / Screen.width, area.yMax / Screen.height);
            safeRoot.offsetMin = Vector2.zero;
            safeRoot.offsetMax = Vector2.zero;
            Canvas.ForceUpdateCanvases();
            Vector2 available = safeRoot.rect.size;
            Vector2 authored = contentRoot.sizeDelta;
            contentRoot.localScale = Vector3.one * Mathf.Min(available.x / authored.x, available.y / authored.y);
        }
        void ReportClose() {
            closeHandle?.Invoke();
        }
        void ReportClaim() {
            claimHandle?.Invoke();
        }
        public void TearDown() {
            closeButton.onClick.RemoveListener(ReportClose);
            claimButton.onClick.RemoveListener(ReportClaim);
            foreach (var text in GetComponentsInChildren<TMP_Text>(true)) {
                localization.TMP_Unregister(text);
            }
            closeHandle = null;
            claimHandle = null;
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
