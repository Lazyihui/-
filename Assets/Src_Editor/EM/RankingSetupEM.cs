using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Hamdoku.Controllers;
using Hamdoku.Main;
using TMPro;
using UnityEditor;
using UnityEditor.AddressableAssets;
using UnityEditor.AddressableAssets.Settings;
using UnityEditor.AddressableAssets.Settings.GroupSchemas;
using UnityEngine;

namespace Hamdoku.Editor {
    public static class RankingSetupEM {
        [MenuItem("Hamdoku/Setup/Configure Ranking")]
        public static void Setup() {
            AssetDatabase.Refresh();
            foreach (string path in Directory.GetFiles("Assets/Res_Runtime/UI/Ranking", "*.png").Concat(Directory.GetFiles("Assets/Res_Runtime/UI/Ranking/new", "*.png"))) {
                var importer = (TextureImporter)AssetImporter.GetAtPath(path);
                importer.textureType = TextureImporterType.Sprite;
                importer.spriteImportMode = SpriteImportMode.Single;
                importer.spritePixelsPerUnit = 100;
                importer.mipmapEnabled = false;
                importer.alphaIsTransparency = true;
                importer.textureCompression = TextureImporterCompression.Uncompressed;
                if (Path.GetFileNameWithoutExtension(path).StartsWith("btn_Ranking_Pill_", StringComparison.Ordinal)) {
                    importer.spriteBorder = new Vector4(128, 100, 128, 100);
                }
                switch (Path.GetFileNameWithoutExtension(path))
                {
                    case "btn_Ranking_Pill_Cream":
                        importer.spriteBorder = new Vector4(162f, 125f, 162f, 123f);
                        break;
                    case "btn_Ranking_Pill_Orange":
                        importer.spriteBorder = new Vector4(189f, 146f, 189f, 144f);
                        break;
                }
                importer.SaveAndReimport();
            }
            var texts = AssetDatabase.FindAssets("t:L10NSO", new[] { "Assets/Res_Runtime/Localization" })
                .Select(guid => AssetDatabase.LoadAssetAtPath<L10NSO>(AssetDatabase.GUIDToAssetPath(guid))).ToArray();
            BakeFonts(texts);
            var config = CreateConfig();
            CreatePreview();
            var font = AssetDatabase.LoadAssetAtPath<TMP_FontAsset>("Assets/Res_Runtime/Font/Chinese SDF.asset");
            string row = "Assets/Res_Runtime/UI/Ranking/Widget_RankingEntry.prefab";
            string panel = "Assets/Res_Runtime/UI/Ranking/Panel_Ranking.prefab";
            string dialog = "Assets/Res_Runtime/UI/Ranking/Panel_RankingDialog.prefab";
            if (AssetDatabase.LoadAssetAtPath<GameObject>(row) == null) {
                var entry = CreateRow("Widget_RankingEntry", null, font);
                PrefabUtility.SaveAsPrefabAsset(entry.gameObject, row);
                UnityEngine.Object.DestroyImmediate(entry.gameObject);
            }
            if (AssetDatabase.LoadAssetAtPath<GameObject>(panel) == null) {
                CreatePanel(panel, row, font, config);
            }
            if (AssetDatabase.LoadAssetAtPath<GameObject>(dialog) == null) {
                CreateDialog(dialog, font);
            }
            Refine(row, panel);
            RegisterAssets(new[] { panel, dialog, "Assets/Res_Runtime/Config/RankingConfig.asset" }
                .Concat(texts.Where(text => text.id.ToString().StartsWith("Ranking_", StringComparison.Ordinal)).Select(text => AssetDatabase.GetAssetPath(text))));
            var home = AssetDatabase.LoadAssetAtPath<GameConfigSO>("Assets/Res_Runtime/Config/GameConfig.asset");
            home.saveVersion = Math.Max(home.saveVersion, 4);
            EditorUtility.SetDirty(home);
            AssetDatabase.SaveAssets();
            Debug.Log("[RankingSetup] Formal prefabs, config, localization, fonts and default registrations saved. Preview fixture is not default-labelled.");
        }
        static RankingConfigSO CreateConfig() {
            string path = "Assets/Res_Runtime/Config/RankingConfig.asset";
            var config = AssetDatabase.LoadAssetAtPath<RankingConfigSO>(path);
            if (config != null) {
                if (config.assetVersion == 0) {
                    BindVisuals(config);
                    EditorUtility.SetDirty(config);
                }
                return config;
            }
            config = ScriptableObject.CreateInstance<RankingConfigSO>();
            BindVisuals(config);
            config.rowColors = new[] { new Color(1, 0.93f, 0.70f), new Color(0.91f, 0.94f, 0.98f), new Color(0.99f, 0.88f, 0.79f) };
            config.myRowColor = new Color(1, 0.90f, 0.64f);
            AssetDatabase.CreateAsset(config, path);
            return config;
        }
        static void BindVisuals(RankingConfigSO config) {
            config.assetVersion = 1;
            config.avatars = new[] { Sprite("Img_Common_HamsterAvatar") };
            config.costumes = new[] { (Sprite)null, Sprite("Img_Ranking_Costume_Pumpkin") };
            config.medals = new[] { Sprite("Img_Ranking_Medal_Gold"), Sprite("Img_Ranking_Medal_Silver"), Sprite("Img_Ranking_Medal_Bronze") };
            config.gifts = new[] { Sprite("Img_Ranking_Gift_Red"), Sprite("Img_Ranking_Gift_Blue"), Sprite("Img_Ranking_Gift_Green") };
        }
        static void CreatePreview() {
            string folder = "Assets/Res_Editor/Ranking";
            Directory.CreateDirectory(folder);
            AssetDatabase.Refresh();
            string path = folder + "/RankingPreview.asset";
            if (AssetDatabase.LoadAssetAtPath<RankingPreviewSO>(path) != null) {
                return;
            }
            var preview = ScriptableObject.CreateInstance<RankingPreviewSO>();
            preview.entries = new[] {
                new RankingEntryModel { playerId = 1, displayName = "PlayerUF4DMV", rank = 1, seeds = 124, costumeId = 1 },
                new RankingEntryModel { playerId = 2, displayName = "PlayerC9Y7CD", rank = 2, seeds = 79 },
                new RankingEntryModel { playerId = 3, displayName = "PlayerJC96NK", rank = 3, seeds = 65 }
            };
            preview.me = new RankingEntryModel { playerId = 49, displayName = "PlayerF0PIB8", rank = 49, seeds = 11 };
            AssetDatabase.CreateAsset(preview, path);
        }
        static void BakeFonts(L10NSO[] texts) {
            foreach (string language in new[] { "Chinese", "English" }) {
                var font = AssetDatabase.LoadAssetAtPath<TMP_FontAsset>("Assets/Res_Runtime/Font/" + language + " SDF.asset");
                string characters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz/: -i" +
                    string.Concat(texts.Select(text => language == "Chinese" ? text.chinese : text.english));
                characters = Regex.Replace(characters, "<[^>]*>|\\{[^}]*\\}", string.Empty).Replace("\n", string.Empty);
                if (!font.HasCharacters(characters)) {
                    var serialized = new SerializedObject(font);
                    string guid = serialized.FindProperty("m_SourceFontFileGUID").stringValue;
                    var source = AssetDatabase.LoadAssetAtPath<Font>(AssetDatabase.GUIDToAssetPath(guid));
                    if (source == null) {
                        throw new InvalidOperationException("Missing ranking font source: " + language);
                    }
                    serialized.FindProperty("m_SourceFontFile").objectReferenceValue = source;
                    serialized.ApplyModifiedPropertiesWithoutUndo();
                    font.atlasPopulationMode = AtlasPopulationMode.Dynamic;
                    try {
                        if (!font.TryAddCharacters(characters, out string missing)) {
                            throw new InvalidOperationException("Missing ranking glyphs: " + missing);
                        }
                    } finally {
                        font.atlasPopulationMode = AtlasPopulationMode.Static;
                    }
                }
                EditorUtility.SetDirty(font);
                foreach (var atlas in font.atlasTextures) {
                    EditorUtility.SetDirty(atlas);
                }
            }
        }
        static void RegisterAssets(IEnumerable<string> paths) {
            var defaultObject = AssetDatabase.LoadAssetAtPath<AddressableAssetSettingsDefaultObject>("Assets/AddressableAssetsData/DefaultObject.asset");
            EditorBuildSettings.AddConfigObject(AddressableAssetSettingsDefaultObject.kDefaultConfigObjectName, defaultObject, true);
            var settings = AddressableAssetSettingsDefaultObject.Settings;
            var group = settings.FindGroup("Ranking");
            if (group == null) {
                group = settings.CreateGroup("Ranking", false, false, true, null, typeof(BundledAssetGroupSchema), typeof(ContentUpdateGroupSchema));
            }
            var schema = group.GetSchema<BundledAssetGroupSchema>();
            schema.BuildPath.SetVariableByName(settings, AddressableAssetSettings.kLocalBuildPath);
            schema.LoadPath.SetVariableByName(settings, AddressableAssetSettings.kLocalLoadPath);
            foreach (string path in paths) {
                string guid = AssetDatabase.AssetPathToGUID(path);
                if (string.IsNullOrEmpty(guid)) {
                    throw new InvalidOperationException("Ranking asset not imported: " + path);
                }
                var entry = settings.CreateOrMoveEntry(guid, group);
                entry.address = path;
                entry.SetLabel(AAConst.LABEL_DEFAULT, true);
            }
            EditorUtility.SetDirty(settings);
        }
        static Widget_RankingEntry CreateRow(string name, Transform parent, TMP_FontAsset font) {
            var root = Rect(name, parent, new Vector2(980, 158), Vector2.zero);
            var entry = root.gameObject.AddComponent<Widget_RankingEntry>();
            entry.background = Image("Background", root, Sprite("bg_Common_Rounded"), new Vector2(980, 158), Vector2.zero);
            entry.medal = Image("Medal", root, Sprite("Img_Ranking_Medal_Gold"), new Vector2(132, 122), new Vector2(-397, 0));
            entry.rankLabel = Label("Rank", root, font, new Vector2(130, 100), new Vector2(-397, 0), 47);
            var frame = Image("Frame", root, Sprite("Img_Common_ProfileFrame"), new Vector2(142, 142), new Vector2(-236, 0));
            entry.avatar = Image("Avatar", frame.transform, Sprite("Img_Common_HamsterAvatar"), new Vector2(112, 106), Vector2.zero);
            entry.costume = Image("Costume", frame.transform, Sprite("Img_Ranking_Costume_Pumpkin"), new Vector2(118, 118), Vector2.zero);
            entry.nameLabel = Label("Name", root, font, new Vector2(310, 100), new Vector2(-7, 0), 33);
            entry.nameLabel.alignment = TextAlignmentOptions.Left;
            var pill = Image("Seeds", root, Sprite("bg_Common_Rounded"), new Vector2(185, 68), new Vector2(255, 0));
            Image("Seed", pill.transform, Sprite("Img_Common_Seed"), new Vector2(37, 55), new Vector2(-60, 0));
            entry.seedsLabel = Label("Value", pill.transform, font, new Vector2(122, 58), new Vector2(22, 0), 35);
            entry.gift = Image("Gift", root, Sprite("Img_Ranking_Gift_Red"), new Vector2(112, 112), new Vector2(416, 0));
            entry.giftButton = HitButton(entry.gift);
            return entry;
        }
        static Widget_RankingEntry CreatePodium(Transform parent, TMP_FontAsset font, Vector2 position) {
            var root = Rect("Winner", parent, new Vector2(280, 460), position);
            var entry = root.gameObject.AddComponent<Widget_RankingEntry>();
            entry.background = Image("Background", root, null, Vector2.one, Vector2.zero);
            entry.background.enabled = false;
            var frame = Image("Frame", root, Sprite("Img_Common_ProfileFrame"), new Vector2(174, 174), new Vector2(0, 145));
            entry.avatar = Image("Avatar", frame.transform, Sprite("Img_Common_HamsterAvatar"), new Vector2(136, 132), Vector2.zero);
            entry.costume = Image("Costume", frame.transform, Sprite("Img_Ranking_Costume_Pumpkin"), new Vector2(147, 147), Vector2.zero);
            entry.medal = Image("Medal", root, Sprite("Img_Ranking_Medal_Gold"), new Vector2(146, 132), new Vector2(0, 22));
            entry.rankLabel = Label("Rank", root, font, new Vector2(120, 80), new Vector2(0, 22), 40);
            entry.nameLabel = Label("Name", root, font, new Vector2(280, 52), new Vector2(0, -65), 29);
            var pill = Image("Seeds", root, Sprite("bg_Common_Rounded"), new Vector2(154, 52), new Vector2(0, -122));
            Image("Seed", pill.transform, Sprite("Img_Common_Seed"), new Vector2(28, 44), new Vector2(-51, 0));
            entry.seedsLabel = Label("Value", pill.transform, font, new Vector2(98, 48), new Vector2(16, 0), 32);
            entry.gift = Image("Gift", root, Sprite("Img_Ranking_Gift_Red"), new Vector2(143, 134), new Vector2(0, -265));
            entry.giftButton = HitButton(entry.gift);
            return entry;
        }
        static void CreatePanel(string path, string rowPath, TMP_FontAsset font, RankingConfigSO config) {
            var root = Rect("Panel_Ranking", null, Vector2.zero, Vector2.zero);
            Stretch(root);
            var panel = root.gameObject.AddComponent<Panel_Ranking>();
            var background = Image("Background", root, Sprite("bg_Common_Game"), Vector2.zero, Vector2.zero);
            Stretch(background.rectTransform);
            background.raycastTarget = true;
            var aspect = background.gameObject.AddComponent<UnityEngine.UI.AspectRatioFitter>();
            aspect.aspectMode = UnityEngine.UI.AspectRatioFitter.AspectMode.EnvelopeParent;
            aspect.aspectRatio = background.sprite.rect.width / background.sprite.rect.height;
            panel.safeRoot = Rect("SafeRoot", root, Vector2.zero, Vector2.zero);
            Stretch(panel.safeRoot);
            panel.contentRoot = Rect("Content", panel.safeRoot, new Vector2(1080, 1920), Vector2.zero);
            var content = panel.contentRoot;
            Image("Ribbon", content, Sprite("Img_Ranking_TitleRibbon"), new Vector2(600, 130), new Vector2(0, 840));
            panel.titleLabel = Label("Title", content, font, new Vector2(400, 92), new Vector2(0, 840), 52);
            panel.titleLabel.color = Color.white;
            panel.titleLabel.text = "排行榜";
            panel.backButton = Button("Back", content, new Vector2(86, 86), new Vector2(-440, 860));
            Image("Icon", panel.backButton.transform, Sprite("Img_Common_Back"), new Vector2(33, 45), Vector2.zero);
            panel.infoButton = Button("Info", content, new Vector2(86, 86), new Vector2(440, 860));
            Label("Icon", panel.infoButton.transform, font, new Vector2(60, 60), Vector2.zero, 47).text = "i";
            var timer = Image("TimePill", content, Sprite("bg_Common_Rounded"), new Vector2(420, 62), new Vector2(0, 746));
            Image("Clock", timer.transform, Sprite("Img_Ranking_Clock"), new Vector2(44, 44), new Vector2(-173, 0));
            panel.timeLabel = Label("Time", timer.transform, font, new Vector2(340, 54), new Vector2(24, 0), 28);
            panel.previewLabel = Label("Preview", content, font, new Vector2(960, 45), new Vector2(0, 688), 25);
            Image("Podium", content, Sprite("Img_Ranking_Podium"), new Vector2(1035, 408), new Vector2(0, 328));
            panel.podium = new[] {
                CreatePodium(content, font, new Vector2(0, 443)),
                CreatePodium(content, font, new Vector2(-319, 338)),
                CreatePodium(content, font, new Vector2(319, 323))
            };
            panel.podium[0].gift.rectTransform.anchoredPosition = new Vector2(0, -278);
            panel.podium[1].gift.rectTransform.anchoredPosition = new Vector2(0, -203);
            panel.podium[2].gift.rectTransform.anchoredPosition = new Vector2(0, -188);
            var card = Image("ListCard", content, Sprite("bg_Common_Rounded"), new Vector2(1034, 720), new Vector2(0, -320));
            card.color = new Color(1, 0.99f, 0.94f);
            var scrollRoot = Rect("ScrollView", card.transform, new Vector2(980, 504), new Vector2(0, 89));
            panel.scroll = scrollRoot.gameObject.AddComponent<UnityEngine.UI.ScrollRect>();
            var viewport = Image("Viewport", scrollRoot, Sprite("bg_Common_Rounded"), Vector2.zero, Vector2.zero);
            Stretch(viewport.rectTransform);
            viewport.raycastTarget = true;
            var mask = viewport.gameObject.AddComponent<UnityEngine.UI.Mask>();
            mask.showMaskGraphic = false;
            panel.listRoot = Rect("Content", viewport.transform, new Vector2(0, 0), Vector2.zero);
            panel.listRoot.anchorMin = new Vector2(0, 1);
            panel.listRoot.anchorMax = Vector2.one;
            panel.listRoot.pivot = new Vector2(0.5f, 1);
            var layout = panel.listRoot.gameObject.AddComponent<UnityEngine.UI.VerticalLayoutGroup>();
            layout.spacing = 14;
            layout.childControlWidth = true;
            layout.childControlHeight = false;
            layout.childForceExpandWidth = false;
            layout.childForceExpandHeight = false;
            var fit = panel.listRoot.gameObject.AddComponent<UnityEngine.UI.ContentSizeFitter>();
            fit.verticalFit = UnityEngine.UI.ContentSizeFitter.FitMode.PreferredSize;
            panel.scroll.viewport = viewport.rectTransform;
            panel.scroll.content = panel.listRoot;
            panel.scroll.horizontal = false;
            panel.scroll.movementType = UnityEngine.UI.ScrollRect.MovementType.Clamped;
            panel.entryPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(rowPath).GetComponent<Widget_RankingEntry>();
            panel.myEntry = CreateRow("MyEntry", card.transform, font);
            ((RectTransform)panel.myEntry.transform).anchoredPosition = new Vector2(0, -267);
            panel.myLabel = Label("MyLabel", card.transform, font, new Vector2(290, 24), new Vector2(-330, -175), 20);
            panel.statusLabel = Label("Status", content, font, new Vector2(1000, 65), new Vector2(0, -735), 29);
            panel.collectButton = Button("Collect", content, new Vector2(550, 125), new Vector2(0, -846), Sprite("btn_Common_Rounded_Yellow"));
            panel.collectLabel = Label("Label", panel.collectButton.transform, font, new Vector2(480, 95), Vector2.zero, 47);
            panel.collectLabel.color = Color.white;
            panel.retryButton = Button("Retry", content, new Vector2(190, 65), new Vector2(380, -846));
            panel.retryLabel = Label("Label", panel.retryButton.transform, font, new Vector2(170, 55), Vector2.zero, 29);
            panel.rewardButton = Button("Reward", content, new Vector2(210, 65), new Vector2(-390, -846));
            panel.rewardLabel = Label("Label", panel.rewardButton.transform, font, new Vector2(195, 56), Vector2.zero, 26);
            PrefabUtility.SaveAsPrefabAsset(root.gameObject, path);
            UnityEngine.Object.DestroyImmediate(root.gameObject);
        }
        static void CreateDialog(string path, TMP_FontAsset font) {
            var root = Rect("Panel_RankingDialog", null, Vector2.zero, Vector2.zero);
            Stretch(root);
            var panel = root.gameObject.AddComponent<Panel_RankingDialog>();
            var dim = Image("Dim", root, null, Vector2.zero, Vector2.zero);
            Stretch(dim.rectTransform);
            dim.color = new Color(0.25f, 0.16f, 0.08f, 0.65f);
            dim.raycastTarget = true;
            panel.safeRoot = Rect("SafeRoot", root, Vector2.zero, Vector2.zero);
            Stretch(panel.safeRoot);
            panel.contentRoot = Rect("Content", panel.safeRoot, new Vector2(1080, 1920), Vector2.zero);
            var card = Image("Card", panel.contentRoot, Sprite("bg_Common_Popup"), new Vector2(930, 1170), Vector2.zero);
            panel.titleLabel = Label("Title", card.transform, font, new Vector2(700, 105), new Vector2(0, 445), 55);
            panel.bodyLabel = Label("Body", card.transform, font, new Vector2(790, 650), new Vector2(0, 40), 39);
            panel.bodyLabel.alignment = TextAlignmentOptions.TopLeft;
            panel.noticeLabel = Label("Notice", card.transform, font, new Vector2(790, 110), new Vector2(0, -355), 29);
            panel.closeButton = Button("Close", card.transform, new Vector2(90, 90), new Vector2(367, 486));
            Image("Icon", panel.closeButton.transform, Sprite("Img_Common_Cross"), new Vector2(42, 42), Vector2.zero);
            panel.claimButton = Button("Claim", card.transform, new Vector2(420, 105), new Vector2(0, -470), Sprite("btn_Common_Rounded_Yellow"));
            panel.claimLabel = Label("Label", panel.claimButton.transform, font, new Vector2(380, 90), Vector2.zero, 43);
            PrefabUtility.SaveAsPrefabAsset(root.gameObject, path);
            UnityEngine.Object.DestroyImmediate(root.gameObject);
        }
        static void Refine(string rowPath, string panelPath) {
            var rowRoot = PrefabUtility.LoadPrefabContents(rowPath);
            try {
                var row = rowRoot.GetComponent<Widget_RankingEntry>();
                BindEntryVisuals(row);
                row.background.pixelsPerUnitMultiplier = 0.6f;
                PrefabUtility.SaveAsPrefabAsset(rowRoot, rowPath);
            } finally {
                PrefabUtility.UnloadPrefabContents(rowRoot);
            }
            var root = PrefabUtility.LoadPrefabContents(panelPath);
            try {
                var panel = root.GetComponent<Panel_Ranking>();
                panel.contentRoot.Find("Podium").GetComponent<UnityEngine.UI.Image>().sprite = Sprite("Img_Ranking_Podium");
                panel.contentRoot.Find("Ribbon").GetComponent<UnityEngine.UI.Image>().sprite = Sprite("Img_Ranking_TitleRibbon");
                panel.timeLabel.transform.parent.Find("Clock").GetComponent<UnityEngine.UI.Image>().sprite = Sprite("Img_Ranking_Clock");
                var layout = panel.listRoot.GetComponent<UnityEngine.UI.VerticalLayoutGroup>();
                layout.childForceExpandWidth = true;
                panel.podium[0].gift.rectTransform.anchoredPosition = new Vector2(0, -278);
                panel.podium[1].gift.rectTransform.anchoredPosition = new Vector2(0, -203);
                panel.podium[2].gift.rectTransform.anchoredPosition = new Vector2(0, -188);
                foreach (var winner in panel.podium) {
                    BindEntryVisuals(winner);
                    winner.rankLabel.fontSize = 65;
                    winner.rankLabel.fontSizeMin = 65;
                    winner.rankLabel.fontSizeMax = 65;
                }
                var backImage = (UnityEngine.UI.Image)panel.backButton.targetGraphic;
                backImage.sprite = Sprite("Img_Common_Back");
                backImage.type = UnityEngine.UI.Image.Type.Simple;
                backImage.preserveAspect = true;
                panel.backButton.transform.Find("Icon").gameObject.SetActive(false);
                var infoImage = (UnityEngine.UI.Image)panel.infoButton.targetGraphic;
                infoImage.sprite = Sprite("bg_Ranking_Circle");
                infoImage.type = UnityEngine.UI.Image.Type.Simple;
                infoImage.preserveAspect = true;
                infoImage.color = new Color(1, 0.98f, 0.93f);
                var timer = panel.timeLabel.transform.parent.GetComponent<UnityEngine.UI.Image>();
                Pill(timer, "btn_Ranking_Pill_Cream");
                Pill((UnityEngine.UI.Image)panel.collectButton.targetGraphic, "btn_Ranking_Pill_Orange");
                Pill((UnityEngine.UI.Image)panel.retryButton.targetGraphic, "btn_Ranking_Pill_Cream");
                Pill((UnityEngine.UI.Image)panel.rewardButton.targetGraphic, "btn_Ranking_Pill_Cream");
                var rewardRect = (RectTransform)panel.rewardButton.transform;
                rewardRect.anchoredPosition = new Vector2(-390, -846);
                rewardRect.sizeDelta = new Vector2(210, 65);
                panel.rewardLabel.rectTransform.sizeDelta = new Vector2(195, 56);
                panel.rewardLabel.fontSizeMax = 26;
                panel.myLabel.rectTransform.sizeDelta = new Vector2(290, 24);
                panel.myLabel.rectTransform.anchoredPosition = new Vector2(-330, -175);
                panel.myLabel.fontSizeMax = 20;
                panel.myEntry.background.pixelsPerUnitMultiplier = 0.6f;
                BindEntryVisuals(panel.myEntry);
                PrefabUtility.SaveAsPrefabAsset(root, panelPath);
            } finally {
                PrefabUtility.UnloadPrefabContents(root);
            }
        }
        static void Pill(UnityEngine.UI.Image image, string name) {
            image.sprite = Sprite(name);
            image.type = UnityEngine.UI.Image.Type.Sliced;
            image.preserveAspect = false;
            image.pixelsPerUnitMultiplier = image.sprite.rect.height / image.rectTransform.sizeDelta.y;
        }
        static void BindEntryVisuals(Widget_RankingEntry entry) {
            entry.avatar.sprite = Sprite("Img_Common_HamsterAvatar");
            entry.avatar.transform.parent.GetComponent<UnityEngine.UI.Image>().sprite = Sprite("Img_Common_ProfileFrame");
            entry.costume.sprite = Sprite("Img_Ranking_Costume_Pumpkin");
            entry.medal.sprite = Sprite("Img_Ranking_Medal_Gold");
            entry.gift.sprite = Sprite("Img_Ranking_Gift_Red");
        }
        static Sprite Sprite(string name) {
            switch (name)
            {
                case "btn_Common_Rounded_Yellow":
                    return AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Res_Runtime/UI/Game/new/btn_Common_Rounded_Yellow.png") ?? throw new InvalidOperationException("Missing installed button: Assets/Res_Runtime/UI/Game/new/btn_Common_Rounded_Yellow.png");
                case "btn_Ranking_Pill_Cream":
                    return AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Res_Runtime/UI/Ranking/new/btn_Ranking_Pill_Cream.png") ?? throw new InvalidOperationException("Missing installed button: Assets/Res_Runtime/UI/Ranking/new/btn_Ranking_Pill_Cream.png");
                case "btn_Ranking_Pill_Orange":
                    return AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Res_Runtime/UI/Ranking/new/btn_Ranking_Pill_Orange.png") ?? throw new InvalidOperationException("Missing installed button: Assets/Res_Runtime/UI/Ranking/new/btn_Ranking_Pill_Orange.png");
            }
            string folder;
            switch (name) {
                case "bg_Common_Game": case "bg_Common_Rounded": case "btn_Common_Rounded_Yellow": case "bg_Common_Popup": case "Img_Common_Back": case "Img_Common_Seed": case "Img_Common_Cross":
                    folder = "Game"; break;
                case "Img_Common_HamsterAvatar": case "Img_Common_ProfileFrame":
                    folder = "Home"; break;
                default: folder = "Ranking"; break;
            }
            var sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Res_Runtime/UI/" + folder + "/" + name + ".png");
            if (sprite == null) {
                throw new InvalidOperationException("Missing ranking sprite " + name);
            }
            return sprite;
        }
        static RectTransform Rect(string name, Transform parent, Vector2 size, Vector2 position) {
            var rect = new GameObject(name, typeof(RectTransform)).GetComponent<RectTransform>();
            rect.gameObject.layer = LayerMask.NameToLayer("UI");
            rect.SetParent(parent, false);
            rect.anchorMin = Vector2.one * 0.5f;
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
                image.pixelsPerUnitMultiplier = 2;
            }
            if (sprite != null && sprite.border != Vector4.zero &&
                AssetDatabase.GetAssetPath(sprite).Contains("/new/") &&
                (sprite.name == "btn_Ranking_Pill_Cream" || sprite.name == "btn_Ranking_Pill_Orange" || sprite.name == "btn_Common_Rounded_Yellow"))
            {
                image.type = UnityEngine.UI.Image.Type.Sliced;
                image.preserveAspect = false;
                image.pixelsPerUnitMultiplier = sprite.rect.height / size.y;
            }
            return image;
        }
        static UnityEngine.UI.Button HitButton(UnityEngine.UI.Image image) {
            image.raycastTarget = true;
            var button = image.gameObject.AddComponent<UnityEngine.UI.Button>();
            button.targetGraphic = image;
            return button;
        }
        static UnityEngine.UI.Button Button(string name, Transform parent, Vector2 size, Vector2 position, Sprite sprite = null) {
            return HitButton(Image(name, parent, sprite == null ? Sprite("bg_Common_Rounded") : sprite, size, position));
        }
        static TMP_Text Label(string name, Transform parent, TMP_FontAsset font, Vector2 size, Vector2 position, float fontSize) {
            var text = Rect(name, parent, size, position).gameObject.AddComponent<TextMeshProUGUI>();
            text.font = font;
            text.fontSize = fontSize;
            text.fontSizeMin = fontSize * 0.65f;
            text.fontSizeMax = fontSize;
            text.enableAutoSizing = true;
            text.alignment = TextAlignmentOptions.Center;
            text.color = new Color(0.41f, 0.29f, 0.18f);
            text.raycastTarget = false;
            text.richText = false;
            var buttonImage = parent.GetComponent<UnityEngine.UI.Image>();
            if (buttonImage != null && buttonImage.sprite != null &&
                AssetDatabase.GetAssetPath(buttonImage.sprite).Contains("/new/") &&
                (buttonImage.sprite.name == "btn_Ranking_Pill_Cream" || buttonImage.sprite.name == "btn_Ranking_Pill_Orange" || buttonImage.sprite.name == "btn_Common_Rounded_Yellow"))
            {
                text.color = new Color(0.32f, 0.22f, 0.12f);
            }
            return text;
        }
        [MenuItem("Hamdoku/Ranking Preview/Normal")]
        static void PreviewNormal() {
            Preview(RankingPreviewType.Normal);
        }
        [MenuItem("Hamdoku/Ranking Preview/Loading")]
        static void PreviewLoading() {
            Preview(RankingPreviewType.Loading);
        }
        [MenuItem("Hamdoku/Ranking Preview/Empty")]
        static void PreviewEmpty() {
            Preview(RankingPreviewType.Empty);
        }
        [MenuItem("Hamdoku/Ranking Preview/Failed")]
        static void PreviewFailed() {
            Preview(RankingPreviewType.Failed);
        }
        [MenuItem("Hamdoku/Ranking Preview/Not Participating")]
        static void PreviewNotParticipating() {
            Preview(RankingPreviewType.NotParticipating);
        }
        [MenuItem("Hamdoku/Ranking Preview/Ended")]
        static void PreviewEnded() {
            Preview(RankingPreviewType.Ended);
        }
        [MenuItem("Hamdoku/Ranking Preview/Reward Available")]
        static void PreviewReward() {
            Preview(RankingPreviewType.RewardAvailable);
        }
        [MenuItem("Hamdoku/Ranking Preview/Claimed")]
        static void PreviewClaimed() {
            Preview(RankingPreviewType.Claimed);
        }
        static void Preview(RankingPreviewType scenario) {
            var main = UnityEngine.Object.FindAnyObjectByType<ClientMain>();
            if (!EditorApplication.isPlaying || main == null || main.GetContext() == null || main.GetContext().state_Loading.status != LoadingStatus.Ready) {
                throw new InvalidOperationException("Enter Play Mode in Scene_Main and wait for Home before previewing rankings.");
            }
            var fixture = AssetDatabase.LoadAssetAtPath<RankingPreviewSO>("Assets/Res_Editor/Ranking/RankingPreview.asset");
            RankingController.OpenPreview(main.GetContext(), fixture, scenario);
        }
    }
}
