using System;
using TMPro;
using UnityEngine;
namespace Hamdoku {
    public sealed class Widget_ShopProduct : MonoBehaviour {
        public int productId;
        public UnityEngine.UI.Button buyButton;
        public UnityEngine.UI.Button infoButton;
        public UnityEngine.UI.Button autoButton;
        public TMP_Text priceLabel;
        public TMP_Text magnifierLabel;
        public TMP_Text hintLabel;
        public Action<int> buyHandle;
        public Action<int, bool> infoHandle;
        public void Ctor() {
            buyButton.onClick.AddListener(ReportBuy);
            if (infoButton != null) {
                infoButton.onClick.AddListener(ReportInfo);
            }
            if (autoButton != null) {
                autoButton.onClick.AddListener(ReportAuto);
            }
        }
        void ReportBuy() {
            buyHandle?.Invoke(productId);
        }
        void ReportInfo() {
            infoHandle?.Invoke(productId, false);
        }
        void ReportAuto() {
            infoHandle?.Invoke(productId, true);
        }
        public void TearDown() {
            buyButton.onClick.RemoveListener(ReportBuy);
            if (infoButton != null) {
                infoButton.onClick.RemoveListener(ReportInfo);
            }
            if (autoButton != null) {
                autoButton.onClick.RemoveListener(ReportAuto);
            }
            buyHandle = null;
            infoHandle = null;
        }
    }
}
