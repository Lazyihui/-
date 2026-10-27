using Hamdoku.Controllers;
namespace Hamdoku {
    public static class SettingsSystem {
        public static void Open(GameContext ctx) {
            SettingsController.Open(ctx);
        }
        public static void Tick(GameContext ctx) {
            var state = ctx.state_Settings;
            if (state.isOpen) {
                Panel_Settings_Controller.RefreshSafeArea(ctx);
                if (UnityEngine.InputSystem.Keyboard.current != null && UnityEngine.InputSystem.Keyboard.current.escapeKey.wasPressedThisFrame) {
                    SettingsController.Back(ctx);
                }
            }
        }
        public static void Exit(GameContext ctx) {
            Panel_Settings_Controller.Close(ctx);
        }
    }
}
