namespace Hamdoku {
    public sealed class GameContext {
        public LoadingState state_Loading;
        public LoadingSystemEvents events_Loading;
        public CanvasRepository canvasRepository;
        public AudioModule audioModule;
        public Panel_Logo panel_Logo;
        public LogoConfigSO logoConfig;
        public AssetModule assetModule;
        public SaveModule saveModule;
        public L10NModule l10NModule;
        public PanelRepository panelRepository;
        public PlayerSaveModel playerSave;
        public HomeState state_Home;
        public HomeSystemEvents events_Home;
    }
}
