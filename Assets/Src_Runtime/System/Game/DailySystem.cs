using Hamdoku.Controllers;

namespace Hamdoku {
    public static class DailySystem {
        public static void Open(GameContext ctx) {
            DailyController.Open(ctx);
        }

        public static void Tick(GameContext ctx, float deltaTime) {
            DailyController.Tick(ctx, deltaTime);
        }

        public static void Exit(GameContext ctx) {
            DailyController.Dispose(ctx);
        }
    }
}
