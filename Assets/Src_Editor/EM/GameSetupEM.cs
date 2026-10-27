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
            Directory.CreateDirectory("Assets/Res_Runtime/Config/Puzzles");
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
            var home = AssetDatabase.LoadAssetAtPath<HomeConfigSO>("Assets/Res_Runtime/Config/HomeConfig.asset");
            home.saveVersion = Math.Max(home.saveVersion, 2);
            EditorUtility.SetDirty(home);
            RegisterAssets(new[] { gamePath, dialogPath, "Assets/Res_Runtime/Config/GameConfig.asset" }.Concat(texts.Select(text => AssetDatabase.GetAssetPath(text))));
            AssetDatabase.SaveAssets();
            Debug.Log("[GameSetup] Gameplay assets, fonts and default registrations ready.");
        }
        static void ImportSprites() {
            foreach (string path in Directory.GetFiles("Assets/Res_Runtime/UI/Game", "*.png")) {
                var importer = (TextureImporter)AssetImporter.GetAtPath(path);
                importer.textureType = TextureImporterType.Sprite;
                importer.spriteImportMode = SpriteImportMode.Single;
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
                importer.SaveAndReimport();
            }
        }
        static GameConfigSO CreateConfig() {
            string path = "Assets/Res_Runtime/Config/GameConfig.asset";
            var config = AssetDatabase.LoadAssetAtPath<GameConfigSO>(path);
            if (config != null) {
                return config;
            }
            config = ScriptableObject.CreateInstance<GameConfigSO>();
            var puzzles = new List<PuzzleSO>();
            foreach (string source in Directory.GetFiles("Logs/GameplayMigration/PuzzleImport", "*.json").OrderBy(sourcePath => int.Parse(Path.GetFileNameWithoutExtension(sourcePath)))) {
                string puzzlePath = "Assets/Res_Runtime/Config/Puzzles/Puzzle_" + Path.GetFileNameWithoutExtension(source) + ".asset";
                var puzzle = AssetDatabase.LoadAssetAtPath<PuzzleSO>(puzzlePath);
                if (puzzle == null) {
                    puzzle = ScriptableObject.CreateInstance<PuzzleSO>();
                    JsonUtility.FromJsonOverwrite(File.ReadAllText(source), puzzle);
                    AssetDatabase.CreateAsset(puzzle, puzzlePath);
                }
                if (puzzle.id == 1) {
                    config.tutorial = puzzle;
                } else {
                    puzzles.Add(puzzle);
                }
            }
            config.puzzles = puzzles.ToArray();
            // First five sizes from the native BoardSize table candidate, cross-checked against the extracted data.
            // This batch deliberately excludes later adaptive skill progression and map transforms.
            config.campaignSizes = new[] { 4, 5, 6, 6, 8 };
            config.tutorialPlaceIndex = 13;
            config.tutorialTapIndex = 14;
            config.tutorialDragIndices = new[] { 12, 14, 15 };
            config.maxHearts = 3;
            config.hintsPerLevel = 3;
            config.guidesPerLevel = 3;
            config.scoreBase = 576;
            config.scoreStep = 96;
            config.doubleTapSeconds = 0.3f;
            config.dragThreshold = 12;
            config.soundVolume = 0.6f;
            // Original BoardView palette, first eight entries used by the shipped map pools.
            config.regionColors = new[] {
                new Color(0.95098f, 0.60178f, 0.54358f, 1), new Color(0.318388f, 0.764588f, 0.719322f, 1),
                new Color(0.939569f, 0.790835f, 0.373735f, 1), new Color(0.446771f, 0.517904f, 0.844471f, 1),
                new Color(0.432506f, 0.749373f, 0.461606f, 1), new Color(0.897725f, 0.493559f, 0.768392f, 1),
                new Color(0.528175f, 0.783608f, 0.912941f, 1), new Color(0.954784f, 0.667018f, 0.343684f, 1)
            };
            config.patterns = new[] { "Img_Game_PatternPaw", "Img_Game_PatternHeart", "Img_Game_PatternFlower", "Img_Game_PatternSparkle", "Img_Game_PatternSeed", "Img_Game_PatternAcorn", "Img_Game_PatternClover", "Img_Game_PatternDots" }.Select(Sprite).ToArray();
            config.placeClip = AssetDatabase.LoadAssetAtPath<AudioClip>("Assets/Res_Runtime/Audio/Game/place.wav");
            config.markClip = AssetDatabase.LoadAssetAtPath<AudioClip>("Assets/Res_Runtime/Audio/Game/mark.wav");
            config.mistakeClip = AssetDatabase.LoadAssetAtPath<AudioClip>("Assets/Res_Runtime/Audio/Game/crack.wav");
            config.clearClip = AssetDatabase.LoadAssetAtPath<AudioClip>("Assets/Res_Runtime/Audio/Game/clear.wav");
            AssetDatabase.CreateAsset(config, path);
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
            return text;
        }
    }
}
