using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Hamdoku.Main;
using TMPro;
using UnityEditor;
using UnityEditor.AddressableAssets;
using UnityEditor.AddressableAssets.Settings;
using UnityEditor.AddressableAssets.Settings.GroupSchemas;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.UI;
using UnityEngine.TextCore.LowLevel;

namespace Hamdoku.Editor {
    public static class HomeSetupEM {
        [MenuItem("Hamdoku/Setup/Configure Home")]
        public static void Setup() {
            if (EditorSceneManager.GetActiveScene().isDirty) {
                throw new InvalidOperationException("Save scene changes before configuring Home.");
            }
            if (TMP_Settings.instance == null) {
                AssetDatabase.importPackageCompleted += CompleteTMPImport;
                TMP_PackageResourceImporter.ImportResources(true, false, false);
                return;
            }
            ImportSprites();
            Directory.CreateDirectory("Assets/Res_Runtime/Localization");
            Directory.CreateDirectory("Assets/Res_Runtime/Config");
            AssetDatabase.Refresh();
            var texts = ImportTexts();
            var chineseFont = CreateFont("ZCOOLKuaiLe-Regular", "Chinese", SystemLanguage.ChineseSimplified, texts);
            CreateFont("Nunito", "English", SystemLanguage.English, texts);
            var config = CreateConfig();
            string prefabPath = "Assets/Res_Runtime/UI/Home/Panel_Home.prefab";
            if (AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath) == null) {
                CreatePrefab(prefabPath, chineseFont, config);
            }
            RefineOriginalLayout();
            ConfigureAddressables(prefabPath);
            var scene = EditorSceneManager.OpenScene("Assets/Res_Runtime/Scene_Main.unity", OpenSceneMode.Single);
            var main = UnityEngine.Object.FindAnyObjectByType<ClientMain>();
            if (main == null) {
                throw new InvalidOperationException("Scene_Main must already contain ClientMain.");
            }
            if (UnityEngine.Object.FindAnyObjectByType<EventSystem>() == null) {
                var events = new GameObject("EventSystem", typeof(EventSystem));
                events.AddComponent<InputSystemUIInputModule>().AssignDefaultActions();
            }
            EditorSceneManager.MarkSceneDirty(scene);
            EditorSceneManager.SaveScene(scene);
            AssetDatabase.SaveAssets();
            Debug.Log("[HomeSetup] Home prefab, localization, Addressables and scene EventSystem are ready.");
        }

        static void CompleteTMPImport(string packageName) {
            AssetDatabase.importPackageCompleted -= CompleteTMPImport;
            EditorApplication.delayCall += Setup;
        }

        static void ImportSprites() {
            foreach (string path in Directory.GetFiles("Assets/Res_Runtime/UI/Home", "*.png").Concat(Directory.GetFiles("Assets/Res_Runtime/UI/Home/new", "*.png"))) {
                var importer = (TextureImporter)AssetImporter.GetAtPath(path);
                var settings = new TextureImporterSettings();
                importer.ReadTextureSettings(settings);
                settings.textureType = TextureImporterType.Sprite;
                settings.textureShape = TextureImporterShape.Texture2D;
                settings.spriteMode = (int)SpriteImportMode.Single;
                settings.spriteMeshType = SpriteMeshType.FullRect;
                settings.spritePixelsPerUnit = 100;
                if (Path.GetFileNameWithoutExtension(path) == "btn_Home_DailyCard" || Path.GetFileNameWithoutExtension(path) == "btn_Home_RankingCard" || Path.GetFileNameWithoutExtension(path) == "bg_Home_StreakCard") {
                    settings.spriteBorder = new Vector4(80, 80, 80, 80);
                }
                settings.alphaIsTransparency = true;
                settings.mipmapEnabled = false;
                importer.SetTextureSettings(settings);
                importer.maxTextureSize = 4096;
                importer.textureCompression = TextureImporterCompression.Uncompressed;
                switch (Path.GetFileNameWithoutExtension(path))
                {
                    case "btn_Home_Endless":
                        importer.spriteBorder = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
                        break;
                    case "btn_Home_Level":
                        importer.spriteBorder = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
                        break;
                    case "btn_Home_Level_Hard":
                        importer.spriteBorder = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
                        break;
                    case "btn_Home_Play":
                        importer.spriteBorder = new Vector4(125f, 96f, 125f, 95f);
                        break;
                }
                importer.SaveAndReimport();
            }
        }

        static List<L10NSO> ImportTexts() {
            var result = new List<L10NSO>();
            foreach (UINameType id in Enum.GetValues(typeof(UINameType))) {
                if (id == UINameType.None) {
                    continue;
                }
                string path = "Assets/Res_Runtime/Localization/" + id + ".asset";
                var text = AssetDatabase.LoadAssetAtPath<L10NSO>(path);
                if (text == null) {
                    text = ScriptableObject.CreateInstance<L10NSO>();
                    JsonUtility.FromJsonOverwrite(File.ReadAllText("Library/HomeSetup/Text_" + (int)id + ".json"), text);
                    AssetDatabase.CreateAsset(text, path);
                }
                result.Add(text);
            }
            return result;
        }

        static TMP_FontAsset CreateFont(string sourceName, string languageName, SystemLanguage language, List<L10NSO> entries) {
            string fontPath = "Assets/Res_Runtime/Font/" + languageName + " SDF.asset";
            var font = AssetDatabase.LoadAssetAtPath<TMP_FontAsset>(fontPath);
            if (font == null) {
                var source = AssetDatabase.LoadAssetAtPath<Font>("Assets/Res_Runtime/Font/" + sourceName + ".ttf");
                font = TMP_FontAsset.CreateFontAsset(source, 90, 9, GlyphRenderMode.SDFAA, 2048, 2048, AtlasPopulationMode.Dynamic, false);
                font.name = languageName + " SDF";
                string characters = "0123456789 /:-JanFebMarAprMayJunJulAugSepOctNovDec";
                foreach (var entry in entries) {
                    characters += language == SystemLanguage.ChineseSimplified ? entry.chinese : entry.english;
                }
                characters = Regex.Replace(characters, "<[^>]*>|\\{[0-9]+\\}", string.Empty).Replace("\n", string.Empty);
                if (!font.TryAddCharacters(characters, out string missing)) {
                    throw new InvalidOperationException("Font " + sourceName + " is missing UI characters: " + missing);
                }
                font.atlasPopulationMode = AtlasPopulationMode.Static;
                font.fallbackFontAssetTable = new List<TMP_FontAsset>();
                AssetDatabase.CreateAsset(font, fontPath);
                foreach (var texture in font.atlasTextures) {
                    AssetDatabase.AddObjectToAsset(texture, font);
                }
                AssetDatabase.AddObjectToAsset(font.material, font);
                EditorUtility.SetDirty(font);
            }
            string mapPath = "Assets/Res_Runtime/Localization/Font_" + languageName + ".asset";
            if (AssetDatabase.LoadAssetAtPath<L10NFontSO>(mapPath) == null) {
                var map = ScriptableObject.CreateInstance<L10NFontSO>();
                map.language = language;
                map.font = font;
                AssetDatabase.CreateAsset(map, mapPath);
            }
            return font;
        }

        static HomeConfigSO CreateConfig() {
            string path = "Assets/Res_Runtime/Config/HomeConfig.asset";
            var config = AssetDatabase.LoadAssetAtPath<HomeConfigSO>(path);
            if (config != null) {
                return config;
            }
            config = ScriptableObject.CreateInstance<HomeConfigSO>();
            config.dailyUnlockClears = 20;
            config.rankingUnlockClears = 10;
            config.endlessUnlockClears = 100;
            config.hardLevelStart = 21;
            config.hardLevelInterval = 10;
            config.saveVersion = 1;
            config.saveFileName = "hamdoku-progress.json";
            config.defaultLanguage = SystemLanguage.ChineseSimplified;
            config.noticeSeconds = 2.5f;
            config.buttonVolume = 0.6f;
            config.buttonClip = AssetDatabase.LoadAssetAtPath<AudioClip>("Assets/Res_Runtime/Audio/button.wav");
            config.levelNormal = Sprite("btn_Home_Level");
            config.levelHard = Sprite("btn_Home_Level_Hard");
            config.logoNormal = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Res_Runtime/UI/Logo/new/Img_Common_Logo.png");
            config.logoHard = Sprite("Img_Home_Logo_Hard");
            config.lockedTint = new Color(0.78f, 0.78f, 0.78f, 1);
            config.idleBreatheAmount = 0.015f;
            config.idleBreatheSpeed = 1.7f;
            config.idleBobHeight = 2.5f;
            config.idleBobSpeed = 1.2f;
            ConfigureSunflowerConfig(config);
            AssetDatabase.CreateAsset(config, path);
            return config;
        }

        static void CreatePrefab(string path, TMP_FontAsset font, HomeConfigSO config) {
            var root = Rect("Panel_Home", null, Vector2.zero, Vector2.zero);
            Stretch(root);
            var panel = root.gameObject.AddComponent<Panel_Home>();
            var background = Image("Background", root, AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Res_Runtime/UI/Logo/new/bg_Common_Menu.png"), Vector2.zero, Vector2.zero);
            Stretch(background.rectTransform);
            var fitter = background.gameObject.AddComponent<UnityEngine.UI.AspectRatioFitter>();
            fitter.aspectMode = UnityEngine.UI.AspectRatioFitter.AspectMode.EnvelopeParent;
            fitter.aspectRatio = background.sprite.rect.width / background.sprite.rect.height;
            panel.safeRoot = Rect("SafeRoot", root, Vector2.zero, Vector2.zero);
            Stretch(panel.safeRoot);
            var content = Rect("Content", panel.safeRoot, new Vector2(UIResolutionConst.WIDTH, UIResolutionConst.HEIGHT), Vector2.zero);
            panel.contentRoot = content;

            // Original cards group: bottom anchor 0.62, 460x495 daily card and two right cards.
            var cards = Rect("CardsGroup", content, new Vector2(894, 495), new Vector2(0, 230));
            cards.pivot = new Vector2(0.5f, 0);
            panel.dailyButton = Button("Daily", cards, Sprite("btn_Home_DailyCard"), new Vector2(460, 495), new Vector2(-217, 0));
            panel.dailyImage = panel.dailyButton.GetComponent<UnityEngine.UI.Image>();
            Image("DailyIcon", panel.dailyButton.transform, Sprite("Img_Home_Daily"), new Vector2(145, 140), new Vector2(-135, 115));
            panel.dailyLabel = Label("DailyTitle", panel.dailyButton.transform, font, new Vector2(230, 145), new Vector2(70, 115), 52);
            panel.dailyLabel.text = "每日挑战";
            panel.dailyDateLabel = Label("Date", panel.dailyButton.transform, font, new Vector2(350, 70), new Vector2(0, 0), 46);
            panel.dailyLock = Lock(panel.dailyButton.transform, font, new Vector2(0, -135), out panel.dailyLockLabel);
            var dailyPlay = Image("PlayPill", panel.dailyButton.transform, Sprite("btn_Home_Play"), new Vector2(330, 92), new Vector2(0, -135));
            panel.dailyPlay = dailyPlay.gameObject;
            panel.dailyPlayLabel = Label("Title", dailyPlay.transform, font, new Vector2(240, 70), Vector2.zero, 48);
            panel.dailyPlayLabel.text = "开始";

            var streak = Image("Streak", cards, Sprite("bg_Home_StreakCard"), new Vector2(412, 225), new Vector2(241, 135));
            Image("Sunflower", streak.transform, Sprite("Img_Home_Sunflower"), new Vector2(105, 142), new Vector2(-115, 0));
            panel.streakLabel = Label("Days", streak.transform, font, new Vector2(230, 100), new Vector2(55, 0), 64);

            panel.rankingButton = Button("Ranking", cards, Sprite("btn_Home_RankingCard"), new Vector2(412, 253), new Vector2(241, -121));
            panel.rankingImage = panel.rankingButton.GetComponent<UnityEngine.UI.Image>();
            Image("Podium", panel.rankingButton.transform, Sprite("Img_Home_Podium"), new Vector2(200, 95), new Vector2(0, 48));
            panel.rankingLabel = Label("Title", panel.rankingButton.transform, font, new Vector2(290, 65), new Vector2(0, -22), 43);
            panel.rankingLabel.text = "排行榜";
            panel.rankingLock = Lock(panel.rankingButton.transform, font, new Vector2(0, -90), out panel.rankingLockLabel);

            panel.logoRoot = Rect("LogoMotion", content, new Vector2(800, 600), new Vector2(0, -112));
            panel.logo = Image("Logo", panel.logoRoot, config.logoNormal, new Vector2(800, 600), Vector2.zero);
            panel.logo.preserveAspect = true;

            panel.campaignButton = Button("Campaign", content, config.levelNormal, new Vector2(900, 250), new Vector2(0, -560));
            panel.campaignImage = panel.campaignButton.GetComponent<UnityEngine.UI.Image>();
            panel.levelLabel = Label("Level", panel.campaignButton.transform, font, new Vector2(730, 110), new Vector2(0, 12), 70);
            panel.levelLabel.text = "关卡 1";
            panel.endlessButton = Button("Endless", content, Sprite("btn_Home_Endless"), new Vector2(800, 170), new Vector2(0, -805));
            panel.endlessImage = panel.endlessButton.GetComponent<UnityEngine.UI.Image>();
            Image("Icon", panel.endlessButton.transform, Sprite("Img_Home_Endless"), new Vector2(95, 95), new Vector2(-250, 5));
            panel.endlessLabel = Label("Title", panel.endlessButton.transform, font, new Vector2(350, 75), new Vector2(20, 27), 47);
            panel.endlessLabel.text = "无限模式";
            panel.endlessLock = Lock(panel.endlessButton.transform, font, new Vector2(30, -47), out panel.endlessLockLabel);

            panel.settingsButton = Button("Settings", content, Sprite("Img_Common_Settings"), new Vector2(100, 100), new Vector2(440, 855));
            panel.settingsLabel = Label("Title", panel.settingsButton.transform, font, new Vector2(150, 50), new Vector2(0, -75), 30);
            panel.settingsLabel.text = "设置";
            panel.noticeLabel = Label("Notice", content, font, new Vector2(940, 100), new Vector2(0, -370), 38);
            panel.noticeLabel.color = new Color(0.42f, 0.25f, 0.17f, 1);
            PrefabUtility.SaveAsPrefabAsset(root.gameObject, path);
            UnityEngine.Object.DestroyImmediate(root.gameObject);
        }


        [MenuItem("Hamdoku/Setup/Refine Original Logo And Home")]
        public static void RefineOriginalLayout() {
            if (EditorSceneManager.GetActiveScene().isDirty) {
                throw new InvalidOperationException("Save scene changes before refining UI.");
            }
            ImportSprites();
            string path = "Assets/Res_Runtime/UI/Home/Panel_Home.prefab";
            var root = PrefabUtility.LoadPrefabContents(path);
            try {
                var panel = root.GetComponent<Panel_Home>();
                var content = panel.contentRoot;
                // Original LobbyLayoutConfig and level1 RectTransforms, in 1080 x 1920 coordinates.
                SetRect(content.Find("CardsGroup"), new Vector2(894, 495), Vector2.zero,
                    new Vector2(0.5f, 0.62f), new Vector2(0.5f, 0));
                SetRect(panel.dailyLabel.transform, new Vector2(210, 150), new Vector2(40, -118), new Vector2(0.5f, 1));
                SetRect(panel.dailyDateLabel.transform, new Vector2(340, 68), new Vector2(0, -225), new Vector2(0.5f, 1));
                // Exported icon is trimmed; preserve its aspect instead of stretching its visible pixels.
                SetRect(panel.dailyButton.transform.Find("DailyIcon"), new Vector2(99.14f, 106.17f), new Vector2(-140, -118), new Vector2(0.5f, 1));
                SetRect(panel.dailyPlay.transform, new Vector2(350, 95), new Vector2(0, 95), new Vector2(0.5f, 0));
                SetRect(panel.dailyPlayLabel.transform, new Vector2(220, 65), new Vector2(0, 4));
                SetRect(panel.dailyLock.transform, new Vector2(340, 65), new Vector2(0, 95), new Vector2(0.5f, 0));
                SetRect(panel.rankingButton.transform.Find("Podium"), new Vector2(250, 120), new Vector2(0, 30));
                SetRect(panel.rankingLabel.transform, new Vector2(290, 44), new Vector2(0, -68));
                panel.rankingLabel.gameObject.SetActive(false);
                panel.rankingLabel.fontSize = 32;
                panel.rankingLabel.fontSizeMax = 32;
                SetRect(panel.rankingLock.transform, new Vector2(340, 65), new Vector2(0, -68));
                SetRect(panel.logoRoot, new Vector2(800, 800), new Vector2(0, -70), new Vector2(0.5f, 0.478f));
                // Original sprite rect is 1080 square, PNG is trimmed to 871 x 627.
                SetRect(panel.logo.rectTransform, new Vector2(871, 627) * (800f / 1080f), Vector2.zero);
                // LevelButton: original 1920 x 630 sprite fits a 900.672 x 342 node.
                // Its exported 1580 x 443 visible pixels occupy this smaller rect.
                SetRect(panel.campaignButton.transform, new Vector2(1580, 443) * (900.6721f / 1920f),
                    Vector2.zero, new Vector2(0.5f, 0.162f));
                SetRect(panel.levelLabel.transform, new Vector2(700, 96), Vector2.zero);
                panel.levelLabel.color = new Color(0.32f, 0.22f, 0.12f);
                SetRect(panel.endlessButton.transform, new Vector2(790, 170), new Vector2(0, 90), new Vector2(0.5f, 0));
                SetRect(panel.settingsButton.transform, new Vector2(100, 100), new Vector2(-110, -100), new Vector2(1, 1));
                panel.settingsLabel.gameObject.SetActive(false);
                SetRect(panel.noticeLabel.transform, new Vector2(940, 85), new Vector2(0, -430));
                if (panel.shopButton == null) {
                    panel.shopButton = Button("Shop", content, Sprite("Img_Common_Shop"), new Vector2(100, 100), Vector2.zero);
                }
                SetRect(panel.shopButton.transform, new Vector2(100, 100), new Vector2(-225, -100), new Vector2(1, 1));
                if (panel.profileButton == null) {
                    panel.profileButton = Button("Profile", content, Sprite("Img_Common_ProfileFrame"), new Vector2(145, 145), Vector2.zero);
                    var portrait = Image("Portrait", panel.profileButton.transform, Sprite("Img_Common_HamsterAvatar"), new Vector2(105, 105), Vector2.zero);
                    portrait.preserveAspect = true;
                }
                SetRect(panel.profileButton.transform, new Vector2(145, 145), new Vector2(120, -100), new Vector2(0, 1));
                if (panel.streakButton == null) {
                    var streak = content.Find("CardsGroup/Streak");
                    var image = streak.GetComponent<UnityEngine.UI.Image>();
                    image.raycastTarget = true;
                    panel.streakButton = streak.gameObject.AddComponent<UnityEngine.UI.Button>();
                    panel.streakButton.targetGraphic = image;
                }
                foreach (var image in root.GetComponentsInChildren<UnityEngine.UI.Image>(true)) {
                    image.preserveAspect = image.type != UnityEngine.UI.Image.Type.Sliced;
                }
                Slice(panel.dailyImage);
                panel.dailyImage.pixelsPerUnitMultiplier = 1.8f;
                Slice(panel.rankingImage);
                panel.rankingImage.pixelsPerUnitMultiplier = 2.2f;
                Slice(content.Find("CardsGroup/Streak").GetComponent<UnityEngine.UI.Image>());
                content.Find("CardsGroup/Streak").GetComponent<UnityEngine.UI.Image>().pixelsPerUnitMultiplier = 2.2f;
                panel.dailyPlay.GetComponent<UnityEngine.UI.Image>().preserveAspect = false;
                panel.endlessImage.preserveAspect = false;
                panel.sunflower = (RectTransform)content.Find("CardsGroup/Streak/Sunflower");
                var homeConfig = AssetDatabase.LoadAssetAtPath<HomeConfigSO>("Assets/Res_Runtime/Config/HomeConfig.asset");
                panel.sunflowerSparkles = new UnityEngine.UI.Image[homeConfig.sunflowerSparkleCount];
                for (int i = 0; i < panel.sunflowerSparkles.Length; i++) {
                    string sparkleName = "Sparkle" + (i + 1);
                    var existing = panel.sunflower.Find(sparkleName);
                    var sparkle = existing == null ? Image(sparkleName, panel.sunflower,
                        Sprite("Img_Home_SunflowerSparkle"), Vector2.one * homeConfig.sunflowerSparkleSize.x,
                        Vector2.zero) : existing.GetComponent<UnityEngine.UI.Image>();
                    sparkle.raycastTarget = false;
                    sparkle.color = new Color(1, 1, 1, 0);
                    panel.sunflowerSparkles[i] = sparkle;
                }
                PrefabUtility.SaveAsPrefabAsset(root, path);
            } finally {
                PrefabUtility.UnloadPrefabContents(root);
            }
            var scene = EditorSceneManager.OpenScene("Assets/Res_Runtime/Scene_Main.unity", OpenSceneMode.Single);
            var main = UnityEngine.Object.FindAnyObjectByType<ClientMain>();
            var logoPanel = main.panel_Logo;
            var intro = logoPanel.logoIntro;
            if (logoPanel.contentRoot == null) {
                var authoredContent = intro.motionRoot.parent as RectTransform;
                if (authoredContent != null && authoredContent.name == "Content" && authoredContent.parent == logoPanel.safeRoot) {
                    logoPanel.contentRoot = authoredContent;
                } else {
                    logoPanel.contentRoot = Rect("Content", logoPanel.safeRoot,
                        new Vector2(UIResolutionConst.WIDTH, UIResolutionConst.HEIGHT), Vector2.zero);
                    intro.motionRoot.SetParent(logoPanel.contentRoot, false);
                }
                EditorUtility.SetDirty(logoPanel);
            }
            // Loading screen owns its own composition; homepage layout does not reposition it.
            EditorSceneManager.MarkSceneDirty(scene);
            EditorSceneManager.SaveScene(scene);
            AssetDatabase.SaveAssets();
        }


        static void ConfigureSunflowerConfig(HomeConfigSO config) {
            config.sunflowerSwayDegrees = 3;
            config.sunflowerSwaySeconds = 5.5f;
            config.sunflowerSwayPivotY = 0.04f;
            config.sunflowerSwayHarmonicAmount = 0.22f;
            config.sunflowerSwayHarmonicSpeed = 2.17f;
            config.sunflowerSwayHarmonicPhase = 1.3f;
            config.sunflowerSparkleCount = 3;
            config.sunflowerSparkleColor = new Color(1f, 1f, 1f, 0.95f);
            config.sunflowerSparkleSize = new Vector2(34f, 60f);
            config.sunflowerSparkleInnerScale = 0.55f;
            config.sunflowerSparkleAreaScale = 0.95f;
            config.sunflowerSparkleRadiusGap = 8;
            config.sunflowerSparkleInitialDelay = 1.4f;
            config.sunflowerSparkleFadeIn = new Vector2(0.18f, 0.3f);
            config.sunflowerSparkleHold = new Vector2(0.05f, 0.15f);
            config.sunflowerSparkleFadeOut = new Vector2(0.25f, 0.4f);
            config.sunflowerSparkleRest = new Vector2(0.4f, 1.3f);
        }

        static void SetRect(Transform target, Vector2 size, Vector2 position) {
            SetRect(target, size, position, Vector2.one * 0.5f);
        }

        static void SetRect(Transform target, Vector2 size, Vector2 position, Vector2 anchor) {
            SetRect(target, size, position, anchor, Vector2.one * 0.5f);
        }

        static void SetRect(Transform target, Vector2 size, Vector2 position, Vector2 anchor, Vector2 pivot) {
            var rect = (RectTransform)target;
            rect.anchorMin = anchor;
            rect.anchorMax = anchor;
            rect.pivot = pivot;
            rect.sizeDelta = size;
            var image = target.GetComponent<UnityEngine.UI.Image>();
            if (image != null && image.sprite != null && image.sprite.border != Vector4.zero &&
                AssetDatabase.GetAssetPath(image.sprite).Contains("/new/") && image.sprite.name.StartsWith("btn_", StringComparison.Ordinal))
            {
                image.pixelsPerUnitMultiplier = image.sprite.rect.height / size.y;
            }
            rect.anchoredPosition = position;
        }

        static void Slice(UnityEngine.UI.Image image) {
            image.type = UnityEngine.UI.Image.Type.Sliced;
            image.preserveAspect = false;
        }

        static GameObject Lock(Transform parent, TMP_FontAsset font, Vector2 position, out TMP_Text label) {
            var root = Rect("Lock", parent, new Vector2(340, 65), position);
            Image("Icon", root, Sprite("Img_Home_Lock"), new Vector2(35, 42), new Vector2(-128, 0));
            label = Label("Requirement", root, font, new Vector2(265, 60), new Vector2(30, 0), 28);
            label.text = "通关 100 关解锁";
            return root.gameObject;
        }

        static TMP_Text Label(string name, Transform parent, TMP_FontAsset font, Vector2 size, Vector2 position, float fontSize) {
            var rect = Rect(name, parent, size, position);
            var label = rect.gameObject.AddComponent<TextMeshProUGUI>();
            label.font = font;
            label.fontSize = fontSize;
            label.enableAutoSizing = true;
            label.fontSizeMin = fontSize * 0.6f;
            label.fontSizeMax = fontSize;
            label.alignment = TextAlignmentOptions.Center;
            label.color = new Color(0.43f, 0.27f, 0.2f, 1);
            label.raycastTarget = false;
            label.textWrappingMode = TextWrappingModes.Normal;
            var buttonImage = parent.GetComponent<UnityEngine.UI.Image>();
            if (buttonImage != null && buttonImage.sprite != null &&
                AssetDatabase.GetAssetPath(buttonImage.sprite).Contains("/new/") &&
                (buttonImage.sprite.name == "btn_Home_Endless" || buttonImage.sprite.name == "btn_Home_Level" || buttonImage.sprite.name == "btn_Home_Level_Hard" || buttonImage.sprite.name == "btn_Home_Play"))
            {
                label.color = new Color(0.32f, 0.22f, 0.12f);
            }
            return label;
        }

        static UnityEngine.UI.Button Button(string name, Transform parent, Sprite sprite, Vector2 size, Vector2 position) {
            var image = Image(name, parent, sprite, size, position);
            image.raycastTarget = true;
            var button = image.gameObject.AddComponent<UnityEngine.UI.Button>();
            button.targetGraphic = image;
            var colors = button.colors;
            colors.pressedColor = new Color(0.85f, 0.8f, 0.75f, 1);
            colors.highlightedColor = Color.white;
            button.colors = colors;
            return button;
        }

        static UnityEngine.UI.Image Image(string name, Transform parent, Sprite sprite, Vector2 size, Vector2 position) {
            var image = Rect(name, parent, size, position).gameObject.AddComponent<UnityEngine.UI.Image>();
            image.sprite = sprite;
            image.raycastTarget = false;
            if (sprite != null && sprite.border != Vector4.zero &&
                AssetDatabase.GetAssetPath(sprite).Contains("/new/") &&
                (sprite.name == "btn_Home_Endless" || sprite.name == "btn_Home_Level" || sprite.name == "btn_Home_Level_Hard" || sprite.name == "btn_Home_Play"))
            {
                image.type = UnityEngine.UI.Image.Type.Sliced;
                image.preserveAspect = false;
                image.pixelsPerUnitMultiplier = sprite.rect.height / size.y;
            }
            return image;
        }

        static RectTransform Rect(string name, Transform parent, Vector2 size, Vector2 position) {
            var rect = new GameObject(name, typeof(RectTransform)).GetComponent<RectTransform>();
            rect.gameObject.layer = LayerMask.NameToLayer("UI");
            rect.SetParent(parent, false);
            rect.anchorMin = Vector2.one * 0.5f;
            rect.anchorMax = rect.anchorMin;
            rect.pivot = Vector2.one * 0.5f;
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

        static Sprite Sprite(string name) {
            switch (name)
            {
                case "btn_Home_Endless":
                    return AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Res_Runtime/UI/Home/new/btn_Home_Endless.png") ?? throw new InvalidOperationException("Missing installed button: Assets/Res_Runtime/UI/Home/new/btn_Home_Endless.png");
                case "btn_Home_Level":
                    return AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Res_Runtime/UI/Home/new/btn_Home_Level.png") ?? throw new InvalidOperationException("Missing installed button: Assets/Res_Runtime/UI/Home/new/btn_Home_Level.png");
                case "btn_Home_Level_Hard":
                    return AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Res_Runtime/UI/Home/new/btn_Home_Level_Hard.png") ?? throw new InvalidOperationException("Missing installed button: Assets/Res_Runtime/UI/Home/new/btn_Home_Level_Hard.png");
                case "btn_Home_Play":
                    return AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Res_Runtime/UI/Home/new/btn_Home_Play.png") ?? throw new InvalidOperationException("Missing installed button: Assets/Res_Runtime/UI/Home/new/btn_Home_Play.png");
            }
            return AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Res_Runtime/UI/Home/" + name + ".png");
        }

        static void ConfigureAddressables(string prefabPath) {
            var defaultObject = AssetDatabase.LoadAssetAtPath<AddressableAssetSettingsDefaultObject>(
                "Assets/AddressableAssetsData/DefaultObject.asset");
            if (defaultObject != null) {
                EditorBuildSettings.AddConfigObject(AddressableAssetSettingsDefaultObject.kDefaultConfigObjectName,
                    defaultObject, true);
            }
            var settings = AddressableAssetSettingsDefaultObject.GetSettings(true);
            var group = settings.FindGroup("Home");
            if (group == null) {
                group = settings.CreateGroup("Home", false, false, true, null,
                    typeof(BundledAssetGroupSchema), typeof(ContentUpdateGroupSchema));
            }
            var schema = group.GetSchema<BundledAssetGroupSchema>();
            schema.BuildPath.SetVariableByName(settings, AddressableAssetSettings.kLocalBuildPath);
            schema.LoadPath.SetVariableByName(settings, AddressableAssetSettings.kLocalLoadPath);
            settings.AddLabel(AAConst.LABEL_DEFAULT);
            Register(settings, group, prefabPath);
            Register(settings, group, "Assets/Res_Runtime/Config/HomeConfig.asset");
            foreach (string guid in AssetDatabase.FindAssets("t:L10NSO t:L10NFontSO", new[] { "Assets/Res_Runtime/Localization" })) {
                Register(settings, group, AssetDatabase.GUIDToAssetPath(guid));
            }
            for (int i = 0; i < settings.DataBuilders.Count; i++) {
                if (settings.DataBuilders[i] is UnityEditor.AddressableAssets.Build.DataBuilders.BuildScriptFastMode) {
                    settings.ActivePlayModeDataBuilderIndex = i;
                }
            }
            EditorUtility.SetDirty(settings);
        }

        static void Register(AddressableAssetSettings settings, AddressableAssetGroup group, string path) {
            var entry = settings.CreateOrMoveEntry(AssetDatabase.AssetPathToGUID(path), group);
            entry.address = path;
            entry.SetLabel(AAConst.LABEL_DEFAULT, true);
        }
    }
}
