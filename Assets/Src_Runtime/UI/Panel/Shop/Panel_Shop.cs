using System;
using TMPro;
using UnityEngine;
namespace Hamdoku {
    public sealed class Panel_Shop : MonoBehaviour, IPanelAsset {
        public RectTransform safeRoot;
        public RectTransform layoutRoot;
        public UnityEngine.UI.ScrollRect scroll;
        public UnityEngine.UI.Button closeButton;
        public UnityEngine.UI.Button restoreButton;
        public UnityEngine.UI.Button dialogCloseButton;
        public UnityEngine.UI.Button dialogBuyButton;
        public TMP_Text[] textLabels;
        public UINameType[] textIds;
        public Widget_ShopProduct[] products;
        public TMP_Text timerLabel;
        public GameObject dialogRoot;
        public RectTransform dialogBox;
        public TMP_Text dialogTitle;
        public TMP_Text dialogBody;
        public TMP_Text dialogPrice;
        public TMP_Text dialogCloseLabel;
        public GameObject demoRoot;
        public GameObject[] demoCrosses;
        public Action closeHandle;
        public Action restoreHandle;
        public Action dialogCloseHandle;
        public Action dialogBuyHandle;
        public Action<int> buyHandle;
        public Action<int, bool> infoHandle;
        L10NModule localization;
        Rect previousSafeArea;
        Vector2Int previousScreen;
        float referenceWidth;
        float demoStepSeconds;
        float minimumLayoutHeight;
        float demoElapsed;
        bool demoPlaying;
        public PanelType Type {
            get {
                return PanelType.Shop;
            }
        }
        public void Ctor(L10NModule localization) {
            if (safeRoot == null || layoutRoot == null || scroll == null || products.Length != 11 ||
                textLabels.Length != textIds.Length || demoCrosses.Length != 12) {
                throw new InvalidOperationException("Panel_Shop has invalid serialized bindings.");
            }
            this.localization = localization;
            foreach (var text in GetComponentsInChildren<TMP_Text>(true)) {
                localization.TMP_Register(text);
            }
            closeButton.onClick.AddListener(ReportClose);
            restoreButton.onClick.AddListener(ReportRestore);
            dialogCloseButton.onClick.AddListener(ReportDialogClose);
            dialogBuyButton.onClick.AddListener(ReportDialogBuy);
            foreach (var product in products) {
                product.Ctor();
                product.buyHandle = id => buyHandle?.Invoke(id);
                product.infoHandle = (id, demo) => infoHandle?.Invoke(id, demo);
            }
        }
        public void Init(ShopConfigSO config) {
            referenceWidth = config.referenceWidth;
            demoStepSeconds = config.demoStepSeconds;
            minimumLayoutHeight = config.minimumLayoutHeight;
            RefreshSafeArea(true);
            scroll.StopMovement();
            scroll.verticalNormalizedPosition = 1;
            ShowDemo(false);
        }
        public void RefreshSafeArea(bool force = false) {
            Rect area = Screen.safeArea;
            var screen = new Vector2Int(Screen.width, Screen.height);
            if (!force && area == previousSafeArea && screen == previousScreen) {
                return;
            }
            ApplySafeArea(area, screen.x, screen.y);
        }
        public void ApplySafeArea(Rect area, int width, int height) {
            float scrollPosition = Mathf.Clamp01(scroll.verticalNormalizedPosition);
            var screen = new Vector2Int(width, height);
            previousSafeArea = area;
            previousScreen = screen;
            safeRoot.anchorMin = new Vector2(area.xMin / screen.x, area.yMin / screen.y);
            safeRoot.anchorMax = new Vector2(area.xMax / screen.x, area.yMax / screen.y);
            safeRoot.offsetMin = Vector2.zero;
            safeRoot.offsetMax = Vector2.zero;
            Canvas.ForceUpdateCanvases();
            Vector2 available = safeRoot.rect.size;
            // Keep the original column width; extra vertical room belongs to the scrolling viewport.
            float scale = Mathf.Min(available.x / referenceWidth, available.y / minimumLayoutHeight);
            layoutRoot.localScale = Vector3.one * scale;
            layoutRoot.sizeDelta = available / scale;
            float dialogScale = Mathf.Min(1, Mathf.Min(layoutRoot.sizeDelta.x / (dialogBox.sizeDelta.x + 40),
                layoutRoot.sizeDelta.y / (dialogBox.sizeDelta.y + 40)));
            dialogBox.localScale = Vector3.one * dialogScale;
            Canvas.ForceUpdateCanvases();
            scroll.verticalNormalizedPosition = scrollPosition;
        }
        public void ShowDemo(bool show) {
            demoRoot.SetActive(show);
            if (show != demoPlaying) {
                demoElapsed = 0;
                foreach (var cross in demoCrosses) {
                    cross.SetActive(false);
                }
            }
            demoPlaying = show;
        }
        public void Tick(float deltaTime) {
            RefreshSafeArea();
            if (!demoPlaying) {
                return;
            }
            demoElapsed = (demoElapsed + deltaTime) % (demoStepSeconds * (demoCrosses.Length + 4));
            int visible = Mathf.FloorToInt(demoElapsed / demoStepSeconds) - 1;
            for (int i = 0; i < demoCrosses.Length; i++) {
                demoCrosses[i].SetActive(i < visible);
            }
        }
        void ReportClose() {
            closeHandle?.Invoke();
        }
        void ReportRestore() {
            restoreHandle?.Invoke();
        }
        void ReportDialogClose() {
            dialogCloseHandle?.Invoke();
        }
        void ReportDialogBuy() {
            dialogBuyHandle?.Invoke();
        }
        public void TearDown() {
            closeButton.onClick.RemoveListener(ReportClose);
            restoreButton.onClick.RemoveListener(ReportRestore);
            dialogCloseButton.onClick.RemoveListener(ReportDialogClose);
            dialogBuyButton.onClick.RemoveListener(ReportDialogBuy);
            foreach (var product in products) {
                product.TearDown();
            }
            foreach (var text in GetComponentsInChildren<TMP_Text>(true)) {
                localization.TMP_Unregister(text);
            }
            closeHandle = null;
            restoreHandle = null;
            dialogCloseHandle = null;
            dialogBuyHandle = null;
            buyHandle = null;
            infoHandle = null;
            scroll.StopMovement();
            ShowDemo(false);
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
