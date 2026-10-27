using Hamdoku.Controllers;

namespace Hamdoku {
    public static class StreakSystem {
        public static void Open(GameContext ctx) {
            StreakController.Open(ctx);
        }

        public static void Tick(GameContext ctx, float deltaTime) {
            var state = ctx.state_Streak;
            if (!state.disposed && state.isOpen) {
                StreakController.Tick(ctx, deltaTime);
            }
        }

        public static void Exit(GameContext ctx) {
            StreakController.Dispose(ctx);
        }
    }
}
