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
    public static class ProfileSetupEM {
        [MenuItem("Hamdoku/Setup/Configure Profile")]
        public static void Setup() {
            ImportSprites();
            var config = CreateConfig();
            BakeFonts();
            var font = AssetDatabase.LoadAssetAtPath<TMP_FontAsset>("Assets/Res_Runtime/Font/Chinese SDF.asset");
            string path = "Assets/Res_Runtime/UI/Profile/Panel_Profile.prefab";
            if (AssetDatabase.LoadAssetAtPath<GameObject>(path) == null) {
                CreatePanel(path, font, config);
            }
            RefinePanel(path, config);
            BindHome();
            var home = AssetDatabase.LoadAssetAtPath<HomeConfigSO>("Assets/Res_Runtime/Config/HomeConfig.asset");
            home.saveVersion = 5;
            EditorUtility.SetDirty(home);
            var settings = AddressableAssetSettingsDefaultObject.Settings;
            foreach (string asset in new[] { path, "Assets/Res_Runtime/Config/ProfileConfig.asset" }.Concat(
                AssetDatabase.FindAssets("t:L10NSO", new[] { "Assets/Res_Runtime/Localization" }).Select(AssetDatabase.GUIDToAssetPath).Where(p => Path.GetFileName(p).StartsWith("Profile_")))) {
                var entry = settings.CreateOrMoveEntry(AssetDatabase.AssetPathToGUID(asset), settings.DefaultGroup);
                entry.SetLabel(AAConst.LABEL_DEFAULT, true, true);
            }
            EditorUtility.SetDirty(settings);
            AssetDatabase.SaveAssets();
            ProfileCompletionEM.Setup();
            Debug.Log("[ProfileSetup] Saved production profile prefab, config, localization, fonts and default registrations.");
        }

        static void ImportSprites() {
            foreach (string path in Directory.GetFiles("Assets/Res_Runtime/UI/Profile", "*.png")) {
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
                case "club_card_basic": return new Vector4(40.0f, 40.0f, 40.0f, 40.0f);
                case "profile_tab": return new Vector4(28.0f, 6.0f, 28.0f, 28.0f);
                case "profile_tab_off": return new Vector4(28.0f, 6.0f, 28.0f, 28.0f);
                default: return Vector4.zero;
            }
        }

        static ProfileConfigSO CreateConfig() {
            string path = "Assets/Res_Runtime/Config/ProfileConfig.asset";
            var config = AssetDatabase.LoadAssetAtPath<ProfileConfigSO>(path);
            if (config != null) {
                config.hiddenAvatarId = 6;
                config.noticeSeconds = 3;
                EditorUtility.SetDirty(config);
                return config;
            }
            config = ScriptableObject.CreateInstance<ProfileConfigSO>();
            config.avatars = new Sprite[] { Sprite("hamster_idle_02"), Sprite("hamster_idle_01"), Sprite("hamster_idle_07"), Sprite("hamster_idle_08"), Sprite("hamster_appear_01"), Sprite("hamster_wrong_01"), Sprite("icon_hamster"), Sprite("profile_avatar_7"), Sprite("profile_avatar_8"), Sprite("profile_avatar_9"), Sprite("profile_avatar_10"), Sprite("profile_avatar_11"), Sprite("profile_avatar_12"), Sprite("profile_avatar_13"), Sprite("profile_avatar_14"), Sprite("profile_avatar_15"), Sprite("profile_avatar_16"), Sprite("hamster_pearl_idle_02"), Sprite("hamster_pearl_idle_01"), Sprite("hamster_pearl_idle_07"), Sprite("hamster_pearl_idle_08"), Sprite("hamster_pearl_appear_01"), Sprite("hamster_pearl_wrong_01"), Sprite("hamster_pearl_club_01"), Sprite("hamster_pearl_club_02"), Sprite("hamster_pearl_club_03"), Sprite("hamster_pearl_club_04"), Sprite("hamster_pearl_club_05"), Sprite("hamster_pearl_club_06") };
            config.frames = new Sprite[] { Sprite("profile_frame_0"), Sprite("profile_frame_1"), Sprite("profile_frame_2"), Sprite("profile_frame_3"), Sprite("profile_frame_4"), Sprite("profile_frame_5"), Sprite("profile_frame_6"), Sprite("profile_frame_7"), null, null, Sprite("profile_frame_10"), Sprite("profile_frame_11"), Sprite("profile_frame_12"), Sprite("profile_frame_13"), Sprite("profile_frame_14"), Sprite("profile_frame_15"), Sprite("profile_frame_16"), Sprite("profile_frame_17"), Sprite("profile_frame_18"), Sprite("profile_frame_19"), Sprite("profile_frame_20") };
            config.costumes = new Sprite[] { Sprite("costume_pumpkin"), Sprite("costume_202610_nightcap"), Sprite("costume_202610_mummy"), Sprite("costume_202611_maplesunglasses"), Sprite("costume_202611_baguettehood"), Sprite("costume_202611_chefhat") };
            config.avatarColors = new Color[] { new Color(1.0f,0.93f,0.78f,1.0f), new Color(0.83f,0.91f,1.0f,1.0f), new Color(0.85f,0.95f,0.83f,1.0f), new Color(1.0f,0.87f,0.86f,1.0f), new Color(0.93f,0.87f,1.0f,1.0f), new Color(0.87f,0.95f,0.95f,1.0f), new Color(1.0f,0.9f,0.95f,1.0f) };
            config.avatarUnlockClears = new int[] { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 };
            config.frameUnlockClears = new int[] { 0,0,0,0,0,0,0,-1,-1,-1,0,0,0,0,0,0,0,0,0,0,0 };
            config.frameRankWins = new int[] { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,15,30,50,0 };
            config.mottos = new UINameType[] { UINameType.Profile_Motto1, UINameType.Profile_Motto2, UINameType.Profile_Motto3, UINameType.Profile_Motto4, UINameType.Profile_Motto5, UINameType.Profile_Motto6, UINameType.Profile_Motto7, UINameType.Profile_Motto8, UINameType.Profile_Motto9, UINameType.Profile_Motto10, UINameType.Profile_Motto11, UINameType.Profile_Motto12, UINameType.Profile_Motto13, UINameType.Profile_Motto14, UINameType.Profile_Motto15, UINameType.Profile_Motto16, UINameType.Profile_Motto17, UINameType.Profile_Motto18, UINameType.Profile_Motto19, UINameType.Profile_Motto20, UINameType.Profile_Motto21, UINameType.Profile_Motto22, UINameType.Profile_Motto23, UINameType.Profile_Motto24, UINameType.Profile_Motto25, UINameType.Profile_Motto26, UINameType.Profile_Motto27, UINameType.Profile_Motto28, UINameType.Profile_Motto29, UINameType.Profile_Motto30, UINameType.Profile_Motto31, UINameType.Profile_Motto32, UINameType.Profile_Motto33, UINameType.Profile_Motto34, UINameType.Profile_Motto35, UINameType.Profile_Motto36, UINameType.Profile_Motto37, UINameType.Profile_Motto38, UINameType.Profile_Motto39, UINameType.Profile_Motto40, UINameType.Profile_Motto41, UINameType.Profile_Motto42, UINameType.Profile_Motto43, UINameType.Profile_Motto44, UINameType.Profile_Motto45, UINameType.Profile_Motto46, UINameType.Profile_Motto47, UINameType.Profile_Motto48, UINameType.Profile_Motto49, UINameType.Profile_Motto50, UINameType.Profile_Motto51, UINameType.Profile_Motto52, UINameType.Profile_Motto53, UINameType.Profile_Motto54, UINameType.Profile_Motto55, UINameType.Profile_Motto56, UINameType.Profile_Motto57, UINameType.Profile_Motto58, UINameType.Profile_Motto59, UINameType.Profile_Motto60, UINameType.Profile_Motto61, UINameType.Profile_Motto62, UINameType.Profile_Motto63, UINameType.Profile_Motto64, UINameType.Profile_Motto65, UINameType.Profile_Motto66, UINameType.Profile_Motto67, UINameType.Profile_Motto68, UINameType.Profile_Motto69, UINameType.Profile_Motto70, UINameType.Profile_Motto71, UINameType.Profile_Motto72, UINameType.Profile_Motto73, UINameType.Profile_Motto74, UINameType.Profile_Motto75, UINameType.Profile_Motto76, UINameType.Profile_Motto77, UINameType.Profile_Motto78, UINameType.Profile_Motto79, UINameType.Profile_Motto80 };
            config.costumeNames = new UINameType[] { UINameType.Profile_Costume0, UINameType.Profile_Costume1, UINameType.Profile_Costume2, UINameType.Profile_Costume3, UINameType.Profile_Costume4, UINameType.Profile_Costume5 };
            config.clubAvatarStart = 17;
            config.hiddenAvatarId = 6;
            config.noticeSeconds = 3;
            config.clubFrameId = 20;
            config.nameMaxChars = 12;
            config.selectedColor = Color.white;
            config.idleColor = new Color(1, 1, 1, .45f);
            config.lockedAlpha = .3f;
            AssetDatabase.CreateAsset(config, path);
            return config;
        }

        internal static void BakeFonts() {
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

        static void CreatePanel(string path, TMP_FontAsset font, ProfileConfigSO config) {
            var root = Rect("Panel_Profile", null, Vector2.zero, Vector2.zero);
            Stretch(root);
            var panel = root.gameObject.AddComponent<Panel_Profile>();
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
            panel.titleLabel = Label("Title", content, font, new Vector2(780, 100), new Vector2(0, 884), 64);
            panel.titleLabel.text = "个人资料设置";
            panel.backButton = Button("Back", content, Sprite("bg_Game_Circle"), Vector2.one * 90, new Vector2(-465, 887));
            Image("Icon", panel.backButton.transform, Sprite("Img_Common_Back"), Vector2.one * 56, Vector2.zero);
            panel.infoButton = Button("Info", content, Sprite("bg_Game_Circle"), Vector2.one * 90, new Vector2(465, 887));
            Label("Icon", panel.infoButton.transform, font, Vector2.one * 70, Vector2.zero, 66).text = "i";
            var card = Image("MemberCard", content, Sprite("club_card_basic"), new Vector2(980, 850), new Vector2(0, 380));Rectangular(card);
            Image("Watermark", card.transform, Sprite("club_card_mark_basic"), Vector2.one * 270, new Vector2(420, 90)).color = new Color(1, 1, 1, .1f);
            panel.brandLabel = Label("Brand", content, font, new Vector2(760, 70), new Vector2(0, 740), 52);
            panel.gradeLabel = Label("Grade", content, font, new Vector2(600, 44), new Vector2(0, 687), 28);
            panel.gradeLabel.color = new Color(.5f, .55f, .65f);
            panel.avatarBackground = Image("AvatarBackground", content, Sprite("bg_Common_Rounded"), Vector2.one * 224, new Vector2(-325, 520));
            panel.avatar = Image("Avatar", panel.avatarBackground.transform, config.avatars[0], Vector2.one * 200, Vector2.zero);
            panel.frame = Image("Frame", content, config.frames[0], Vector2.one * 250, new Vector2(-325, 520));
            panel.mottoButton = Button("Motto", content, Sprite("bg_Common_Rounded"), new Vector2(615, 88), new Vector2(145, 606));
            panel.mottoButton.GetComponent<UnityEngine.UI.Image>().color = new Color(1, .95f, .85f);
            panel.mottoLabel = Label("Label", panel.mottoButton.transform, font, new Vector2(555, 75), Vector2.zero, 33);
            panel.mottoLabel.alignment = TextAlignmentOptions.MidlineLeft;
            panel.nameLabel = Label("Name", content, font, new Vector2(560, 78), new Vector2(110, 518), 50);
            panel.nameLabel.alignment = TextAlignmentOptions.MidlineLeft;
            panel.nameLabel.fontStyle = FontStyles.Bold;
            panel.editButton = Button("Edit", content, Sprite("bg_Common_Rounded"), Vector2.one * 65, new Vector2(420, 518));
            panel.editButton.GetComponent<UnityEngine.UI.Image>().color = new Color(1, .95f, .85f);
            Image("Icon", panel.editButton.transform, Sprite("icon_edit"), Vector2.one * 40, Vector2.zero);
            panel.infoLabel = Label("LevelStart", content, font, new Vector2(615, 65), new Vector2(140, 445), 30);
            panel.infoLabel.alignment = TextAlignmentOptions.MidlineLeft;
            panel.infoLabel.color = new Color(.55f, .46f, .36f);
            panel.statLabels = new TMP_Text[6];
            panel.statValues = new TMP_Text[6];
            string[] icons = { "club_ico_streak", "club_ico_days", "club_ico_puzzle", "club_ico_seed", "club_ico_first", "club_ico_crown" };
            for (int i = 0; i < 6; i++) {
                var tile = Image("Stat" + i, content, Sprite("bg_Common_Rounded"), new Vector2(292, 116), new Vector2(-310 + i % 3 * 310, 303 - i / 3 * 133));
                tile.color = new Color(1, .99f, .97f);
                Image("Icon", tile.transform, Sprite(icons[i]), Vector2.one * 33, new Vector2(-112, 26));
                panel.statLabels[i] = Label("Label", tile.transform, font, new Vector2(220, 44), new Vector2(20, 27), 31);
                panel.statLabels[i].alignment = TextAlignmentOptions.MidlineLeft;
                panel.statLabels[i].color = new Color(.55f, .46f, .36f);
                panel.statValues[i] = Label("Value", tile.transform, font, new Vector2(260, 52), new Vector2(0, -25), 40);
                panel.statValues[i].alignment = TextAlignmentOptions.MidlineLeft;
            }
            for (int i = 0; i < 47; i++) {
                var dash = Image("Dash" + i, content, Sprite("bg_Common_Rounded"), new Vector2(10, 3), new Vector2(-450 + i * 19, 82));
                dash.color = new Color(.86f, .8f, .72f, .63f);
            }
            Image("UidIcon", content, Sprite("club_ico_uid"), Vector2.one * 30, new Vector2(-435, 22));
            panel.uidLabel = Label("Uid", content, font, new Vector2(410, 52), new Vector2(-200, 22), 26);
            panel.uidLabel.alignment = TextAlignmentOptions.MidlineLeft;
            panel.uidLabel.color = new Color(.55f, .46f, .36f);
            panel.copyButton = Button("Copy", content, Sprite("bg_Common_Rounded"), Vector2.one * 58, new Vector2(70, 22));
            Image("Icon", panel.copyButton.transform, Sprite("club_ico_copy"), Vector2.one * 35, Vector2.zero);
            panel.memberButton = Button("Gold", content, Sprite("bg_Common_Rounded"), new Vector2(330, 95), new Vector2(305, 22));
            panel.memberButton.GetComponent<UnityEngine.UI.Image>().color = new Color(.91f, .875f, .816f);
            Image("Lock", panel.memberButton.transform, Sprite("club_ico_lock"), Vector2.one * 36, new Vector2(-120, 0));
            panel.memberLabel = Label("Label", panel.memberButton.transform, font, new Vector2(255, 75), new Vector2(20, 0), 35);
            panel.memberLabel.color = new Color(.545f, .478f, .408f);
            panel.tabButtons = new UnityEngine.UI.Button[3];
            panel.tabLabels = new TMP_Text[3];
            panel.grids = new GameObject[3];
            panel.scrolls = new UnityEngine.UI.ScrollRect[3];
            var items = new List<Widget_ProfileItem>();
            for (int i = 0; i < 3; i++) {
                panel.tabButtons[i] = Button("Tab" + i, content, Sprite("profile_tab"), new Vector2(302, 130), new Vector2(-320 + 320 * i, -159));
                panel.tabLabels[i] = Label("Label", panel.tabButtons[i].transform, font, new Vector2(270, 100), new Vector2(0, 10), 48);
                // Keep the frame viewport above the next row's protruding crowns.
                float gridHeight = i == 1 ? 722 : 730;
                var scroll = Scroll("Grid" + i, content, new Vector2(980, gridHeight), new Vector2(0, -200 - gridHeight * .5f));
                panel.scrolls[i] = scroll;
                panel.grids[i] = scroll.gameObject;
                var grid = scroll.content.gameObject.AddComponent<UnityEngine.UI.GridLayoutGroup>();
                grid.cellSize = new Vector2(220, 220);
                grid.spacing = new Vector2(18, 18);
                grid.padding = new RectOffset(23, 23, 23, 23);
                grid.constraint = UnityEngine.UI.GridLayoutGroup.Constraint.FixedColumnCount;
                grid.constraintCount = 4;
                var fitter = scroll.content.gameObject.AddComponent<UnityEngine.UI.ContentSizeFitter>();
                fitter.verticalFit = UnityEngine.UI.ContentSizeFitter.FitMode.PreferredSize;
                int count = i == 0 ? config.avatars.Length : i == 1 ? config.frames.Length : config.costumes.Length;
                for (int id = i == 2 ? -1 : 0; id < count; id++) {
                    if (i == 1 && config.frames[id] == null) {
                        continue;
                    }
                    items.Add(CreateItem(scroll.content, font, config, (ProfileTabType)(i + 1), id));
                }
            }
            panel.items = items.ToArray();
            panel.noticeLabel = Label("Notice", content, font, new Vector2(850, 170), new Vector2(0, -740), 34);
            var noticeBg = Image("Background", panel.noticeLabel.transform, Sprite("bg_Common_Rounded"), new Vector2(930, 190), Vector2.zero);
            noticeBg.color = new Color(1, .97f, .87f, .98f);
            noticeBg.transform.SetAsFirstSibling();
            panel.noticeLabel.gameObject.SetActive(false);
            CreateDialog(panel, font, config);
            PrefabUtility.SaveAsPrefabAsset(root.gameObject, path);
            UnityEngine.Object.DestroyImmediate(root.gameObject);
        }

        static Widget_ProfileItem CreateItem(Transform parent, TMP_FontAsset font, ProfileConfigSO config, ProfileTabType tab, int id) {
            var rect = Rect(tab + "_" + id, parent, Vector2.one * 220, Vector2.zero);
            var item = rect.gameObject.AddComponent<Widget_ProfileItem>();
            item.itemId = id;
            item.tab = tab;
            item.background = rect.gameObject.AddComponent<UnityEngine.UI.Image>();
            item.background.sprite = Sprite("bg_Common_Rounded");
            item.background.type = UnityEngine.UI.Image.Type.Sliced;
            item.background.pixelsPerUnitMultiplier = 1;
            item.background.color = tab == ProfileTabType.Avatar ? config.avatarColors[id % config.avatarColors.Length] : new Color(1, .97f, .91f);
            item.button = Hit(item.background);
            item.avatar = Image("Avatar", rect, config.avatars[0], Vector2.one * 165, Vector2.zero);
            item.avatar.gameObject.SetActive(tab == ProfileTabType.Frame);
            item.art = Image("Art", rect, tab == ProfileTabType.Avatar ? config.avatars[id] : tab == ProfileTabType.Frame ? config.frames[id] : id < 0 ? null : config.costumes[id],
                Vector2.one * (tab == ProfileTabType.Frame ? 204 : 180), Vector2.zero);
            item.art.gameObject.SetActive(tab != ProfileTabType.Costume || id >= 0);
            item.label = Label("Label", rect, font, new Vector2(200, 45), new Vector2(0, id < 0 ? 0 : -83), 25);
            item.label.gameObject.SetActive(tab == ProfileTabType.Costume);
            if (tab == ProfileTabType.Costume && id >= 0) {
                item.art.rectTransform.sizeDelta = Vector2.one * 160;
                item.art.rectTransform.anchoredPosition = new Vector2(0, 15);
            }
            item.selection = Image("Selection", rect, Sprite("bg_Common_Rounded"), Vector2.one * 228, Vector2.zero);
            item.selection.type = UnityEngine.UI.Image.Type.Sliced;
            item.selection.fillCenter = false;
            item.selection.pixelsPerUnitMultiplier = 1.6f;
            item.selection.color = new Color(1, .56f, .08f);
            var check = Image("Check", rect, Sprite("bg_Game_Circle"), Vector2.one * 52, new Vector2(100, -100));
            check.color = new Color(1, .56f, .08f);
            Image("Tick", check.transform, Sprite("Img_Streak_Check_White"), Vector2.one * 34, Vector2.zero);
            item.check = check.gameObject;
            item.locked = Image("Lock", rect, Sprite("club_ico_lock"), Vector2.one * 50, new Vector2(75, -70)).gameObject;
            return item;
        }

        static void CreateDialog(Panel_Profile panel, TMP_FontAsset font, ProfileConfigSO config) {
            var overlay = Image("Dialog", panel.contentRoot, null, new Vector2(1080, 1920), Vector2.zero);
            overlay.color = new Color(.23f, .17f, .12f, .5f);
            overlay.raycastTarget = true;
            panel.dialogRoot = overlay.gameObject;
            var box = Image("Box", overlay.transform, Sprite("bg_Common_Rounded"), new Vector2(930, 1200), Vector2.zero);
            box.color = new Color(1, .98f, .94f);
            panel.dialogTitle = Label("Title", box.transform, font, new Vector2(850, 100), new Vector2(0, 505), 54);
            panel.nameRoot = Rect("NameEditor", box.transform, new Vector2(850, 760), new Vector2(0, 30)).gameObject;
            panel.nameHint = Label("Hint", panel.nameRoot.transform, font, new Vector2(800, 210), new Vector2(0, 180), 36);
            var inputBg = Image("Input", panel.nameRoot.transform, Sprite("bg_Common_Rounded"), new Vector2(800, 120), new Vector2(0, 0));
            inputBg.color = new Color(1, .93f, .78f);
            inputBg.raycastTarget = true;
            panel.nameInput = inputBg.gameObject.AddComponent<TMP_InputField>();
            var textArea = Rect("TextArea", inputBg.transform, new Vector2(740, 110), Vector2.zero);
            textArea.gameObject.AddComponent<UnityEngine.UI.RectMask2D>();
            var inputText = Label("Text", textArea, font, new Vector2(740, 110), Vector2.zero, 46);
            inputText.alignment = TextAlignmentOptions.MidlineLeft;
            panel.nameInput.textViewport = textArea;
            panel.nameInput.textComponent = (TextMeshProUGUI)inputText;
            panel.nameInput.targetGraphic = inputBg;
            panel.nameInput.richText = false;
            panel.nameInput.lineType = TMP_InputField.LineType.SingleLine;
            panel.nameInput.characterLimit = config.nameMaxChars;
            panel.nameInput.fontAsset = font;
            var mottoScroll = Scroll("Mottos", box.transform, new Vector2(850, 760), new Vector2(0, 25));
            panel.mottoRoot = mottoScroll.gameObject;
            var layout = mottoScroll.content.gameObject.AddComponent<UnityEngine.UI.VerticalLayoutGroup>();
            layout.childControlWidth = true;
            layout.childControlHeight = true;
            layout.childForceExpandHeight = false;
            layout.spacing = 10;
            layout.padding = new RectOffset(15, 15, 15, 15);
            var fitter = mottoScroll.content.gameObject.AddComponent<UnityEngine.UI.ContentSizeFitter>();
            fitter.verticalFit = UnityEngine.UI.ContentSizeFitter.FitMode.PreferredSize;
            panel.mottoButtons = new UnityEngine.UI.Button[config.mottos.Length + 1];
            panel.mottoLabels = new TMP_Text[config.mottos.Length + 1];
            for (int i = 0; i < panel.mottoButtons.Length; i++) {
                var button = Button("Motto" + i, mottoScroll.content, Sprite("bg_Common_Rounded"), new Vector2(800, 84), Vector2.zero);
                button.GetComponent<UnityEngine.UI.Image>().color = new Color(1, .95f, .85f);
                button.gameObject.AddComponent<UnityEngine.UI.LayoutElement>().preferredHeight = 84;
                panel.mottoButtons[i] = button;
                panel.mottoLabels[i] = Label("Label", button.transform, font, new Vector2(770, 80), Vector2.zero, 34);
            }
            panel.helpRoot = Rect("Help", box.transform, new Vector2(820, 790), new Vector2(0, 30)).gameObject;
            panel.dialogBody = Label("Body", panel.helpRoot.transform, font, new Vector2(800, 790), Vector2.zero, 34);
            panel.dialogBody.alignment = TextAlignmentOptions.TopLeft;
            panel.dialogNotice = Label("Notice", box.transform, font, new Vector2(830, 120), new Vector2(0, -405), 32);
            panel.saveButton = Button("Save", box.transform, Sprite("btn_Common_Rounded_Yellow"), new Vector2(330, 100), new Vector2(210, -510));
            panel.saveLabel = Label("Label", panel.saveButton.transform, font, new Vector2(310, 90), Vector2.zero, 42);
            panel.cancelButton = Button("Close", box.transform, Sprite("bg_Common_Rounded"), new Vector2(330, 100), new Vector2(-210, -510));
            panel.cancelLabel = Label("Label", panel.cancelButton.transform, font, new Vector2(310, 90), Vector2.zero, 42);
            panel.dialogRoot.SetActive(false);
        }

        static void BindHome() {
            string path = "Assets/Res_Runtime/UI/Home/Panel_Home.prefab";
            var root = PrefabUtility.LoadPrefabContents(path);
            try {
                var panel = root.GetComponent<Panel_Home>();
                panel.profileAvatar = panel.profileButton.transform.Find("Portrait").GetComponent<UnityEngine.UI.Image>();
                panel.profileFrame = panel.profileButton.GetComponent<UnityEngine.UI.Image>();
                PrefabUtility.SaveAsPrefabAsset(root, path);
            } finally {
                PrefabUtility.UnloadPrefabContents(root);
            }
        }

        static void RefinePanel(string path, ProfileConfigSO config) {
            var root = PrefabUtility.LoadPrefabContents(path);
            try {
                var panel = root.GetComponent<Panel_Profile>();
                var hidden = panel.items.FirstOrDefault(i => i.tab == ProfileTabType.Avatar && i.itemId == config.hiddenAvatarId);
                if (hidden != null) {
                    panel.items = panel.items.Where(i => i != hidden).ToArray();
                    UnityEngine.Object.DestroyImmediate(hidden.gameObject);
                }
                panel.avatar.rectTransform.sizeDelta = Vector2.one * 160;
                panel.backButton.GetComponent<UnityEngine.UI.Image>().sprite = Sprite("Img_Common_Back");
                var extraBack = panel.backButton.transform.Find("Icon");
                if (extraBack != null) {
                    UnityEngine.Object.DestroyImmediate(extraBack.gameObject);
                }
                panel.infoButton.GetComponent<UnityEngine.UI.Image>().color = new Color(1, .99f, .95f);
                panel.infoButton.GetComponentInChildren<TMP_Text>().color = new Color(.66f, .46f, .25f);
                var card = panel.contentRoot.Find("MemberCard");
                if (card.GetComponent<UnityEngine.UI.Mask>() == null) {
                    card.gameObject.AddComponent<UnityEngine.UI.Mask>().showMaskGraphic = true;
                }
                var colors = new[] { new Color(.97f, .54f, .4f), new Color(.48f, .7f, .5f), new Color(.63f, .51f, .86f),
                    new Color(.71f, .57f, .3f), new Color(.96f, .64f, .23f), new Color(.91f, .62f, .28f) };
                for (int i = 0; i < 6; i++) {
                    panel.contentRoot.Find("Stat" + i + "/Icon").GetComponent<UnityEngine.UI.Image>().color = colors[i];
                }
                foreach (string icon in new[] { "UidIcon", "Copy/Icon", "Gold/Lock" }) {
                    panel.contentRoot.Find(icon).GetComponent<UnityEngine.UI.Image>().color = new Color(.63f, .54f, .43f);
                }
                panel.statValues[0].richText = true;
                panel.statValues[1].richText = true;
                PrefabUtility.SaveAsPrefabAsset(root, path);
            } finally {
                PrefabUtility.UnloadPrefabContents(root);
            }
        }

        static UnityEngine.UI.ScrollRect Scroll(string name, Transform parent, Vector2 size, Vector2 position) {
            var rect = Rect(name, parent, size, position);
            var scroll = rect.gameObject.AddComponent<UnityEngine.UI.ScrollRect>();
            scroll.horizontal = false;
            scroll.movementType = UnityEngine.UI.ScrollRect.MovementType.Clamped;
            scroll.scrollSensitivity = 50;
            var viewport = Image("Viewport", rect, Sprite("bg_Common_Rounded"), size, Vector2.zero);
            viewport.raycastTarget = true;
            viewport.gameObject.AddComponent<UnityEngine.UI.Mask>().showMaskGraphic = true;
            viewport.color = new Color(1, .99f, .97f);
            var content = Rect("Content", viewport.transform, new Vector2(size.x, size.y), Vector2.zero);
            content.anchorMin = new Vector2(0, 1);
            content.anchorMax = new Vector2(1, 1);
            content.pivot = new Vector2(.5f, 1);
            content.sizeDelta = new Vector2(0, size.y);
            scroll.content = content;
            scroll.viewport = viewport.rectTransform;
            return scroll;
        }

        static Sprite Sprite(string name) {
            string[] folders = { "Profile", "Game", "Home", "Streak" };
            foreach (string folder in folders) {
                var sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Res_Runtime/UI/" + folder + "/" + name + ".png");
                if (sprite != null) {
                    return sprite;
                }
            }
            throw new InvalidOperationException("Missing profile sprite " + name);
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
