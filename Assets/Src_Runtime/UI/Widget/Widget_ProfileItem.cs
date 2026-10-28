using System;
using TMPro;
using UnityEngine;

namespace Hamdoku {
    public sealed class Widget_ProfileItem : MonoBehaviour {
        public UnityEngine.UI.Button button;
        public UnityEngine.UI.Image background;
        public UnityEngine.UI.Image art;
        public UnityEngine.UI.Image avatar;
        public UnityEngine.UI.Image selection;
        public GameObject check;
        public GameObject locked;
        public TMP_Text label;
        public int itemId;
        public ProfileTabType tab;
        public Widget_ProfilePortrait portrait;
        public GameObject newDot;
        public GameObject clubTag;
        public TMP_Text clubLabel;
        public TMP_Text requirementLabel;
        public Action<ProfileTabType, int> selectHandle;

        public void Ctor() {
            button.onClick.AddListener(Report);
        }

        void Report() {
            selectHandle?.Invoke(tab, itemId);
        }

        public void Show(bool selected, bool available, float lockedAlpha) {
            selection.gameObject.SetActive(selected);
            check.SetActive(selected);
            locked.SetActive(!available);
            art.color = new Color(1, 1, 1, available ? 1 : lockedAlpha);
        }

        public void TearDown() {
            button.onClick.RemoveListener(Report);
            selectHandle = null;
        }
    }
}
