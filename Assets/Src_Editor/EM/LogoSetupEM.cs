using System;
using System.IO;
using Hamdoku.Main;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using TMPro;
using System.Linq;
using System.Collections.Generic;

namespace Hamdoku.Editor {
    public static class LogoSetupEM {
        [InitializeOnLoadMethod]
        static void RegisterContentBindingMigration() {
            EditorApplication.delayCall += MigrateContentBinding;
            EditorApplication.delayCall += ApplyPendingLoadingScreen;
            EditorApplication.playModeStateChanged -= MigrateContentBindingOnPlayMode;
            EditorApplication.playModeStateChanged += MigrateContentBindingOnPlayMode;
        }

        static void MigrateContentBindingOnPlayMode(PlayModeStateChange state) {
            if (state == PlayModeStateChange.ExitingEditMode || state == PlayModeStateChange.EnteredEditMode) {
                ApplyPendingLoadingScreen();
                MigrateContentBinding();
            }
        }

        static void MigrateContentBinding() {
            if (EditorApplication.isPlaying) {
                return;
            }
            var scene = EditorSceneManager.GetActiveScene();
            if (scene.path != "Assets/Res_Runtime/Scene_Main.unity") {
                return;
            }
            var panel = UnityEngine.Object.FindAnyObjectByType<Panel_Logo>();
            if (panel == null || panel.contentRoot != null) {
                return;
            }
            // Upgrade the already-authored Content node; never create a replacement at runtime.
            var content = panel.logoIntro == null ? null : panel.logoIntro.motionRoot.parent as RectTransform;
            if (content == null || content.name != "Content" || content.parent != panel.safeRoot) {
                Debug.LogError("Panel_Logo Content migration requires the authored SafeRoot/Content/LogoMotion hierarchy.");
                return;
            }
            bool wasDirty = scene.isDirty;
            Undo.RecordObject(panel, "Bind Logo Content");
            var serialized = new SerializedObject(panel);
            serialized.FindProperty("contentRoot").objectReferenceValue = content;
            serialized.ApplyModifiedProperties();
            EditorSceneManager.MarkSceneDirty(scene);
            if (!wasDirty) {
                EditorSceneManager.SaveScene(scene);
            }
            Debug.Log("[LogoSetup] Migrated the missing Panel_Logo ContentRoot binding.");
        }

        static void ApplyPendingLoadingScreen() {
            const string request = "Library/LogoSetup/LoadingScreen.request";
            if (EditorApplication.isPlaying || !File.Exists(request)) {
                return;
            }
            var scene = EditorSceneManager.GetActiveScene();
            if (scene.path != "Assets/Res_Runtime/Scene_Main.unity") {
                return;
            }
            ConfigureLoadingScreen();
            File.Delete(request);
        }

        [MenuItem("Hamdoku/Setup/Configure Loading Screen")]
        public static void ConfigureLoadingScreen() {
            var scene = EditorSceneManager.GetActiveScene();
            if (scene.path != "Assets/Res_Runtime/Scene_Main.unity") {
                throw new InvalidOperationException("Open Scene_Main before configuring the loading screen.");
            }
            bool wasDirty = scene.isDirty;
            ImportSprites();
            var main = UnityEngine.Object.FindAnyObjectByType<ClientMain>();
            var panel = main.panel_Logo;
            var config = main.logoConfig;
            // Upgrade the existing authored content without replacing the panel or its animation.
            var content = panel.logoIntro.motionRoot.parent as RectTransform;
            if (content == null || content.name != "Content" || content.parent != panel.safeRoot) {
                throw new InvalidOperationException("Loading screen requires authored SafeRoot/Content/LogoMotion.");
            }
            panel.contentRoot = content;
            config.startupHomeConfig = AssetDatabase.LoadAssetAtPath<HomeConfigSO>("Assets/Res_Runtime/Config/HomeConfig.asset");
            config.seedCount = 5;
            config.seedPopScale = 1.18f;
            config.seedPopSeconds = 0.34f;
            config.seedIdlePulse = 0.05f;
            config.finishHoldSeconds = 0.3f;
            config.startupTexts = new[] {
                LoadingText(UINameType.Loading_Quote, "一颗葵花籽就足够今天了", "One sunflower seed is enough for today"),
                LoadingText(UINameType.Loading_Author, "- 仓鼠格言", "- Hamster proverb"),
                LoadingText(UINameType.Loading_Copyright, "© MOBIRIX Corporation. All Rights Reserved.", "© MOBIRIX Corporation. All Rights Reserved.")
            };
            config.startupFonts = new[] {
                AssetDatabase.LoadAssetAtPath<L10NFontSO>("Assets/Res_Runtime/Localization/Font_Chinese.asset"),
                AssetDatabase.LoadAssetAtPath<L10NFontSO>("Assets/Res_Runtime/Localization/Font_English.asset")
            };
            foreach (var map in config.startupFonts) {
                var font = map.font;
                string characters = string.Concat(config.startupTexts.Select(text => map.language == SystemLanguage.ChineseSimplified ? text.chinese : text.english));
                if (!font.HasCharacters(characters)) {
                    font.atlasPopulationMode = AtlasPopulationMode.Dynamic;
                    var serializedFont = new SerializedObject(font);
                    string sourceGuid = serializedFont.FindProperty("m_SourceFontFileGUID").stringValue;
                    var source = AssetDatabase.LoadAssetAtPath<Font>(AssetDatabase.GUIDToAssetPath(sourceGuid));
                    if (source == null) {
                        throw new InvalidOperationException("Loading font source is missing: " + font.name);
                    }
                    serializedFont.FindProperty("m_SourceFontFile").objectReferenceValue = source;
                    serializedFont.ApplyModifiedPropertiesWithoutUndo();
                    try {
                        if (!font.TryAddCharacters(characters, out string missing)) {
                            throw new InvalidOperationException("Loading font is missing characters: " + missing);
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
            var chinese = config.startupFonts[0].font;
            var motion = panel.logoIntro.motionRoot;
            motion.anchorMin = new Vector2(0.5f, 0.58f);
            motion.anchorMax = motion.anchorMin;
            motion.anchoredPosition = Vector2.zero;
            motion.localScale = Vector3.one * (720f / 1080f);
            panel.quoteLabel = LoadingLabel(content, "Quote", chinese, new Vector2(840, 90), new Vector2(0.5f, 0.37f), new Vector2(0, 35), 47);
            panel.quoteLabel.enableAutoSizing = true;
            panel.quoteLabel.fontSizeMin = 25;
            panel.quoteLabel.fontSizeMax = 47;
            panel.authorLabel = LoadingLabel(content, "Author", chinese, new Vector2(840, 60), new Vector2(0.5f, 0.37f), new Vector2(0, -55), 35.25f);
            panel.copyrightLabel = LoadingLabel(content, "Copyright", chinese, new Vector2(1000, 50), new Vector2(0.5f, 0), new Vector2(0, 80), 26);
            panel.copyrightLabel.color = new Color(0.42f, 0.31f, 0.22f, 0.92f);
            panel.SetText(config.startupTexts[0].chinese, config.startupTexts[1].chinese, config.startupTexts[2].chinese);
            var row = LoadingRect(content, "SeedRow", new Vector2(431, 75), new Vector2(0.5f, 0.24f), Vector2.zero);
            panel.seedFills = new UnityEngine.UI.Image[config.seedCount];
            panel.seedEmpties = new UnityEngine.UI.Image[config.seedCount];
            for (int i = 0; i < config.seedCount; i++) {
                var slot = LoadingRect(row, "Seed" + (i + 1), new Vector2(75, 75), Vector2.one * 0.5f, new Vector2((i - 2) * 89, 0));
                panel.seedEmpties[i] = LoadingImage(slot, "Empty", Sprite("Img_Logo_LoadingSeed_Empty"), new Vector2(75, 75), Vector2.zero);
                panel.seedFills[i] = LoadingImage(slot, "Filled", Sprite("Img_Logo_LoadingSeed"), new Vector2(75, 75), Vector2.zero);
                panel.seedFills[i].enabled = false;
            }
            panel.seedMark = LoadingImage(row, "PopMark", Sprite("Img_Logo_LoadingSeed_Pop"), new Vector2(69, 42), new Vector2(0, 66)).rectTransform;
            panel.seedMark.gameObject.SetActive(false);
            EditorUtility.SetDirty(panel);
            EditorUtility.SetDirty(config);
            AssetDatabase.SaveAssets();
            EditorSceneManager.MarkSceneDirty(scene);
            if (!wasDirty) {
                EditorSceneManager.SaveScene(scene);
            }
            Debug.Log("[LogoSetup] Loading screen quote, copyright and five seed slots are bound.");
        }

        static L10NSO LoadingText(UINameType id, string chinese, string english) {
            string path = "Assets/Res_Runtime/Localization/" + id + ".asset";
            var text = AssetDatabase.LoadAssetAtPath<L10NSO>(path);
            if (text == null) {
                text = ScriptableObject.CreateInstance<L10NSO>();
                text.id = id;
                text.chinese = chinese;
                text.english = english;
                AssetDatabase.CreateAsset(text, path);
            }
            var settings = UnityEditor.AddressableAssets.AddressableAssetSettingsDefaultObject.Settings;
            var group = settings.FindGroup("Home");
            var entry = settings.CreateOrMoveEntry(AssetDatabase.AssetPathToGUID(path), group);
            entry.address = path;
            entry.SetLabel(AAConst.LABEL_DEFAULT, true);
            return text;
        }

        static RectTransform LoadingRect(RectTransform parent, string name, Vector2 size, Vector2 anchor, Vector2 position) {
            var existing = parent.Find(name);
            var rect = existing == null ? NewRect(name, parent) : (RectTransform)existing;
            rect.anchorMin = anchor;
            rect.anchorMax = anchor;
            rect.sizeDelta = size;
            rect.anchoredPosition = position;
            return rect;
        }

        static TMP_Text LoadingLabel(RectTransform parent, string name, TMP_FontAsset font, Vector2 size, Vector2 anchor, Vector2 position, float fontSize) {
            var rect = LoadingRect(parent, name, size, anchor, position);
            var text = rect.GetComponent<TextMeshProUGUI>();
            if (text == null) {
                text = rect.gameObject.AddComponent<TextMeshProUGUI>();
            }
            text.font = font;
            text.fontSize = fontSize;
            text.alignment = TextAlignmentOptions.Center;
            text.color = new Color(0.42f, 0.31f, 0.22f, 1);
            text.raycastTarget = false;
            return text;
        }

        static UnityEngine.UI.Image LoadingImage(RectTransform parent, string name, Sprite sprite, Vector2 size, Vector2 position) {
            var rect = LoadingRect(parent, name, size, Vector2.one * 0.5f, position);
            var image = rect.GetComponent<UnityEngine.UI.Image>();
            if (image == null) {
                image = rect.gameObject.AddComponent<UnityEngine.UI.Image>();
            }
            image.sprite = sprite;
            image.preserveAspect = true;
            image.raycastTarget = false;
            return image;
        }

        [MenuItem("Hamdoku/Setup/Configure Logo Scene")]
        public static void Setup() {
            var scene = EditorSceneManager.GetActiveScene();
            if (scene.isDirty) {
                throw new InvalidOperationException("Save scene changes before configuring the Logo scene.");
            }
            ImportSprites();
            var config = LoadConfig();
            scene = EditorSceneManager.OpenScene("Assets/Res_Runtime/Scene_Main.unity", OpenSceneMode.Single);
            if (UnityEngine.Object.FindAnyObjectByType<ClientMain>() != null) {
                throw new InvalidOperationException("Scene_Main already has ClientMain. Update its existing bindings instead of rebuilding it.");
            }

            var mainObject = new GameObject("ClientMain");
            var main = mainObject.AddComponent<ClientMain>();
            var effects = mainObject.AddComponent<AudioSource>();
            effects.playOnAwake = false;
            effects.loop = false;
            effects.spatialBlend = 0;
            main.logoEffects = effects;
            main.logoConfig = config;

            var canvasRect = NewRect("Canvas_Screen", null);
            var canvas = canvasRect.gameObject.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            var scaler = canvasRect.gameObject.AddComponent<UnityEngine.UI.CanvasScaler>();
            scaler.uiScaleMode = UnityEngine.UI.CanvasScaler.ScaleMode.ScaleWithScreenSize;
            scaler.referenceResolution = new Vector2(UIResolutionConst.WIDTH, UIResolutionConst.HEIGHT);
            scaler.screenMatchMode = UnityEngine.UI.CanvasScaler.ScreenMatchMode.MatchWidthOrHeight;
            scaler.matchWidthOrHeight = UIResolutionConst.MATCH_WIDTH_OR_HEIGHT;
            canvasRect.gameObject.AddComponent<UnityEngine.UI.GraphicRaycaster>();
            var entity = canvasRect.gameObject.AddComponent<CanvasEntity>();
            entity.type = CanvasType.ScreenSpace;
            entity.order = 0;
            main.canvas_Screen = entity;

            var panelRect = NewRect("Panel_Logo", canvasRect);
            Stretch(panelRect);
            var panel = panelRect.gameObject.AddComponent<Panel_Logo>();
            main.panel_Logo = panel;
            var background = NewImage("Background", panelRect, Sprite("bg_Common_Menu"), Vector2.zero, Vector2.zero);
            Stretch(background.rectTransform);
            var backgroundFit = background.gameObject.AddComponent<UnityEngine.UI.AspectRatioFitter>();
            backgroundFit.aspectMode = UnityEngine.UI.AspectRatioFitter.AspectMode.EnvelopeParent;
            backgroundFit.aspectRatio = background.sprite.rect.width / background.sprite.rect.height;
            var safeRoot = NewRect("SafeRoot", panelRect);
            Stretch(safeRoot);
            panel.safeRoot = safeRoot;

            var content = NewRect("Content", safeRoot);
            content.sizeDelta = new Vector2(UIResolutionConst.WIDTH, UIResolutionConst.HEIGHT);
            panel.contentRoot = content;
            var motion = NewRect("LogoMotion", content);
            motion.sizeDelta = config.canvasSize;
            // Original Logo uses an 800px square with a 1080px composition.
            motion.localScale = Vector3.one * (800f / config.canvasSize.x);
            motion.anchorMin = new Vector2(0.5f, 0.478f);
            motion.anchorMax = motion.anchorMin;
            motion.anchoredPosition = new Vector2(0, -70);
            var widget = motion.gameObject.AddComponent<Widget_LogoIntro>();
            panel.logoIntro = widget;
            widget.motionRoot = motion;
            widget.baseLogo = NewImage("Logo", motion, config.baseLogo, config.baseLogoSize, config.baseLogoCenter);
            widget.baseLogo.preserveAspect = true;

            var parts = NewRect("IntroParts", motion);
            parts.sizeDelta = config.canvasSize;
            widget.partsRoot = parts;
            var mask = NewImage("HamsterMask", parts, config.hamsterMask, config.hamsterMaskSize, config.hamsterMaskCenter);
            mask.gameObject.AddComponent<UnityEngine.UI.Mask>().showMaskGraphic = false;
            var hamster = NewRect("HamsterMotion", mask.rectTransform);
            hamster.sizeDelta = config.canvasSize;
            widget.hamsterRoot = hamster;
            NewImage("HamsterBody", hamster, config.hamsterBody, config.hamsterBodySize,
                config.hamsterBodyCenter - config.hamsterMaskCenter);
            widget.eyesOpen = NewImage("EyesOpen", hamster, config.eyesOpen, config.eyesOpenSize,
                config.eyesOpenCenter - config.hamsterMaskCenter);
            widget.eyesBlink = NewImage("EyesBlink", hamster, config.eyesBlink, config.eyesBlinkSize,
                config.eyesBlinkCenter - config.hamsterMaskCenter);
            var board = NewRect("BoardMotion", parts);
            board.sizeDelta = config.canvasSize;
            widget.boardRoot = board;
            NewImage("BoardBack", board, config.boardBack, config.boardBackSize, config.boardBackCenter);
            NewImage("BoardFront", board, config.boardFront, config.boardFrontSize, config.boardFrontCenter);
            widget.belly = NewImage("BellyOverlay", board, config.bellyOverlay, config.bellyOverlaySize, config.bellyOverlayCenter);
            widget.xMark = NewImage("XMark", board, config.xMark, config.xMarkSize, config.xMarkCenter).rectTransform;
            parts.gameObject.SetActive(false);

            EditorSceneManager.MarkSceneDirty(scene);
            EditorSceneManager.SaveScene(scene);
            AssetDatabase.SaveAssets();
            Debug.Log("[LogoSetup] Scene_Main configured with ClientMain, Panel_Logo and LogoConfig.");
        }

        static void ImportSprites() {
            foreach (string assetGuid in AssetDatabase.FindAssets("t:Texture2D", new[] { "Assets/Res_Runtime/UI/Logo/new" })) {
                string path = AssetDatabase.GUIDToAssetPath(assetGuid);
                var importer = (TextureImporter)AssetImporter.GetAtPath(path);
                importer.textureType = TextureImporterType.Sprite;
                importer.spriteImportMode = SpriteImportMode.Single;
                importer.spritePixelsPerUnit = 100;
                importer.alphaIsTransparency = true;
                importer.mipmapEnabled = false;
                importer.textureCompression = TextureImporterCompression.Uncompressed;
                importer.maxTextureSize = 4096;
                var settings = new TextureImporterSettings();
                importer.ReadTextureSettings(settings);
                settings.textureType = TextureImporterType.Sprite;
                settings.textureShape = TextureImporterShape.Texture2D;
                settings.spriteMode = (int)SpriteImportMode.Single;
                settings.spriteMeshType = SpriteMeshType.FullRect;
                importer.SetTextureSettings(settings);
                importer.SaveAndReimport();
            }
        }

        static LogoConfigSO LoadConfig() {
            string path = "Assets/Res_Runtime/Config/LogoConfig.asset";
            var config = AssetDatabase.LoadAssetAtPath<LogoConfigSO>(path);
            if (config != null) {
                return config;
            }
            // One-time development import. The saved SO is the runtime source of truth.
            string importPath = "Library/LogoSetup/LogoConfig.import.json";
            if (!File.Exists(importPath)) {
                throw new FileNotFoundException("LogoConfig.asset or its one-time import data is required.", importPath);
            }
            config = ScriptableObject.CreateInstance<LogoConfigSO>();
            JsonUtility.FromJsonOverwrite(File.ReadAllText(importPath), config);
            config.baseLogo = Sprite("Img_Common_Logo");
            config.hamsterMask = Sprite("Img_Logo_HamsterMask");
            config.hamsterBody = Sprite("Img_Logo_HamsterBody");
            config.eyesOpen = Sprite("Img_Logo_Eyes_Open");
            config.eyesBlink = Sprite("Img_Logo_Eyes_Blink");
            config.boardBack = Sprite("Img_Logo_BoardBack");
            config.bellyOverlay = Sprite("Img_Logo_BellyOverlay");
            config.boardFront = Sprite("Img_Logo_BoardFront");
            config.xMark = Sprite("Img_Logo_Cross");
            config.riseClip = AssetDatabase.LoadAssetAtPath<AudioClip>("Assets/Res_Runtime/Audio/Logo/squeak.wav");
            config.landClip = AssetDatabase.LoadAssetAtPath<AudioClip>("Assets/Res_Runtime/Audio/Logo/stamp.wav");
            config.xPunchClip = config.landClip;
            Directory.CreateDirectory("Assets/Res_Runtime/Config");
            AssetDatabase.Refresh();
            AssetDatabase.CreateAsset(config, path);
            return config;
        }

        static Sprite Sprite(string name) {
            var sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Res_Runtime/UI/Logo/new/" + name + ".png");
            if (sprite == null) {
                throw new InvalidOperationException("Missing imported Logo sprite: " + name);
            }
            return sprite;
        }

        static RectTransform NewRect(string name, Transform parent) {
            var rect = new GameObject(name, typeof(RectTransform)).GetComponent<RectTransform>();
            rect.gameObject.layer = LayerMask.NameToLayer("UI");
            rect.SetParent(parent, false);
            rect.anchorMin = Vector2.one * 0.5f;
            rect.anchorMax = rect.anchorMin;
            rect.pivot = Vector2.one * 0.5f;
            return rect;
        }

        static UnityEngine.UI.Image NewImage(string name, Transform parent, Sprite sprite, Vector2 size, Vector2 center) {
            var rect = NewRect(name, parent);
            rect.sizeDelta = size;
            rect.anchoredPosition = center;
            var image = rect.gameObject.AddComponent<UnityEngine.UI.Image>();
            image.sprite = sprite;
            image.raycastTarget = false;
            return image;
        }

        static void Stretch(RectTransform rect) {
            rect.anchorMin = Vector2.zero;
            rect.anchorMax = Vector2.one;
            rect.offsetMin = Vector2.zero;
            rect.offsetMax = Vector2.zero;
        }
    }
}
