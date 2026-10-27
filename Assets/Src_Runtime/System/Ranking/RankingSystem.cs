using Hamdoku.Controllers;
namespace Hamdoku {
    public static class RankingSystem {
        public static void Open(GameContext ctx) {
            RankingController.Open(ctx);
        }
        public static void Tick(GameContext ctx, float deltaTime) {
            var state = ctx.state_Ranking;
            if (state.isOpen && !state.disposed) {
                RankingController.Tick(ctx);
            }
        }
        public static void Exit(GameContext ctx) {
            RankingController.Dispose(ctx);
        }
    }
}
