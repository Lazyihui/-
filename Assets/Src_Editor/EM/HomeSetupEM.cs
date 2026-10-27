using System;
using System.Collections.Generic;
using System.IO;
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
            foreach (string path in Directory.GetFiles("Assets/Res_Runtime/UI/Home", "*.png")) {
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
                importer.SetTextureSettings(settings);
                importer.maxTextureSize = 4096;
                importer.textureCompression = TextureImporterCompression.Uncompressed;
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
            config.levelNormal = Sprite("LevelButton");
            config.levelHard = Sprite("LevelButtonHard");
            config.logoNormal = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Res_Runtime/UI/Logo/Logo.png");
            config.logoHard = Sprite("LogoHard");
            config.lockedTint = new Color(0.78f, 0.78f, 0.78f, 1);
            config.idleBreatheAmount = 0.015f;
            config.idleBreatheSpeed = 1.7f;
            AssetDatabase.CreateAsset(config, path);
            return config;
        }

        static void CreatePrefab(string path, TMP_FontAsset font, HomeConfigSO config) {
            var root = Rect("Panel_Home", null, Vector2.zero, Vector2.zero);
            Stretch(root);
            var panel = root.gameObject.AddComponent<Panel_Home>();
            var background = Image("Background", root, AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Res_Runtime/UI/Logo/MenuBackground.png"), Vector2.zero, Vector2.zero);
            Stretch(background.rectTransform);
            var fitter = background.gameObject.AddComponent<UnityEngine.UI.AspectRatioFitter>();
            fitter.aspectMode = UnityEngine.UI.AspectRatioFitter.AspectMode.EnvelopeParent;
            fitter.aspectRatio = background.sprite.rect.width / background.sprite.rect.height;
            panel.safeRoot = Rect("SafeRoot", root, Vector2.zero, Vector2.zero);
            Stretch(panel.safeRoot);
            var content = Rect("Content", panel.safeRoot, new Vector2(1080, 1920), Vector2.zero);
            panel.contentRoot = content;

            // Original cards group: bottom anchor 0.62, 460x495 daily card and two right cards.
            var cards = Rect("CardsGroup", content, new Vector2(894, 495), new Vector2(0, 230));
            cards.pivot = new Vector2(0.5f, 0);
            panel.dailyButton = Button("Daily", cards, Sprite("CardDaily"), new Vector2(460, 495), new Vector2(-217, 0));
            panel.dailyImage = panel.dailyButton.GetComponent<UnityEngine.UI.Image>();
            Image("DailyIcon", panel.dailyButton.transform, Sprite("icon_daily"), new Vector2(145, 140), new Vector2(-135, 115));
            panel.dailyLabel = Label("DailyTitle", panel.dailyButton.transform, font, new Vector2(230, 145), new Vector2(70, 115), 52);
            panel.dailyLabel.text = "每日挑战";
            panel.dailyDateLabel = Label("Date", panel.dailyButton.transform, font, new Vector2(350, 70), new Vector2(0, 0), 46);
            panel.dailyLock = Lock(panel.dailyButton.transform, font, new Vector2(0, -135), out panel.dailyLockLabel);
            var dailyPlay = Image("PlayPill", panel.dailyButton.transform, Sprite("BtnPlayPill"), new Vector2(330, 92), new Vector2(0, -135));
            panel.dailyPlay = dailyPlay.gameObject;
            panel.dailyPlayLabel = Label("Title", dailyPlay.transform, font, new Vector2(240, 70), Vector2.zero, 48);
            panel.dailyPlayLabel.text = "开始";

            var streak = Image("Streak", cards, Sprite("CardStreak"), new Vector2(412, 225), new Vector2(241, 135));
            Image("Sunflower", streak.transform, Sprite("IconSunflower"), new Vector2(105, 142), new Vector2(-115, 0));
            panel.streakLabel = Label("Days", streak.transform, font, new Vector2(230, 100), new Vector2(55, 0), 64);

            panel.rankingButton = Button("Ranking", cards, Sprite("CardRank"), new Vector2(412, 253), new Vector2(241, -121));
            panel.rankingImage = panel.rankingButton.GetComponent<UnityEngine.UI.Image>();
            Image("Podium", panel.rankingButton.transform, Sprite("IconPodium_0"), new Vector2(200, 95), new Vector2(0, 48));
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
            panel.endlessButton = Button("Endless", content, Sprite("EndlessButton"), new Vector2(800, 170), new Vector2(0, -805));
            panel.endlessImage = panel.endlessButton.GetComponent<UnityEngine.UI.Image>();
            Image("Icon", panel.endlessButton.transform, Sprite("icon_endless"), new Vector2(95, 95), new Vector2(-250, 5));
            panel.endlessLabel = Label("Title", panel.endlessButton.transform, font, new Vector2(350, 75), new Vector2(20, 27), 47);
            panel.endlessLabel.text = "无限模式";
            panel.endlessLock = Lock(panel.endlessButton.transform, font, new Vector2(30, -47), out panel.endlessLockLabel);

            panel.settingsButton = Button("Settings", content, Sprite("icon_settings"), new Vector2(100, 100), new Vector2(440, 855));
            panel.settingsLabel = Label("Title", panel.settingsButton.transform, font, new Vector2(150, 50), new Vector2(0, -75), 30);
            panel.settingsLabel.text = "设置";
            panel.noticeLabel = Label("Notice", content, font, new Vector2(940, 100), new Vector2(0, -370), 38);
            panel.noticeLabel.color = new Color(0.42f, 0.25f, 0.17f, 1);
            PrefabUtility.SaveAsPrefabAsset(root.gameObject, path);
            UnityEngine.Object.DestroyImmediate(root.gameObject);
        }

        static GameObject Lock(Transform parent, TMP_FontAsset font, Vector2 position, out TMP_Text label) {
            var root = Rect("Lock", parent, new Vector2(340, 65), position);
            Image("Icon", root, Sprite("lock"), new Vector2(35, 42), new Vector2(-128, 0));
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
            return AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Res_Runtime/UI/Home/" + name + ".png");
        }

        static void ConfigureAddressables(string prefabPath) {
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
