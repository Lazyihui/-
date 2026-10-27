using Hamdoku.Controllers;
namespace Hamdoku {
    public static class ShopSystem {
        public static void Open(GameContext ctx) {
            ShopController.Open(ctx);
        }
        public static void Tick(GameContext ctx, float deltaTime) {
            var state = ctx.state_Shop;
            if (state.isOpen && !state.disposed) {
                Panel_Shop_Controller.Tick(ctx, deltaTime);
            }
        }
        public static void Exit(GameContext ctx) {
            ShopController.Dispose(ctx);
        }
    }
}
