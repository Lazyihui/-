using System;
using TMPro;
using UnityEngine;

namespace Hamdoku {
    public sealed class Panel_Profile : MonoBehaviour, IPanelAsset {
        public RectTransform safeRoot;
        public RectTransform contentRoot;
        public TMP_Text titleLabel;
        public TMP_Text brandLabel;
        public TMP_Text gradeLabel;
        public TMP_Text nameLabel;
        public TMP_Text mottoLabel;
        public TMP_Text infoLabel;
        public TMP_Text uidLabel;
        public TMP_Text memberLabel;
        public TMP_Text noticeLabel;
        public UnityEngine.UI.Image noticeBackground;
        public TMP_Text[] statLabels;
        public TMP_Text[] statValues;
        public TMP_Text[] tabLabels;
        public UnityEngine.UI.Image avatar;
        public UnityEngine.UI.Image frame;
        public UnityEngine.UI.Image avatarBackground;
        public Widget_ProfilePortrait portrait;
        public GameObject[] tabDots;
        public UnityEngine.UI.Button backButton;
        public UnityEngine.UI.Button infoButton;
        public UnityEngine.UI.Button editButton;
        public UnityEngine.UI.Button mottoButton;
        public UnityEngine.UI.Button copyButton;
        public UnityEngine.UI.Button memberButton;
        public UnityEngine.UI.Button[] tabButtons;
        public GameObject[] grids;
        public UnityEngine.UI.ScrollRect[] scrolls;
        public Widget_ProfileItem[] items;
        public GameObject dialogRoot;
        public GameObject nameRoot;
        public GameObject mottoRoot;
        public GameObject helpRoot;
        public GameObject dialogBox;
        public UnityEngine.UI.Image dialogBackdrop;
        public TMP_Text helpTitle;
        public TMP_Text[] helpRowTitles;
        public TMP_Text[] helpRowDescriptions;
        public TMP_Text helpConfirmLabel;
        public UnityEngine.UI.Button helpConfirmButton;
        public UnityEngine.UI.Button helpCloseButton;
        public TMP_InputField nameInput;
        public TMP_Text dialogTitle;
        public TMP_Text dialogBody;
        public TMP_Text dialogNotice;
        public TMP_Text saveLabel;
        public TMP_Text cancelLabel;
        public TMP_Text nameHint;
        public TMP_Text[] mottoLabels;
        public UnityEngine.UI.Button[] mottoButtons;
        public UnityEngine.UI.Button saveButton;
        public UnityEngine.UI.Button cancelButton;
        public Action backHandle;
        public Action infoHandle;
        public Action editHandle;
        public Action mottoHandle;
        public Action copyHandle;
        public Action memberHandle;
        public Action closeDialogHandle;
        public Action<string> saveNameHandle;
        public Action<int> selectMottoHandle;
        public Action<ProfileTabType> tabHandle;
        public Action<ProfileTabType, int> selectHandle;
        L10NModule localization;
        Rect previousSafeArea;
        Vector2Int previousScreen;

        public PanelType Type {
            get {
                return PanelType.Profile;
            }
        }

        public void Ctor(L10NModule localization) {
            if (safeRoot == null || contentRoot == null || items == null || grids.Length != 3 || tabButtons.Length != 3 ||
                statLabels.Length != 6 || statValues.Length != 6 || nameInput == null || dialogBox == null ||
                dialogBackdrop == null || helpTitle == null || helpRowTitles == null || helpRowTitles.Length != 4 ||
                helpRowDescriptions == null || helpRowDescriptions.Length != 4 || helpConfirmLabel == null ||
                helpConfirmButton == null || helpCloseButton == null) {
                throw new InvalidOperationException("Panel_Profile has missing serialized bindings.");
            }
            this.localization = localization;
            foreach (var text in GetComponentsInChildren<TMP_Text>(true)) {
                localization.TMP_Register(text);
            }
            backButton.onClick.AddListener(ReportBack);
            infoButton.onClick.AddListener(ReportInfo);
            editButton.onClick.AddListener(ReportEdit);
            mottoButton.onClick.AddListener(ReportMotto);
            copyButton.onClick.AddListener(ReportCopy);
            memberButton.onClick.AddListener(ReportMember);
            saveButton.onClick.AddListener(ReportSave);
            cancelButton.onClick.AddListener(ReportCancel);
            helpConfirmButton.onClick.AddListener(ReportCancel);
            helpCloseButton.onClick.AddListener(ReportCancel);
            for (int i = 0; i < tabButtons.Length; i++) {
                var tab = (ProfileTabType)(i + 1);
                tabButtons[i].onClick.AddListener(() => tabHandle?.Invoke(tab));
            }
            for (int i = 0; i < mottoButtons.Length; i++) {
                int id = i;
                mottoButtons[i].onClick.AddListener(() => selectMottoHandle?.Invoke(id));
            }
            foreach (var item in items) {
                item.Ctor();
                item.selectHandle = (tab, id) => selectHandle?.Invoke(tab, id);
            }
        }

        public void Init() {
            dialogRoot.SetActive(false);
            foreach (var scroll in scrolls) {
                scroll.verticalNormalizedPosition = 1;
                scroll.StopMovement();
            }
            ApplySafeArea(Screen.safeArea, Screen.width, Screen.height);
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
            previousSafeArea = area;
            previousScreen = new Vector2Int(width, height);
        }

        public void RefreshSafeArea() {
            if (previousSafeArea != Screen.safeArea || previousScreen.x != Screen.width || previousScreen.y != Screen.height) {
                ApplySafeArea(Screen.safeArea, Screen.width, Screen.height);
            }
        }

        public void RefreshTabLayering() {
            // Every tab tucks under the content plate, including the selected tab.
            for (int i = 0; i < tabButtons.Length; i++) {
                var tab = tabButtons[i].transform;
                int firstGrid = grids[0].transform.GetSiblingIndex();
                for (int j = 1; j < grids.Length; j++) {
                    firstGrid = Mathf.Min(firstGrid, grids[j].transform.GetSiblingIndex());
                }
                tab.SetSiblingIndex(firstGrid - (tab.GetSiblingIndex() < firstGrid ? 1 : 0));
            }
        }

        public void BeginName(string value, int maxLength) {
            nameInput.characterLimit = maxLength;
            nameInput.SetTextWithoutNotify(value);
            nameInput.ActivateInputField();
        }

        void ReportBack() {
            backHandle?.Invoke();
        }
        void ReportInfo() {
            infoHandle?.Invoke();
        }
        void ReportEdit() {
            editHandle?.Invoke();
        }
        void ReportMotto() {
            mottoHandle?.Invoke();
        }
        void ReportCopy() {
            copyHandle?.Invoke();
        }
        void ReportMember() {
            memberHandle?.Invoke();
        }
        void ReportSave() {
            saveNameHandle?.Invoke(nameInput.text);
        }
        void ReportCancel() {
            closeDialogHandle?.Invoke();
        }

        public void TearDown() {
            backButton.onClick.RemoveListener(ReportBack);
            infoButton.onClick.RemoveListener(ReportInfo);
            editButton.onClick.RemoveListener(ReportEdit);
            mottoButton.onClick.RemoveListener(ReportMotto);
            copyButton.onClick.RemoveListener(ReportCopy);
            memberButton.onClick.RemoveListener(ReportMember);
            saveButton.onClick.RemoveListener(ReportSave);
            cancelButton.onClick.RemoveListener(ReportCancel);
            helpConfirmButton.onClick.RemoveListener(ReportCancel);
            helpCloseButton.onClick.RemoveListener(ReportCancel);
            foreach (var button in tabButtons) {
                button.onClick.RemoveAllListeners();
            }
            foreach (var button in mottoButtons) {
                button.onClick.RemoveAllListeners();
            }
            foreach (var item in items) {
                item.TearDown();
            }
            foreach (var text in GetComponentsInChildren<TMP_Text>(true)) {
                localization.TMP_Unregister(text);
            }
            backHandle = null;
            infoHandle = null;
            editHandle = null;
            mottoHandle = null;
            copyHandle = null;
            memberHandle = null;
            closeDialogHandle = null;
            saveNameHandle = null;
            selectMottoHandle = null;
            tabHandle = null;
            selectHandle = null;
            Destroy(gameObject);
        }
    }
}
