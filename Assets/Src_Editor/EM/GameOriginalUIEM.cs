using System;
using TMPro;
using UnityEditor;
using UnityEngine;

namespace Hamdoku.Editor {
    // Adapts the extracted level2 Canvas and sharedassets2 Cell; does not generate their base hierarchy.
    public static class GameOriginalUIEM {
        public static void Adapt() {
            string path = "Assets/Res_Runtime/UI/Game/Widget_BoardCell.prefab";
            var root = PrefabUtility.LoadPrefabContents(path);
            try {
                var cell = root.GetComponent<Widget_BoardCell>();
                if (cell == null) {
                    cell = root.AddComponent<Widget_BoardCell>();
                }
                cell.background = root.GetComponent<UnityEngine.UI.Image>();
                cell.background.type = UnityEngine.UI.Image.Type.Sliced;
                cell.background.pixelsPerUnitMultiplier = 1.5f;
                cell.hamster = root.transform.Find("Hamster").GetComponent<UnityEngine.UI.Image>();
                cell.cross = root.transform.Find("StrokeA").GetComponent<UnityEngine.UI.Image>();
                cell.crossSecond = root.transform.Find("StrokeB").GetComponent<UnityEngine.UI.Image>();
                foreach (var stroke in new[] { cell.cross, cell.crossSecond }) {
                    var rect = stroke.rectTransform;
                    rect.anchorMin = new Vector2(0.07f, 0.43f);
                    rect.anchorMax = new Vector2(0.93f, 0.57f);
                    rect.offsetMin = Vector2.zero;
                    rect.offsetMax = Vector2.zero;
                    rect.pivot = Vector2.one * 0.5f;
                    rect.localRotation = Quaternion.Euler(0, 0, stroke == cell.cross ? 45 : -45);
                    stroke.sprite = Sprite("bg_Common_Rounded");
                    stroke.type = UnityEngine.UI.Image.Type.Sliced;
                    stroke.pixelsPerUnitMultiplier = 3;
                    stroke.color = Color.white;
                }
                root.transform.Find("Label").gameObject.SetActive(false);
                cell.pattern = EnsureImage("AssistPattern", root.transform, Sprite("Img_Game_PatternPaw"));
                cell.pattern.rectTransform.anchorMin = Vector2.one * 0.15f;
                cell.pattern.rectTransform.anchorMax = Vector2.one * 0.85f;
                cell.pattern.rectTransform.offsetMin = Vector2.zero;
                cell.pattern.rectTransform.offsetMax = Vector2.zero;
                cell.pattern.preserveAspect = true;
                cell.pattern.rectTransform.SetSiblingIndex(0);
                cell.focus = EnsureImage("TutorialFocus", root.transform, Sprite("bg_Common_Rounded"));
                Stretch(cell.focus.rectTransform);
                cell.focus.type = UnityEngine.UI.Image.Type.Sliced;
                cell.focus.color = new Color(1, 1, 1, 0.55f);
                cell.focus.rectTransform.SetSiblingIndex(0);
                cell.given = EnsureImage("Given", root.transform, Sprite("bg_Common_Rounded"));
                Center(cell.given.rectTransform, Vector2.one * 12, Vector2.zero);
                cell.given.rectTransform.anchorMin = new Vector2(0.5f, 0.08f);
                cell.given.rectTransform.anchorMax = cell.given.rectTransform.anchorMin;
                foreach (var image in root.GetComponentsInChildren<UnityEngine.UI.Image>(true)) {
                    image.raycastTarget = false;
                }
                PrefabUtility.SaveAsPrefabAsset(root, path);
            } finally {
                PrefabUtility.UnloadPrefabContents(root);
            }
            path = "Assets/Res_Runtime/UI/Game/Panel_Game.prefab";
            root = PrefabUtility.LoadPrefabContents(path);
            try {
                var panel = root.GetComponent<Panel_Game>();
                if (panel == null) {
                    panel = root.AddComponent<Panel_Game>();
                }
                Stretch((RectTransform)root.transform);
                root.transform.localScale = Vector3.one;
                ((RectTransform)root.transform).pivot = Vector2.one * 0.5f;
                panel.safeRoot = (RectTransform)root.transform.Find("SafeArea");
                var layout = panel.safeRoot.Find("Layout") as RectTransform;
                if (layout == null) {
                    layout = Rect("Layout", panel.safeRoot);
                    var children = new Transform[panel.safeRoot.childCount - 1];
                    int index = 0;
                    foreach (Transform child in panel.safeRoot) {
                        if (child != layout) {
                            children[index++] = child;
                        }
                    }
                    foreach (var child in children) {
                        child.SetParent(layout, false);
                    }
                }
                Center(layout, new Vector2(1080, 1920), Vector2.zero);
                panel.contentRoot = layout;
                var font = AssetDatabase.LoadAssetAtPath<TMP_FontAsset>("Assets/Res_Runtime/Font/Chinese SDF.asset");
                var header = layout.Find("Header");
                panel.levelLabel = header.Find("LevelText").GetComponent<TMP_Text>();
                panel.scoreLabel = EnsureText("Score", header, font);
                Center(panel.levelLabel.rectTransform, new Vector2(210, 130), new Vector2(-100, 55));
                Center(panel.scoreLabel.rectTransform, new Vector2(200, 130), new Vector2(100, 55));
                panel.levelLabel.fontSize = 45;
                panel.levelLabel.fontStyle = FontStyles.Normal;
                panel.levelLabel.fontSizeMax = 45;
                panel.levelLabel.fontSizeMin = 32;
                panel.levelLabel.enableAutoSizing = true;
                panel.scoreLabel.fontSize = 45;
                panel.scoreLabel.enableAutoSizing = false;
                panel.countLabel = header.Find("StatusRow/HamsterCounter/Count").GetComponent<TMP_Text>();
                panel.countLabel.fontSize = 42;
                var status = header.Find("StatusRow");
                Center((RectTransform)status.Find("HamsterCounter"), new Vector2(256, 85), new Vector2(-160, 0));
                Center((RectTransform)status.Find("LifeCounter"), new Vector2(256, 85), new Vector2(160, 0));
                panel.hearts = new UnityEngine.UI.Image[3];
                for (int i = 0; i < 3; i++) {
                    panel.hearts[i] = status.Find("LifeCounter/Life" + i).GetComponent<UnityEngine.UI.Image>();
                }
                panel.homeButton = layout.Find("PauseButton").GetComponent<UnityEngine.UI.Button>();
                panel.shopButton = layout.Find("ShopButton").GetComponent<UnityEngine.UI.Button>();
                panel.settingsButton = layout.Find("SettingsButton").GetComponent<UnityEngine.UI.Button>();
                HeaderButton(panel.homeButton, "Img_Common_Back", 70);
                HeaderButton(panel.shopButton, "Img_Common_Shop", -195);
                HeaderButton(panel.settingsButton, "Img_Common_Settings", -70);
                panel.restartButton = layout.Find("TipButton").GetComponent<UnityEngine.UI.Button>();
                panel.restartButton.gameObject.SetActive(true);
                Center((RectTransform)panel.restartButton.transform, Vector2.one * 84, new Vector2(440, -710));
                panel.restartButton.GetComponent<UnityEngine.UI.Image>().sprite = Sprite("bg_Game_Circle");
                var retry = EnsureImage("RestartIcon", panel.restartButton.transform, Sprite("Img_Game_Retry"));
                Center(retry.rectTransform, Vector2.one * 50, Vector2.zero);
                var originalTipLabel = panel.restartButton.transform.Find("t");
                originalTipLabel.gameObject.SetActive(false);
                var rules = (RectTransform)layout.Find("RuleBanner");
                Center(rules, new Vector2(920, 128), new Vector2(0, 580));
                var banner = EnsureImage("Band", rules, Sprite("bg_Common_Rounded"));
                Stretch(banner.rectTransform);
                banner.color = new Color(1, 0.980392f, 0.94902f, 1);
                banner.pixelsPerUnitMultiplier = 0.65f;
                banner.rectTransform.SetAsFirstSibling();
                panel.ruleLabels = new TMP_Text[3];
                string[] icons = { "Img_Game_RuleRegion", "Img_Game_RuleLine", "Img_Game_RuleAdjacent" };
                for (int i = 0; i < 3; i++) {
                    var card = EnsureImage("Card" + i, rules, Sprite("bg_Common_Rounded"));
                    Center(card.rectTransform, new Vector2(290, 102), new Vector2((i - 1) * 298, 0));
                    card.color = new Color(0.960784f, 0.92549f, 0.890196f, 1);
                    card.pixelsPerUnitMultiplier = 0.8f;
                    var icon = EnsureImage("Icon", card.transform, Sprite(icons[i]));
                    Center(icon.rectTransform, Vector2.one * 82, new Vector2(-94, 0));
                    icon.preserveAspect = true;
                    panel.ruleLabels[i] = EnsureText("Text", card.transform, font);
                    Center(panel.ruleLabels[i].rectTransform, new Vector2(175, 88), new Vector2(42, 0));
                    panel.ruleLabels[i].fontSize = 26;
                    panel.ruleLabels[i].fontSizeMin = 15;
                    panel.ruleLabels[i].fontSizeMax = 26;
                    panel.ruleLabels[i].enableAutoSizing = true;
                    panel.ruleLabels[i].alignment = TextAlignmentOptions.MidlineLeft;
                    panel.ruleLabels[i].color = new Color(0.35f, 0.26f, 0.16f, 1);
                }
                var boardArea = (RectTransform)layout.Find("BoardArea");
                Center(boardArea, new Vector2(976, 976), new Vector2(0, -60));
                var frame = boardArea.Find("BoardFrame").GetComponent<UnityEngine.UI.Image>();
                frame.GetComponent<UnityEngine.UI.AspectRatioFitter>().aspectMode = UnityEngine.UI.AspectRatioFitter.AspectMode.None;
                Stretch(frame.rectTransform);
                frame.pixelsPerUnitMultiplier = 0.8f;
                frame.type = UnityEngine.UI.Image.Type.Sliced;
                var grid = (RectTransform)frame.transform.Find("CellsGrid");
                Stretch(grid);
                grid.offsetMin = Vector2.one * 17;
                grid.offsetMax = -Vector2.one * 17;
                var gridImage = EnsureImage("CellsGrid", frame.transform, null);
                gridImage.color = new Color(1, 1, 1, 0.001f);
                gridImage.raycastTarget = true;
                panel.board = grid.GetComponent<Widget_Board>();
                if (panel.board == null) {
                    panel.board = grid.gameObject.AddComponent<Widget_Board>();
                }
                panel.board.gridRoot = grid;
                panel.board.cellPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Res_Runtime/UI/Game/Widget_BoardCell.prefab").GetComponent<Widget_BoardCell>();
                panel.instructionLabel = EnsureText("TutorialInstruction", layout, font);
                Center(panel.instructionLabel.rectTransform, new Vector2(940, 66), new Vector2(0, 470));
                panel.instructionLabel.fontSize = 33;
                panel.noticeLabel = EnsureText("Notice", layout, font);
                Center(panel.noticeLabel.rectTransform, new Vector2(940, 72), new Vector2(0, -597));
                panel.noticeLabel.fontSize = 33;
                var bottom = (RectTransform)layout.Find("BottomBar");
                Center(bottom, new Vector2(1080, 200), new Vector2(0, -720));
                panel.guideButton = bottom.Find("ItemButton_A").GetComponent<UnityEngine.UI.Button>();
                panel.hintButton = bottom.Find("ItemButton_B").GetComponent<UnityEngine.UI.Button>();
                panel.guideCount = panel.guideButton.transform.Find("Badge/t").GetComponent<TMP_Text>();
                panel.hintCount = panel.hintButton.transform.Find("Badge/t").GetComponent<TMP_Text>();
                panel.guideLabel = panel.guideButton.transform.Find("Icon").GetComponent<TMP_Text>();
                panel.hintLabel = panel.hintButton.transform.Find("Icon").GetComponent<TMP_Text>();
                ItemButton(panel.guideButton, panel.guideLabel, panel.guideCount, "Img_Game_Hint", -115);
                ItemButton(panel.hintButton, panel.hintLabel, panel.hintCount, "Img_Game_Guide", 115);
                panel.timeLabel = EnsureText("Time", layout, font);
                panel.timeLabel.gameObject.SetActive(false);
                var background = root.transform.Find("Background").GetComponent<UnityEngine.UI.Image>();
                background.preserveAspect = true;
                background.GetComponent<UnityEngine.UI.AspectRatioFitter>().aspectMode = UnityEngine.UI.AspectRatioFitter.AspectMode.EnvelopeParent;
                background.GetComponent<UnityEngine.UI.AspectRatioFitter>().aspectRatio = background.sprite.rect.width / background.sprite.rect.height;
                foreach (var text in root.GetComponentsInChildren<TMP_Text>(true)) {
                    text.font = font;
                    text.fontSharedMaterial = font.material;
                    text.raycastTarget = false;
                    text.textWrappingMode = Array.IndexOf(panel.ruleLabels, text) >= 0 ? TextWrappingModes.Normal : TextWrappingModes.NoWrap;
                }
                foreach (var image in root.GetComponentsInChildren<UnityEngine.UI.Image>(true)) {
                    image.raycastTarget = image == gridImage || image.GetComponent<UnityEngine.UI.Button>() != null;
                }
                PrefabUtility.SaveAsPrefabAsset(root, path);
            } finally {
                PrefabUtility.UnloadPrefabContents(root);
            }
            foreach (string name in new[] { "Level", "Score" }) {
                var text = AssetDatabase.LoadAssetAtPath<L10NSO>("Assets/Res_Runtime/Localization/Game_" + name + ".asset");
                text.chinese = (name == "Level" ? "关卡" : "分数") + "\n<size=55>{0}</size>";
                text.english = name + "\n<size=55>{0}</size>";
                EditorUtility.SetDirty(text);
            }
            AssetDatabase.SaveAssets();
        }
        static void HeaderButton(UnityEngine.UI.Button button, string iconName, float x) {
            var rect = (RectTransform)button.transform;
            rect.sizeDelta = Vector2.one * 108;
            rect.pivot = Vector2.one * 0.5f;
            rect.anchoredPosition = new Vector2(x, 0);
            var image = button.GetComponent<UnityEngine.UI.Image>();
            string folder = iconName == "Img_Common_Back" ? "Game" : "Home";
            image.sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Res_Runtime/UI/" + folder + "/" + iconName + ".png");
            if (image.sprite == null) {
                throw new InvalidOperationException("Missing original header sprite " + iconName);
            }
            image.type = UnityEngine.UI.Image.Type.Simple;
            image.preserveAspect = true;
            var label = button.transform.Find("t");
            if (label != null) {
                label.gameObject.SetActive(false);
            }
        }
        static void ItemButton(UnityEngine.UI.Button button, TMP_Text label, TMP_Text count, string sprite, float x) {
            Center((RectTransform)button.transform, new Vector2(180, 186), new Vector2(x, 0));
            var image = button.GetComponent<UnityEngine.UI.Image>();
            image.sprite = Sprite(sprite);
            image.type = UnityEngine.UI.Image.Type.Simple;
            image.preserveAspect = true;
            image.color = Color.white;
            label.gameObject.SetActive(false);
            var colors = button.colors;
            colors.disabledColor = Color.white;
            button.colors = colors;
            var badge = button.transform.Find("Badge").GetComponent<UnityEngine.UI.Image>();
            badge.sprite = Sprite("bg_Game_Circle");
            badge.type = UnityEngine.UI.Image.Type.Simple;
            badge.color = new Color(1, 0.365f, 0.286f, 1);
            badge.rectTransform.sizeDelta = Vector2.one * 58;
            badge.rectTransform.anchoredPosition = new Vector2(-18, -7);
            badge.rectTransform.pivot = Vector2.one * 0.5f;
            Stretch(count.rectTransform);
            count.color = Color.white;
            count.fontSize = 36;
            count.fontStyle = FontStyles.Bold;
            count.enableAutoSizing = false;
        }
        static Sprite Sprite(string name) {
            var sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Res_Runtime/UI/Game/" + name + ".png");
            if (sprite == null) {
                throw new InvalidOperationException("Missing original game sprite " + name);
            }
            return sprite;
        }
        static RectTransform Rect(string name, Transform parent) {
            var rect = new GameObject(name, typeof(RectTransform)).GetComponent<RectTransform>();
            rect.gameObject.layer = LayerMask.NameToLayer("UI");
            rect.SetParent(parent, false);
            return rect;
        }
        static UnityEngine.UI.Image EnsureImage(string name, Transform parent, Sprite sprite) {
            var child = parent.Find(name);
            var rect = child == null ? Rect(name, parent) : (RectTransform)child;
            var image = rect.GetComponent<UnityEngine.UI.Image>();
            if (image == null) {
                image = rect.gameObject.AddComponent<UnityEngine.UI.Image>();
            }
            image.sprite = sprite;
            image.raycastTarget = false;
            image.type = sprite != null && sprite.border != Vector4.zero ? UnityEngine.UI.Image.Type.Sliced : UnityEngine.UI.Image.Type.Simple;
            return image;
        }
        static TMP_Text EnsureText(string name, Transform parent, TMP_FontAsset font) {
            var child = parent.Find(name);
            var rect = child == null ? Rect(name, parent) : (RectTransform)child;
            var text = rect.GetComponent<TMP_Text>();
            if (text == null) {
                text = rect.gameObject.AddComponent<TextMeshProUGUI>();
            }
            text.font = font;
            text.raycastTarget = false;
            text.alignment = TextAlignmentOptions.Center;
            text.color = new Color(0.42745f, 0.24706f, 0.29804f, 1);
            return text;
        }
        static void Center(RectTransform rect, Vector2 size, Vector2 position) {
            rect.anchorMin = Vector2.one * 0.5f;
            rect.anchorMax = rect.anchorMin;
            rect.pivot = Vector2.one * 0.5f;
            rect.sizeDelta = size;
            rect.anchoredPosition = position;
        }
        static void Stretch(RectTransform rect) {
            rect.anchorMin = Vector2.zero;
            rect.anchorMax = Vector2.one;
            rect.offsetMin = Vector2.zero;
            rect.offsetMax = Vector2.zero;
        }
    }
}
