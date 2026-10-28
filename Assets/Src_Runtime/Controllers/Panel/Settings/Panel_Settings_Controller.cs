using System;
using UnityEngine;
namespace Hamdoku.Controllers {
    public static class Panel_Settings_Controller {
        public static void Open(GameContext ctx) {
            var result = PanelFactory.TryOpen(ctx, PanelType.Settings, out Panel_Settings panel);
            if (result == UIOpenType.FirstOpen) {
                var localization = ctx.l10NModule;
                panel.Ctor(localization);
                panel.actionHandle = action => SettingsController.Act(ctx, action);
            }
            Refresh(ctx);
            panel.Init();
        }
        static string Text(GameContext ctx, UINameType id) {
            var localization = ctx.l10NModule;
            if (!localization.TryGet(id, out string text)) {
                throw new InvalidOperationException("Missing settings text: " + id);
            }
            return text;
        }
        public static void Refresh(GameContext ctx) {
            var panels = ctx.panelRepository;
            if (!panels.TryGet(PanelType.Settings, out Panel_Settings panel)) {
                return;
            }
            var assets = ctx.assetModule;
            var config = assets.GetSettingsConfig();
            var save = ctx.playerSave;
            var settings = save.settings;
            var state = ctx.state_Settings;
            var game = ctx.state_Game;
            panel.title.text = Text(ctx, UINameType.Settings_Title);
            var ids = new[] { UINameType.Settings_Effects, UINameType.Settings_Music, UINameType.Settings_Voice, UINameType.Settings_Vibration,
                UINameType.Settings_Border, UINameType.Settings_Pattern, UINameType.Settings_Language };
            for (int i = 0; i < ids.Length; i++) {
                panel.rowLabels[i].text = Text(ctx, ids[i]);
            }
            panel.ShowSwitch(0, settings.effects, config);
            panel.ShowSwitch(1, settings.music, config);
            panel.ShowSwitch(2, settings.vibration, config);
            panel.ShowSwitch(3, settings.border, config);
            panel.ShowSwitch(4, settings.pattern, config);
            panel.voiceValue.text = Text(ctx, settings.voice == ComboVoiceType.Cute ? UINameType.Settings_Cute : settings.voice == ComboVoiceType.Female ? UINameType.Settings_Female :
                settings.voice == ComboVoiceType.Male ? UINameType.Settings_Male : UINameType.Settings_Off);
            panel.languageValue.text = Text(ctx, save.language == SystemLanguage.English ? UINameType.Settings_English : UINameType.Settings_Chinese);
            panel.saveLabel.text = Text(ctx, UINameType.Settings_Save);
            panel.restartLabel.text = Text(ctx, UINameType.Game_Restart);
            panel.tutorialLabel.text = Text(ctx, UINameType.Settings_Tutorial);
            panel.linkLabels[0].text = Text(ctx, UINameType.Settings_Support);
            panel.linkLabels[1].text = Text(ctx, UINameType.Settings_Privacy);
            panel.linkLabels[2].text = Text(ctx, UINameType.Settings_Terms);
            panel.versionLabel.text = "v" + Application.version;
            var dialog = state.dialog;
            panel.dialogRoot.SetActive(dialog != SettingsDialogType.None);
            panel.chineseButton.gameObject.SetActive(dialog == SettingsDialogType.Language);
            panel.englishButton.gameObject.SetActive(dialog == SettingsDialogType.Language);
            panel.startButton.gameObject.SetActive(dialog == SettingsDialogType.Tutorial);
            panel.chineseLabel.text = Text(ctx, UINameType.Settings_Chinese);
            panel.englishLabel.text = Text(ctx, UINameType.Settings_English);
            panel.chineseButton.GetComponent<UnityEngine.UI.Image>().color = save.language == SystemLanguage.ChineseSimplified ? config.listSelColor : config.listBgColor;
            panel.englishButton.GetComponent<UnityEngine.UI.Image>().color = save.language == SystemLanguage.English ? config.listSelColor : config.listBgColor;
            panel.startLabel.text = Text(ctx, UINameType.Settings_Start);
            panel.closeLabel.text = Text(ctx, UINameType.Settings_Close);
            panel.dialogTitle.text = Text(ctx, dialog == SettingsDialogType.Save ? UINameType.Settings_Save : dialog == SettingsDialogType.Tutorial ? UINameType.Settings_Tutorial :
                dialog == SettingsDialogType.Support ? UINameType.Settings_Support : dialog == SettingsDialogType.Privacy ? UINameType.Settings_Privacy :
                dialog == SettingsDialogType.Terms ? UINameType.Settings_Terms : UINameType.Settings_Language);
            panel.dialogBody.text = dialog == SettingsDialogType.Language || dialog == SettingsDialogType.None ? string.Empty :
                Text(ctx, dialog == SettingsDialogType.Save ? UINameType.Settings_SaveBody : dialog == SettingsDialogType.Tutorial ? UINameType.Settings_TutorialBody :
                dialog == SettingsDialogType.Support ? UINameType.Settings_SupportBody : dialog == SettingsDialogType.Privacy ? UINameType.Settings_PrivacyBody : UINameType.Settings_TermsBody);
            panel.ShowLayout(game.isOpen, game.isOpen && !game.isTutorial && game.status == GameStatus.Playing && game.dialog == GameDialogType.None, config);
        }
        public static void RefreshSafeArea(GameContext ctx) {
            var panels = ctx.panelRepository;
            if (panels.TryGet(PanelType.Settings, out Panel_Settings panel)) {
                panel.RefreshSafeArea();
            }
        }
        public static void Close(GameContext ctx) {
            var panels = ctx.panelRepository;
            if (panels.TryGet(PanelType.Settings, out Panel_Settings panel)) {
                panels.Remove(panel);
                panel.TearDown();
            }
            var state = ctx.state_Settings;
            state.isOpen = false;
            state.dialog = SettingsDialogType.None;
        }
    }
}
