using System;
using System.IO;
using Hamdoku.Main;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Hamdoku.Editor {
    public static class LogoSetupEM {
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
            scaler.referenceResolution = new Vector2(1080, 1920);
            scaler.screenMatchMode = UnityEngine.UI.CanvasScaler.ScreenMatchMode.MatchWidthOrHeight;
            scaler.matchWidthOrHeight = 0.5f;
            canvasRect.gameObject.AddComponent<UnityEngine.UI.GraphicRaycaster>();
            var entity = canvasRect.gameObject.AddComponent<CanvasEntity>();
            entity.type = CanvasType.ScreenSpace;
            entity.order = 0;
            main.canvas_Screen = entity;

            var panelRect = NewRect("Panel_Logo", canvasRect);
            Stretch(panelRect);
            var panel = panelRect.gameObject.AddComponent<Panel_Logo>();
            main.panel_Logo = panel;
            var background = NewImage("Background", panelRect, Sprite("MenuBackground"), Vector2.zero, Vector2.zero);
            Stretch(background.rectTransform);
            var backgroundFit = background.gameObject.AddComponent<UnityEngine.UI.AspectRatioFitter>();
            backgroundFit.aspectMode = UnityEngine.UI.AspectRatioFitter.AspectMode.EnvelopeParent;
            backgroundFit.aspectRatio = background.sprite.rect.width / background.sprite.rect.height;
            var safeRoot = NewRect("SafeRoot", panelRect);
            Stretch(safeRoot);
            panel.safeRoot = safeRoot;

            var motion = NewRect("LogoMotion", safeRoot);
            motion.sizeDelta = config.canvasSize;
            // Original Logo uses an 800px square with a 1080px composition.
            motion.localScale = Vector3.one * (800f / config.canvasSize.x);
            motion.anchorMin = new Vector2(0.5f, 0.55f);
            motion.anchorMax = motion.anchorMin;
            var widget = motion.gameObject.AddComponent<Widget_LogoIntro>();
            panel.logoIntro = widget;
            widget.motionRoot = motion;
            widget.baseLogo = NewImage("Logo", motion, config.baseLogo, config.baseLogo.rect.size, Vector2.zero);
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
            widget.belly = NewImage("BellyOverlay", board, config.bellyOverlay, config.bellyOverlaySize, config.bellyOverlayCenter);
            NewImage("BoardFront", board, config.boardFront, config.boardFrontSize, config.boardFrontCenter);
            widget.xMark = NewImage("XMark", board, config.xMark, config.xMarkSize, config.xMarkCenter).rectTransform;
            parts.gameObject.SetActive(false);

            EditorSceneManager.MarkSceneDirty(scene);
            EditorSceneManager.SaveScene(scene);
            AssetDatabase.SaveAssets();
            Debug.Log("[LogoSetup] Scene_Main configured with ClientMain, Panel_Logo and LogoConfig.");
        }

        static void ImportSprites() {
            foreach (string assetGuid in AssetDatabase.FindAssets("t:Texture2D", new[] { "Assets/Res_Runtime/UI/Logo" })) {
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
            config.baseLogo = Sprite("Logo");
            config.hamsterMask = Sprite("hamster_mask");
            config.hamsterBody = Sprite("hamster_body");
            config.eyesOpen = Sprite("eyes_open");
            config.eyesBlink = Sprite("eyes_blink");
            config.boardBack = Sprite("board_back");
            config.bellyOverlay = Sprite("belly_overlay");
            config.boardFront = Sprite("board_front");
            config.xMark = Sprite("x_mark");
            config.riseClip = AssetDatabase.LoadAssetAtPath<AudioClip>("Assets/Res_Runtime/Audio/Logo/squeak.wav");
            config.landClip = AssetDatabase.LoadAssetAtPath<AudioClip>("Assets/Res_Runtime/Audio/Logo/stamp.wav");
            config.xPunchClip = config.landClip;
            Directory.CreateDirectory("Assets/Res_Runtime/Config");
            AssetDatabase.Refresh();
            AssetDatabase.CreateAsset(config, path);
            return config;
        }

        static Sprite Sprite(string name) {
            var sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Res_Runtime/UI/Logo/" + name + ".png");
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
