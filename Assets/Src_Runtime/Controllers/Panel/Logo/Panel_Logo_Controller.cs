using UnityEngine;

namespace Hamdoku.Controllers {
    public static class Panel_Logo_Controller {
        public static void Open(GameContext ctx) {
            var panel = ctx.panel_Logo;
            var config = ctx.logoConfig;
            panel.Ctor();
            panel.completedHandle = () => {
                LoadingController.CompleteLogo(ctx);
            };
            panel.audioHandle = (clip, volume) => {
                var audio = ctx.audioModule;
                audio.PlayOneShot(clip, volume);
            };
            panel.gameObject.SetActive(true);
            RefreshSafeArea(ctx);
            panel.Init(config);
        }

        public static void Tick(GameContext ctx, float deltaTime) {
            var panel = ctx.panel_Logo;
            if (panel.gameObject.activeInHierarchy) {
                panel.Tick(deltaTime);
            }
        }

        public static void RefreshSafeArea(GameContext ctx) {
            var state = ctx.state_Loading;
            var panel = ctx.panel_Logo;
            Rect area = Screen.safeArea;
            int width = Screen.width;
            int height = Screen.height;
            if (state.safeArea == area && state.screenWidth == width && state.screenHeight == height) {
                return;
            }
            state.safeArea = area;
            state.screenWidth = width;
            state.screenHeight = height;
            panel.ApplySafeArea(area, width, height);
        }

        public static void Close(GameContext ctx) {
            var panel = ctx.panel_Logo;
            if (panel != null) {
                panel.TearDown();
                panel.gameObject.SetActive(false);
            }
        }
    }
}
