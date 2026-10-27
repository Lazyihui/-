using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using TMPro;
using UnityEditor;
using UnityEditor.AddressableAssets;
using UnityEngine;
namespace Hamdoku.Editor {
    public static class SettingsSetupEM {
        [MenuItem("Hamdoku/Setup/Configure Settings")]
        public static void Setup() {
            ImportSprites();
            var config = CreateConfig();
            BakeFonts();
            string path = "Assets/Res_Runtime/UI/Settings/Panel_Settings.prefab";
            if (AssetDatabase.LoadAssetAtPath<GameObject>(path) == null) {
                CreatePanel(path, AssetDatabase.LoadAssetAtPath<TMP_FontAsset>("Assets/Res_Runtime/Font/Chinese SDF.asset"), config);
            }
            var root = PrefabUtility.LoadPrefabContents(path);
            try {
                var panel = root.GetComponent<Panel_Settings>();
                var overlay = root.transform.Find("Overlay").GetComponent<UnityEngine.UI.Image>();
                overlay.color = new Color(0, 0, 0, .97f);
                var close = panel.contentRoot.Find("Close").GetComponent<UnityEngine.UI.Image>();
                close.sprite = Sprite("icon_close");
                foreach (var track in panel.tracks) {
                    track.pixelsPerUnitMultiplier = 44f / config.toggleSize.y;
                }
                PrefabUtility.SaveAsPrefabAsset(root, path);
            } finally {
                PrefabUtility.UnloadPrefabContents(root);
            }
            BindRegionEdges();
            var home = AssetDatabase.LoadAssetAtPath<HomeConfigSO>("Assets/Res_Runtime/Config/HomeConfig.asset");
            home.saveVersion = 6;
            EditorUtility.SetDirty(home);
            var settings = AddressableAssetSettingsDefaultObject.Settings;
            foreach (string asset in new[] { path, "Assets/Res_Runtime/Config/SettingsConfig.asset" }.Concat(
                AssetDatabase.FindAssets("t:L10NSO", new[] { "Assets/Res_Runtime/Localization" }).Select(AssetDatabase.GUIDToAssetPath).Where(p => Path.GetFileName(p).StartsWith("Settings_")))) {
                var entry = settings.CreateOrMoveEntry(AssetDatabase.AssetPathToGUID(asset), settings.DefaultGroup);
                entry.SetLabel(AAConst.LABEL_DEFAULT, true, true);
            }
            EditorUtility.SetDirty(settings);
            AssetDatabase.SaveAssets();
            Debug.Log("[SettingsSetup] Saved original-derived settings prefab, configuration, fonts, board edges and Addressables registration.");
        }
        static void ImportSprites() {
            foreach (string path in Directory.GetFiles("Assets/Res_Runtime/UI/Settings", "*.png")) {
                var importer = (TextureImporter)AssetImporter.GetAtPath(path);
                var settings = new TextureImporterSettings();
                importer.ReadTextureSettings(settings);
                settings.textureType = TextureImporterType.Sprite;
                settings.spriteMode = (int)SpriteImportMode.Single;
                settings.spriteMeshType = SpriteMeshType.FullRect;
                settings.spritePixelsPerUnit = 100;
                settings.alphaIsTransparency = true;
                settings.mipmapEnabled = false;
                settings.spriteBorder = OriginalBorder(Path.GetFileNameWithoutExtension(path));
                importer.SetTextureSettings(settings);
                importer.textureCompression = TextureImporterCompression.Uncompressed;
                importer.maxTextureSize = 2048;
                importer.SaveAndReimport();
            }
        }
        static Vector4 OriginalBorder(string name) {
            switch (name) {
                case "PopupPanel": return new Vector4(28.0f, 28.0f, 28.0f, 28.0f);
                case "PopupPanelInner": return new Vector4(28.0f, 28.0f, 28.0f, 28.0f);
                case "RoundedFill": return new Vector4(22.0f, 22.0f, 22.0f, 22.0f);
                case "CircleFill": return new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
                case "icon_sfx": return new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
                case "icon_music": return new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
                case "icon_combo_voice": return new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
                case "icon_vibration": return new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
                case "icon_border": return new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
                case "icon_pattern": return new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
                case "icon_language": return new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
                case "icon_save": return new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
                case "icon_tutorial": return new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
                case "icon_support": return new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
                case "icon_privacy": return new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
                case "icon_terms": return new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
                case "icon_chevron": return new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
                case "icon_close": return Vector4.zero;
                case "popup_btn_close": return new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
                default: throw new InvalidOperationException("Unmapped original settings Sprite: " + name);
            }
        }
        static SettingsConfigSO CreateConfig() {
            string path = "Assets/Res_Runtime/Config/SettingsConfig.asset";
            var config = AssetDatabase.LoadAssetAtPath<SettingsConfigSO>(path);
            if (config != null) {
                return config;
            }
            config = ScriptableObject.CreateInstance<SettingsConfigSO>();
            config.panelWidth = 820.0f;
            config.panelPpum = 0.6000000238418579f;
            config.padTop = 56.0f;
            config.padBottom = 44.0f;
            config.padSide = 44.0f;
            config.titleFs = 62.0f;
            config.titleH = 90.0f;
            config.closeSize = 116.0f;
            config.closeOffset = new Vector2(-24.0f, -24.0f);
            config.groupPpum = 0.699999988079071f;
            config.rowH = 120.0f;
            config.groupPadV = 18.0f;
            config.rowIconSize = 80.0f;
            config.rowIconX = 95.0f;
            config.rowLabelX = 175.0f;
            config.rowLabelFs = 38.0f;
            config.sepThickness = 2.0f;
            config.sepInset = 34.0f;
            config.sepColor = new Color(0.550000011920929f, 0.44999998807907104f, 0.3499999940395355f, 0.15000000596046448f);
            config.toggleSize = new Vector2(180.0f, 64.0f);
            config.toggleRightPad = 40.0f;
            config.knobSize = 52.0f;
            config.knobInset = 8.0f;
            config.toggleTextFs = 30.0f;
            config.toggleTextX = 34.0f;
            config.trackOnColor = new Color(0.24705882370471954f, 0.6705882549285889f, 0.6470588445663452f, 1.0f);
            config.trackOffColor = new Color(0.6292719841003418f, 0.7452830076217651f, 0.7355154156684875f, 1.0f);
            config.toggleTextColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            config.voicePillSize = new Vector2(268.0f, 72.0f);
            config.voiceArrowSize = 60.0f;
            config.voiceArrowInset = 4.0f;
            config.voiceValueFs = 34.0f;
            config.voicePillColor = new Color(0.9399999976158142f, 0.9100000262260437f, 0.8600000143051147f, 1.0f);
            config.langValueFs = 36.0f;
            config.chevronRightPad = 70.0f;
            config.chevronSize = 36.0f;
            config.langValueGap = 34.0f;
            config.listBgColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            config.listSelColor = new Color(0.9433962106704712f, 0.8812651634216309f, 0.7431470155715942f, 0.8509804010391235f);
            config.langListW = 360.0f;
            config.langListYOffset = 44.0f;
            config.langListItemH = 96.0f;
            config.langListFs = 36.0f;
            config.langListPad = 12.0f;
            config.langListVisibleRows = 5;
            config.langListPeek = 0.5f;
            config.accountBlockH = 135.0f;
            config.gapGroupAccount = 26.0f;
            config.accountIconSize = 64.0f;
            config.accountIconGap = 14.0f;
            config.saveGapTitleBody = 30.0f;
            config.saveMsgFs = 38.0f;
            config.saveMsgH = 130.0f;
            config.saveMsgColor = new Color(0.550000011920929f, 0.33000001311302185f, 0.33000001311302185f, 1.0f);
            config.saveGapMsgBtns = 36.0f;
            config.saveBtnSize = new Vector2(700.0f, 124.0f);
            config.saveBtnGap = 30.0f;
            config.saveBtnFs = 42.0f;
            config.saveBtnIconSize = 64.0f;
            config.saveBtnIconX = 66.0f;
            config.saveBorderW = 3.0f;
            config.saveFacebookColor = new Color(0.03099999949336052f, 0.4000000059604645f, 1.0f, 1.0f);
            config.saveGoogleColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            config.saveGoogleBorderColor = new Color(0.550000011920929f, 0.550000011920929f, 0.550000011920929f, 1.0f);
            config.saveGoogleTextColor = new Color(0.11999999731779099f, 0.11999999731779099f, 0.11999999731779099f, 1.0f);
            config.saveAppleColor = new Color(0.0f, 0.0f, 0.0f, 1.0f);
            config.saveGapBtnsLink = 44.0f;
            config.saveLinkFs = 34.0f;
            config.saveLinkH = 60.0f;
            config.saveLinkColor = new Color(0.550000011920929f, 0.33000001311302185f, 0.33000001311302185f, 1.0f);
            config.savePadBottom = 60.0f;
            config.saveStatusBoxH = 300.0f;
            config.saveStatusPad = 40.0f;
            config.saveStatusFs = 38.0f;
            config.saveStatusLineSpacing = 26.0f;
            config.saveShowEmail = 1;
            config.saveGapBoxBtn = 40.0f;
            config.saveDeleteBoxH = 500.0f;
            config.saveDeleteGapTitleBox = 16.0f;
            config.saveDeleteGapBoxBtn = 34.0f;
            config.saveDeleteFs = 35.0f;
            config.saveDeleteLineSpacing = 40.0f;
            config.saveDeleteParagraphSpacing = 40.0f;
            config.saveDeletePad = 36.0f;
            config.saveNoticeBoxH = 330.0f;
            config.saveNoticeMaxBoxH = 1000.0f;
            config.saveResultBoxH = 440.0f;
            config.saveResultIconSize = 170.0f;
            config.saveResultIconTop = 44.0f;
            config.saveResultTextGap = 40.0f;
            config.saveResultFs = 40.0f;
            config.saveResultLineSpacing = 26.0f;
            config.saveResultOkColor = new Color(0.30000001192092896f, 0.6899999976158142f, 0.3100000023841858f, 1.0f);
            config.saveResultFailColor = new Color(0.9100000262260437f, 0.30000001192092896f, 0.30000001192092896f, 1.0f);
            config.gapTitleGroup = 34.0f;
            config.gapGroupDash = 42.0f;
            config.gapDashBtn = 42.0f;
            config.gapBtnBtn = 10.0f;
            config.gapBtnLinks = 60.0f;
            config.gapLinksVersion = 50.0f;
            config.dashLen = 10.0f;
            config.dashGap = 10.0f;
            config.dashThickness = 2.0f;
            config.dashColor = new Color(0.8301886916160583f, 0.6590957641601562f, 0.48166608810424805f, 0.729411780834198f);
            config.btnH = 120.0f;
            config.btnPpum = 1.125f;
            config.btnFs = 38.0f;
            config.btnIconSize = 70.0f;
            config.btnIconX = 130.0f;
            config.linkIconSize = 70.0f;
            config.linkFs = 30.0f;
            config.linkIconTextGap = 10.0f;
            config.linkItemGap = 250.0f;
            config.linkRowH = 52.0f;
            config.uidFs = 26.0f;
            config.uidH = 46.0f;
            config.uidCopyIconSize = 42.0f;
            config.uidCopyGap = 14.0f;
            config.uidVersionGap = 28.0f;
            config.uidDisplayChars = 0;
            config.versionFs = 28.0f;
            config.versionH = 42.0f;
            config.wideScale = 0.800000011920929f;
            config.fitMargin = 0.9399999976158142f;
            config.defaultEffects = true;
            config.defaultMusic = true;
            config.defaultVibration = true;
            config.defaultBorder = false;
            config.defaultPattern = false;
            config.defaultVoice = ComboVoiceType.Cute;
            config.backgroundMusic = AssetDatabase.LoadAssetAtPath<AudioClip>("Assets/Res_Runtime/Audio/Settings/bgm.wav");
            config.cuteVoices = Clips("cute");
            config.femaleVoices = Clips("female");
            config.maleVoices = Clips("male");
            config.musicVolume = .3f;
            config.voiceVolume = .8f;
            config.sampleTier = 3;
            config.borderColor = new Color(.39f, .29f, .20f, .85f);
            config.borderWidth = 4;
            AssetDatabase.CreateAsset(config, path);
            return config;
        }
        static AudioClip[] Clips(string theme) {
            var clips = new AudioClip[10];
            for (int i = 0; i < clips.Length; i++) {
                string path = "Assets/Res_Runtime/Audio/Settings/combo_" + theme + "_combo_" + (i + 1).ToString("00") + ".wav";
                clips[i] = AssetDatabase.LoadAssetAtPath<AudioClip>(path);
                if (clips[i] == null) {
                    throw new InvalidOperationException("Missing original combo clip: " + path);
                }
            }
            return clips;
        }
        static void BakeFonts() {
            var entries = AssetDatabase.FindAssets("t:L10NSO", new[] { "Assets/Res_Runtime/Localization" }).Select(
                guid => AssetDatabase.LoadAssetAtPath<L10NSO>(AssetDatabase.GUIDToAssetPath(guid))).ToArray();
            foreach (string language in new[] { "Chinese", "English" }) {
                var font = AssetDatabase.LoadAssetAtPath<TMP_FontAsset>("Assets/Res_Runtime/Font/" + language + " SDF.asset");
                string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789 /:+.-" + string.Concat(entries.Select(e => language == "Chinese" ? e.chinese : e.english));
                characters = Regex.Replace(characters, "<[^>]*>|\\{[^}]*\\}", string.Empty).Replace("\n", string.Empty).Replace("\r", string.Empty);
                if (!font.HasCharacters(characters)) {
                    var serialized = new SerializedObject(font);
                    var source = AssetDatabase.LoadAssetAtPath<Font>(AssetDatabase.GUIDToAssetPath(serialized.FindProperty("m_SourceFontFileGUID").stringValue));
                    if (source == null) {
                        throw new InvalidOperationException("Missing profile font source: " + language);
                    }
                    serialized.FindProperty("m_SourceFontFile").objectReferenceValue = source;
                    serialized.ApplyModifiedPropertiesWithoutUndo();
                    font.atlasPopulationMode = AtlasPopulationMode.Dynamic;
                    font.isMultiAtlasTexturesEnabled = true;
                    try {
                        if (!font.TryAddCharacters(characters, out string missing)) {
                            throw new InvalidOperationException("Profile font cannot bake: " + missing);
                        }
                    } finally {
                        font.atlasPopulationMode = AtlasPopulationMode.Static;
                    }
                    EditorUtility.SetDirty(font);
                    foreach (var texture in font.atlasTextures) {
                        EditorUtility.SetDirty(texture);
                    }
                }
            }
        }


        static void BindRegionEdges() {
            string path = "Assets/Res_Runtime/UI/Game/Widget_BoardCell.prefab";
            var root = PrefabUtility.LoadPrefabContents(path);
            try {
                var cell = root.GetComponent<Widget_BoardCell>();
                if (cell.regionEdges == null || cell.regionEdges.Length == 0) {
                    cell.regionEdges = new UnityEngine.UI.Image[4];
                    for (int i = 0; i < 4; i++) {
                        var edge = Image("RegionEdge" + i, root.transform, null, Vector2.zero, Vector2.zero);
                        var rect = edge.rectTransform;
                        rect.anchorMin = i == 0 ? new Vector2(0, 1) : i == 1 ? new Vector2(1, 0) : Vector2.zero;
                        rect.anchorMax = i == 0 ? Vector2.one : i == 1 ? Vector2.one : i == 2 ? new Vector2(1, 0) : new Vector2(0, 1);
                        rect.pivot = i == 0 ? new Vector2(.5f, 1) : i == 1 ? new Vector2(1, .5f) : i == 2 ? new Vector2(.5f, 0) : new Vector2(0, .5f);
                        edge.enabled = false;
                        cell.regionEdges[i] = edge;
                    }
                }
                if (cell.regionEdges.Length != 4 || cell.regionEdges.Any(e => e == null)) {
                    throw new InvalidOperationException("Board region edge bindings are incomplete.");
                }
                PrefabUtility.SaveAsPrefabAsset(root, path);
            } finally {
                PrefabUtility.UnloadPrefabContents(root);
            }
        }
        static void CreatePanel(string path, TMP_FontAsset font, SettingsConfigSO config) {
            var root = Rect("Panel_Settings", null, Vector2.zero, Vector2.zero);
            Stretch(root);
            var panel = root.gameObject.AddComponent<Panel_Settings>();
            var buttons = new List<UnityEngine.UI.Button>();
            var actions = new List<SettingsActionType>();
            var overlay = Image("Overlay", root, null, Vector2.zero, Vector2.zero);
            Stretch(overlay.rectTransform);
            overlay.color = new Color(0, 0, 0, .97f);
            overlay.raycastTarget = true;
            panel.safeRoot = Rect("SafeRoot", root, Vector2.zero, Vector2.zero);
            Stretch(panel.safeRoot);
            // The original seven-row popup: Title, Group, AccountBlock, Dash, Tutorial, Links, Footer.
            float groupW = config.panelWidth - config.padSide * 2;
            float groupH = config.rowH * 7 + config.groupPadV * 2;
            float groupTop = config.padTop + config.titleH + config.gapTitleGroup;
            float accountTop = groupTop + groupH + config.gapGroupAccount;
            float dashY = accountTop + config.accountBlockH + config.gapGroupDash;
            float tutorialY = dashY + config.gapDashBtn + config.btnH / 2;
            float linksY = tutorialY + config.btnH / 2 + config.gapBtnLinks + config.linkRowH / 2;
            float versionY = linksY + config.linkRowH / 2 + config.gapLinksVersion + config.versionH / 2;
            float panelH = versionY + config.versionH / 2 + config.padBottom;
            panel.contentRoot = Rect("Panel", panel.safeRoot, new Vector2(config.panelWidth, panelH), Vector2.zero);
            var bg = panel.contentRoot.gameObject.AddComponent<UnityEngine.UI.Image>();
            bg.sprite = Sprite("PopupPanel");
            bg.type = UnityEngine.UI.Image.Type.Sliced;
            bg.pixelsPerUnitMultiplier = config.panelPpum;
            bg.raycastTarget = true;
            var content = panel.contentRoot;
            float top = panelH / 2;
            panel.title = Label("Title", content, font, new Vector2(groupW, config.titleH), new Vector2(0, top - config.padTop - config.titleH / 2), config.titleFs);
            var close = Button("Close", content, Sprite("icon_close"), Vector2.one * config.closeSize,
                new Vector2(config.panelWidth / 2 + config.closeOffset.x - config.closeSize / 2, top + config.closeOffset.y - config.closeSize / 2));
            Bind(close, SettingsActionType.Close, buttons, actions);
            var group = Image("Group", content, Sprite("PopupPanelInner"), new Vector2(groupW, groupH), new Vector2(0, top - groupTop - groupH / 2));
            group.pixelsPerUnitMultiplier = config.groupPpum;
            string[] rowNames = { "Sfx", "Music", "ComboVoice", "Vibration", "RegionBorder", "Pattern", "Language" };
            string[] icons = { "icon_sfx", "icon_music", "icon_combo_voice", "icon_vibration", "icon_border", "icon_pattern", "icon_language" };
            panel.rowLabels = new TMP_Text[7];
            panel.switchLabels = new TMP_Text[5];
            panel.tracks = new UnityEngine.UI.Image[5];
            panel.knobs = new RectTransform[5];
            int toggle = 0;
            for (int i = 0; i < 7; i++) {
                var row = Rect(rowNames[i], group.transform, new Vector2(groupW, config.rowH), new Vector2(0, groupH / 2 - config.groupPadV - (i + .5f) * config.rowH));
                Image("Icon", row, Sprite(icons[i]), Vector2.one * config.rowIconSize, new Vector2(-groupW / 2 + config.rowIconX, 0));
                panel.rowLabels[i] = Label("Label", row, font, new Vector2(280, config.rowH), new Vector2(-groupW / 2 + config.rowLabelX + 140, 0), config.rowLabelFs);
                panel.rowLabels[i].alignment = TextAlignmentOptions.MidlineLeft;
                if (i < 6) {
                    var sep = Image("Separator", row, null, new Vector2(groupW - config.sepInset * 2, config.sepThickness), new Vector2(0, -config.rowH / 2));
                    sep.color = config.sepColor;
                }
                if (i != 2 && i != 6) {
                    var track = Button("Switch", row, Sprite("RoundedFill"), config.toggleSize, new Vector2(groupW / 2 - config.toggleRightPad - config.toggleSize.x / 2, 0));
                    var graphic = track.GetComponent<UnityEngine.UI.Image>();
                    graphic.preserveAspect = false;
                    graphic.pixelsPerUnitMultiplier = 44f / config.toggleSize.y;
                    var knob = Image("Knob", track.transform, Sprite("CircleFill"), Vector2.one * config.knobSize, Vector2.zero);
                    knob.color = new Color(1, .97f, .92f);
                    panel.switchLabels[toggle] = Label("State", track.transform, font, new Vector2(82, 54), Vector2.zero, config.toggleTextFs);
                    panel.switchLabels[toggle].color = config.toggleTextColor;
                    panel.tracks[toggle] = graphic;
                    panel.knobs[toggle] = knob.rectTransform;
                    Bind(track, (SettingsActionType)(toggle + 1), buttons, actions);
                    toggle++;
                } else if (i == 2) {
                    var pill = Image("VoicePill", row, Sprite("RoundedFill"), config.voicePillSize, new Vector2(groupW / 2 - config.toggleRightPad - config.voicePillSize.x / 2, 0));
                    pill.color = config.voicePillColor;
                    panel.voiceValue = Label("Value", pill.transform, font, new Vector2(136, config.voicePillSize.y), Vector2.zero, config.voiceValueFs);
                    for (int a = 0; a < 2; a++) {
                        var arrow = Button(a == 0 ? "Previous" : "Next", pill.transform, Sprite("CircleFill"), Vector2.one * config.voiceArrowSize,
                            new Vector2((a == 0 ? -1 : 1) * (config.voicePillSize.x / 2 - config.voiceArrowSize / 2 - config.voiceArrowInset), 0));
                        var icon = Image("Chevron", arrow.transform, Sprite("icon_chevron"), Vector2.one * config.chevronSize, Vector2.zero);
                        icon.rectTransform.localRotation = Quaternion.Euler(0, 0, a == 0 ? 180 : 0);
                        Bind(arrow, a == 0 ? SettingsActionType.PreviousVoice : SettingsActionType.NextVoice, buttons, actions);
                    }
                } else {
                    var button = Button("LanguageButton", row, null, new Vector2(280, config.rowH), new Vector2(groupW / 2 - 160, 0));
                    button.GetComponent<UnityEngine.UI.Image>().color = Color.clear;
                    panel.languageValue = Label("Value", button.transform, font, new Vector2(210, config.rowH), new Vector2(-30, 0), config.langValueFs);
                    panel.languageValue.alignment = TextAlignmentOptions.MidlineRight;
                    Image("Chevron", row, Sprite("icon_chevron"), Vector2.one * config.chevronSize, new Vector2(groupW / 2 - config.chevronRightPad, 0));
                    Bind(button, SettingsActionType.Language, buttons, actions);
                }
            }
            var account = Button("AccountBlock", content, Sprite("PopupPanelInner"), new Vector2(groupW, config.accountBlockH), new Vector2(0, top - accountTop - config.accountBlockH / 2));
            account.GetComponent<UnityEngine.UI.Image>().pixelsPerUnitMultiplier = config.groupPpum;
            Image("Icon", account.transform, Sprite("icon_save"), Vector2.one * config.rowIconSize, new Vector2(-groupW / 2 + config.rowIconX, 0));
            panel.saveLabel = Label("Label", account.transform, font, new Vector2(470, 100), new Vector2(45, 0), config.rowLabelFs);
            panel.saveLabel.alignment = TextAlignmentOptions.MidlineLeft;
            Image("Chevron", account.transform, Sprite("icon_chevron"), Vector2.one * config.chevronSize, new Vector2(groupW / 2 - config.chevronRightPad, 0));
            Bind(account, SettingsActionType.Save, buttons, actions);
            var dashRoot = Rect("Dash", content, new Vector2(groupW, config.dashThickness), new Vector2(0, top - dashY));
            for (float x = -groupW / 2; x < groupW / 2; x += config.dashLen + config.dashGap) {
                var dash = Image("Dash", dashRoot, null, new Vector2(Mathf.Min(config.dashLen, groupW / 2 - x), config.dashThickness), new Vector2(x + config.dashLen / 2, 0));
                dash.color = config.dashColor;
            }
            var tutorial = Button("Tutorial", content, Sprite("btn_Game_Rounded_Blue"), new Vector2(groupW, config.btnH), new Vector2(0, top - tutorialY));
            tutorial.GetComponent<UnityEngine.UI.Image>().pixelsPerUnitMultiplier = config.btnPpum;
            Image("Icon", tutorial.transform, Sprite("icon_tutorial"), Vector2.one * config.btnIconSize, new Vector2(-groupW / 2 + config.btnIconX, 0));
            panel.tutorialLabel = Label("Label", tutorial.transform, font, new Vector2(450, config.btnH), new Vector2(60, 0), config.btnFs);
            Bind(tutorial, SettingsActionType.Tutorial, buttons, actions);
            var links = Rect("Links", content, new Vector2(groupW, config.linkRowH), new Vector2(0, top - linksY));
            panel.linkLabels = new TMP_Text[3];
            string[] linkIcons = { "icon_support", "icon_privacy", "icon_terms" };
            for (int i = 0; i < 3; i++) {
                var link = Button("Link" + i, links, null, new Vector2(235, 85), new Vector2((i - 1) * config.linkItemGap, 0));
                link.GetComponent<UnityEngine.UI.Image>().color = Color.clear;
                Image("Icon", link.transform, Sprite(linkIcons[i]), Vector2.one * config.linkIconSize, new Vector2(-65, 0));
                panel.linkLabels[i] = Label("Label", link.transform, font, new Vector2(140, 70), new Vector2(42, 0), config.linkFs);
                Bind(link, (SettingsActionType)((int)SettingsActionType.Support + i), buttons, actions);
            }
            panel.versionLabel = Label("Version", content, font, new Vector2(400, config.versionH), new Vector2(groupW / 2 - 200, top - versionY), config.versionFs);
            panel.versionLabel.alignment = TextAlignmentOptions.MidlineRight;
            CreateDialog(panel, font, buttons, actions);
            panel.buttons = buttons.ToArray();
            panel.actions = actions.ToArray();
            PrefabUtility.SaveAsPrefabAsset(root.gameObject, path);
            UnityEngine.Object.DestroyImmediate(root.gameObject);
        }
        static void CreateDialog(Panel_Settings panel, TMP_FontAsset font, List<UnityEngine.UI.Button> buttons, List<SettingsActionType> actions) {
            var root = Rect("Dialog", panel.contentRoot, new Vector2(820, 1770), Vector2.zero);
            panel.dialogRoot = root.gameObject;
            var shade = Button("Shade", root, null, new Vector2(4000, 5000), Vector2.zero);
            shade.GetComponent<UnityEngine.UI.Image>().color = new Color(0, 0, 0, .65f);
            Bind(shade, SettingsActionType.CloseDialog, buttons, actions);
            var box = Image("Box", root, Sprite("PopupPanel"), new Vector2(780, 860), Vector2.zero);
            box.raycastTarget = true;
            panel.dialogTitle = Label("Title", box.transform, font, new Vector2(670, 100), new Vector2(0, 320), 56);
            panel.dialogBody = Label("Body", box.transform, font, new Vector2(650, 400), new Vector2(0, 50), 38);
            panel.dialogBody.alignment = TextAlignmentOptions.TopLeft;
            panel.chineseButton = Button("Chinese", box.transform, Sprite("PopupPanelInner"), new Vector2(630, 110), new Vector2(0, 130));
            panel.chineseLabel = Label("Label", panel.chineseButton.transform, font, new Vector2(600, 100), Vector2.zero, 40);
            Bind(panel.chineseButton, SettingsActionType.Chinese, buttons, actions);
            panel.englishButton = Button("English", box.transform, Sprite("PopupPanelInner"), new Vector2(630, 110), new Vector2(0, -10));
            panel.englishLabel = Label("Label", panel.englishButton.transform, font, new Vector2(600, 100), Vector2.zero, 40);
            Bind(panel.englishButton, SettingsActionType.English, buttons, actions);
            panel.startButton = Button("StartTutorial", box.transform, Sprite("btn_Game_Rounded_Blue"), new Vector2(630, 115), new Vector2(0, -190));
            panel.startLabel = Label("Label", panel.startButton.transform, font, new Vector2(600, 100), Vector2.zero, 40);
            Bind(panel.startButton, SettingsActionType.StartTutorial, buttons, actions);
            var close = Button("CloseDialog", box.transform, Sprite("PopupPanelInner"), new Vector2(350, 100), new Vector2(0, -320));
            panel.closeLabel = Label("Label", close.transform, font, new Vector2(330, 100), Vector2.zero, 40);
            Bind(close, SettingsActionType.CloseDialog, buttons, actions);
            root.gameObject.SetActive(false);
        }
        static void Bind(UnityEngine.UI.Button button, SettingsActionType action, List<UnityEngine.UI.Button> buttons, List<SettingsActionType> actions) {
            buttons.Add(button);
            actions.Add(action);
        }
        static Sprite Sprite(string name) {
            foreach (string folder in new[] { "Settings", "Game", "Home" }) {
                var sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Res_Runtime/UI/" + folder + "/" + name + ".png");
                if (sprite != null) {
                    return sprite;
                }
            }
            throw new InvalidOperationException("Missing settings sprite: " + name);
        }
        static RectTransform Rect(string name, Transform parent, Vector2 size, Vector2 position) {
            var rect = new GameObject(name, typeof(RectTransform)).GetComponent<RectTransform>();
            rect.gameObject.layer = LayerMask.NameToLayer("UI");
            rect.SetParent(parent, false);
            rect.anchorMin = Vector2.one * .5f;
            rect.anchorMax = rect.anchorMin;
            rect.sizeDelta = size;
            rect.anchoredPosition = position;
            return rect;
        }

        static void Stretch(RectTransform rect) {
            rect.anchorMin = Vector2.zero;
            rect.anchorMax = Vector2.one;
            rect.offsetMin = Vector2.zero;
            rect.offsetMax = Vector2.zero;
        }

        static void Rectangular(UnityEngine.UI.Image image) {
            image.preserveAspect = false;
            image.type = UnityEngine.UI.Image.Type.Sliced;
        }

        static UnityEngine.UI.Image Image(string name, Transform parent, Sprite sprite, Vector2 size, Vector2 position) {
            var image = Rect(name, parent, size, position).gameObject.AddComponent<UnityEngine.UI.Image>();
            image.sprite = sprite;
            image.raycastTarget = false;
            image.preserveAspect = sprite != null && sprite.border == Vector4.zero;
            if (sprite != null && sprite.border != Vector4.zero) {
                image.type = UnityEngine.UI.Image.Type.Sliced;
                image.pixelsPerUnitMultiplier = 1;
            }
            return image;
        }

        static UnityEngine.UI.Button Hit(UnityEngine.UI.Image image) {
            image.raycastTarget = true;
            var button = image.gameObject.AddComponent<UnityEngine.UI.Button>();
            button.targetGraphic = image;
            return button;
        }

        static UnityEngine.UI.Button Button(string name, Transform parent, Sprite sprite, Vector2 size, Vector2 position) {
            return Hit(Image(name, parent, sprite, size, position));
        }

        static TMP_Text Label(string name, Transform parent, TMP_FontAsset font, Vector2 size, Vector2 position, float fontSize) {
            var text = Rect(name, parent, size, position).gameObject.AddComponent<TextMeshProUGUI>();
            text.font = font;
            text.fontSize = fontSize;
            text.fontSizeMin = fontSize * .65f;
            text.fontSizeMax = fontSize;
            text.enableAutoSizing = true;
            text.alignment = TextAlignmentOptions.Center;
            text.color = new Color(.32f, .24f, .18f);
            text.raycastTarget = false;
            text.richText = false;
            return text;
        }

    }
}
