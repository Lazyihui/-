using System;
using UnityEngine;
namespace Hamdoku.Controllers {
    public static class SettingsController {
        public static void InitializeSave(GameContext ctx, PlayerSaveModel loaded) {
            var assets = ctx.assetModule;
            var config = assets.GetSettingsConfig();
            var save = ctx.playerSave;
            save.settings = loaded != null && loaded.version >= 6 ? loaded.settings : new SettingsSaveModel {
                effects = config.defaultEffects, music = config.defaultMusic, vibration = config.defaultVibration,
                border = config.defaultBorder, pattern = config.defaultPattern, voice = config.defaultVoice
            };
            SaveModule.ValidateSettings(save.settings);
            if (config.backgroundMusic == null || config.cuteVoices.Length != 10 || config.femaleVoices.Length != 10 || config.maleVoices.Length != 10 ||
                config.sampleTier < 1 || config.sampleTier > 10 || config.borderWidth <= 0) {
                throw new InvalidOperationException("Invalid settings audio or border configuration.");
            }
            ApplyAudio(ctx);
        }
        public static void ApplyAudio(GameContext ctx) {
            var assets = ctx.assetModule;
            var config = assets.GetSettingsConfig();
            var save = ctx.playerSave;
            var settings = save.settings;
            var audio = ctx.audioModule;
            audio.Configure(settings.effects, settings.music, settings.voice != ComboVoiceType.None, config.backgroundMusic, config.musicVolume);
        }
        public static void Open(GameContext ctx) {
            var state = ctx.state_Settings;
            if (state.isOpen || state.tutorialReview) {
                return;
            }
            var game = ctx.state_Game;
            if (game.isOpen && game.dialog != GameDialogType.None) {
                return;
            }
            var panels = ctx.panelRepository;
            if (panels.TryGet(PanelType.Game, out Panel_Game panel)) {
                panel.board.CancelGesture();
            }
            GameController.Persist(ctx);
            state.dialog = SettingsDialogType.None;
            state.isOpen = true;
            Panel_Settings_Controller.Open(ctx);
        }
        public static void Back(GameContext ctx) {
            var state = ctx.state_Settings;
            if (state.dialog != SettingsDialogType.None) {
                state.dialog = SettingsDialogType.None;
                Panel_Settings_Controller.Refresh(ctx);
            } else {
                Panel_Settings_Controller.Close(ctx);
            }
        }
        public static void Act(GameContext ctx, SettingsActionType action) {
            var state = ctx.state_Settings;
            if (!state.isOpen) {
                return;
            }
            if (action == SettingsActionType.Close || action == SettingsActionType.CloseDialog) {
                Back(ctx);
                return;
            }
            var save = ctx.playerSave;
            var settings = save.settings;
            if (state.dialog != SettingsDialogType.None) {
                if (state.dialog == SettingsDialogType.Language && (action == SettingsActionType.Chinese || action == SettingsActionType.English)) {
                    state.dialog = SettingsDialogType.None;
                    HomeController.SetLanguage(ctx, action == SettingsActionType.Chinese ? SystemLanguage.ChineseSimplified : SystemLanguage.English);
                } else if (state.dialog == SettingsDialogType.Tutorial && action == SettingsActionType.StartTutorial) {
                    StartTutorial(ctx);
                }
                return;
            }
            switch (action) {
                case SettingsActionType.Effects: settings.effects = !settings.effects; break;
                case SettingsActionType.Music: settings.music = !settings.music; break;
                case SettingsActionType.Vibration:
                    settings.vibration = !settings.vibration;
                    if (settings.vibration) {
                        var vibration = ctx.vibrationModule;
                        vibration.Pulse();
                    }
                    break;
                case SettingsActionType.Border: settings.border = !settings.border; break;
                case SettingsActionType.Pattern: settings.pattern = !settings.pattern; break;
                case SettingsActionType.PreviousVoice:
                case SettingsActionType.NextVoice:
                    settings.voice = (ComboVoiceType)(((int)settings.voice + (action == SettingsActionType.NextVoice ? 1 : 3)) % 4);
                    break;
                case SettingsActionType.Language: state.dialog = SettingsDialogType.Language; break;
                case SettingsActionType.Save:
                    var game = ctx.state_Game;
                    if (game.isOpen) {
                        return;
                    }
                    GameController.Persist(ctx);
                    HomeController.SaveProgress(ctx);
                    state.dialog = SettingsDialogType.Save;
                    break;
                case SettingsActionType.Restart:
                    var activeGame = ctx.state_Game;
                    if (!activeGame.isOpen || activeGame.isTutorial || activeGame.status != GameStatus.Playing || activeGame.dialog != GameDialogType.None) {
                        return;
                    }
                    Panel_Settings_Controller.Close(ctx);
                    GameController.Restart(ctx);
                    return;
                case SettingsActionType.Tutorial: state.dialog = SettingsDialogType.Tutorial; break;
                case SettingsActionType.Support: OpenLink(ctx, SettingsDialogType.Support); return;
                case SettingsActionType.Privacy: OpenLink(ctx, SettingsDialogType.Privacy); return;
                case SettingsActionType.Terms: OpenLink(ctx, SettingsDialogType.Terms); return;
                default: throw new ArgumentOutOfRangeException(nameof(action));
            }
            ApplyAudio(ctx);
            HomeController.SaveProgress(ctx);
            if (action == SettingsActionType.NextVoice || action == SettingsActionType.PreviousVoice) {
                var assets = ctx.assetModule;
                PlayVoice(ctx, assets.GetSettingsConfig().sampleTier);
            }
            Panel_Game_Controller.Refresh(ctx);
            Panel_Settings_Controller.Refresh(ctx);
        }
        static void OpenLink(GameContext ctx, SettingsDialogType type) {
            var assets = ctx.assetModule;
            var config = assets.GetSettingsConfig();
            string url = type == SettingsDialogType.Support ? config.supportUrl : type == SettingsDialogType.Privacy ? config.privacyUrl : config.termsUrl;
            if (!string.IsNullOrEmpty(url)) {
                if (!Uri.TryCreate(url, UriKind.Absolute, out var uri) || uri.Scheme != Uri.UriSchemeHttps) {
                    throw new InvalidOperationException("Settings links require a configured HTTPS URL.");
                }
                Application.OpenURL(url);
                return;
            }
            var state = ctx.state_Settings;
            state.dialog = type;
            Panel_Settings_Controller.Refresh(ctx);
        }
        public static void PlayVoice(GameContext ctx, int tier) {
            var save = ctx.playerSave;
            var settings = save.settings;
            if (!settings.effects || settings.voice == ComboVoiceType.None || tier < 3) {
                return;
            }
            var assets = ctx.assetModule;
            var config = assets.GetSettingsConfig();
            var clips = settings.voice == ComboVoiceType.Cute ? config.cuteVoices : settings.voice == ComboVoiceType.Female ? config.femaleVoices : config.maleVoices;
            var audio = ctx.audioModule;
            audio.PlayVoice(clips[Mathf.Min(tier, clips.Length) - 1], config.voiceVolume);
        }
        public static void StartTutorial(GameContext ctx) {
            var state = ctx.state_Settings;
            var game = ctx.state_Game;
            if (!state.isOpen || state.tutorialReview) {
                return;
            }
            state.returnToGame = game.isOpen;
            state.returnDailyDay = game.dailyDay;
            state.returnMode = game.mode;
            if (game.mode == GameModeType.Endless) {
                EndlessController.SuspendTutorial(ctx);
            }
            GameController.Persist(ctx);
            Panel_Settings_Controller.Close(ctx);
            Panel_Game_Controller.Close(ctx);
            game.isOpen = false;
            state.tutorialReview = true;
            var save = ctx.playerSave;
            var active = save.activePuzzle;
            try {
                save.activePuzzle = null;
                game.mode = GameModeType.None;
                GameController.Open(ctx, true);
            } finally {
                save.activePuzzle = active;
            }
        }
        public static void EndTutorial(GameContext ctx) {
            var state = ctx.state_Settings;
            var game = ctx.state_Game;
            if (!state.tutorialReview) {
                return;
            }
            Panel_GameDialog_Controller.Close(ctx);
            Panel_GameResult_Controller.Close(ctx);
            Panel_Game_Controller.Close(ctx);
            game.isOpen = false;
            state.tutorialReview = false;
            if (state.returnToGame) {
                if (state.returnMode == GameModeType.Endless) {
                    EndlessController.ResumeTutorial(ctx);
                } else {
                    GameController.Open(ctx, false, state.returnDailyDay);
                }
            } else {
                HomeSystem.Open(ctx);
            }
            Open(ctx);
        }
    }
}
