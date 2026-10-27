using System;
using Hamdoku.Controllers;

namespace Hamdoku {
    public static class LoadingSystem {
        public static void Initialize(GameContext ctx) {
            LoadingController.Begin(ctx);
        }

        public static void Tick(GameContext ctx, float deltaTime) {
            var state = ctx.state_Loading;
            if (state.status == LoadingStatus.Disposed || state.status == LoadingStatus.Failed) {
                return;
            }
            try {
                Panel_Logo_Controller.RefreshSafeArea(ctx);
                if (state.status != LoadingStatus.Loading && state.status != LoadingStatus.Ready) {
                    return;
                }
                Panel_Logo_Controller.Tick(ctx, deltaTime);
                if (state.status == LoadingStatus.Loading) {
                    LoadingController.Advance(ctx, deltaTime);
                    if (!state.assetsLoaded) {
                        LoadingController.LoadAssets(ctx);
                    }
                    var config = ctx.logoConfig;
                    if (state.assetsLoaded && state.logoCompleted && state.elapsedSeconds >= config.minShowSeconds &&
                        state.finishHoldElapsed >= config.finishHoldSeconds) {
                        LoadingController.SetReady(ctx);
                    }
                }
            } catch (Exception error) {
                LoadingController.Fail(ctx, error);
                return;
            }
            // Application callbacks run outside the internal error boundary.
            // A consumer failure must not be reported as a failed Logo initialization.
            if (state.status == LoadingStatus.Ready && !state.readyNotified) {
                LoadingController.NotifyReady(ctx);
            }
        }
    }
}
