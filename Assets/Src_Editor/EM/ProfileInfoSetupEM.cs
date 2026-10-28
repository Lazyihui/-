using System;
using System.IO;
using TMPro;
using UnityEditor;
using UnityEditor.AddressableAssets;
using UnityEngine;

namespace Hamdoku.Editor {
    public static class ProfileInfoSetupEM {
        [MenuItem("Hamdoku/Setup/Configure Profile Info")]
        public static void Setup() {
            foreach (string path in Directory.GetFiles("Assets/Res_Runtime/UI/Profile/Info", "*.png")) {
                var importer = (TextureImporter)AssetImporter.GetAtPath(path);
                importer.textureType = TextureImporterType.Sprite;
                importer.spriteImportMode = SpriteImportMode.Single;
                importer.spritePixelsPerUnit = 100;
                importer.alphaIsTransparency = true;
                importer.mipmapEnabled = false;
                importer.textureCompression = TextureImporterCompression.Uncompressed;
                importer.SaveAndReimport();
            }
            var config = AssetDatabase.LoadAssetAtPath<ProfileConfigSO>("Assets/Res_Runtime/Config/ProfileConfig.asset");
            config.helpMemberDays = 30;
            config.helpRewardMax = 20;
            config.helpRewardHint = 2;
            config.helpRewardGuide = 2;
            config.helpEligibleStreak = 7;
            config.helpBackdropColor = new Color(0, 0, 0, .96f);
            config.editBackdropColor = new Color(.23f, .17f, .12f, .5f);
            EditorUtility.SetDirty(config);
            ProfileSetupEM.BakeFonts();
            string pathPrefab = "Assets/Res_Runtime/UI/Profile/Panel_Profile.prefab";
            var root = PrefabUtility.LoadPrefabContents(pathPrefab);
            try {
                var panel = root.GetComponent<Panel_Profile>();
                var font = panel.dialogTitle.font;
                var overlay = panel.dialogRoot.GetComponent<UnityEngine.UI.Image>();
                panel.dialogBackdrop = overlay;
                overlay.color = config.editBackdropColor;
                panel.dialogBox = panel.dialogTitle.transform.parent.gameObject;
                var help = (RectTransform)panel.helpRoot.transform;
                help.SetParent(panel.dialogRoot.transform, false);
                SetRect(help, new Vector2(800, 1120), Vector2.zero);
                var frame = help.GetComponent<UnityEngine.UI.Image>();
                if (frame == null) {
                    frame = help.gameObject.AddComponent<UnityEngine.UI.Image>();
                }
                frame.sprite = Sprite("popup_frame");
                frame.type = UnityEngine.UI.Image.Type.Sliced;
                frame.pixelsPerUnitMultiplier = 1.25f;
                frame.raycastTarget = true;
                panel.dialogBody.gameObject.SetActive(false);
                panel.helpTitle = Text(help, "HelpTitle", font, new Vector2(690, 80), new Vector2(0, 200), 48);
                panel.helpTitle.text = "什么是仓鼠俱乐部?";
                panel.helpRowTitles = new TMP_Text[4];
                panel.helpRowDescriptions = new TMP_Text[4];
                string[] icons = { "club_ico_days", "club_ico_stamp", "club_ico_crown", "club_ico_streak" };
                float[] positions = { 76, -42, -160, -308 };
                for (int i = 0; i < 4; i++) {
                    var row = Rect(help, "HelpRow" + i, new Vector2(672, 108), new Vector2(0, positions[i]));
                    var tile = Image(row, "IconTile", Sprite("bg_Common_Rounded"), new Vector2(88, 88), new Vector2(-288, 0));
                    tile.color = new Color(1, .91f, .76f);
                    var icon = Image(tile.transform, "Icon", Sprite(icons[i]), new Vector2(48, 48), Vector2.zero);
                    icon.color = new Color(.69f, .41f, .16f);
                    panel.helpRowTitles[i] = Text(row, "Title", font, new Vector2(560, 44), new Vector2(56, 23), 29);
                    panel.helpRowTitles[i].alignment = TextAlignmentOptions.MidlineLeft;
                    panel.helpRowDescriptions[i] = Text(row, "Description", font, new Vector2(560, 58), new Vector2(56, -24), 26);
                    panel.helpRowDescriptions[i].alignment = TextAlignmentOptions.TopLeft;
                    panel.helpRowDescriptions[i].color = new Color(.56f, .40f, .29f);
                }
                var divider = Image(help, "Divider", null, new Vector2(672, 2), new Vector2(0, -234));
                divider.color = new Color(.77f, .58f, .38f, .28f);
                panel.helpConfirmButton = Button(help, "Confirm", Sprite("popup_btn_pink"), new Vector2(400, 110), new Vector2(0, -452));
                panel.helpConfirmLabel = Text(panel.helpConfirmButton.transform, "Label", font, new Vector2(360, 92), Vector2.zero, 42);
                panel.helpConfirmLabel.color = Color.white;
                panel.helpConfirmLabel.text = "确认";
                panel.helpCloseButton = Button(help, "Close", Sprite("popup_btn_close"), new Vector2(144, 144), new Vector2(320, 365));
                panel.helpCloseButton.transform.SetAsLastSibling();
                panel.helpRoot.SetActive(false);
                panel.dialogRoot.SetActive(false);
                PrefabUtility.SaveAsPrefabAsset(root, pathPrefab);
            } finally {
                PrefabUtility.UnloadPrefabContents(root);
            }
            var settings = AddressableAssetSettingsDefaultObject.Settings;
            foreach (string guid in AssetDatabase.FindAssets("t:L10NSO", new[] { "Assets/Res_Runtime/Localization" })) {
                string path = AssetDatabase.GUIDToAssetPath(guid);
                if (Path.GetFileNameWithoutExtension(path).StartsWith("Profile_Help", StringComparison.Ordinal)) {
                    var entry = settings.CreateOrMoveEntry(guid, settings.DefaultGroup);
                    entry.SetLabel(AAConst.LABEL_DEFAULT, true, true);
                }
            }
            EditorUtility.SetDirty(settings);
            AssetDatabase.SaveAssets();
            Debug.Log("[ProfileInfo] Saved profile information popup, configuration, fonts and localization registrations.");
        }

        static Sprite Sprite(string name) {
            string path = name == "bg_Common_Rounded" ? "Assets/Res_Runtime/UI/Game/" : "Assets/Res_Runtime/UI/Profile/Info/";
            if (name == "club_ico_days" || name == "club_ico_streak" || name == "club_ico_crown") {
                path = "Assets/Res_Runtime/UI/Profile/";
            }
            var sprite = AssetDatabase.LoadAssetAtPath<Sprite>(path + name + ".png");
            if (sprite == null) {
                throw new InvalidOperationException("Missing profile info sprite: " + name);
            }
            return sprite;
        }

        static void SetRect(RectTransform rect, Vector2 size, Vector2 position) {
            rect.anchorMin = Vector2.one * .5f;
            rect.anchorMax = rect.anchorMin;
            rect.pivot = rect.anchorMin;
            rect.sizeDelta = size;
            rect.anchoredPosition = position;
            rect.localScale = Vector3.one;
        }

        static RectTransform Rect(Transform parent, string name, Vector2 size, Vector2 position) {
            var child = parent.Find(name);
            var rect = child == null ? new GameObject(name, typeof(RectTransform)).GetComponent<RectTransform>() : (RectTransform)child;
            rect.gameObject.layer = LayerMask.NameToLayer("UI");
            rect.SetParent(parent, false);
            SetRect(rect, size, position);
            return rect;
        }

        static UnityEngine.UI.Image Image(Transform parent, string name, Sprite sprite, Vector2 size, Vector2 position) {
            var rect = Rect(parent, name, size, position);
            var image = rect.GetComponent<UnityEngine.UI.Image>();
            if (image == null) {
                image = rect.gameObject.AddComponent<UnityEngine.UI.Image>();
            }
            image.sprite = sprite;
            image.type = sprite != null && sprite.border != Vector4.zero ? UnityEngine.UI.Image.Type.Sliced : UnityEngine.UI.Image.Type.Simple;
            image.preserveAspect = image.type == UnityEngine.UI.Image.Type.Simple;
            image.raycastTarget = false;
            return image;
        }

        static UnityEngine.UI.Button Button(Transform parent, string name, Sprite sprite, Vector2 size, Vector2 position) {
            var image = Image(parent, name, sprite, size, position);
            image.raycastTarget = true;
            var button = image.GetComponent<UnityEngine.UI.Button>();
            if (button == null) {
                button = image.gameObject.AddComponent<UnityEngine.UI.Button>();
            }
            button.targetGraphic = image;
            return button;
        }

        static TMP_Text Text(Transform parent, string name, TMP_FontAsset font, Vector2 size, Vector2 position, float fontSize) {
            var rect = Rect(parent, name, size, position);
            var text = rect.GetComponent<TextMeshProUGUI>();
            if (text == null) {
                text = rect.gameObject.AddComponent<TextMeshProUGUI>();
            }
            text.font = font;
            text.fontSize = fontSize;
            text.fontSizeMin = fontSize * .80f;
            text.fontSizeMax = fontSize;
            text.enableAutoSizing = true;
            text.alignment = TextAlignmentOptions.Center;
            text.color = new Color(.32f, .21f, .12f);
            text.raycastTarget = false;
            text.richText = false;
            return text;
        }
    }
}
