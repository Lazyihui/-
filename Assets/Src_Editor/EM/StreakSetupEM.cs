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
    public static class StreakSetupEM {
        [MenuItem("Hamdoku/Setup/Configure Streak")]
        public static void Setup() {
            CreateAura();
            AssetDatabase.Refresh();
            ImportSprites();
            var config = CreateConfig();
            CreateTexts();
            BakeFonts();
            var font = AssetDatabase.LoadAssetAtPath<TMP_FontAsset>("Assets/Res_Runtime/Font/Chinese SDF.asset");
            string dayPath = "Assets/Res_Runtime/UI/Streak/Widget_StreakDay.prefab";
            if (AssetDatabase.LoadAssetAtPath<GameObject>(dayPath) == null) {
                CreateDay(dayPath, font, config);
            }
            string panelPath = "Assets/Res_Runtime/UI/Streak/Panel_Streak.prefab";
            if (AssetDatabase.LoadAssetAtPath<GameObject>(panelPath) == null) {
                CreatePanel(panelPath, dayPath, font, config);
            }
            var home = AssetDatabase.LoadAssetAtPath<HomeConfigSO>("Assets/Res_Runtime/Config/HomeConfig.asset");
            home.saveVersion = Math.Max(home.saveVersion, 3);
            EditorUtility.SetDirty(home);
            RegisterAssets(panelPath);
            AssetDatabase.SaveAssets();
            Debug.Log("[StreakSetup] Saved streak prefab, localized text, fonts, config and default asset registrations.");
        }

        static void CreateAura() {
            // The source UiFactory also creates its GlowSprite procedurally.
            // Bake this primitive into a production sprite rather than a runtime texture.
            string path = "Assets/Res_Runtime/UI/Streak/Img_Streak_Aura.png";
            var texture = new Texture2D(256, 256, TextureFormat.RGBA32, false);
            for (int y = 0; y < texture.height; y++) {
                for (int x = 0; x < texture.width; x++) {
                    float r = new Vector2((x + 0.5f) / 128 - 1, (y + 0.5f) / 128 - 1).magnitude;
                    float alpha = Mathf.Pow(Mathf.Clamp01(1 - r), 2);
                    texture.SetPixel(x, y, new Color(1, 1, 1, alpha));
                }
            }
            texture.Apply();
            File.WriteAllBytes(path, texture.EncodeToPNG());
            for (int y = 0; y < texture.height; y++) {
                for (int x = 0; x < texture.width; x++) {
                    float distance = new Vector2(x - 127.5f, y - 127.5f).magnitude;
                    texture.SetPixel(x, y, new Color(1, 1, 1, Mathf.Clamp01(128 - distance)));
                }
            }
            texture.Apply();
            File.WriteAllBytes("Assets/Res_Runtime/UI/Streak/bg_Streak_Pill.png", texture.EncodeToPNG());
            UnityEngine.Object.DestroyImmediate(texture);
        }

        static void ImportSprites() {
            foreach (string path in Directory.GetFiles("Assets/Res_Runtime/UI/Streak", "*.png").Concat(Directory.GetFiles("Assets/Res_Runtime/UI/Streak/new", "*.png"))) {
                var importer = (TextureImporter)AssetImporter.GetAtPath(path);
                var settings = new TextureImporterSettings();
                importer.ReadTextureSettings(settings);
                settings.textureType = TextureImporterType.Sprite;
                settings.spriteMode = (int)SpriteImportMode.Single;
                settings.spriteMeshType = SpriteMeshType.FullRect;
                settings.spritePixelsPerUnit = UIResolutionConst.REFERENCE_PIXELS_PER_UNIT;
                settings.alphaIsTransparency = true;
                settings.mipmapEnabled = false;
                if (Path.GetFileNameWithoutExtension(path) == "btn_Streak_Continue") {
                    settings.spriteBorder = new Vector4(86, 86, 86, 86);
                } else if (Path.GetFileNameWithoutExtension(path) == "bg_Streak_Pill") {
                    settings.spriteBorder = new Vector4(127, 127, 127, 127);
                }
                importer.SetTextureSettings(settings);
                importer.textureCompression = TextureImporterCompression.Uncompressed;
                importer.maxTextureSize = 2048;
                switch (Path.GetFileNameWithoutExtension(path))
                {
                    case "btn_Streak_Continue":
                        importer.spriteBorder = new Vector4(189f, 146f, 189f, 144f);
                        break;
                }
                importer.SaveAndReimport();
            }
        }

        static StreakConfigSO CreateConfig() {
            string path = "Assets/Res_Runtime/Config/StreakConfig.asset";
            var config = AssetDatabase.LoadAssetAtPath<StreakConfigSO>(path);
            if (config != null) {
                return config;
            }
            config = ScriptableObject.CreateInstance<StreakConfigSO>();
            // Original GameConfig reward and bloom thresholds, StreakPageConfig presentation.
            config.cycleDays = 7;
            config.rewardHints = new[] { 0, 0, 1, 0, 0, 0, 1 };
            config.rewardGuides = new[] { 0, 0, 0, 0, 1, 0, 1 };
            config.recoveryEnabled = true;
            config.recoveryMaxGapDays = 1;
            config.recoveryMinStreak = 2;
            config.companionDays = new[] { 10, 14, 21, 30, 45, 60, 90 };
            config.plants = new[] { "Img_Streak_Plant_Soil", "Img_Streak_Plant_Sprout", "Img_Streak_Plant_Bud", "Img_Streak_Plant_BudOpening", "Img_Streak_Plant_Stem", "Img_Streak_Plant_Bloom" }.Select(Sprite).ToArray();
            config.smallGift = Sprite("Img_Streak_Gift_Small");
            config.bigGift = Sprite("Img_Streak_Gift_Large");
            config.check = Sprite("Img_Streak_Check_White");
            config.aura = Sprite("Img_Streak_Aura");
            config.petal = Sprite("Img_Streak_Petal");
            config.flowerHead = Sprite("Img_Streak_FlowerHead");
            config.butterflies = new[] { "Img_Streak_Butterfly_Yellow_01", "Img_Streak_Butterfly_Yellow_02", "Img_Streak_Butterfly_Pink_01", "Img_Streak_Butterfly_Pink_02" }.Select(Sprite).ToArray();
            config.completedColor = new Color(0.9433962f, 0.550576f, 0.1824493f, 1);
            config.emptyColor = new Color(0.89f, 0.84f, 0.70f, 1);
            config.todayColor = new Color(1, 0.55f, 0.03f, 1);
            config.weekdayColor = new Color(0.69f, 0.57f, 0.39f, 1);
            config.auraColor = new Color(0.1214f, 0.8302f, 0.823f, 0.3f);
            config.plantSize = 600;
            config.plantReferencePixels = 540;
            config.plantPosition = new Vector2(0, 430);
            config.swayDegrees = 2.4f;
            config.swaySeconds = 3.2f;
            config.auraBreath = 0.4f;
            config.introSeconds = 0.45f;
            config.butterflySeconds = 22;
            config.butterflyFlapSeconds = 0.18f;
            config.butterflyRange = new Vector2(204, 60);
            config.butterflyHeight = 150;
            config.stampSeconds = 0.45f;
            config.petalCount = 12;
            config.petalInterval = 0.055f;
            config.petalLength = 123;
            config.petalOutset = 0.55f;
            config.flowerHeadPosition = new Vector2(0, 298);
            config.flowerHeadSize = 148;
            AssetDatabase.CreateAsset(config, path);
            return config;
        }

        static void CreateTexts() {
            var ids = new[] {
                UINameType.Streak_Title, UINameType.Streak_Current, UINameType.Streak_Best, UINameType.Streak_Continue,
                UINameType.Streak_Monday, UINameType.Streak_Tuesday, UINameType.Streak_Wednesday, UINameType.Streak_Thursday,
                UINameType.Streak_Friday, UINameType.Streak_Saturday, UINameType.Streak_Sunday,
                UINameType.Streak_Reward, UINameType.Streak_Claim, UINameType.Streak_Claimed, UINameType.Streak_RewardPreview,
                UINameType.Streak_Recover, UINameType.Streak_RecoverButton, UINameType.Streak_GiveUp, UINameType.Streak_RecoveryUnavailable
            };
            var chinese = new[] {
                "每日连胜", "当前连胜", "最佳连胜: {0}", "继续", "周一", "周二", "周三", "周四", "周五", "周六", "周日",
                "每日连胜奖励送达！\n提示 +{0}　排除辅助 +{1}", "领取", "奖励已领取，可在棋盘使用。",
                "连续获胜第{0}天\n提示 +{1}　排除辅助 +{2}", "恢复{0}天连胜？", "观看广告恢复", "放弃恢复", "广告服务尚未接入，暂时无法恢复连胜。"
            };
            var english = new[] {
                "Daily Streak", "Current Streak", "Best Streak: {0}", "Continue", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun",
                "Daily streak reward!\nHints +{0}   Auto-X +{1}", "Claim", "Reward claimed. Use it on the board.",
                "Streak day {0}\nHints +{1}   Auto-X +{2}", "Restore your {0}-day streak?", "Watch ad to restore", "Give up", "Ad service is not connected. Streak restoration is unavailable."
            };
            for (int i = 0; i < ids.Length; i++) {
                string path = "Assets/Res_Runtime/Localization/" + ids[i] + ".asset";
                if (AssetDatabase.LoadAssetAtPath<L10NSO>(path) != null) {
                    continue;
                }
                var text = ScriptableObject.CreateInstance<L10NSO>();
                text.id = ids[i];
                text.chinese = chinese[i];
                text.english = english[i];
                AssetDatabase.CreateAsset(text, path);
            }
        }

        static void BakeFonts() {
            var texts = AssetDatabase.FindAssets("t:L10NSO", new[] { "Assets/Res_Runtime/Localization" })
                .Select(guid => AssetDatabase.LoadAssetAtPath<L10NSO>(AssetDatabase.GUIDToAssetPath(guid))).ToArray();
            foreach (string language in new[] { "Chinese", "English" }) {
                var font = AssetDatabase.LoadAssetAtPath<TMP_FontAsset>("Assets/Res_Runtime/Font/" + language + " SDF.asset");
                string characters = "0123456789/: +" + string.Concat(texts.Select(text => language == "Chinese" ? text.chinese : text.english));
                characters = Regex.Replace(characters, "<[^>]*>|\\{[^}]*\\}", string.Empty).Replace("\n", string.Empty);
                if (!font.HasCharacters(characters)) {
                    var serialized = new SerializedObject(font);
                    string guid = serialized.FindProperty("m_SourceFontFileGUID").stringValue;
                    var source = AssetDatabase.LoadAssetAtPath<Font>(AssetDatabase.GUIDToAssetPath(guid));
                    if (source == null) {
                        throw new InvalidOperationException("Missing font source for " + language);
                    }
                    serialized.FindProperty("m_SourceFontFile").objectReferenceValue = source;
                    serialized.ApplyModifiedPropertiesWithoutUndo();
                    font.atlasPopulationMode = AtlasPopulationMode.Dynamic;
                    try {
                        if (!font.TryAddCharacters(characters, out string missing)) {
                            throw new InvalidOperationException("Missing streak glyphs: " + missing);
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

        static void CreateDay(string path, TMP_FontAsset font, StreakConfigSO config) {
            var root = Rect("Widget_StreakDay", null, new Vector2(132, 200), Vector2.zero);
            var widget = root.gameObject.AddComponent<Widget_StreakDay>();
            widget.weekday = Label("Weekday", root, font, new Vector2(130, 65), new Vector2(0, 85), 38);
            widget.disc = Image("Disc", root, Sprite("bg_Streak_Circle"), Vector2.one * 100, new Vector2(0, -20));
            widget.disc.color = config.emptyColor;
            widget.disc.raycastTarget = true;
            widget.button = widget.disc.gameObject.AddComponent<UnityEngine.UI.Button>();
            widget.button.targetGraphic = widget.disc;
            widget.button.transition = UnityEngine.UI.Selectable.Transition.None;
            widget.check = Image("Check", widget.disc.transform, config.check, Vector2.one * 70, Vector2.zero);
            widget.gift = Image("Gift", widget.disc.transform, config.smallGift, Vector2.one * 130, Vector2.zero);
            widget.gift.preserveAspect = true;
            PrefabUtility.SaveAsPrefabAsset(root.gameObject, path);
            UnityEngine.Object.DestroyImmediate(root.gameObject);
        }

        static void CreatePanel(string path, string dayPath, TMP_FontAsset font, StreakConfigSO config) {
            var root = Rect("Panel_Streak", null, Vector2.zero, Vector2.zero);
            Stretch(root);
            var panel = root.gameObject.AddComponent<Panel_Streak>();
            var background = Image("Background", root, GameSprite("bg_Common_Game"), Vector2.zero, Vector2.zero);
            Stretch(background.rectTransform);
            background.raycastTarget = true;
            var aspect = background.gameObject.AddComponent<UnityEngine.UI.AspectRatioFitter>();
            aspect.aspectMode = UnityEngine.UI.AspectRatioFitter.AspectMode.EnvelopeParent;
            aspect.aspectRatio = background.sprite.rect.width / background.sprite.rect.height;
            panel.safeRoot = Rect("SafeRoot", root, Vector2.zero, Vector2.zero);
            Stretch(panel.safeRoot);
            panel.contentRoot = Rect("Content", panel.safeRoot, new Vector2(UIResolutionConst.WIDTH, UIResolutionConst.HEIGHT), Vector2.zero);
            var content = panel.contentRoot;
            panel.titleLabel = Label("Title", content, font, new Vector2(760, 100), new Vector2(0, 830), 55);
            panel.backButton = Button("Back", content, GameSprite("Img_Common_Back"), Vector2.one * 100, new Vector2(-435, 855));
            CreatePlant(panel, config);
            panel.countLabel = Label("Count", content, font, new Vector2(780, 230), Vector2.zero, 190);
            panel.countLabel.color = new Color(0.95f, 0.56f, 0.05f, 1);
            panel.currentLabel = Label("Current", content, font, new Vector2(900, 70), new Vector2(0, -120), 50);
            var pill = Image("BestPill", content, Sprite("bg_Streak_Pill"), new Vector2(460, 90), new Vector2(0, -235));
            pill.pixelsPerUnitMultiplier = 127f / 45;
            pill.color = new Color(1, 0.99f, 0.96f, 1);
            panel.bestLabel = Label("Best", pill.transform, font, new Vector2(440, 80), Vector2.zero, 45);
            var week = Rect("Week", content, new Vector2(1000, 240), new Vector2(0, -450));
            panel.days = new Widget_StreakDay[7];
            var dayPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(dayPath);
            for (int i = 0; i < panel.days.Length; i++) {
                var day = (GameObject)PrefabUtility.InstantiatePrefab(dayPrefab, week);
                day.name = "Day" + (i + 1);
                var rect = day.GetComponent<RectTransform>();
                rect.anchoredPosition = new Vector2((i - 3) * 132, 0);
                panel.days[i] = day.GetComponent<Widget_StreakDay>();
            }
            panel.continueButton = Button("Continue", content, Sprite("btn_Streak_Continue"), new Vector2(620, 150), new Vector2(0, -730));
            panel.continueLabel = Label("Label", panel.continueButton.transform, font, new Vector2(540, 110), Vector2.zero, 56);
            panel.continueLabel.color = Color.white;
            var outline = panel.continueLabel.gameObject.AddComponent<UnityEngine.UI.Shadow>();
            outline.effectColor = new Color(0.76f, 0.45f, 0.16f, 1);
            outline.effectDistance = new Vector2(2, -3);
            panel.noticeLabel = Label("Notice", content, font, new Vector2(950, 115), new Vector2(0, -880), 32);
            var reward = Image("Reward", content, GameSprite("bg_Common_Popup"), new Vector2(830, 470), new Vector2(0, 60));
            reward.raycastTarget = true;
            panel.rewardRoot = reward.gameObject;
            panel.rewardLabel = Label("RewardText", reward.transform, font, new Vector2(750, 240), new Vector2(0, 65), 49);
            panel.claimButton = Button("Claim", reward.transform, GameSprite("btn_Common_Rounded_Yellow"), new Vector2(620, 130), new Vector2(0, -135));
            panel.claimLabel = Label("Label", panel.claimButton.transform, font, new Vector2(560, 110), Vector2.zero, 48);
            var recovery = Image("Recovery", content, GameSprite("bg_Common_Popup"), new Vector2(830, 540), new Vector2(0, 60));
            recovery.raycastTarget = true;
            panel.recoveryRoot = recovery.gameObject;
            panel.recoverLabel = Label("Description", recovery.transform, font, new Vector2(740, 160), new Vector2(0, 145), 52);
            panel.recoverButton = Button("Restore", recovery.transform, GameSprite("btn_Common_Rounded_Yellow"), new Vector2(680, 130), new Vector2(0, -30));
            panel.recoverButtonLabel = Label("Label", panel.recoverButton.transform, font, new Vector2(640, 110), Vector2.zero, 43);
            panel.dismissButton = Button("GiveUp", recovery.transform, GameSprite("bg_Common_Rounded"), new Vector2(680, 105), new Vector2(0, -165));
            panel.dismissLabel = Label("Label", panel.dismissButton.transform, font, new Vector2(640, 100), Vector2.zero, 43);
            reward.gameObject.SetActive(false);
            recovery.gameObject.SetActive(false);
            PrefabUtility.SaveAsPrefabAsset(root.gameObject, path);
            UnityEngine.Object.DestroyImmediate(root.gameObject);
        }

        static void CreatePlant(Panel_Streak panel, StreakConfigSO config) {
            var root = Rect("Plant", panel.contentRoot, Vector2.one * config.plantSize, config.plantPosition);
            var plant = root.gameObject.AddComponent<Widget_StreakPlant>();
            panel.plant = plant;
            plant.aura = Image("Aura", root, config.aura, Vector2.one * 1080, new Vector2(0, -30));
            plant.aura.color = config.auraColor;
            plant.motionRoot = Rect("Motion", root, Vector2.one * 600, new Vector2(0, -290));
            plant.motionRoot.pivot = new Vector2(0.5f, 0);
            plant.main = Image("Main", plant.motionRoot, config.plants[1], new Vector2(232, 175), Vector2.zero);
            plant.main.rectTransform.pivot = new Vector2(0.5f, 0);
            plant.main.rectTransform.anchorMin = new Vector2(0.5f, 0);
            plant.main.rectTransform.anchorMax = plant.main.rectTransform.anchorMin;
            plant.main.preserveAspect = true;
            plant.companions = new UnityEngine.UI.Image[6];
            for (int i = 0; i < plant.companions.Length; i++) {
                var sprite = i == 0 ? config.plants[1] : config.plants[5];
                float x = (i % 2 == 0 ? -1 : 1) * (160 + i / 2 * 85);
                float scale = i == 0 ? 0.6f : 0.7f;
                var image = Image("Companion" + i, plant.motionRoot, sprite, sprite.rect.size * scale, new Vector2(x, 0));
                image.rectTransform.pivot = new Vector2(0.5f, 0);
                image.rectTransform.anchorMin = new Vector2(0.5f, 0);
                image.rectTransform.anchorMax = image.rectTransform.anchorMin;
                image.preserveAspect = true;
                image.gameObject.SetActive(false);
                plant.companions[i] = image;
            }
            plant.main.transform.SetAsLastSibling();
            plant.petalRoot = Rect("PetalRing", plant.motionRoot, Vector2.one * config.flowerHeadSize, config.flowerHeadPosition);
            plant.petalRoot.anchorMin = new Vector2(0.5f, 0);
            plant.petalRoot.anchorMax = plant.petalRoot.anchorMin;
            plant.petals = new RectTransform[config.petalCount];
            for (int i = 0; i < plant.petals.Length; i++) {
                var axis = Rect("PetalAxis" + i, plant.petalRoot, Vector2.zero, Vector2.zero);
                axis.localRotation = Quaternion.Euler(0, 0, 360f * i / config.petalCount);
                var petal = Image("Petal", axis, config.petal, new Vector2(config.petalLength * config.petal.rect.width / config.petal.rect.height, config.petalLength), new Vector2(0, config.flowerHeadSize * config.petalOutset * 0.5f));
                petal.rectTransform.pivot = new Vector2(0.5f, 0);
                plant.petals[i] = axis;
            }
            plant.flowerHead = Image("Head", plant.petalRoot, config.flowerHead, Vector2.one * config.flowerHeadSize, Vector2.zero);
            plant.petalRoot.gameObject.SetActive(false);
            plant.butterflies = new UnityEngine.UI.Image[2];
            for (int i = 0; i < plant.butterflies.Length; i++) {
                plant.butterflies[i] = Image("Butterfly" + i, root, config.butterflies[i * 2], Vector2.one * 45, new Vector2(0, 150));
                plant.butterflies[i].preserveAspect = true;
                plant.butterflies[i].gameObject.SetActive(false);
            }
        }

        static void RegisterAssets(string panelPath) {
            var defaultObject = AssetDatabase.LoadAssetAtPath<AddressableAssetSettingsDefaultObject>("Assets/AddressableAssetsData/DefaultObject.asset");
            EditorBuildSettings.AddConfigObject(AddressableAssetSettingsDefaultObject.kDefaultConfigObjectName, defaultObject, true);
            var settings = AddressableAssetSettingsDefaultObject.Settings;
            var group = settings.FindGroup("Streak");
            if (group == null) {
                group = settings.CreateGroup("Streak", false, false, true, null, typeof(BundledAssetGroupSchema), typeof(ContentUpdateGroupSchema));
            }
            var schema = group.GetSchema<BundledAssetGroupSchema>();
            schema.BuildPath.SetVariableByName(settings, AddressableAssetSettings.kLocalBuildPath);
            schema.LoadPath.SetVariableByName(settings, AddressableAssetSettings.kLocalLoadPath);
            var paths = new List<string> { panelPath, "Assets/Res_Runtime/Config/StreakConfig.asset" };
            paths.AddRange(AssetDatabase.FindAssets("t:L10NSO", new[] { "Assets/Res_Runtime/Localization" })
                .Select(AssetDatabase.GUIDToAssetPath).Where(path => Path.GetFileName(path).StartsWith("Streak_", StringComparison.Ordinal)));
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
                case "btn_Streak_Continue":
                    return AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Res_Runtime/UI/Streak/new/btn_Streak_Continue.png") ?? throw new InvalidOperationException("Missing installed button: Assets/Res_Runtime/UI/Streak/new/btn_Streak_Continue.png");
            }
            var sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Res_Runtime/UI/Streak/" + name + ".png");
            if (sprite == null) {
                throw new InvalidOperationException("Missing streak sprite " + name);
            }
            return sprite;
        }

        static Sprite GameSprite(string name) {
            switch (name)
            {
                case "btn_Common_Rounded_Yellow":
                    return AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Res_Runtime/UI/Game/new/btn_Common_Rounded_Yellow.png") ?? throw new InvalidOperationException("Missing installed button: Assets/Res_Runtime/UI/Game/new/btn_Common_Rounded_Yellow.png");
                case "btn_Streak_Continue":
                    return AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Res_Runtime/UI/Streak/new/btn_Streak_Continue.png") ?? throw new InvalidOperationException("Missing installed button: Assets/Res_Runtime/UI/Streak/new/btn_Streak_Continue.png");
            }
            var sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Res_Runtime/UI/Game/" + name + ".png");
            if (sprite == null) {
                throw new InvalidOperationException("Missing shared game sprite " + name);
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
            if (sprite.border != Vector4.zero) {
                image.type = UnityEngine.UI.Image.Type.Sliced;
                image.pixelsPerUnitMultiplier = 2;
            }
            if (sprite != null && sprite.border != Vector4.zero &&
                AssetDatabase.GetAssetPath(sprite).Contains("/new/") &&
                (sprite.name == "btn_Streak_Continue" || sprite.name == "btn_Common_Rounded_Yellow"))
            {
                image.type = UnityEngine.UI.Image.Type.Sliced;
                image.preserveAspect = false;
                image.pixelsPerUnitMultiplier = sprite.rect.height / size.y;
            }
            return image;
        }

        static UnityEngine.UI.Button Button(string name, Transform parent, Sprite sprite, Vector2 size, Vector2 position) {
            var image = Image(name, parent, sprite, size, position);
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
            text.color = new Color(0.36f, 0.27f, 0.18f, 1);
            text.raycastTarget = false;
            var buttonImage = parent.GetComponent<UnityEngine.UI.Image>();
            if (buttonImage != null && buttonImage.sprite != null &&
                AssetDatabase.GetAssetPath(buttonImage.sprite).Contains("/new/") &&
                (buttonImage.sprite.name == "btn_Streak_Continue" || buttonImage.sprite.name == "btn_Common_Rounded_Yellow"))
            {
                text.color = new Color(0.32f, 0.22f, 0.12f);
            }
            return text;
        }
    }
}
