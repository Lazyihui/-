using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using TMPro;
using UnityEditor;
using UnityEditor.AddressableAssets;
using UnityEngine;
using UnityEngine.UI;
namespace Hamdoku.Editor {
    public static class ResultSetupEM {
        [MenuItem("Hamdoku/Setup/Configure Main Results")]
        public static void Apply() {
            AssetDatabase.Refresh();
            foreach (string path in Directory.GetFiles("Assets/Res_Runtime/UI/GameResult", "*.png")) {
                var importer = (TextureImporter)AssetImporter.GetAtPath(path);
                importer.textureType = TextureImporterType.Sprite;
                importer.spriteImportMode = SpriteImportMode.Single;
                importer.spritePixelsPerUnit = 100;
                importer.alphaIsTransparency = true;
                importer.mipmapEnabled = false;
                importer.npotScale = TextureImporterNPOTScale.None;
                importer.textureCompression = TextureImporterCompression.Uncompressed;
                importer.SaveAndReimport();
            }
            string configPath = "Assets/Res_Runtime/Config/ResultConfig.asset";
            var config = AssetDatabase.LoadAssetAtPath<ResultConfigSO>(configPath);
            if (config == null) {
                config = ScriptableObject.CreateInstance<ResultConfigSO>();
                config.titleAnchorY = .85f;
                config.clearHeroAnchorY = .58f;
                config.clearHeroSize = 720;
                config.failHeroAnchorY = .64f;
                config.failHeroSize = 620;
                config.messageAnchorY = .35f;
                config.statRowAnchorY = .26f;
                config.clearButtonAnchorY = .15f;
                config.failRemainingAnchorY = .41f;
                config.failMessageAnchorY = .33f;
                config.failContinueAnchorY = .21f;
                config.failRestartAnchorY = .10f;
                config.revealHeroAt = .3f;
                config.revealStatsAt = 1.15f;
                config.revealButtonAt = 1.9f;
                config.revealFadeSeconds = .25f;
                config.statCountUpSeconds = .7f;
                config.failButtonsAt = .3f;
                AssetDatabase.CreateAsset(config, configPath);
            }
            config.clearHero = Sprite("Assets/Res_Runtime/UI/GameResult/clear.png");
            config.clearHeroes = new[] { config.clearHero, Sprite("Assets/Res_Runtime/UI/GameResult/clear_a.png"),
                Sprite("Assets/Res_Runtime/UI/GameResult/clear_b.png"), Sprite("Assets/Res_Runtime/UI/GameResult/clear_c.png"),
                Sprite("Assets/Res_Runtime/UI/GameResult/clear_d.png"), Sprite("Assets/Res_Runtime/UI/GameResult/clear_e.png"),
                Sprite("Assets/Res_Runtime/UI/GameResult/clear_f.png") };
            config.perfectHeroIds = new[] { 6, 4 };
            config.hardFirstHeroIds = new[] { 3, 6 };
            config.retryHeroIds = new[] { 7 };
            config.highHeroIds = new[] { 3, 2 };
            config.midHeroIds = new[] { 1, 2, 5 };
            config.lowHeroIds = new[] { 4, 5 };
            config.allHeroIds = new[] { 2, 3, 4, 5, 6, 7 };
            config.heroBandHigh = 90;
            config.heroBandMid = 70;
            config.heroRankMid = .834f;
            config.heroRankSharp = 17.5f;
            config.heroTimePower = 1.103f;
            config.heroTimeScale = 6.14f;
            config.heroScoreWeight = .7f;
            config.heroTimeWeight = .3f;
            config.heroPickSalt = 67;
            config.clearHeroTextGap = 14;
            config.failHero = Sprite("Assets/Res_Runtime/UI/GameResult/fail.png");
            ConfigureReward(config);
            Controllers.Panel_GameResult_Controller.ValidateConfig(config);
            EditorUtility.SetDirty(config);

            BakeFonts();
            string prefabPath = "Assets/Res_Runtime/UI/GameResult/Panel_GameResult.prefab";
            bool existing = File.Exists(prefabPath);
            var root = existing ? PrefabUtility.LoadPrefabContents(prefabPath) : new GameObject("Panel_GameResult", typeof(RectTransform), typeof(Panel_GameResult));
            try {
                Build(root);
                PrefabUtility.SaveAsPrefabAsset(root, prefabPath);
            } finally {
                if (existing) {
                    PrefabUtility.UnloadPrefabContents(root);
                } else {
                    UnityEngine.Object.DestroyImmediate(root);
                }
            }
            var settings = AddressableAssetSettingsDefaultObject.Settings;
            var paths = Directory.GetFiles("Assets/Res_Runtime/Localization", "Result_*.asset").Concat(new[] { prefabPath });
            foreach (string path in paths) {
                var entry = settings.CreateOrMoveEntry(AssetDatabase.AssetPathToGUID(path), settings.DefaultGroup);
                entry.SetLabel(AAConst.LABEL_DEFAULT, true, true);
            }
            EditorUtility.SetDirty(settings);
            AssetDatabase.SaveAssets();
            Debug.Log("[ResultSetup] Formal main-result prefab, original illustrations, config and localization saved.");
        }
        static void Build(GameObject root) {
            var panel = root.GetComponent<Panel_GameResult>();
            var rect = (RectTransform)root.transform;
            Stretch(rect);
            var background = Image("Background", rect, Sprite("Assets/Res_Runtime/UI/Game/bg_Common_Game.png"), Vector2.zero, Vector2.zero);
            Stretch(background.rectTransform);
            background.raycastTarget = true;
            var fitter = background.GetComponent<AspectRatioFitter>();
            if (fitter == null) {
                fitter = background.gameObject.AddComponent<AspectRatioFitter>();
            }
            fitter.aspectMode = AspectRatioFitter.AspectMode.EnvelopeParent;
            fitter.aspectRatio = background.sprite.rect.width / background.sprite.rect.height;
            panel.safeRoot = Rect("SafeArea", rect, Vector2.zero, Vector2.zero);
            Stretch(panel.safeRoot);
            panel.contentRoot = Rect("Content", panel.safeRoot, new Vector2(1080, 1920), Vector2.zero);
            var content = panel.contentRoot;
            panel.titleLabel = Text("Title", content, new Vector2(980, 170), new Vector2(0, 672), 84);
            var heroRoot = Rect("Hero", content, new Vector2(720, 720), Vector2.zero);
            panel.heroGroup = Group(heroRoot);
            panel.hero = Image("Illustration", heroRoot, Sprite("Assets/Res_Runtime/UI/GameResult/clear.png"), new Vector2(720, 720), Vector2.zero);
            // The parent anchors the stage; the sprite itself uses authored result coordinates.
            Stretch(heroRoot);
            panel.hero.preserveAspect = true;
            panel.messageLabel = Text("Message", content, new Vector2(940, 130), new Vector2(0, -288), 62);
            panel.remainingLabel = Text("Remaining", content, new Vector2(940, 90), new Vector2(0, -173), 55);
            var stats = Rect("Statistics", content, new Vector2(900, 150), new Vector2(0, -461));
            panel.statsGroup = Group(stats);
            panel.statLabels = new TMP_Text[3];
            panel.statValues = new TMP_Text[3];
            for (int i = 0; i < 3; i++) {
                panel.statLabels[i] = Text("Label" + i, stats, new Vector2(292, 55), new Vector2((i - 1) * 300, 38), 40);
                panel.statValues[i] = Text("Value" + i, stats, new Vector2(292, 80), new Vector2((i - 1) * 300, -32), 56);
            }
            var buttons = Rect("Actions", content, new Vector2(1080, 1920), Vector2.zero);
            panel.buttonsGroup = Group(buttons);
            panel.primaryButton = Button("Primary", buttons, Sprite("Assets/Res_Runtime/UI/Game/new/btn_Common_Rounded_Yellow.png"), new Vector2(760, 155), new Vector2(0, -672));
            panel.primaryLabel = Text("Label", panel.primaryButton.transform, new Vector2(700, 130), Vector2.zero, 54);
            panel.adButton = Button("Ad", buttons, Sprite("Assets/Res_Runtime/UI/Game/new/btn_Game_Rounded_Blue.png"), new Vector2(760, 155), new Vector2(0, -557));
            panel.adLabel = Text("Label", panel.adButton.transform, new Vector2(700, 130), Vector2.zero, 48);
            panel.statusLabel = Text("ServiceStatus", buttons, new Vector2(940, 64), new Vector2(0, -653), 26);
            panel.secondaryButton = Button("Home", buttons, null, new Vector2(700, 80), new Vector2(0, -900));
            panel.secondaryLabel = Text("Label", panel.secondaryButton.transform, new Vector2(680, 80), Vector2.zero, 40);
            BuildRewardRow(panel);
        }
        [MenuItem("Hamdoku/Setup/Configure Campaign Reward")]
        public static void SetupCampaignReward() {
            var config = AssetDatabase.LoadAssetAtPath<ResultConfigSO>("Assets/Res_Runtime/Config/ResultConfig.asset");
            ConfigureReward(config);
            Controllers.Panel_GameResult_Controller.ValidateConfig(config);
            EditorUtility.SetDirty(config);
            BakeFonts();
            string path = "Assets/Res_Runtime/UI/GameResult/Panel_GameResult.prefab";
            var root = PrefabUtility.LoadPrefabContents(path);
            try {
                var panel = root.GetComponent<Panel_GameResult>();
                BuildRewardRow(panel);
                var primaryImage = panel.primaryButton.GetComponent<UnityEngine.UI.Image>();
                primaryImage.sprite = Sprite("Assets/Res_Runtime/UI/Game/new/btn_Common_Rounded_Yellow.png");
                primaryImage.pixelsPerUnitMultiplier = primaryImage.sprite.rect.height / primaryImage.rectTransform.rect.height;
                var adImage = panel.adButton.GetComponent<UnityEngine.UI.Image>();
                adImage.sprite = Sprite("Assets/Res_Runtime/UI/Game/new/btn_Game_Rounded_Blue.png");
                adImage.pixelsPerUnitMultiplier = adImage.sprite.rect.height / adImage.rectTransform.rect.height;
                PrefabUtility.SaveAsPrefabAsset(root, path);
            } finally {
                PrefabUtility.UnloadPrefabContents(root);
            }
            var settings = AddressableAssetSettingsDefaultObject.Settings;
            foreach (string text in Directory.GetFiles("Assets/Res_Runtime/Localization", "Result_Reward*.asset")) {
                var entry = settings.CreateOrMoveEntry(AssetDatabase.AssetPathToGUID(text), settings.DefaultGroup);
                entry.SetLabel(AAConst.LABEL_DEFAULT, true, true);
            }
            EditorUtility.SetDirty(settings);
            AssetDatabase.SaveAssets();
        }
        static void ConfigureReward(ResultConfigSO config) {
            if (config == null) {
                throw new InvalidOperationException("Missing formal ResultConfig.");
            }
            config.rewardHero = Sprite("Assets/Res_Runtime/UI/Game/Img_Game_Guide.png");
            config.rewardHeroSize = 240;
            config.rewardHeroAnchorY = .61f;
            config.rewardMessageAnchorY = .43f;
            config.rewardContentLiftY = .04f;
            config.rewardTickColor = new Color(.2f, .11f, .05f, 1);
            config.rewardTickColorEmpty = new Color(.45f, .33f, .22f, .55f);
        }
        static void BuildRewardRow(Panel_GameResult panel) {
            // Original ResultScreen.MakeRewardRow: 640x50, gap46, inset9, cell gap3.
            var game = AssetDatabase.LoadAssetAtPath<CampaignConfigSO>("Assets/Res_Runtime/Config/CampaignConfig.asset");
            int total = game.campaignRewardStep;
            panel.rewardProgressRoot = Rect("RewardProgress", panel.contentRoot, new Vector2(640, 100), new Vector2(0, -523.5f));
            panel.rewardProgressLabel = Text("Caption", panel.rewardProgressRoot, new Vector2(940, 46), new Vector2(0, -48), 32);
            panel.rewardTicks = new UnityEngine.UI.Image[total];
            float width = (640 - 18 - (total - 1) * 3) / total;
            for (int i = 0; i < total; i++) {
                panel.rewardTicks[i] = Image("Tick" + i, panel.rewardProgressRoot, null, new Vector2(width, 32), new Vector2(-311 + width * .5f + i * (width + 3), 0));
            }
        }
        static Sprite Sprite(string path) {
            var sprite = AssetDatabase.LoadAssetAtPath<Sprite>(path);
            if (sprite == null) {
                throw new InvalidOperationException("Missing result sprite " + path);
            }
            return sprite;
        }
        static RectTransform Rect(string name, Transform parent, Vector2 size, Vector2 position) {
            var found = parent.Find(name);
            var rect = found == null ? new GameObject(name, typeof(RectTransform)).GetComponent<RectTransform>() : (RectTransform)found;
            rect.SetParent(parent, false);
            rect.anchorMin = Vector2.one * .5f;
            rect.anchorMax = Vector2.one * .5f;
            rect.pivot = Vector2.one * .5f;
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
        static Image Image(string name, Transform parent, Sprite sprite, Vector2 size, Vector2 position) {
            var rect = Rect(name, parent, size, position);
            var image = rect.GetComponent<Image>();
            if (image == null) {
                image = rect.gameObject.AddComponent<Image>();
            }
            image.sprite = sprite;
            image.raycastTarget = false;
            return image;
        }
        static Button Button(string name, Transform parent, Sprite sprite, Vector2 size, Vector2 position) {
            var image = Image(name, parent, sprite, size, position);
            image.type = sprite == null ? UnityEngine.UI.Image.Type.Simple : UnityEngine.UI.Image.Type.Sliced;
            image.color = sprite == null ? Color.clear : Color.white;
            if (sprite != null) {
                image.pixelsPerUnitMultiplier = sprite.rect.height / size.y;
            }
            image.raycastTarget = true;
            var button = image.GetComponent<Button>();
            if (button == null) {
                button = image.gameObject.AddComponent<Button>();
            }
            button.targetGraphic = image;
            return button;
        }
        static TMP_Text Text(string name, Transform parent, Vector2 size, Vector2 position, float fontSize) {
            var rect = Rect(name, parent, size, position);
            var text = rect.GetComponent<TMP_Text>();
            if (text == null) {
                text = rect.gameObject.AddComponent<TextMeshProUGUI>();
            }
            text.font = AssetDatabase.LoadAssetAtPath<TMP_FontAsset>("Assets/Res_Runtime/Font/Chinese SDF.asset");
            text.fontSize = fontSize;
            text.fontSizeMin = Math.Min(fontSize, 32);
            text.fontSizeMax = fontSize;
            text.enableAutoSizing = true;
            text.textWrappingMode = TextWrappingModes.Normal;
            text.alignment = TextAlignmentOptions.Center;
            text.color = new Color(.427451f, .247059f, .298039f, 1);
            text.raycastTarget = false;
            text.text = string.Empty;
            return text;
        }
        static CanvasGroup Group(RectTransform rect) {
            var group = rect.GetComponent<CanvasGroup>();
            if (group == null) {
                group = rect.gameObject.AddComponent<CanvasGroup>();
            }
            return group;
        }
        public static void BakeFonts() {
            var texts = AssetDatabase.FindAssets("t:L10NSO", new[] { "Assets/Res_Runtime/Localization" })
                .Select(guid => AssetDatabase.LoadAssetAtPath<L10NSO>(AssetDatabase.GUIDToAssetPath(guid))).ToArray();
            foreach (string language in new[] { "Chinese", "English" }) {
                var font = AssetDatabase.LoadAssetAtPath<TMP_FontAsset>("Assets/Res_Runtime/Font/" + language + " SDF.asset");
                string characters = "0123456789:—" + string.Concat(texts.Select(text => language == "Chinese" ? text.chinese : text.english));
                characters = Regex.Replace(characters, "<[^>]*>|\\{[^}]*\\}", string.Empty).Replace("\n", string.Empty);
                if (!font.HasCharacters(characters)) {
                    var serialized = new SerializedObject(font);
                    var source = AssetDatabase.LoadAssetAtPath<Font>(AssetDatabase.GUIDToAssetPath(serialized.FindProperty("m_SourceFontFileGUID").stringValue));
                    if (source == null) {
                        throw new InvalidOperationException("Missing result localization font source.");
                    }
                    serialized.FindProperty("m_SourceFontFile").objectReferenceValue = source;
                    serialized.ApplyModifiedPropertiesWithoutUndo();
                    font.atlasPopulationMode = AtlasPopulationMode.Dynamic;
                    try {
                        if (!font.TryAddCharacters(characters, out string missing)) {
                            throw new InvalidOperationException("Missing result glyphs: " + missing);
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
    }
}
