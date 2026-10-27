using System;
using Hamdoku.Controllers;

namespace Hamdoku {
    public static class HomeSystem {
        public static void Open(GameContext ctx) {
            HomeController.Open(ctx);
        }

        public static void Tick(GameContext ctx, float deltaTime) {
            var state = ctx.state_Home;
            if (!state.isOpen || state.disposed) {
                return;
            }
            try {
                HomeController.Tick(ctx, deltaTime);
            } catch (Exception error) {
                HomeController.Fail(ctx, error);
            }
        }

        public static void Exit(GameContext ctx) {
            HomeController.Dispose(ctx);
        }
    }
}
