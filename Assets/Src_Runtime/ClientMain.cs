using System;
using Hamdoku.Controllers;
using UnityEngine;

namespace Hamdoku.Main {
    public sealed class ClientMain : MonoBehaviour {
        [SerializeField] public CanvasEntity canvas_Screen;
        [SerializeField] public Panel_Logo panel_Logo;
        [SerializeField] public LogoConfigSO logoConfig;
        [SerializeField] public AudioSource logoEffects;
        public Action readyHandle;
        public Action<Exception> errorHandle;
        public Action<HomeRequestType> homeRequestHandle;
        GameContext ctx;
        bool isTornDown;

        public GameContext GetContext() {
            return ctx;
        }

        void Awake() {
            if (canvas_Screen == null || panel_Logo == null || logoConfig == null || logoEffects == null) {
                throw new InvalidOperationException("Scene_Main must bind its Canvas, Panel_Logo, LogoConfigSO and AudioSource.");
            }
            ctx = new GameContext();
            ctx.state_Loading = new LoadingState();
            ctx.events_Loading = new LoadingSystemEvents();
            ctx.canvasRepository = new CanvasRepository();
            ctx.audioModule = new AudioModule(logoEffects);
            ctx.panel_Logo = panel_Logo;
            ctx.logoConfig = logoConfig;
            ctx.assetModule = new AssetModule();
            ctx.saveModule = new SaveModule();
            ctx.l10NModule = new L10NModule();
            ctx.panelRepository = new PanelRepository();
            ctx.playerSave = new PlayerSaveModel();
            ctx.state_Home = new HomeState();
            ctx.events_Home = new HomeSystemEvents();
            var homeEvents = ctx.events_Home;
            homeEvents.requestHandle = request => {
                homeRequestHandle?.Invoke(request);
            };
            var canvases = ctx.canvasRepository;
            canvases.Add(canvas_Screen);
            var events = ctx.events_Loading;
            events.readyHandle = () => {
                readyHandle?.Invoke();
            };
            events.errorHandle = error => {
                errorHandle?.Invoke(error);
            };
        }

        void Start() {
            Initialize();
        }

        public void Initialize() {
            if (isTornDown || ctx == null) {
                throw new InvalidOperationException("ClientMain must be awake and not disposed before initialization.");
            }
            LoadingSystem.Initialize(ctx);
        }

        void Update() {
            LoadingSystem.Tick(ctx, Time.unscaledDeltaTime);
            HomeSystem.Tick(ctx, Time.unscaledDeltaTime);
        }

        void OnDestroy() {
            TearDown();
        }

        void OnApplicationQuit() {
            TearDown();
        }

        void TearDown() {
            if (isTornDown || ctx == null) {
                return;
            }
            isTornDown = true;
            HomeSystem.Exit(ctx);
            LoadingController.Dispose(ctx);
            readyHandle = null;
            errorHandle = null;
            homeRequestHandle = null;
        }
    }
}
