using Hamdoku.Controllers;

namespace Hamdoku {
    public static class ProfileSystem {
        public static void Open(GameContext ctx) {
            ProfileController.Open(ctx);
        }

        public static void Tick(GameContext ctx, float deltaTime) {
            var state = ctx.state_Profile;
            if (state.isOpen) {
                ProfileController.Tick(ctx, deltaTime);
                Panel_Profile_Controller.RefreshSafeArea(ctx);
            }
        }

        public static void Exit(GameContext ctx) {
            Panel_Profile_Controller.Close(ctx);
        }
    }
}
