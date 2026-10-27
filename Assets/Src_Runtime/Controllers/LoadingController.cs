using System;
using UnityEngine;

namespace Hamdoku.Controllers {
    public static class LoadingController {
        public static void Begin(GameContext ctx) {
            var state = ctx.state_Loading;
            if (state.status == LoadingStatus.Disposed) {
                throw new InvalidOperationException("Cannot restart a disposed loading flow.");
            }
            if (state.status != LoadingStatus.None) {
                return;
            }
            state.status = LoadingStatus.Loading;
            state.elapsedSeconds = 0;
            state.logoCompleted = false;
            state.readyNotified = false;
            state.error = null;
            try {
                Screen.orientation = ScreenOrientation.Portrait;
                Panel_Logo_Controller.Open(ctx);
                var assets = ctx.assetModule;
                assets.BeginLoadAll();
            } catch (Exception error) {
                Fail(ctx, error);
            }
        }

        public static void Advance(GameContext ctx, float deltaTime) {
            var state = ctx.state_Loading;
            state.elapsedSeconds += deltaTime;
        }

        public static void LoadAssets(GameContext ctx) {
            var assets = ctx.assetModule;
            var state = ctx.state_Loading;
            if (!assets.IsLoadDone()) {
                return;
            }
            assets.CompleteLoadAll();
            HomeController.InitializeSave(ctx);
            state.assetsLoaded = true;
        }

        public static void CompleteLogo(GameContext ctx) {
            var state = ctx.state_Loading;
            if (state.status == LoadingStatus.Loading) {
                state.logoCompleted = true;
            }
        }

        public static void SetReady(GameContext ctx) {
            var state = ctx.state_Loading;
            HomeSystem.Open(ctx);
            Panel_Logo_Controller.Close(ctx);
            state.status = LoadingStatus.Ready;
        }

        public static void NotifyReady(GameContext ctx) {
            var state = ctx.state_Loading;
            var events = ctx.events_Loading;
            if (state.status != LoadingStatus.Ready || state.readyNotified) {
                return;
            }
            state.readyNotified = true;
            events.readyHandle?.Invoke();
        }

        public static void Fail(GameContext ctx, Exception error) {
            var state = ctx.state_Loading;
            var events = ctx.events_Loading;
            var audio = ctx.audioModule;
            state.status = LoadingStatus.Failed;
            state.error = error;
            Panel_Logo_Controller.Close(ctx);
            audio.Stop();
            Debug.LogException(error);
            events.errorHandle?.Invoke(error);
        }

        public static void Dispose(GameContext ctx) {
            var state = ctx.state_Loading;
            var events = ctx.events_Loading;
            var audio = ctx.audioModule;
            if (state.status == LoadingStatus.Disposed) {
                return;
            }
            state.status = LoadingStatus.Disposed;
            Panel_Logo_Controller.Close(ctx);
            audio.Stop();
            var localization = ctx.l10NModule;
            var assets = ctx.assetModule;
            localization.Release();
            assets.Release();
            events.readyHandle = null;
            events.errorHandle = null;
        }
    }
}
