using System;
using System.Linq;
using TMPro;
using UnityEditor;
using UnityEditor.AddressableAssets;
using UnityEngine;

namespace Hamdoku.Editor {
    public static class ProfileCompletionEM {
        [MenuItem("Hamdoku/Setup/Complete Profile")]
        public static void Setup() {
            foreach (string path in System.IO.Directory.GetFiles("Assets/Res_Runtime/UI/Profile", "*.png")) {
                var importer = (TextureImporter)AssetImporter.GetAtPath(path);
                if (importer.textureType != TextureImporterType.Sprite || importer.textureShape != TextureImporterShape.Texture2D) {
                    importer.textureType = TextureImporterType.Sprite;
                    importer.textureShape = TextureImporterShape.Texture2D;
                    importer.spriteImportMode = SpriteImportMode.Single;
                    importer.alphaIsTransparency = true;
                    importer.mipmapEnabled = false;
                    importer.textureCompression = TextureImporterCompression.Uncompressed;
                    importer.SaveAndReimport();
                }
            }
            var config = AssetDatabase.LoadAssetAtPath<ProfileConfigSO>("Assets/Res_Runtime/Config/ProfileConfig.asset");
            if (config == null) {
                throw new InvalidOperationException("Production ProfileConfig is missing.");
            }
            config.tabOn = Sprite("profile_tab");
            config.tabOff = Sprite("profile_tab_off");
            config.selectedColor = Color.white;
            config.idleColor = Color.white;
            config.tabOnText = new Color(0.349999994f, 0.25999999f, 0.159999996f, 1f);
            config.tabOffText = new Color(0.649999976f, 0.560000002f, 0.460000008f, 1f);
            config.hands = new Sprite[] { null, null, null, null, Sprite("avatar_hand_4"), Sprite("avatar_hand_5"), null, Sprite("avatar_hand_7"), Sprite("avatar_hand_8"), Sprite("avatar_hand_9"), Sprite("avatar_hand_10"), Sprite("avatar_hand_11"), Sprite("avatar_hand_12"), Sprite("avatar_hand_13"), Sprite("avatar_hand_14"), Sprite("avatar_hand_15"), Sprite("avatar_hand_16"), null, null, null, null, Sprite("avatar_hand_21"), Sprite("avatar_hand_22"), Sprite("avatar_hand_23"), Sprite("avatar_hand_24"), Sprite("avatar_hand_25"), Sprite("avatar_hand_26"), Sprite("avatar_hand_27"), Sprite("avatar_hand_28") };
            config.costumeFits = new ProfileCostumeFitModel[config.costumes.Length * config.avatars.Length];
            for (int i = 0; i < config.costumeFits.Length; i++) {
                config.costumeFits[i] = new ProfileCostumeFitModel { offset = Vector2.zero, scale = 1f, rotation = 0f };
            }
            config.costumeRects = new Rect[] { new Rect(-.25f, -.25f, 1.5f, 1.5f), new Rect(-.25f, -.25f, 1.5f, 1.5f), new Rect(-.25f, -.25f, 1.5f, 1.5f), new Rect(-.25f, -.25f, 1.5f, 1.5f), new Rect(-.25f, -.25f, 1.5f, 1.5f), new Rect(-.25f, -.25f, 1.5f, 1.5f) };
            config.costumeHeadPivot = new Vector2(0.497999996f, 0.565599978f);
            config.costumeSeasons = new int[] { 202610, 202610, 202610, 202611, 202611, 202611 };
            config.costumeSourceIds = new int[] { 1, 2, 3, 7, 5, 6 };
            config.crownFrames = new bool[] { false, false, false, false, false, false, false, true, false, false, true, true, true, true, true, true, true, true, true, true, false };
            config.frameOpenings = new float[] { 0.769999981f, 0.769999981f, 0.769999981f, 0.769999981f, 0.769999981f, 0.769999981f, 0.769999981f, 0.5567f, 0.769999981f, 0.769999981f, 0.5567f, 0.5567f, 0.5567f, 0.5567f, 0.5567f, 0.5567f, 0.5567f, 0.5567f, 0.5567f, 0.5567f, 0.587000012f };
            config.badgeCenters = new Vector2[] { new Vector2(0.194999993f, 0.312999994f), new Vector2(0.194999993f, 0.312999994f), new Vector2(0.194999993f, 0.312999994f), new Vector2(0.194999993f, 0.312999994f), new Vector2(0.194999993f, 0.312999994f), new Vector2(0.194999993f, 0.312999994f), new Vector2(0.194999993f, 0.312999994f), new Vector2(0.194999993f, 0.312999994f), new Vector2(0.194999993f, 0.312999994f), new Vector2(0.194999993f, 0.312999994f), new Vector2(0.194999993f, 0.312999994f), new Vector2(0.194999993f, 0.312999994f), new Vector2(0.194999993f, 0.312999994f), new Vector2(0.194999993f, 0.312999994f), new Vector2(0.194999993f, 0.312999994f), new Vector2(0.194999993f, 0.312999994f), new Vector2(0.186000004f, 0.32100001f), new Vector2(0.194000006f, 0.319000006f), new Vector2(0.193000004f, 0.319999993f), new Vector2(0.193000004f, 0.331999987f), new Vector2(0.194999993f, 0.312999994f) };
            config.badgeColors = new Color[] { new Color(0.819999993f, 0.550000012f, 0.0199999996f, 1), new Color(0.819999993f, 0.550000012f, 0.0199999996f, 1), new Color(0.819999993f, 0.550000012f, 0.0199999996f, 1), new Color(0.819999993f, 0.550000012f, 0.0199999996f, 1), new Color(0.819999993f, 0.550000012f, 0.0199999996f, 1), new Color(0.819999993f, 0.550000012f, 0.0199999996f, 1), new Color(0.819999993f, 0.550000012f, 0.0199999996f, 1), new Color(0.819999993f, 0.550000012f, 0.0199999996f, 1), new Color(0.819999993f, 0.550000012f, 0.0199999996f, 1), new Color(0.819999993f, 0.550000012f, 0.0199999996f, 1), new Color(0.899999976f, 0.340000004f, 0.5f, 1), new Color(0.200000003f, 0.620000005f, 0.949999988f, 1), new Color(0.439999998f, 0.660000026f, 0.0500000007f, 1), new Color(0.519999981f, 0.239999995f, 0.800000012f, 1), new Color(0.159999996f, 0.280000001f, 0.620000005f, 1), new Color(0.129999995f, 0.579999983f, 0.469999999f, 1), new Color(0.360000014f, 0.419999987f, 0.540000021f, 1), new Color(0.219999999f, 0.239999995f, 0.660000026f, 1), new Color(0.379999995f, 0.200000003f, 0.620000005f, 1), new Color(0.660000026f, 0.100000001f, 0.360000014f, 1), new Color(0.819999993f, 0.550000012f, 0.0199999996f, 1) };
            config.frameAuras = new Sprite[] { null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, Sprite("crown_aura_17"), Sprite("crown_aura_18"), Sprite("crown_aura_19"), null };
            config.frameAuraTiers = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 0 };
            config.crownPlateScale = 1.04f;
            config.crownFrameScale = 1.39f;
            config.crownBadgeScale = .135f;
            config.ringOpeningOfPlate = .9f;
            config.portraitFaceScale = .8f;
            config.auraScale = 1.3333334f;
            config.sparkleSpeed = 3.2f;
            config.sparkleMinScale = .45f;
            config.crownOpeningCenter = new Vector2(.518f, .568f);
            config.auraAlpha = new float[] { 0.600000024f, 1f, 1f };
            config.auraSpeed = new float[] { 0.140000001f, 0.150000006f, 0.150000006f };
            config.auraHueBase = new float[] { 0.579999983f, 0f, 0f };
            config.auraHueRange = new float[] { 0.200000003f, 0.400000006f, 0.5f };
            config.auraSaturation = 1f;
            config.auraValue = 0.879999995f;
            config.newDotPulseScale = 1.15999997f;
            config.newDotPulseSeconds = 0.899999976f;
            Hamdoku.Controllers.ProfileController.ValidateVisualConfig(config);
            EditorUtility.SetDirty(config);
            CompletePanel(config);
            CompleteHome(config);
            var settings = AddressableAssetSettingsDefaultObject.Settings;
            foreach (string name in new[] { "Profile_SeasonSource", "Profile_SeasonLocked", "Profile_ClubTag" }) {
                string path = "Assets/Res_Runtime/Localization/" + name + ".asset";
                var entry = settings.CreateOrMoveEntry(AssetDatabase.AssetPathToGUID(path), settings.DefaultGroup);
                entry.SetLabel(AAConst.LABEL_DEFAULT, true, true);
            }
            ProfileSetupEM.BakeFonts();
            var home = AssetDatabase.LoadAssetAtPath<GameConfigSO>("Assets/Res_Runtime/Config/GameConfig.asset");
            home.saveVersion = Math.Max(home.saveVersion, 7);
            EditorUtility.SetDirty(home);
            EditorUtility.SetDirty(settings);
            AssetDatabase.SaveAssets();
            Debug.Log("[ProfileCompletion] Formal profile and home prefabs, configuration, localization and save v7 saved.");
        }

        static void CompletePanel(ProfileConfigSO config) {
            string path = "Assets/Res_Runtime/UI/Profile/Panel_Profile.prefab";
            var root = PrefabUtility.LoadPrefabContents(path);
            try {
                var panel = root.GetComponent<Panel_Profile>();
                if (panel == null || panel.items.Length != 54) {
                    throw new InvalidOperationException("Unexpected production profile bindings or item count.");
                }
                var font = panel.nameLabel.font;
                var oldNoticeBackground = panel.noticeLabel.transform.Find("Background");
                if (oldNoticeBackground != null) {
                    oldNoticeBackground.SetParent(panel.contentRoot, false);
                    oldNoticeBackground.name = "NoticeBackground";
                    var backgroundRect = (RectTransform)oldNoticeBackground;
                    backgroundRect.anchoredPosition = panel.noticeLabel.rectTransform.anchoredPosition;
                }
                panel.noticeBackground = panel.contentRoot.Find("NoticeBackground").GetComponent<UnityEngine.UI.Image>();
                panel.noticeBackground.gameObject.SetActive(false);
                panel.avatarBackground.gameObject.SetActive(false);
                panel.frame.gameObject.SetActive(false);
                panel.portrait = Portrait(panel.contentRoot, "Portrait", new Vector2(-325, 520), 224, font, config);
                panel.portrait.Show(config, 0, 0, -1, 1, -1);
                panel.tabDots = new GameObject[3];
                for (int i = 0; i < 3; i++) {
                    panel.tabDots[i] = Dot(panel.tabButtons[i].transform, config);
                    var image = panel.tabButtons[i].GetComponent<UnityEngine.UI.Image>();
                    image.sprite = i == 0 ? config.tabOn : config.tabOff;
                    image.color = Color.white;
                    panel.tabLabels[i].color = i == 0 ? config.tabOnText : config.tabOffText;
                }
                panel.RefreshTabLayering();
                foreach (var item in panel.items) {
                    bool avatarCell = item.tab == ProfileTabType.Avatar;
                    item.art.gameObject.SetActive(avatarCell);
                    if (avatarCell) {
                        item.art.sprite = config.avatars[item.itemId];
                        item.art.rectTransform.sizeDelta = Vector2.one * 220;
                        item.art.preserveAspect = true;
                    }
                    item.avatar.gameObject.SetActive(false);
                    Transform portraitParent = item.transform;
                    if (item.tab == ProfileTabType.Costume) {
                        var previewClip = Rect(item.transform, "PreviewClip", new Vector2(220, 154), new Vector2(0, 32));
                        if (previewClip.GetComponent<UnityEngine.UI.RectMask2D>() == null) {
                            previewClip.gameObject.AddComponent<UnityEngine.UI.RectMask2D>();
                        }
                        var oldPortrait = item.transform.Find("Portrait");
                        if (oldPortrait != null) {
                            oldPortrait.SetParent(previewClip, false);
                        }
                        portraitParent = previewClip;
                        var previousClip = item.GetComponent<UnityEngine.UI.RectMask2D>();
                        if (previousClip != null) {
                            previousClip.enabled = false;
                        }
                    }
                    float size = item.tab == ProfileTabType.Costume ? 142 : item.tab == ProfileTabType.Frame && config.crownFrames[item.itemId] ? 154 : 176;
                    item.portrait = Portrait(portraitParent, "Portrait", item.tab == ProfileTabType.Costume ? new Vector2(0, -4) : Vector2.zero, size, font, config);
                    ((RectTransform)item.portrait.transform).sizeDelta = Vector2.one * size;
                    ((RectTransform)item.portrait.transform).anchoredPosition = item.tab == ProfileTabType.Costume ? new Vector2(0, -4) : Vector2.zero;
                    item.portrait.Show(config, 0, item.tab == ProfileTabType.Frame ? item.itemId : -1,
                        item.tab == ProfileTabType.Costume ? item.itemId : -1, 1, -1);
                    item.portrait.gameObject.SetActive(!avatarCell);
                    item.selection.sprite = Sprite("profile_selection");
                    item.selection.pixelsPerUnitMultiplier = 1;
                    if (item.tab == ProfileTabType.Costume) {
                        item.label.rectTransform.anchoredPosition = new Vector2(0, -65);
                        item.label.fontSize = 24;
                        item.locked.GetComponent<RectTransform>().anchoredPosition = new Vector2(88, -24);
                    }
                    item.requirementLabel = Label(item.transform, "Requirement", new Vector2(210, 30), new Vector2(0, -94), font, 20);
                    item.requirementLabel.gameObject.SetActive(false);
                    var tag = Graphic(item.transform, "ClubTag", Sprite("bg_Common_Rounded"), new Vector2(70, 32), new Vector2(-68, 84));
                    tag.color = new Color(1, .85f, .45f);
                    var text = Label(tag.transform, "Label", new Vector2(66, 30), Vector2.zero, font, 20);
                    text.text = "CLUB";
                    item.clubLabel = text;
                    item.clubTag = tag.gameObject;
                    item.clubTag.SetActive(item.tab == ProfileTabType.Avatar && item.itemId >= config.clubAvatarStart || item.tab == ProfileTabType.Frame && item.itemId == config.clubFrameId);
                    item.newDot = Dot(item.transform, config);
                    item.selection.transform.SetAsLastSibling();
                    item.check.transform.SetAsLastSibling();
                    item.locked.transform.SetAsLastSibling();
                    item.newDot.transform.SetAsLastSibling();
                    item.locked.GetComponent<UnityEngine.UI.Image>().color = new Color(.5f, .37f, .24f);
                }
                // Keep the existing overlay above additions to the card.
                panel.noticeBackground.transform.SetAsLastSibling();
                panel.noticeLabel.transform.SetAsLastSibling();
                panel.dialogRoot.transform.SetAsLastSibling();
                PrefabUtility.SaveAsPrefabAsset(root, path);
            } finally {
                PrefabUtility.UnloadPrefabContents(root);
            }
        }

        static void CompleteHome(ProfileConfigSO config) {
            string path = "Assets/Res_Runtime/UI/Home/Panel_Home.prefab";
            var root = PrefabUtility.LoadPrefabContents(path);
            try {
                var panel = root.GetComponent<Panel_Home>();
                panel.profileAvatar.gameObject.SetActive(false);
                panel.profileFrame.color = Color.clear;
                panel.profilePortrait = Portrait(panel.profileButton.transform, "ProfilePortrait", Vector2.zero, 114, panel.levelLabel.font, config);
                panel.profilePortrait.Show(config, 0, 0, -1, 1, -1);
                panel.profileNewDot = Dot(panel.profileButton.transform, config);
                PrefabUtility.SaveAsPrefabAsset(root, path);
            } finally {
                PrefabUtility.UnloadPrefabContents(root);
            }
        }

        static Widget_ProfilePortrait Portrait(Transform parent, string name, Vector2 position, float size, TMP_FontAsset font, ProfileConfigSO config) {
            var found = parent.Find(name);
            if (found != null) {
                var existing = found.GetComponent<Widget_ProfilePortrait>();
                if (existing == null) {
                    throw new InvalidOperationException("Unexpected portrait node: " + name);
                }
                existing.clipMask = existing.plate.GetComponent<UnityEngine.UI.Mask>();
                return existing;
            }
            var rect = Rect(parent, name, Vector2.one * size, position);
            var widget = rect.gameObject.AddComponent<Widget_ProfilePortrait>();
            widget.aura = Graphic(rect, "Aura", Sprite("crown_aura"), Vector2.one * size, Vector2.zero);
            widget.plate = Graphic(rect, "Plate", Sprite("bg_Common_Rounded"), Vector2.one * size, Vector2.zero);
            widget.plate.type = UnityEngine.UI.Image.Type.Sliced;
            widget.clipMask = widget.plate.gameObject.AddComponent<UnityEngine.UI.Mask>();
            widget.clipMask.showMaskGraphic = true;
            widget.face = Graphic(widget.plate.transform, "Face", config.avatars[0], Vector2.one * size, Vector2.zero);
            widget.costume = Graphic(widget.face.transform, "Costume", config.costumes[0], Vector2.one * size, Vector2.zero);
            widget.hand = Graphic(widget.face.transform, "Hand", null, Vector2.zero, Vector2.zero);
            Stretch(widget.hand.rectTransform);
            widget.frame = Graphic(rect, "Frame", config.frames[0], Vector2.one * size, Vector2.zero);
            widget.winsBadge = Label(widget.frame.transform, "WinsBadge", Vector2.one * 32, Vector2.zero, font, 25);
            widget.winsBadge.enableAutoSizing = true;
            widget.winsBadge.fontSizeMin = 8;
            widget.winsBadge.fontSizeMax = 40;
            widget.winsBadge.fontStyle = FontStyles.Bold;
            widget.sparkles = new UnityEngine.UI.Image[3];
            var offsets = new[] { new Vector2(-.38f, .38f), new Vector2(.15f, .48f), new Vector2(.42f, -.2f) };
            for (int i = 0; i < widget.sparkles.Length; i++) {
                widget.sparkles[i] = Graphic(rect, "Sparkle" + i, Sprite("sparkle"), Vector2.one * size * .14f, offsets[i] * size);
            }
            return widget;
        }

        static GameObject Dot(Transform parent, ProfileConfigSO config) {
            var found = parent.Find("NewDot");
            if (found != null) {
                return found.gameObject;
            }
            var image = Graphic(parent, "NewDot", Sprite("bg_Game_Circle"), Vector2.one * 32, Vector2.zero);
            var rect = image.rectTransform;
            rect.anchorMin = rect.anchorMax = new Vector2(.94f, .94f);
            rect.anchoredPosition = Vector2.zero;
            image.color = new Color(.95f, .3f, .3f);
            image.gameObject.AddComponent<Widget_ProfileNewDot>().config = config;
            image.gameObject.SetActive(false);
            return image.gameObject;
        }

        static Sprite Sprite(string name) {
            foreach (string folder in new[] { "Profile", "Home", "Game", "Streak" }) {
                var sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Res_Runtime/UI/" + folder + "/" + name + ".png");
                if (sprite != null) {
                    return sprite;
                }
            }
            throw new InvalidOperationException("Missing profile completion sprite: " + name);
        }

        static RectTransform Rect(Transform parent, string name, Vector2 size, Vector2 position) {
            var found = parent.Find(name);
            if (found != null) {
                var existing = found.GetComponent<RectTransform>();
                if (existing == null) {
                    throw new InvalidOperationException("Expected profile RectTransform: " + name);
                }
                return existing;
            }
            var rect = new GameObject(name, typeof(RectTransform)).GetComponent<RectTransform>();
            rect.gameObject.layer = LayerMask.NameToLayer("UI");
            rect.SetParent(parent, false);
            rect.anchorMin = rect.anchorMax = Vector2.one * .5f;
            rect.sizeDelta = size;
            rect.anchoredPosition = position;
            return rect;
        }

        static void Stretch(RectTransform rect) {
            rect.anchorMin = Vector2.zero;
            rect.anchorMax = Vector2.one;
            rect.offsetMin = rect.offsetMax = Vector2.zero;
        }

        static UnityEngine.UI.Image Graphic(Transform parent, string name, Sprite sprite, Vector2 size, Vector2 position) {
            var rect = Rect(parent, name, size, position);
            var image = rect.GetComponent<UnityEngine.UI.Image>();
            if (image == null) {
                image = rect.gameObject.AddComponent<UnityEngine.UI.Image>();
            }
            image.sprite = sprite;
            image.raycastTarget = false;
            image.preserveAspect = true;
            return image;
        }

        static TMP_Text Label(Transform parent, string name, Vector2 size, Vector2 position, TMP_FontAsset font, float fontSize) {
            var rect = Rect(parent, name, size, position);
            var text = rect.GetComponent<TextMeshProUGUI>();
            if (text == null) {
                text = rect.gameObject.AddComponent<TextMeshProUGUI>();
            }
            text.font = font;
            text.fontSize = fontSize;
            text.color = new Color(.35f, .26f, .16f);
            text.alignment = TextAlignmentOptions.Center;
            text.raycastTarget = false;
            return text;
        }
    }
}
