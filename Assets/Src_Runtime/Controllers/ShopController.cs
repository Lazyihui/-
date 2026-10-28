using System;
namespace Hamdoku.Controllers {
    public static class ShopController {
        public static void Open(GameContext ctx) {
            var state = ctx.state_Shop;
            if (state.disposed) {
                throw new ObjectDisposedException(nameof(ShopState));
            }
            if (state.isOpen) {
                return;
            }
            var home = ctx.state_Home;
            var game = ctx.state_Game;
            bool fromGame = game.isOpen;
            if (home.disposed || (!home.isOpen && !fromGame) ||
                (fromGame && (game.isTutorial || game.status != GameStatus.Playing || game.dialog != GameDialogType.None))) {
                return;
            }
            ValidateConfig(ctx);
            if (fromGame) {
                GameController.PauseForShop(ctx);
            }
            home.isOpen = false;
            home.pendingRequest = HomeRequestType.None;
            home.noticeType = UINameType.None;
            home.noticeRemaining = 0;
            Panel_Home_Controller.Close(ctx);
            state.isOpen = true;
            state.openedFromGame = fromGame;
            state.dialogOpen = false;
            state.autoDemo = false;
            state.selectedProductId = 0;
            Panel_Shop_Controller.Open(ctx);
            Request(ctx, ShopRequestType.Catalog, 0);
        }
        static void ValidateConfig(GameContext ctx) {
            var assets = ctx.assetModule;
            var config = assets.GetShopConfig();
            if (config.products == null || config.products.Length != 11 || config.referenceWidth <= 0 || config.demoStepSeconds <= 0) {
                throw new InvalidOperationException("Invalid shop configuration.");
            }
            for (int i = 0; i < config.products.Length; i++) {
                var product = config.products[i];
                if (product == null || product.id != i + 1 || product.section == ShopSectionType.None ||
                    string.IsNullOrWhiteSpace(product.productId) || string.IsNullOrWhiteSpace(product.sku) ||
                    string.IsNullOrWhiteSpace(product.referencePrice)) {
                    throw new InvalidOperationException("Invalid shop product at index " + i);
                }
            }
        }
        public static ShopProductModel Product(GameContext ctx, int id) {
            var assets = ctx.assetModule;
            var products = assets.GetShopConfig().products;
            if (id < 1 || id > products.Length || products[id - 1].id != id) {
                throw new ArgumentOutOfRangeException(nameof(id));
            }
            return products[id - 1];
        }
        public static void ShowInfo(GameContext ctx, int productId, bool autoDemo) {
            var state = ctx.state_Shop;
            if (!state.isOpen || state.requestPending) {
                return;
            }
            Product(ctx, productId);
            state.selectedProductId = productId;
            state.dialogOpen = true;
            state.autoDemo = autoDemo;
            state.requestType = ShopRequestType.None;
            Panel_Shop_Controller.Refresh(ctx);
        }
        public static void CloseDialog(GameContext ctx) {
            var state = ctx.state_Shop;
            if (!state.isOpen || state.disposed) {
                return;
            }
            state.dialogOpen = false;
            state.autoDemo = false;
            Panel_Shop_Controller.Refresh(ctx);
        }
        public static void Request(GameContext ctx, ShopRequestType type, int productId) {
            var state = ctx.state_Shop;
            if (!state.isOpen || state.disposed || state.requestPending) {
                return;
            }
            if (type != ShopRequestType.Catalog && type != ShopRequestType.Purchase && type != ShopRequestType.Restore) {
                throw new ArgumentOutOfRangeException(nameof(type));
            }
            if ((type == ShopRequestType.Purchase && productId == 0) || (type != ShopRequestType.Purchase && productId != 0)) {
                throw new ArgumentException("Shop request has an invalid product ID.");
            }
            var product = productId == 0 ? null : Product(ctx, productId);
            var request = new ShopRequest {
                requestId = ++state.requestId, productId = productId,
                storeProductId = product == null ? null : product.productId,
                sku = product == null ? null : product.sku
            };
            state.requestPending = true;
            state.requestType = type;
            state.selectedProductId = productId;
            state.autoDemo = false;
            state.dialogOpen = type != ShopRequestType.Catalog;
            state.result = ShopResultStatus.None;
            Panel_Shop_Controller.Refresh(ctx);
            var module = ctx.shopModule;
            Action<ShopResultStatus> completed = result => Complete(ctx, request.requestId, result);
            switch (type) {
                case ShopRequestType.Catalog: module.FetchCatalog(request, completed); break;
                case ShopRequestType.Purchase: module.Purchase(request, completed); break;
                case ShopRequestType.Restore: module.Restore(request, completed); break;
                default: throw new ArgumentOutOfRangeException(nameof(type));
            }
        }
        static void Complete(GameContext ctx, int requestId, ShopResultStatus result) {
            var state = ctx.state_Shop;
            if (state.disposed || !state.isOpen || requestId != state.requestId) {
                return;
            }
            if (result != ShopResultStatus.ServiceUnavailable && result != ShopResultStatus.Cancelled && result != ShopResultStatus.Failed) {
                throw new InvalidOperationException("Shop service returned an invalid result.");
            }
            state.requestPending = false;
            state.result = result;
            Panel_Shop_Controller.Refresh(ctx);
        }
        public static void Back(GameContext ctx) {
            var state = ctx.state_Shop;
            if (!state.isOpen || state.disposed) {
                return;
            }
            bool fromGame = state.openedFromGame;
            Close(ctx);
            if (fromGame) {
                var game = ctx.state_Game;
                GameController.Open(ctx, false, game.dailyDay);
            } else {
                HomeSystem.Open(ctx);
            }
        }
        static void Close(GameContext ctx) {
            var state = ctx.state_Shop;
            state.isOpen = false;
            state.openedFromGame = false;
            state.requestPending = false;
            state.requestId++;
            state.dialogOpen = false;
            state.autoDemo = false;
            Panel_Shop_Controller.Close(ctx);
        }
        public static void Dispose(GameContext ctx) {
            var state = ctx.state_Shop;
            if (state.disposed) {
                return;
            }
            Close(ctx);
            state.disposed = true;
            var module = ctx.shopModule;
            module.Dispose();
        }
    }
}
