using System;
namespace Hamdoku.Controllers {
    public static class Panel_Shop_Controller {
        public static void Open(GameContext ctx) {
            var opened = PanelFactory.TryOpen(ctx, PanelType.Shop, out Panel_Shop panel);
            if (opened == UIOpenType.FirstOpen) {
                var localization = ctx.l10NModule;
                panel.Ctor(localization);
                panel.closeHandle = () => ShopController.Back(ctx);
                panel.restoreHandle = () => ShopController.Request(ctx, ShopRequestType.Restore, 0);
                panel.dialogCloseHandle = () => ShopController.CloseDialog(ctx);
                panel.dialogBuyHandle = () => {
                    var state = ctx.state_Shop;
                    ShopController.Request(ctx, ShopRequestType.Purchase, state.selectedProductId);
                };
                panel.buyHandle = id => ShopController.Request(ctx, ShopRequestType.Purchase, id);
                panel.infoHandle = (id, demo) => ShopController.ShowInfo(ctx, id, demo);
            }
            var assets = ctx.assetModule;
            Refresh(ctx);
            panel.Init(assets.GetShopConfig());
        }
        public static string Text(GameContext ctx, UINameType id) {
            var localization = ctx.l10NModule;
            if (!localization.TryGet(id, out string text)) {
                throw new InvalidOperationException("Missing shop text: " + id);
            }
            return text;
        }
        public static void Refresh(GameContext ctx) {
            var panels = ctx.panelRepository;
            if (!panels.TryGet(PanelType.Shop, out Panel_Shop panel)) {
                return;
            }
            var state = ctx.state_Shop;
            for (int i = 0; i < panel.textLabels.Length; i++) {
                panel.textLabels[i].text = Text(ctx, panel.textIds[i]);
            }
            foreach (var widget in panel.products) {
                var product = ShopController.Product(ctx, widget.productId);
                widget.priceLabel.text = product.referencePrice;
                widget.buyButton.interactable = !state.requestPending;
                if (widget.magnifierLabel != null) {
                    widget.magnifierLabel.text = product.magnifiers.ToString();
                }
                if (widget.hintLabel != null) {
                    widget.hintLabel.text = product.hints.ToString();
                }
            }
            panel.timerLabel.text = Text(ctx, UINameType.Shop_TimeUnknown);
            panel.restoreButton.interactable = !state.requestPending;
            panel.dialogRoot.SetActive(state.dialogOpen);
            panel.ShowDemo(state.dialogOpen && state.autoDemo);
            panel.dialogCloseLabel.text = Text(ctx, UINameType.Shop_Close);
            panel.dialogBuyButton.gameObject.SetActive(state.requestType == ShopRequestType.None && !state.autoDemo);
            if (!state.dialogOpen) {
                return;
            }
            if (state.requestType == ShopRequestType.Purchase || state.requestType == ShopRequestType.Restore) {
                panel.dialogTitle.text = Text(ctx, state.requestType == ShopRequestType.Restore ? UINameType.Shop_Restore : UINameType.Shop_Purchase);
                UINameType message = state.requestPending ? UINameType.Shop_Waiting :
                    state.result == ShopResultStatus.Cancelled ? UINameType.Shop_Cancelled :
                    state.result == ShopResultStatus.Failed ? UINameType.Shop_Failed :
                    state.requestType == ShopRequestType.Restore ? UINameType.Shop_RestoreUnavailable : UINameType.Shop_PurchaseUnavailable;
                panel.dialogBody.text = Text(ctx, message);
            } else {
                var product = ShopController.Product(ctx, state.selectedProductId);
                panel.dialogTitle.text = Text(ctx, state.autoDemo ? UINameType.Shop_Auto : product.name);
                panel.dialogBody.text = state.autoDemo ? Text(ctx, UINameType.Shop_AutoDescription) :
                    string.Format(Text(ctx, product.description), product.magnifiers, product.hints);
                panel.dialogPrice.text = product.referencePrice;
            }
            var bodyRect = panel.dialogBody.rectTransform;
            bodyRect.anchoredPosition = new UnityEngine.Vector2(0, state.autoDemo ? -275 : 50);
            bodyRect.sizeDelta = new UnityEngine.Vector2(730, state.autoDemo ? 180 : 560);
        }
        public static void Tick(GameContext ctx, float deltaTime) {
            var panels = ctx.panelRepository;
            if (panels.TryGet(PanelType.Shop, out Panel_Shop panel)) {
                panel.Tick(deltaTime);
            }
        }
        public static void Close(GameContext ctx) {
            var panels = ctx.panelRepository;
            if (panels.TryGet(PanelType.Shop, out Panel_Shop panel)) {
                panels.Remove(panel);
                panel.TearDown();
            }
        }
    }
}
