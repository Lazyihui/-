using Hamdoku.Controllers;
namespace Hamdoku {
    public static class GameSystem {
        public static void Open(GameContext ctx, bool tutorial) {
            GameController.Open(ctx, tutorial);
        }
        public static void Tick(GameContext ctx, float deltaTime) {
            EndlessController.Tick(ctx, deltaTime);
            var state = ctx.state_Game;
            if (state.isOpen && !state.disposed) {
                GameController.Tick(ctx, deltaTime);
            }
        }
        public static void Exit(GameContext ctx) {
            GameController.Dispose(ctx);
        }
    }
}
