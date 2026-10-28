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
    public static class ShopSetupEM {
        [MenuItem("Hamdoku/Setup/Configure Shop")]
        public static void Setup() {
            ImportSprites();
            var config = CreateConfig();
            BakeFonts();
            string path = "Assets/Res_Runtime/UI/Shop/Panel_Shop.prefab";
            if (AssetDatabase.LoadAssetAtPath<GameObject>(path) == null) {
                CreatePanel(path, config);
            }
            var settings = AddressableAssetSettingsDefaultObject.Settings;
            var paths = new[] { path, "Assets/Res_Runtime/Config/ShopConfig.asset" }.Concat(
                AssetDatabase.FindAssets("t:L10NSO", new[] { "Assets/Res_Runtime/Localization" }).Select(AssetDatabase.GUIDToAssetPath)
                .Where(p => Path.GetFileName(p).StartsWith("Shop_")));
            foreach (string asset in paths) {
                var entry = settings.CreateOrMoveEntry(AssetDatabase.AssetPathToGUID(asset), settings.DefaultGroup);
                entry.SetLabel(AAConst.LABEL_DEFAULT, true, true);
            }
            EditorUtility.SetDirty(settings);
            AssetDatabase.SaveAssets();
            Debug.Log("[ShopSetup] Saved production shop prefab, original sprites, SO, localized texts and default registrations.");
        }

        static void ImportSprites() {
            foreach (string path in Directory.GetFiles("Assets/Res_Runtime/UI/Shop/new", "*.png")) {
                var importer = (TextureImporter)AssetImporter.GetAtPath(path);
                var settings = new TextureImporterSettings();
                importer.ReadTextureSettings(settings);
                settings.textureType = TextureImporterType.Sprite;
                settings.spriteMode = (int)SpriteImportMode.Single;
                settings.spriteMeshType = SpriteMeshType.FullRect;
                settings.spritePixelsPerUnit = 100;
                settings.spriteBorder = OriginalBorder(Path.GetFileNameWithoutExtension(path));
                settings.alphaIsTransparency = true;
                settings.mipmapEnabled = false;
                importer.SetTextureSettings(settings);
                importer.textureCompression = TextureImporterCompression.Uncompressed;
                importer.maxTextureSize = 2048;
                switch (Path.GetFileNameWithoutExtension(path))
                {
                    case "shop_btn_magnifier":
                        importer.spriteBorder = new Vector4(104f, 80f, 104f, 79f);
                        break;
                    case "shop_btn_pink":
                        importer.spriteBorder = new Vector4(104f, 80f, 104f, 79f);
                        break;
                    case "shop_btn_special_offer":
                        importer.spriteBorder = new Vector4(104f, 80f, 104f, 79f);
                        break;
                }
                importer.SaveAndReimport();
            }
        }

        static Vector4 OriginalBorder(string name) {
            switch (name) {
                case "shop_card_pink": return new Vector4(337, 34, 34, 60);
                case "shop_card_yellow": return new Vector4(331, 34, 34, 60);
                case "shop_btn_pink": return Vector4.one * 67;
                case "shop_btn_special_offer": return Vector4.one * 67;
                case "shop_btn_magnifier": return Vector4.one * 58;
                case "shop_pad_ads": return new Vector4(52, 52, 52, 119);
                case "shop_pad_magnifier": return new Vector4(52, 52, 52, 119);
                case "shop_pad_hint": return new Vector4(52, 52, 52, 119);
                case "shop_timer_badge_special_offer": return new Vector4(80, 16, 80, 16);
                case "shop_btn_hint": return Vector4.one * 58;
                case "shop_tab_magnifier": return new Vector4(48, 45, 48, 45);
                case "shop_tab_hint": return new Vector4(48, 45, 48, 45);
                case "shop_section_panel": return Vector4.one * 44;
                default: return Vector4.zero;
            }
        }

        static ShopConfigSO CreateConfig() {
            string path = "Assets/Res_Runtime/Config/ShopConfig.asset";
            var config = AssetDatabase.LoadAssetAtPath<ShopConfigSO>(path);
            if (config != null) {
                return config;
            }
            config = ScriptableObject.CreateInstance<ShopConfigSO>();
            // Product values below are imported from the original catalog. Upper-card display overrides
            // follow the user's screenshot; see Logs/ShopMigration/source.json for both versions.
            config.products = ImportedProducts();
            AssetDatabase.CreateAsset(config, path);
            return config;
        }

        static ShopProductModel[] ImportedProducts() {
            return new ShopProductModel[] {
                new ShopProductModel { id = 1, productId = "starter_pack", sku = "hamdoku_tier3", section = ShopSectionType.Starter, name = UINameType.Shop_Starter, description = UINameType.Shop_StarterDescription, duration = UINameType.Shop_Forever, referencePrice = "JP¥1,100", magnifiers = 5, hints = 5, adFreeHours = 0, adFreeForever = true, autoMark = true, maxPurchases = 1, offerHours = 0, offerCooldownHours = 0 },
                new ShopProductModel { id = 2, productId = "special_offer", sku = "hamdoku_tier6", section = ShopSectionType.Special, name = UINameType.Shop_Special, description = UINameType.Shop_SpecialDescription, duration = UINameType.Shop_Forever, referencePrice = "JP¥2,280", magnifiers = 40, hints = 40, adFreeHours = 0, adFreeForever = true, autoMark = true, maxPurchases = 1, offerHours = 12, offerCooldownHours = 44 },
                new ShopProductModel { id = 3, productId = "remove_ads_1d", sku = "hamdoku_tier1", section = ShopSectionType.RemoveAds, name = UINameType.Shop_Ads, description = UINameType.Shop_AdsDescription, duration = UINameType.Shop_Day, referencePrice = "JP¥210", magnifiers = 0, hints = 0, adFreeHours = 24, adFreeForever = false, autoMark = false, maxPurchases = 0, offerHours = 0, offerCooldownHours = 0 },
                new ShopProductModel { id = 4, productId = "remove_ads_1w", sku = "hamdoku_tier2", section = ShopSectionType.RemoveAds, name = UINameType.Shop_Ads, description = UINameType.Shop_AdsDescription, duration = UINameType.Shop_Week, referencePrice = "JP¥650", magnifiers = 0, hints = 0, adFreeHours = 168, adFreeForever = false, autoMark = false, maxPurchases = 0, offerHours = 0, offerCooldownHours = 0 },
                new ShopProductModel { id = 5, productId = "remove_ads_forever", sku = "hamdoku_tier5", section = ShopSectionType.RemoveAds, name = UINameType.Shop_Ads, description = UINameType.Shop_AdsDescription, duration = UINameType.Shop_Forever, referencePrice = "JP¥1,580", magnifiers = 0, hints = 0, adFreeHours = 0, adFreeForever = true, autoMark = true, maxPurchases = 1, offerHours = 0, offerCooldownHours = 0 },
                new ShopProductModel { id = 6, productId = "magnifier_5", sku = "hamdoku_tier1", section = ShopSectionType.Magnifier, name = UINameType.Shop_Magnifier, description = UINameType.Shop_MagnifierDescription, duration = UINameType.None, referencePrice = "US$1.19", magnifiers = 5, hints = 0, adFreeHours = 0, adFreeForever = false, autoMark = false, maxPurchases = 0, offerHours = 0, offerCooldownHours = 0 },
                new ShopProductModel { id = 7, productId = "magnifier_20", sku = "hamdoku_tier2", section = ShopSectionType.Magnifier, name = UINameType.Shop_Magnifier, description = UINameType.Shop_MagnifierDescription, duration = UINameType.None, referencePrice = "US$3.69", magnifiers = 20, hints = 0, adFreeHours = 0, adFreeForever = false, autoMark = false, maxPurchases = 0, offerHours = 0, offerCooldownHours = 0 },
                new ShopProductModel { id = 8, productId = "magnifier_50", sku = "hamdoku_tier4", section = ShopSectionType.Magnifier, name = UINameType.Shop_Magnifier, description = UINameType.Shop_MagnifierDescription, duration = UINameType.None, referencePrice = "US$8.99", magnifiers = 50, hints = 0, adFreeHours = 0, adFreeForever = false, autoMark = false, maxPurchases = 0, offerHours = 0, offerCooldownHours = 0 },
                new ShopProductModel { id = 9, productId = "hint_5", sku = "hamdoku_tier1", section = ShopSectionType.Hint, name = UINameType.Shop_Hint, description = UINameType.Shop_HintDescription, duration = UINameType.None, referencePrice = "US$1.19", magnifiers = 0, hints = 5, adFreeHours = 0, adFreeForever = false, autoMark = false, maxPurchases = 0, offerHours = 0, offerCooldownHours = 0 },
                new ShopProductModel { id = 10, productId = "hint_20", sku = "hamdoku_tier2", section = ShopSectionType.Hint, name = UINameType.Shop_Hint, description = UINameType.Shop_HintDescription, duration = UINameType.None, referencePrice = "US$3.69", magnifiers = 0, hints = 20, adFreeHours = 0, adFreeForever = false, autoMark = false, maxPurchases = 0, offerHours = 0, offerCooldownHours = 0 },
                new ShopProductModel { id = 11, productId = "hint_50", sku = "hamdoku_tier4", section = ShopSectionType.Hint, name = UINameType.Shop_Hint, description = UINameType.Shop_HintDescription, duration = UINameType.None, referencePrice = "US$8.99", magnifiers = 0, hints = 50, adFreeHours = 0, adFreeForever = false, autoMark = false, maxPurchases = 0, offerHours = 0, offerCooldownHours = 0 },
            };
        }

        static void BakeFonts() {
            var entries = AssetDatabase.FindAssets("t:L10NSO", new[] { "Assets/Res_Runtime/Localization" }).Select(
                guid => AssetDatabase.LoadAssetAtPath<L10NSO>(AssetDatabase.GUIDToAssetPath(guid))).ToArray();
            foreach (string language in new[] { "Chinese", "English" }) {
                var font = AssetDatabase.LoadAssetAtPath<TMP_FontAsset>("Assets/Res_Runtime/Font/" + language + " SDF.asset");
                string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789 /:+.-¥" +
                    string.Concat(entries.Select(e => language == "Chinese" ? e.chinese : e.english));
                characters = Regex.Replace(characters, "<[^>]*>|\\{[^}]*\\}", string.Empty).Replace("\n", string.Empty).Replace("\r", string.Empty);
                if (!font.HasCharacters(characters)) {
                    var serialized = new SerializedObject(font);
                    var source = AssetDatabase.LoadAssetAtPath<Font>(AssetDatabase.GUIDToAssetPath(serialized.FindProperty("m_SourceFontFileGUID").stringValue));
                    if (source == null) {
                        throw new InvalidOperationException("Missing shop font source " + language);
                    }
                    serialized.FindProperty("m_SourceFontFile").objectReferenceValue = source;
                    serialized.ApplyModifiedPropertiesWithoutUndo();
                    font.atlasPopulationMode = AtlasPopulationMode.Dynamic;
                    font.isMultiAtlasTexturesEnabled = true;
                    try {
                        if (!font.TryAddCharacters(characters, out string missing)) {
                            throw new InvalidOperationException("Shop glyphs unavailable: " + missing);
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

        static void CreatePanel(string path, ShopConfigSO config) {
            var labels = new List<TMP_Text>();
            var ids = new List<UINameType>();
            var widgets = new List<Widget_ShopProduct>();
            var font = AssetDatabase.LoadAssetAtPath<TMP_FontAsset>("Assets/Res_Runtime/Font/Chinese SDF.asset");
            var root = Rect("Panel_Shop", null, Vector2.zero, Vector2.zero);
            Stretch(root);
            var panel = root.gameObject.AddComponent<Panel_Shop>();
            var background = Image("Background", root, Sprite("bg_Common_Game"), new Vector2(1080, 1920), Vector2.zero);
            background.raycastTarget = true;
            var fitter = background.gameObject.AddComponent<UnityEngine.UI.AspectRatioFitter>();
            fitter.aspectMode = UnityEngine.UI.AspectRatioFitter.AspectMode.EnvelopeParent;
            fitter.aspectRatio = background.sprite.rect.width / background.sprite.rect.height;
            panel.safeRoot = Rect("SafeArea", root, Vector2.zero, Vector2.zero);
            Stretch(panel.safeRoot);
            var layout = Rect("Layout", panel.safeRoot, new Vector2(config.referenceWidth, 1920), Vector2.zero);
            panel.layoutRoot = layout;
            var bannerSprite = Sprite("shop_title_banner");
            float bannerHeight = config.titleBannerWidth * bannerSprite.rect.height / bannerSprite.rect.width;
            var banner = Image("Header", layout, bannerSprite, new Vector2(config.titleBannerWidth, bannerHeight), new Vector2(0, -bannerHeight / 2 - 8));
            Top(banner.rectTransform);
            Localized("Title", banner.transform, font, new Vector2(500, 110), new Vector2(0, -55), config.titleFs, UINameType.Shop_Title, labels, ids);
            panel.closeButton = Hit(Image("Close", layout, Sprite("icon_close"), Vector2.one * config.closeSize, Vector2.zero));
            var close = panel.closeButton.GetComponent<RectTransform>();
            close.anchorMin = Vector2.one;
            close.anchorMax = Vector2.one;
            close.pivot = Vector2.one;
            close.anchoredPosition = new Vector2(-20, -12);
            var scrollRoot = Rect("ScrollView", layout, Vector2.zero, Vector2.zero);
            Stretch(scrollRoot);
            scrollRoot.offsetMin = new Vector2(0, config.padBottom);
            scrollRoot.offsetMax = new Vector2(0, -config.headerHeight);
            panel.scroll = scrollRoot.gameObject.AddComponent<UnityEngine.UI.ScrollRect>();
            var viewport = Image("Viewport", scrollRoot, null, Vector2.zero, Vector2.zero);
            Stretch(viewport.rectTransform);
            viewport.raycastTarget = true;
            viewport.gameObject.AddComponent<UnityEngine.UI.Mask>().showMaskGraphic = false;
            var content = Rect("Content", viewport.transform, Vector2.zero, Vector2.zero);
            content.anchorMin = new Vector2(0, 1);
            content.anchorMax = Vector2.one;
            content.pivot = new Vector2(.5f, 1);
            var group = content.gameObject.AddComponent<UnityEngine.UI.VerticalLayoutGroup>();
            group.childAlignment = TextAnchor.UpperCenter;
            group.childControlWidth = false;
            group.childControlHeight = false;
            group.childForceExpandWidth = false;
            group.childForceExpandHeight = false;
            group.spacing = config.cardGap;
            group.padding = new RectOffset(0, 0, (int)config.padTop, (int)config.padBottom);
            content.gameObject.AddComponent<UnityEngine.UI.ContentSizeFitter>().verticalFit = UnityEngine.UI.ContentSizeFitter.FitMode.PreferredSize;
            panel.scroll.viewport = viewport.rectTransform;
            panel.scroll.content = content;
            panel.scroll.horizontal = false;
            panel.scroll.movementType = UnityEngine.UI.ScrollRect.MovementType.Clamped;
            panel.scroll.scrollSensitivity = 45;
            float width = config.columnWidth - config.padSide * 2;
            foreach (var product in config.products) {
                if (product.section == ShopSectionType.Starter || product.section == ShopSectionType.Special) {
                    BuildOffer(panel, content, product, config, width, font, widgets, labels, ids);
                }
            }
            BuildItems(content, ShopSectionType.RemoveAds, config, width, font, widgets, labels, ids);
            BuildItems(content, ShopSectionType.Magnifier, config, width, font, widgets, labels, ids);
            BuildItems(content, ShopSectionType.Hint, config, width, font, widgets, labels, ids);
            var footer = Rect("BottomLinks", content, new Vector2(width, 360), Vector2.zero);
            Localized("ReferencePrices", footer, font, new Vector2(width - 50, 100), new Vector2(0, 120), 27, UINameType.Shop_ReferencePrice, labels, ids);
            panel.restoreButton = Hit(Image("Restore", footer, Sprite("bg_Common_Rounded"), new Vector2(500, 85), new Vector2(0, 10)));
            Localized("Label", panel.restoreButton.transform, font, new Vector2(460, 70), Vector2.zero, 34, UINameType.Shop_Restore, labels, ids);
            Localized("RestoreNote", footer, font, new Vector2(width - 50, 100), new Vector2(0, -110), 26, UINameType.Shop_RestoreNote, labels, ids);
            BuildDialog(panel, layout, config, font, labels, ids);
            panel.products = widgets.OrderBy(w => w.productId).ToArray();
            panel.textLabels = labels.ToArray();
            panel.textIds = ids.ToArray();
            PrefabUtility.SaveAsPrefabAsset(root.gameObject, path);
            UnityEngine.Object.DestroyImmediate(root.gameObject);
        }

        static void BuildOffer(Panel_Shop panel, Transform parent, ShopProductModel product, ShopConfigSO config, float width,
            TMP_FontAsset font, List<Widget_ShopProduct> widgets, List<TMP_Text> labels, List<UINameType> ids) {
            bool special = product.section == ShopSectionType.Special;
            var card = Image(special ? "SpecialOffer" : "StarterPack", parent, Sprite(special ? "shop_card_yellow" : "shop_card_pink"), new Vector2(width, config.offerCardH), Vector2.zero);
            card.pixelsPerUnitMultiplier = 1.3f;
            var widget = card.gameObject.AddComponent<Widget_ShopProduct>();
            widget.productId = product.id;
            widgets.Add(widget);
            var badge = Localized("Badge", card.transform, font, new Vector2(240, 43), new Vector2(-width / 2 + 145, config.offerCardH / 2 - 17), 26,
                special ? UINameType.Shop_BestBadge : UINameType.Shop_FirstBadge, labels, ids);
            badge.color = Color.white;
            var title = Localized("Title", card.transform, font, new Vector2(600, 75), new Vector2(-width / 2 + 345, config.offerCardH / 2 - 92), config.offerTitleFs, product.name, labels, ids);
            title.alignment = TextAlignmentOptions.MidlineLeft;
            Image("Art", card.transform, Sprite(special ? "offer_art_special_offer" : "offer_art_starter_pack"), Vector2.one * config.offerArtSize, new Vector2(-width / 2 + 160, -35));
            for (int i = 0; i < 4; i++) {
                float x = -width / 2 + 360 + i * (config.offerTileW + config.offerTileGap);
                var tile = Image("Benefit" + i, card.transform, Sprite("bg_Common_Rounded"), new Vector2(config.offerTileW, 150), new Vector2(x, 30));
                Image("Icon", tile.transform, Sprite(i == 0 ? "shop_magnifier" : i == 1 ? "shop_hint" : i == 2 ? "shop_remove_ads" : "icon_autox"), Vector2.one * 94, new Vector2(0, 18));
                var count = Label("Count", tile.transform, font, new Vector2(110, 45), new Vector2(0, -49), 27);
                if (i == 0) {
                    widget.magnifierLabel = count;
                    count.text = product.magnifiers.ToString();
                    widget.infoButton = Hit(tile);
                } else if (i == 1) {
                    widget.hintLabel = count;
                    count.text = product.hints.ToString();
                } else {
                    labels.Add(count);
                    ids.Add(i == 2 ? UINameType.Shop_Forever : UINameType.Shop_AutoLabel);
                    if (i == 3) {
                        widget.autoButton = Hit(tile);
                        var info = Image("InfoBadge", tile.transform, Sprite("bg_Game_Circle"), Vector2.one * 46, new Vector2(53, 70));
                        Label("I", info.transform, font, Vector2.one * 40, Vector2.zero, 32).text = "i";
                    }
                }
            }
            Localized("AdsNote", card.transform, font, new Vector2(500, 80), new Vector2(140, -90), 25, UINameType.Shop_OfferNote, labels, ids);
            widget.buyButton = Hit(Image("Buy", card.transform, Sprite(special ? "shop_btn_special_offer" : "shop_btn_pink"), new Vector2(290, 90), new Vector2(width / 2 - 175, -config.offerCardH / 2 + 68)));
            widget.priceLabel = Label("Price", widget.buyButton.transform, font, new Vector2(270, 75), Vector2.zero, config.offerPriceFs);
            widget.priceLabel.color = Color.white;
            widget.priceLabel.fontStyle = FontStyles.Bold;
            widget.priceLabel.text = product.referencePrice;
            if (special) {
                var timer = Image("Timer", card.transform, Sprite("shop_timer_badge_special_offer"), new Vector2(210, 55), new Vector2(width / 2 - 127, config.offerCardH / 2 - 66));
                Image("Icon", timer.transform, Sprite("shop_timer_icon"), Vector2.one * 34, new Vector2(-77, 0));
                panel.timerLabel = Label("Time", timer.transform, font, new Vector2(160, 44), new Vector2(15, 0), 27);
            }
        }

        static void BuildItems(Transform parent, ShopSectionType section, ShopConfigSO config, float width, TMP_FontAsset font,
            List<Widget_ShopProduct> widgets, List<TMP_Text> labels, List<UINameType> ids) {
            bool ads = section == ShopSectionType.RemoveAds;
            bool hint = section == ShopSectionType.Hint;
            float height = ads ? config.adsCardH : config.itemCardH;
            var card = Image(section + "Card", parent, Sprite("bg_Common_Rounded"), new Vector2(width, height), Vector2.zero);
            card.color = new Color(1, .99f, .96f);
            Image("Icon", card.transform, Sprite(ads ? "shop_remove_ads" : hint ? "shop_hint" : "shop_magnifier"), Vector2.one * 150, new Vector2(-width / 2 + 110, height / 2 - 120));
            var title = Localized("Title", card.transform, font, new Vector2(560, 65), new Vector2(90, height / 2 - 85), config.adsTitleFs,
                ads ? UINameType.Shop_Ads : hint ? UINameType.Shop_Hint : UINameType.Shop_Magnifier, labels, ids);
            title.alignment = TextAlignmentOptions.MidlineLeft;
            var desc = Localized("Description", card.transform, font, new Vector2(560, 100), new Vector2(90, height / 2 - 160), config.adsDescFs,
                ads ? UINameType.Shop_AdsDescription : hint ? UINameType.Shop_HintDescription : UINameType.Shop_MagnifierDescription, labels, ids);
            desc.alignment = TextAlignmentOptions.TopLeft;
            int index = 0;
            foreach (var product in config.products.Where(p => p.section == section)) {
                var tile = Image("Product" + product.id, card.transform, Sprite(ads ? "shop_pad_ads" : hint ? "shop_pad_hint" : "shop_pad_magnifier"), new Vector2(240, 190), new Vector2(-260 + index++ * 260, -height / 2 + 140));
                var widget = tile.gameObject.AddComponent<Widget_ShopProduct>();
                widget.productId = product.id;
                widgets.Add(widget);
                widget.buyButton = Hit(tile);
                if (ads) {
                    var duration = Localized("Duration", tile.transform, font, new Vector2(220, 45), new Vector2(0, 65), 30, product.duration, labels, ids);
                    duration.color = Color.white;
                    var durationIcon = Image("DurationIcon", tile.transform, Sprite(product.adFreeForever ? "icon_infinity" : "icon_calendar"), Vector2.one * 52, new Vector2(0, 3));
                    durationIcon.color = new Color(1, .48f, .6f);
                } else {
                    var count = Label("Count", tile.transform, font, new Vector2(210, 45), new Vector2(0, 65), 31);
                    count.color = Color.white;
                    count.text = (hint ? product.hints : product.magnifiers).ToString();
                    Image("Item", tile.transform, Sprite(hint ? "shop_hint" : "shop_magnifier"), Vector2.one * 65, new Vector2(0, 0));
                }
                widget.priceLabel = Label("Price", tile.transform, font, new Vector2(225, 50), new Vector2(0, -65), config.adsPriceFs);
                widget.priceLabel.text = product.referencePrice;
                widget.priceLabel.fontStyle = FontStyles.Bold;
            }
        }

        static void BuildDialog(Panel_Shop panel, Transform parent, ShopConfigSO config, TMP_FontAsset font,
            List<TMP_Text> labels, List<UINameType> ids) {
            var overlay = Image("Dialog", parent, null, Vector2.zero, Vector2.zero);
            Stretch(overlay.rectTransform);
            overlay.color = new Color(.23f, .16f, .1f, .6f);
            overlay.raycastTarget = true;
            panel.dialogRoot = overlay.gameObject;
            var box = Image("Box", overlay.transform, Sprite("bg_Common_Rounded"), new Vector2(config.dialogWidth, config.dialogHeight), Vector2.zero);
            panel.dialogBox = box.rectTransform;
            panel.dialogTitle = Label("Title", box.transform, font, new Vector2(730, 100), new Vector2(0, 440), 60);
            panel.dialogBody = Label("Description", box.transform, font, new Vector2(730, 560), new Vector2(0, 50), 40);
            panel.dialogBody.alignment = TextAlignmentOptions.Center;
            panel.dialogCloseButton = Hit(Image("Close", box.transform, Sprite("shop_btn_magnifier"), new Vector2(320, 100), new Vector2(0, -450)));
            panel.dialogCloseLabel = Label("Label", panel.dialogCloseButton.transform, font, new Vector2(290, 80), Vector2.zero, 40);
            panel.dialogBuyButton = Hit(Image("Buy", box.transform, Sprite("shop_btn_pink"), new Vector2(320, 100), new Vector2(0, -320)));
            panel.dialogPrice = Label("Price", panel.dialogBuyButton.transform, font, new Vector2(290, 80), Vector2.zero, 40);
            panel.dialogPrice.color = Color.white;
            var demo = Rect("AutoMarkDemo", box.transform, new Vector2(500, 500), new Vector2(0, 75));
            panel.demoRoot = demo.gameObject;
            var crosses = new List<GameObject>();
            for (int row = 0; row < 5; row++) {
                for (int column = 0; column < 5; column++) {
                    var tile = Image("Cell" + (row * 5 + column), demo, Sprite("bg_Common_Rounded"), Vector2.one * 92, new Vector2((column - 2) * 98, (2 - row) * 98));
                    tile.color = row == 2 ? new Color(1, .79f, .49f) : new Color(.72f, .88f, .85f);
                    if (row == 2 && column == 2) {
                        Image("Hamster", tile.transform, Sprite("Img_Game_Hamster"), Vector2.one * 85, Vector2.zero);
                    } else if (row == 2 || column == 2 || (Mathf.Abs(row - 2) == 1 && Mathf.Abs(column - 2) == 1)) {
                        var cross = Image("Cross", tile.transform, Sprite("icon_autox"), Vector2.one * 65, Vector2.zero);
                        crosses.Add(cross.gameObject);
                    }
                }
            }
            panel.demoCrosses = crosses.ToArray();
            demo.gameObject.SetActive(false);
            overlay.gameObject.SetActive(false);
        }

        static Sprite Sprite(string name) {
            switch (name)
            {
                case "shop_btn_magnifier":
                    return AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Res_Runtime/UI/Shop/new/shop_btn_magnifier.png") ?? throw new InvalidOperationException("Missing installed button: Assets/Res_Runtime/UI/Shop/new/shop_btn_magnifier.png");
                case "shop_btn_pink":
                    return AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Res_Runtime/UI/Shop/new/shop_btn_pink.png") ?? throw new InvalidOperationException("Missing installed button: Assets/Res_Runtime/UI/Shop/new/shop_btn_pink.png");
                case "shop_btn_special_offer":
                    return AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Res_Runtime/UI/Shop/new/shop_btn_special_offer.png") ?? throw new InvalidOperationException("Missing installed button: Assets/Res_Runtime/UI/Shop/new/shop_btn_special_offer.png");
            }
            foreach (string folder in new[] { "Shop/new", "Game", "Home", "Profile", "Streak" }) {
                var sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Res_Runtime/UI/" + folder + "/" + name + ".png");
                if (sprite != null) {
                    return sprite;
                }
            }
            throw new InvalidOperationException("Missing shop sprite " + name);
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
        static void Top(RectTransform rect) {
            rect.anchorMin = new Vector2(.5f, 1);
            rect.anchorMax = rect.anchorMin;
        }
        static UnityEngine.UI.Image Image(string name, Transform parent, Sprite sprite, Vector2 size, Vector2 position) {
            var image = Rect(name, parent, size, position).gameObject.AddComponent<UnityEngine.UI.Image>();
            image.sprite = sprite;
            image.raycastTarget = false;
            image.preserveAspect = sprite != null && sprite.border == Vector4.zero;
            if (sprite != null && sprite.border != Vector4.zero) {
                image.type = UnityEngine.UI.Image.Type.Sliced;
            }
            if (sprite != null && sprite.border != Vector4.zero &&
                AssetDatabase.GetAssetPath(sprite).Contains("/new/") &&
                (sprite.name == "shop_btn_magnifier" || sprite.name == "shop_btn_pink" || sprite.name == "shop_btn_special_offer"))
            {
                image.type = UnityEngine.UI.Image.Type.Sliced;
                image.preserveAspect = false;
                image.pixelsPerUnitMultiplier = sprite.rect.height / size.y;
            }
            return image;
        }
        static UnityEngine.UI.Button Hit(UnityEngine.UI.Image image) {
            image.raycastTarget = true;
            var button = image.gameObject.AddComponent<UnityEngine.UI.Button>();
            button.targetGraphic = image;
            return button;
        }
        static TMP_Text Label(string name, Transform parent, TMP_FontAsset font, Vector2 size, Vector2 position, float fontSize) {
            var text = Rect(name, parent, size, position).gameObject.AddComponent<TextMeshProUGUI>();
            text.font = font;
            text.fontSize = fontSize;
            text.fontSizeMin = fontSize * .65f;
            text.fontSizeMax = fontSize;
            text.enableAutoSizing = true;
            text.alignment = TextAlignmentOptions.Center;
            text.color = new Color(.32f, .22f, .12f);
            text.raycastTarget = false;
            text.richText = false;
            var buttonImage = parent.GetComponent<UnityEngine.UI.Image>();
            if (buttonImage != null && buttonImage.sprite != null &&
                AssetDatabase.GetAssetPath(buttonImage.sprite).Contains("/new/") &&
                (buttonImage.sprite.name == "shop_btn_magnifier" || buttonImage.sprite.name == "shop_btn_pink" || buttonImage.sprite.name == "shop_btn_special_offer"))
            {
                text.color = new Color(0.32f, 0.22f, 0.12f);
            }
            return text;
        }
        static TMP_Text Localized(string name, Transform parent, TMP_FontAsset font, Vector2 size, Vector2 position,
            float fontSize, UINameType id, List<TMP_Text> labels, List<UINameType> ids) {
            var text = Label(name, parent, font, size, position, fontSize);
            var entry = AssetDatabase.LoadAssetAtPath<L10NSO>("Assets/Res_Runtime/Localization/" + id + ".asset");
            text.text = entry.chinese;
            labels.Add(text);
            ids.Add(id);
            return text;
        }
    }
}
