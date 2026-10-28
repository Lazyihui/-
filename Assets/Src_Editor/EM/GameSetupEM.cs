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
    public static class GameSetupEM {
        [MenuItem("Hamdoku/Setup/Configure Gameplay")]
        public static void Setup() {
            ImportSprites();
            Directory.CreateDirectory("Assets/Res_Runtime/Puzzle");
            AssetDatabase.Refresh();
            var config = CreateConfig();
            var texts = ImportTexts();
            BakeFonts(texts);
            var font = AssetDatabase.LoadAssetAtPath<TMP_FontAsset>("Assets/Res_Runtime/Font/Chinese SDF.asset");
            string cellPath = "Assets/Res_Runtime/UI/Game/Widget_BoardCell.prefab";
            if (AssetDatabase.LoadAssetAtPath<GameObject>(cellPath) == null) {
                throw new InvalidOperationException("Migrate the original Cell prefab before gameplay setup.");
            }
            string gamePath = "Assets/Res_Runtime/UI/Game/Panel_Game.prefab";
            if (AssetDatabase.LoadAssetAtPath<GameObject>(gamePath) == null) {
                throw new InvalidOperationException("Migrate the original Game Canvas before gameplay setup.");
            }
            string dialogPath = "Assets/Res_Runtime/UI/Game/Panel_GameDialog.prefab";
            if (AssetDatabase.LoadAssetAtPath<GameObject>(dialogPath) == null) {
                CreateDialog(dialogPath, font);
            }
            Refine();
            var home = AssetDatabase.LoadAssetAtPath<GameConfigSO>("Assets/Res_Runtime/Config/GameConfig.asset");
            home.saveVersion = Math.Max(home.saveVersion, 2);
            EditorUtility.SetDirty(home);
            RegisterAssets(new[] { gamePath, dialogPath, "Assets/Res_Runtime/Config/GameConfig.asset" }.Concat(texts.Select(text => AssetDatabase.GetAssetPath(text))));
            PuzzleConfigSetupEM.Register();
            AssetDatabase.SaveAssets();
            Debug.Log("[GameSetup] Gameplay assets, fonts and default registrations ready.");
        }
        [MenuItem("Hamdoku/Setup/Update Original Tutorial")]
        public static void SetupTutorial() {
            ImportSprites();
            var texts = AssetDatabase.FindAssets("t:L10NSO", new[] { "Assets/Res_Runtime/Localization" })
                .Select(guid => AssetDatabase.LoadAssetAtPath<L10NSO>(AssetDatabase.GUIDToAssetPath(guid))).ToList();
            BakeFonts(texts);
            GameOriginalUIEM.Adapt();
            RegisterAssets(texts.Where(text => text.id >= UINameType.Game_TutorialRegion && text.id <= UINameType.Game_TutorialOnlyPurple).Select(text => AssetDatabase.GetAssetPath(text)));
            AssetDatabase.SaveAssets();
        }
        static void ImportSprites() {
            foreach (string path in Directory.GetFiles("Assets/Res_Runtime/UI/Game", "*.png").Concat(Directory.GetFiles("Assets/Res_Runtime/UI/Game/new", "*.png"))) {
                var importer = (TextureImporter)AssetImporter.GetAtPath(path);
                var spriteMode = importer.spriteImportMode;
                importer.textureType = TextureImporterType.Sprite;
                importer.spriteImportMode = spriteMode == SpriteImportMode.None ? SpriteImportMode.Single : spriteMode;
                importer.spritePixelsPerUnit = 100;
                importer.mipmapEnabled = false;
                importer.alphaIsTransparency = true;
                importer.maxTextureSize = 4096;
                importer.textureCompression = TextureImporterCompression.Uncompressed;
                string name = Path.GetFileNameWithoutExtension(path);
                if (name == "bg_Common_Rounded" || name == "bg_Game_Rounded") {
                    importer.spriteBorder = Vector4.one * 16;
                } else if (name == "bg_Common_Popup") {
                    importer.spriteBorder = Vector4.one * 80;
                } else if (name.StartsWith("btn_", StringComparison.Ordinal)) {
                    importer.spriteBorder = new Vector4(60, 60, 60, 60);
                }
                switch (Path.GetFileNameWithoutExtension(path))
                {
                    case "btn_Common_Rounded_Yellow":
                        importer.spriteBorder = new Vector4(105f, 81f, 105f, 80f);
                        break;
                    case "btn_Game_Rounded_Blue":
                        importer.spriteBorder = new Vector4(110f, 85f, 110f, 83f);
                        break;
                }
                importer.SaveAndReimport();
            }
        }
        static PuzzleRulesSO CreateConfig() {
            var config = AssetDatabase.LoadAssetAtPath<PuzzleRulesSO>("Assets/Res_Runtime/Config/PuzzleRules.asset");
            if (config == null) {
                throw new InvalidOperationException("Missing formal PuzzleRules asset. Restore the delivered configuration before setup.");
            }
            return config;
        }
        static List<L10NSO> ImportTexts() {
            var texts = new List<L10NSO>();
            foreach (string source in Directory.GetFiles("Logs/GameplayMigration/TextImport", "*.json")) {
                var id = (UINameType)int.Parse(Path.GetFileNameWithoutExtension(source));
                string path = "Assets/Res_Runtime/Localization/" + id + ".asset";
                var text = AssetDatabase.LoadAssetAtPath<L10NSO>(path);
                if (text == null) {
                    text = ScriptableObject.CreateInstance<L10NSO>();
                    JsonUtility.FromJsonOverwrite(File.ReadAllText(source), text);
                    AssetDatabase.CreateAsset(text, path);
                }
                texts.Add(text);
            }
            return texts;
        }
        static void BakeFonts(List<L10NSO> texts) {
            foreach (string language in new[] { "Chinese", "English" }) {
                var font = AssetDatabase.LoadAssetAtPath<TMP_FontAsset>("Assets/Res_Runtime/Font/" + language + " SDF.asset");
                string characters = "0123456789/: " + string.Concat(texts.Select(text => language == "Chinese" ? text.chinese : text.english));
                characters = Regex.Replace(characters, "<[^>]*>|\\{[^}]*\\}", string.Empty).Replace("\n", string.Empty);
                if (!font.HasCharacters(characters)) {
                    var serialized = new SerializedObject(font);
                    string guid = serialized.FindProperty("m_SourceFontFileGUID").stringValue;
                    var source = AssetDatabase.LoadAssetAtPath<Font>(AssetDatabase.GUIDToAssetPath(guid));
                    if (source == null) {
                        throw new InvalidOperationException("Missing font source " + language);
                    }
                    serialized.FindProperty("m_SourceFontFile").objectReferenceValue = source;
                    serialized.ApplyModifiedPropertiesWithoutUndo();
                    font.atlasPopulationMode = AtlasPopulationMode.Dynamic;
                    try {
                        if (!font.TryAddCharacters(characters, out string missing)) {
                            throw new InvalidOperationException("Missing glyphs " + missing);
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
        public static void Refine() {
            ImportSprites();
            GameOriginalUIEM.Adapt();
            AssetDatabase.SaveAssets();
        }
        static void CreateDialog(string path, TMP_FontAsset font) {
            var root = Rect("Panel_GameDialog", null, Vector2.zero, Vector2.zero);
            Stretch(root);
            var panel = root.gameObject.AddComponent<Panel_GameDialog>();
            var dim = Image("Dim", root, null, Vector2.zero, Vector2.zero);
            Stretch(dim.rectTransform);
            dim.color = new Color(0.17f, 0.1f, 0.06f, 0.65f);
            dim.raycastTarget = true;
            panel.safeRoot = Rect("SafeRoot", root, Vector2.zero, Vector2.zero);
            Stretch(panel.safeRoot);
            panel.contentRoot = Rect("Content", panel.safeRoot, new Vector2(1080, 1920), Vector2.zero);
            var card = Image("Card", panel.contentRoot, Sprite("bg_Common_Popup"), new Vector2(900, 940), Vector2.zero);
            card.raycastTarget = true;
            panel.titleLabel = Label("Title", card.transform, font, new Vector2(780, 200), new Vector2(0, 320), 62);
            panel.bodyLabel = Label("Body", card.transform, font, new Vector2(760, 280), new Vector2(0, 80), 40);
            panel.adButton = Button("Ad", card.transform, "btn_Game_Rounded_Blue", new Vector2(700, 125), new Vector2(0, -125));
            panel.adLabel = Label("Label", panel.adButton.transform, font, new Vector2(630, 100), Vector2.zero, 40);
            panel.primaryButton = Button("Primary", card.transform, "btn_Common_Rounded_Yellow", new Vector2(700, 125), new Vector2(0, -270));
            panel.primaryLabel = Label("Label", panel.primaryButton.transform, font, new Vector2(630, 100), Vector2.zero, 43);
            panel.secondaryButton = Button("Secondary", card.transform, "bg_Common_Rounded", new Vector2(700, 90), new Vector2(0, -390));
            panel.secondaryLabel = Label("Label", panel.secondaryButton.transform, font, new Vector2(630, 75), Vector2.zero, 35);
            PrefabUtility.SaveAsPrefabAsset(root.gameObject, path);
            UnityEngine.Object.DestroyImmediate(root.gameObject);
        }
        static void RegisterAssets(IEnumerable<string> paths) {
            var defaultObject = AssetDatabase.LoadAssetAtPath<AddressableAssetSettingsDefaultObject>("Assets/AddressableAssetsData/DefaultObject.asset");
            EditorBuildSettings.AddConfigObject(AddressableAssetSettingsDefaultObject.kDefaultConfigObjectName, defaultObject, true);
            var settings = AddressableAssetSettingsDefaultObject.Settings;
            var group = settings.FindGroup("Gameplay");
            if (group == null) {
                group = settings.CreateGroup("Gameplay", false, false, true, null, typeof(BundledAssetGroupSchema), typeof(ContentUpdateGroupSchema));
            }
            var schema = group.GetSchema<BundledAssetGroupSchema>();
            schema.BuildPath.SetVariableByName(settings, AddressableAssetSettings.kLocalBuildPath);
            schema.LoadPath.SetVariableByName(settings, AddressableAssetSettings.kLocalLoadPath);
            foreach (string path in paths) {
                var entry = settings.CreateOrMoveEntry(AssetDatabase.AssetPathToGUID(path), group);
                entry.address = path;
                entry.SetLabel(AAConst.LABEL_DEFAULT, true);
            }
            EditorUtility.SetDirty(settings);
        }
        static Sprite Sprite(string name) {
            switch (name)
            {
                case "btn_Common_Rounded_Yellow":
                    return AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Res_Runtime/UI/Game/new/btn_Common_Rounded_Yellow.png") ?? throw new InvalidOperationException("Missing installed button: Assets/Res_Runtime/UI/Game/new/btn_Common_Rounded_Yellow.png");
                case "btn_Game_Rounded_Blue":
                    return AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Res_Runtime/UI/Game/new/btn_Game_Rounded_Blue.png") ?? throw new InvalidOperationException("Missing installed button: Assets/Res_Runtime/UI/Game/new/btn_Game_Rounded_Blue.png");
            }
            var sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Res_Runtime/UI/Game/" + name + ".png");
            if (sprite == null) {
                throw new InvalidOperationException("Missing gameplay sprite " + name);
            }
            return sprite;
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
        static UnityEngine.UI.Image Image(string name, Transform parent, Sprite sprite, Vector2 size, Vector2 position) {
            var image = Rect(name, parent, size, position).gameObject.AddComponent<UnityEngine.UI.Image>();
            image.sprite = sprite;
            image.raycastTarget = false;
            if (sprite != null && sprite.border != Vector4.zero) {
                image.type = UnityEngine.UI.Image.Type.Sliced;
                image.pixelsPerUnitMultiplier = 2;
            }
            if (sprite != null && sprite.border != Vector4.zero &&
                AssetDatabase.GetAssetPath(sprite).Contains("/new/") &&
                (sprite.name == "btn_Common_Rounded_Yellow" || sprite.name == "btn_Game_Rounded_Blue"))
            {
                image.type = UnityEngine.UI.Image.Type.Sliced;
                image.preserveAspect = false;
                image.pixelsPerUnitMultiplier = sprite.rect.height / size.y;
            }
            return image;
        }
        static UnityEngine.UI.Button Button(string name, Transform parent, string sprite, Vector2 size, Vector2 position) {
            var image = Image(name, parent, Sprite(sprite), size, position);
            image.raycastTarget = true;
            var button = image.gameObject.AddComponent<UnityEngine.UI.Button>();
            button.targetGraphic = image;
            return button;
        }
        static TMP_Text Label(string name, Transform parent, TMP_FontAsset font, Vector2 size, Vector2 position, float fontSize) {
            var text = Rect(name, parent, size, position).gameObject.AddComponent<TextMeshProUGUI>();
            text.font = font;
            text.fontSize = fontSize;
            text.fontSizeMin = fontSize * 0.65f;
            text.fontSizeMax = fontSize;
            text.enableAutoSizing = true;
            text.alignment = TextAlignmentOptions.Center;
            text.color = new Color(0.427f, 0.247f, 0.298f, 1);
            text.raycastTarget = false;
            var buttonImage = parent.GetComponent<UnityEngine.UI.Image>();
            if (buttonImage != null && buttonImage.sprite != null &&
                AssetDatabase.GetAssetPath(buttonImage.sprite).Contains("/new/") &&
                (buttonImage.sprite.name == "btn_Common_Rounded_Yellow" || buttonImage.sprite.name == "btn_Game_Rounded_Blue"))
            {
                text.color = new Color(0.32f, 0.22f, 0.12f);
            }
            return text;
        }
    }
}
