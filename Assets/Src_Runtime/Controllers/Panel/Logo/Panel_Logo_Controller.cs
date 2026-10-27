using UnityEngine;

namespace Hamdoku.Controllers {
    public static class Panel_Logo_Controller {
        public static void Open(GameContext ctx) {
            var panel = ctx.panel_Logo;
            var config = ctx.logoConfig;
            var localization = ctx.l10NModule;
            var saves = ctx.saveModule;
            var startupConfig = config.startupHomeConfig;
            var loaded = saves.Load(startupConfig, Application.persistentDataPath);
            var audio = ctx.audioModule;
            audio.SetEffectsEnabled(loaded == null || loaded.version < 6 || loaded.settings.effects);
            localization.AddAll(config.startupTexts, config.startupFonts);
            localization.Language_Set(loaded == null ? startupConfig.defaultLanguage : loaded.language);
            panel.Ctor(localization);
            panel.completedHandle = () => {
                LoadingController.CompleteLogo(ctx);
            };
            panel.audioHandle = (clip, volume) => {
                var effects = ctx.audioModule;
                effects.PlayOneShot(clip, volume);
            };
            RefreshText(ctx);
            panel.gameObject.SetActive(true);
            RefreshSafeArea(ctx);
            panel.Init(config);
        }

        public static void RefreshText(GameContext ctx) {
            var panel = ctx.panel_Logo;
            var localization = ctx.l10NModule;
            if (!localization.TryGet(UINameType.Loading_Quote, out string quote) ||
                !localization.TryGet(UINameType.Loading_Author, out string author) ||
                !localization.TryGet(UINameType.Loading_Copyright, out string copyright)) {
                throw new System.InvalidOperationException("Missing loading screen localization.");
            }
            panel.SetText(quote, author, copyright);
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
