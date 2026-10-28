using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using TMPro;
using UnityEditor;
using UnityEditor.AddressableAssets;
using UnityEditor.AddressableAssets.Settings;
using UnityEditor.AddressableAssets.Settings.GroupSchemas;
using UnityEngine;

namespace Hamdoku.Editor {
    public static class DailySetupEM {
        [MenuItem("Hamdoku/Setup/Configure Daily Challenge")]
        public static void Setup() {
            AssetDatabase.Refresh();
            foreach (string path in Directory.GetFiles("Assets/Res_Runtime/UI/Daily", "*.png", SearchOption.AllDirectories)) {
                var importer = (TextureImporter)AssetImporter.GetAtPath(path);
                var settings = new TextureImporterSettings();
                importer.ReadTextureSettings(settings);
                settings.textureType = TextureImporterType.Sprite;
                settings.textureShape = TextureImporterShape.Texture2D;
                settings.spriteMode = (int)SpriteImportMode.Single;
                settings.spriteMeshType = SpriteMeshType.FullRect;
                settings.spritePixelsPerUnit = 100;
                settings.alphaIsTransparency = true;
                settings.mipmapEnabled = false;
                settings.npotScale = TextureImporterNPOTScale.None;
                string name = Path.GetFileNameWithoutExtension(path);
                settings.spriteBorder = name == "card" || name == "calendarCard" ? Vector4.one * 60 :
                    name == "start" ? Vector4.one * 80 : Vector4.zero;
                importer.SetTextureSettings(settings);
                importer.textureCompression = TextureImporterCompression.Uncompressed;
                importer.maxTextureSize = 2048;
                importer.SaveAndReimport();
            }
            BindSprites();
            BakeFonts();
            string panelPath = "Assets/Res_Runtime/UI/Daily/Panel_Daily.prefab";
            if (!File.Exists(panelPath)) {
                CreatePanel(panelPath);
            }
            Register(panelPath);
            AssetDatabase.SaveAssets();
            Debug.Log("[DailySetup] Formal daily prefab, original sprites, SO database and localization registered.");
        }

        static Sprite Sprite(string relative) {
            var sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Res_Runtime/UI/Daily/" + relative + ".png");
            if (sprite == null) {
                throw new InvalidOperationException("Missing daily sprite: " + relative);
            }
            return sprite;
        }

        static void BindSprites() {
            var config = AssetDatabase.LoadAssetAtPath<DailyConfigSO>("Assets/Res_Runtime/Config/DailyConfig.asset");
            config.background = Sprite("background");
            config.card = Sprite("card");
            config.calendarCard = Sprite("calendarCard");
            config.circle = Sprite("circle");
            config.clearStamp = Sprite("clearStamp");
            config.perfectStamp = Sprite("perfectStamp");
            config.clearIcon = Sprite("clearIcon");
            config.perfectIcon = Sprite("perfectIcon");
            config.back = Sprite("back");
            config.history = Sprite("history");
            config.clock = Sprite("clock");
            config.start = Sprite("start");
            foreach (var season in config.seasons) {
                string art = season.id == 202610 ? "halloween" : "bakery";
                season.artwork = Sprite(art + "/artwork");
                season.lines = Sprite(art + "/lines");
                for (int i = 0; i < season.pieces.Length; i++) {
                    season.pieces[i] = Sprite(art + "/piece_" + i.ToString("00"));
                    season.lockedPieces[i] = Sprite(art + "/piece_" + i.ToString("00") + "_locked");
                }
                EditorUtility.SetDirty(season);
            }
            EditorUtility.SetDirty(config);
        }

        static void BakeFonts() {
            var texts = AssetDatabase.FindAssets("t:L10NSO", new[] { "Assets/Res_Runtime/Localization" })
                .Select(id => AssetDatabase.LoadAssetAtPath<L10NSO>(AssetDatabase.GUIDToAssetPath(id))).ToArray();
            foreach (string language in new[] { "Chinese", "English" }) {
                var font = AssetDatabase.LoadAssetAtPath<TMP_FontAsset>("Assets/Res_Runtime/Font/" + language + " SDF.asset");
                string characters = "0123456789/: +—i" + string.Concat(texts.Select(text => language == "Chinese" ? text.chinese : text.english));
                characters = Regex.Replace(characters, "<[^>]*>|\\{[^}]*\\}", string.Empty).Replace("\n", string.Empty) + "<>";
                if (!font.HasCharacters(characters)) {
                    var serialized = new SerializedObject(font);
                    var source = AssetDatabase.LoadAssetAtPath<Font>(AssetDatabase.GUIDToAssetPath(serialized.FindProperty("m_SourceFontFileGUID").stringValue));
                    if (source == null) {
                        throw new InvalidOperationException("Missing daily localization font source.");
                    }
                    serialized.FindProperty("m_SourceFontFile").objectReferenceValue = source;
                    serialized.ApplyModifiedPropertiesWithoutUndo();
                    font.atlasPopulationMode = AtlasPopulationMode.Dynamic;
                    try {
                        if (!font.TryAddCharacters(characters, out string missing)) {
                            throw new InvalidOperationException("Missing daily glyphs: " + missing);
                        }
                    } finally {
                        font.atlasPopulationMode = AtlasPopulationMode.Static;
                    }
                }
                EditorUtility.SetDirty(font);
                foreach (var texture in font.atlasTextures) {
                    EditorUtility.SetDirty(texture);
                }
            }
        }

        static void CreatePanel(string path) {
            var config = AssetDatabase.LoadAssetAtPath<DailyConfigSO>("Assets/Res_Runtime/Config/DailyConfig.asset");
            var font = AssetDatabase.LoadAssetAtPath<TMP_FontAsset>("Assets/Res_Runtime/Font/Chinese SDF.asset");
            var root = Rect("Panel_Daily", null, Vector2.zero, Vector2.zero);
            Stretch(root);
            var panel = root.gameObject.AddComponent<Panel_Daily>();
            var background = Image("Background", root, config.background, new Vector2(1080, 1920), Vector2.zero);
            Stretch(background.rectTransform);
            var fitter = background.gameObject.AddComponent<UnityEngine.UI.AspectRatioFitter>();
            fitter.aspectMode = UnityEngine.UI.AspectRatioFitter.AspectMode.EnvelopeParent;
            fitter.aspectRatio = config.background.rect.width / config.background.rect.height;
            background.preserveAspect = false;
            panel.safeRoot = Rect("SafeArea", root, Vector2.zero, Vector2.zero);
            Stretch(panel.safeRoot);
            var content = Rect("DailySeasonPage", panel.safeRoot, new Vector2(1080, 1920), Vector2.zero);
            panel.contentRoot = content;
            var actions = new UnityEngine.UI.Button[11];
            actions[0] = Button("Back", content, config.back, new Vector2(84, 84), new Vector2(-440, 855));
            actions[1] = Button("Collection", content, config.history, new Vector2(84, 84), new Vector2(440, 855));
            panel.titleLabel = Label("Title", content, font, new Vector2(730, 90), new Vector2(0, 865), 62);
            panel.titleLabel.text = "10月每日挑战";
            panel.timerLabel = Label("Timer", content, font, new Vector2(660, 65), new Vector2(20, 775), 32);
            panel.timerLabel.color = new Color(.94f, .32f, .46f);
            Image("Clock", content, config.clock, new Vector2(40, 40), new Vector2(-300, 775));
            var card = Image("PuzzleCard", content, config.card, new Vector2(1000, 800), new Vector2(0, 320));
            card.pixelsPerUnitMultiplier = .55f;
            panel.artTitleLabel = Label("ArtTitle", card.transform, font, new Vector2(730, 70), new Vector2(0, 345), 38);
            panel.artTitleLabel.text = "不给仓鼠就捣蛋！";
            actions[2] = Button("Info", card.transform, config.circle, new Vector2(62, 62), new Vector2(405, 345));
            Label("Label", actions[2].transform, font, new Vector2(50, 55), Vector2.zero, 36).text = "i";
            var art = Rect("ArtWindow", card.transform, new Vector2(840, 504), new Vector2(0, 70));
            var pieces = new List<UnityEngine.UI.Image>();
            for (int i = 0; i < 35; i++) {
                var piece = Image("Piece_" + i.ToString("00"), art, config.seasons[0].lockedPieces[i % 30], Vector2.one * 100, Vector2.zero);
                piece.preserveAspect = false;
                pieces.Add(piece);
            }
            panel.pieces = pieces.ToArray();
            panel.puzzleLines = Image("Lines", art, config.seasons[0].lines, new Vector2(840, 504), Vector2.zero);
            panel.puzzleLines.preserveAspect = false;
            actions[10] = Button("Expand", art, null, new Vector2(840, 504), Vector2.zero);
            actions[10].targetGraphic.color = Color.clear;
            Image("Divider", card.transform, null, new Vector2(840, 2), new Vector2(0, -205)).color = new Color(.84f, .72f, .54f, .6f);
            var reward = Image("RewardPortrait", card.transform, config.circle, new Vector2(140, 140), new Vector2(-300, -290));
            reward.color = new Color(1, .86f, .46f);
            panel.rewardFace = Image("Face", reward.transform, null, new Vector2(105, 105), Vector2.zero);
            panel.rewardFace.preserveAspect = true;
            panel.rewardImage = Image("Costume", panel.rewardFace.transform, null, new Vector2(132, 132), Vector2.zero);
            panel.rewardImage.preserveAspect = true;
            actions[3] = Button("PreviousReward", card.transform, null, new Vector2(62, 80), new Vector2(-425, -290));
            actions[3].targetGraphic.color = Color.clear;
            Label("Label", actions[3].transform, font, new Vector2(62, 80), Vector2.zero, 60).text = "<";
            actions[4] = Button("NextReward", card.transform, null, new Vector2(62, 80), new Vector2(-195, -290));
            actions[4].targetGraphic.color = Color.clear;
            Label("Label", actions[4].transform, font, new Vector2(62, 80), Vector2.zero, 60).text = ">";
            panel.rewardDotsLabel = Label("RewardPage", card.transform, font, new Vector2(250, 36), new Vector2(-300, -380), 24);
            panel.rewardNameLabel = Label("RewardName", card.transform, font, new Vector2(430, 55), new Vector2(50, -255), 33);
            panel.rewardNameLabel.textWrappingMode = TextWrappingModes.NoWrap;
            panel.rewardNameLabel.color = new Color(.94f, .32f, .46f);
            panel.rewardProgressLabel = Label("RewardProgress", card.transform, font, new Vector2(130, 55), new Vector2(365, -255), 32);
            var bar = Image("RewardBar", card.transform, config.circle, new Vector2(550, 15), new Vector2(140, -300));
            bar.preserveAspect = false;
            bar.color = new Color(.94f, .88f, .77f);
            panel.rewardBar = Image("Fill", bar.transform, config.circle, new Vector2(550, 15), Vector2.zero);
            panel.rewardBar.preserveAspect = false;
            panel.rewardBar.type = UnityEngine.UI.Image.Type.Filled;
            panel.rewardBar.fillMethod = UnityEngine.UI.Image.FillMethod.Horizontal;
            panel.rewardBar.color = new Color(.96f, .51f, .61f);
            panel.rewardHintLabel = Label("RewardHint", card.transform, font, new Vector2(400, 60), new Vector2(50, -350), 25);
            actions[5] = Button("Claim", card.transform, config.start, new Vector2(135, 65), new Vector2(350, -350));
            panel.claimLabel = Label("Label", actions[5].transform, font, new Vector2(120, 50), Vector2.zero, 29);
            var calendar = Image("StampCard", content, config.calendarCard, new Vector2(1000, 700), new Vector2(0, -455));
            calendar.pixelsPerUnitMultiplier = .55f;
            Image("ClearIcon", calendar.transform, config.clearIcon, new Vector2(55, 55), new Vector2(-405, 285));
            Image("PerfectIcon", calendar.transform, config.perfectIcon, new Vector2(55, 55), new Vector2(85, 285));
            panel.clearLabel = Label("ClearCount", calendar.transform, font, new Vector2(340, 60), new Vector2(-205, 285), 31);
            panel.perfectLabel = Label("PerfectCount", calendar.transform, font, new Vector2(340, 60), new Vector2(285, 285), 31);
            panel.dayButtons = new UnityEngine.UI.Button[31];
            panel.dayDiscs = new UnityEngine.UI.Image[31];
            panel.dayStamps = new UnityEngine.UI.Image[31];
            panel.dayLabels = new TMP_Text[31];
            for (int i = 0; i < 31; i++) {
                var button = Button("Day_" + (i + 1).ToString("00"), calendar.transform, config.circle, Vector2.one * 94,
                    new Vector2(-330 + 110 * (i % 7), 190 - 110 * (i / 7)));
                panel.dayButtons[i] = button;
                panel.dayDiscs[i] = button.GetComponent<UnityEngine.UI.Image>();
                var outline = button.gameObject.AddComponent<UnityEngine.UI.Outline>();
                outline.effectColor = new Color(.91f, .40f, .53f);
                outline.effectDistance = Vector2.one;
                panel.dayLabels[i] = Label("Number", button.transform, font, Vector2.one * 90, Vector2.zero, 38);
                panel.dayLabels[i].text = (i + 1).ToString();
                panel.dayStamps[i] = Image("Stamp", button.transform, config.clearStamp, Vector2.one * 104, Vector2.zero);
                panel.dayStamps[i].gameObject.SetActive(false);
            }
            panel.statsLabel = Label("DateRecord", content, font, new Vector2(960, 42), new Vector2(0, -825), 27);
            actions[6] = Button("StartChallenge", content, config.start, new Vector2(800, 100), new Vector2(0, -900));
            panel.startLabel = Label("Label", actions[6].transform, font, new Vector2(740, 95), Vector2.zero, 44);
            panel.startLabel.text = "开始挑战";
            var notice = Image("Notice", content, config.card, new Vector2(940, 85), new Vector2(0, 765));
            panel.noticeRoot = notice.gameObject;
            panel.noticeLabel = Label("Label", notice.transform, font, new Vector2(900, 80), Vector2.zero, 29);
            panel.noticeLabel.color = new Color(.73f, .17f, .24f);
            var backdrop = Image("Overlay", content, null, new Vector2(1080, 1920), Vector2.zero);
            backdrop.color = new Color(.15f, .10f, .06f, .65f);
            backdrop.raycastTarget = true;
            panel.overlayRoot = backdrop.gameObject;
            var overlay = Image("Window", backdrop.transform, config.card, new Vector2(980, 1700), Vector2.zero);
            panel.overlayTitle = Label("Title", overlay.transform, font, new Vector2(700, 90), new Vector2(0, 745), 40);
            panel.historyRoot = Rect("History", overlay.transform, Vector2.one, Vector2.zero).gameObject;
            panel.historyLabel = Label("Records", panel.historyRoot.transform, font, new Vector2(830, 1300), new Vector2(0, 0), 30);
            panel.historyLabel.alignment = TextAlignmentOptions.TopLeft;
            panel.infoRoot = Rect("Info", overlay.transform, Vector2.one, Vector2.zero).gameObject;
            panel.infoLabel = Label("Rules", panel.infoRoot.transform, font, new Vector2(810, 1250), Vector2.zero, 36);
            panel.infoLabel.alignment = TextAlignmentOptions.TopLeft;
            panel.zoomRoot = Rect("Artwork", overlay.transform, Vector2.one, Vector2.zero).gameObject;
            panel.zoomImage = Image("Image", panel.zoomRoot.transform, config.seasons[0].artwork, new Vector2(900, 1250), Vector2.zero);
            actions[7] = Button("PreviousMonth", overlay.transform, null, new Vector2(80, 85), new Vector2(-410, 745));
            actions[7].targetGraphic.color = Color.clear;
            Label("Label", actions[7].transform, font, new Vector2(70, 80), Vector2.zero, 60).text = "<";
            actions[8] = Button("NextMonth", overlay.transform, null, new Vector2(80, 85), new Vector2(410, 745));
            actions[8].targetGraphic.color = Color.clear;
            Label("Label", actions[8].transform, font, new Vector2(70, 80), Vector2.zero, 60).text = ">";
            actions[9] = Button("CloseOverlay", overlay.transform, config.start, new Vector2(480, 100), new Vector2(0, -745));
            panel.closeLabel = Label("Label", actions[9].transform, font, new Vector2(450, 90), Vector2.zero, 40);
            panel.closeLabel.text = "关闭";
            panel.buttons = actions;
            panel.overlayRoot.SetActive(false);
            PrefabUtility.SaveAsPrefabAsset(root.gameObject, path);
            UnityEngine.Object.DestroyImmediate(root.gameObject);
        }

        static void Register(string panelPath) {
            var defaultObject = AssetDatabase.LoadAssetAtPath<AddressableAssetSettingsDefaultObject>("Assets/AddressableAssetsData/DefaultObject.asset");
            EditorBuildSettings.AddConfigObject(AddressableAssetSettingsDefaultObject.kDefaultConfigObjectName, defaultObject, true);
            var settings = AddressableAssetSettingsDefaultObject.Settings;
            var group = settings.FindGroup("Daily");
            if (group == null) {
                group = settings.CreateGroup("Daily", false, false, true, null, typeof(BundledAssetGroupSchema), typeof(ContentUpdateGroupSchema));
            }
            var schema = group.GetSchema<BundledAssetGroupSchema>();
            schema.BuildPath.SetVariableByName(settings, AddressableAssetSettings.kLocalBuildPath);
            schema.LoadPath.SetVariableByName(settings, AddressableAssetSettings.kLocalLoadPath);
            var paths = new List<string> { panelPath, "Assets/Res_Runtime/Config/DailyConfig.asset" };
            paths.AddRange(AssetDatabase.FindAssets("t:L10NSO", new[] { "Assets/Res_Runtime/Localization" })
                .Select(AssetDatabase.GUIDToAssetPath).Where(path => Path.GetFileName(path).StartsWith("Daily_", StringComparison.Ordinal)));
            foreach (string path in paths) {
                var entry = settings.CreateOrMoveEntry(AssetDatabase.AssetPathToGUID(path), group);
                entry.address = path;
                entry.SetLabel(AAConst.LABEL_DEFAULT, true);
            }
            EditorUtility.SetDirty(settings);
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

        static UnityEngine.UI.Image Image(string name, Transform parent, Sprite sprite, Vector2 size, Vector2 position) {
            var image = Rect(name, parent, size, position).gameObject.AddComponent<UnityEngine.UI.Image>();
            image.sprite = sprite;
            image.raycastTarget = false;
            image.preserveAspect = sprite != null && sprite.border == Vector4.zero;
            if (sprite != null && sprite.border != Vector4.zero) {
                image.type = UnityEngine.UI.Image.Type.Sliced;
            }
            return image;
        }

        static UnityEngine.UI.Button Button(string name, Transform parent, Sprite sprite, Vector2 size, Vector2 position) {
            var image = Image(name, parent, sprite, size, position);
            image.raycastTarget = true;
            var button = image.gameObject.AddComponent<UnityEngine.UI.Button>();
            if (sprite != null && sprite.border != Vector4.zero) {
                image.pixelsPerUnitMultiplier = sprite.rect.height / size.y;
            }
            button.targetGraphic = image;
            button.transition = UnityEngine.UI.Selectable.Transition.None;
            return button;
        }

        static TMP_Text Label(string name, Transform parent, TMP_FontAsset font, Vector2 size, Vector2 position, float fontSize) {
            var text = Rect(name, parent, size, position).gameObject.AddComponent<TextMeshProUGUI>();
            text.font = font;
            text.fontSize = fontSize;
            text.fontSizeMin = fontSize * .65f;
            text.fontSizeMax = fontSize;
            text.enableAutoSizing = true;
            text.alignment = TextAlignmentOptions.Center;
            text.color = new Color(.36f, .23f, .16f);
            text.raycastTarget = false;
            text.richText = false;
            return text;
        }
    }
}
