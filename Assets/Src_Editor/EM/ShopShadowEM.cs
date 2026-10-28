using System;
using UnityEditor;
using UnityEngine;

namespace Hamdoku.Editor {
    public static class ShopShadowEM {
        [MenuItem("Hamdoku/Setup/Apply Shop Shadows")]
        public static void Apply() {
            string path = "Assets/Res_Runtime/UI/Shop/Panel_Shop.prefab";
            var config = AssetDatabase.LoadAssetAtPath<ShopConfigSO>("Assets/Res_Runtime/Config/ShopConfig.asset");
            var shadow = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Res_Runtime/UI/Shop/new/ui_soft_shadow.png");
            if (config == null || shadow == null) {
                throw new InvalidOperationException("Shop shadow config or sprite is missing.");
            }
            var root = PrefabUtility.LoadPrefabContents(path);
            try {
                ApplyTo(root, config, shadow);
                PrefabUtility.SaveAsPrefabAsset(root, path);
            } finally {
                PrefabUtility.UnloadPrefabContents(root);
            }
        }

        public static void ApplyTo(GameObject root, ShopConfigSO config, Sprite shadow) {
            if (config.artShadowSteps < 1 || config.artShadowSpread < 0 || config.cardShadowSpread <= 0 ||
                config.tileShadowSpread <= 0 || config.adsButtonShadowSpread <= 0) {
                throw new InvalidOperationException("Invalid shop shadow configuration.");
            }
            var panel = root.GetComponent<Panel_Shop>();
            if (panel == null || panel.scroll == null) {
                throw new InvalidOperationException("Missing shop panel bindings.");
            }
            // Snapshot first: the added images must never become shadow targets themselves.
            var images = root.GetComponentsInChildren<UnityEngine.UI.Image>(true);
            foreach (var image in images) {
                var target = image.rectTransform;
                string name = target.name;
                if (name.EndsWith("SoftShadow", StringComparison.Ordinal) || name.Contains("DropShadow")) {
                    continue;
                }
                bool card = name == "StarterPack" || name == "SpecialOffer" || name == "RemoveAdsCard" ||
                    name == "MagnifierCard" || name == "HintCard";
                if (card) {
                    WrapLayoutCard(target, panel.scroll.content);
                    Soft(target, shadow, config.cardShadowColor, config.cardShadowOffset, config.cardShadowSpread);
                } else if (name.StartsWith("Benefit", StringComparison.Ordinal) ||
                    (name.StartsWith("Product", StringComparison.Ordinal) && target.GetComponent<Widget_ShopProduct>() != null)) {
                    bool ads = target.parent.name == "RemoveAdsCard";
                    Soft(target, shadow, ads ? config.adsButtonShadowColor : config.tileShadowColor,
                        ads ? config.adsButtonShadowOffset : config.tileShadowOffset,
                        ads ? config.adsButtonShadowSpread : config.tileShadowSpread);
                } else if (name == "Buy" || name == "Restore" ||
                    (name == "Close" && target.parent.name == "Box")) {
                    Soft(target, shadow, config.adsButtonShadowColor, config.adsButtonShadowOffset, config.adsButtonShadowSpread);
                } else if (name == "Art" || (name == "Icon" &&
                    (target.parent.name == "MagnifierCard" || target.parent.name == "HintCard"))) {
                    Art(image, config);
                }
            }
        }

        static void WrapLayoutCard(RectTransform target, RectTransform content) {
            if (target.parent != content) {
                if (target.parent.name != target.name + "ShadowGroup") {
                    throw new InvalidOperationException("Unexpected shop card parent: " + target.name);
                }
                return;
            }
            var wrapper = NewRect(target.name + "ShadowGroup", content);
            CopyRect(target, wrapper);
            wrapper.SetSiblingIndex(target.GetSiblingIndex());
            target.SetParent(wrapper, false);
            target.anchorMin = Vector2.one * .5f;
            target.anchorMax = target.anchorMin;
            target.pivot = Vector2.one * .5f;
            target.anchoredPosition = Vector2.zero;
            // The group occupies the original layout slot; shadows do not affect scroll height.
        }

        static void Soft(RectTransform target, Sprite sprite, Color color, Vector2 offset, float spread) {
            var rect = ShadowRect(target, target.name + "SoftShadow");
            rect.sizeDelta = target.sizeDelta + Vector2.one * (spread * 2);
            rect.anchoredPosition = target.anchoredPosition + offset;
            var image = rect.GetComponent<UnityEngine.UI.Image>();
            image.sprite = sprite;
            image.type = UnityEngine.UI.Image.Type.Sliced;
            image.pixelsPerUnitMultiplier = 1;
            image.color = color;
        }

        static void Art(UnityEngine.UI.Image target, ShopConfigSO config) {
            if (target.sprite == null) {
                throw new InvalidOperationException("Shop art sprite is missing.");
            }
            Color color = config.artShadowColor;
            // Keep combined coverage at the configured opacity rather than multiplying it by six.
            color.a = 1 - Mathf.Pow(1 - color.a, 1f / config.artShadowSteps);
            for (int i = 0; i < config.artShadowSteps; i++) {
                float angle = i * Mathf.PI * 2 / config.artShadowSteps;
                var offset = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * config.artShadowSpread;
                var rect = ShadowRect(target.rectTransform, target.name + "DropShadow" + i);
                rect.anchoredPosition = target.rectTransform.anchoredPosition + config.artShadowOffset + offset;
                var image = rect.GetComponent<UnityEngine.UI.Image>();
                image.sprite = target.sprite;
                image.type = target.type;
                image.preserveAspect = target.preserveAspect;
                image.color = color;
            }
        }

        static RectTransform ShadowRect(RectTransform target, string name) {
            var parent = target.parent;
            var existing = parent.Find(name);
            var rect = existing == null ? NewRect(name, parent) : existing.GetComponent<RectTransform>();
            CopyRect(target, rect);
            int targetIndex = target.GetSiblingIndex();
            if (rect.GetSiblingIndex() < targetIndex) {
                targetIndex--;
            }
            rect.SetSiblingIndex(targetIndex);
            var image = rect.GetComponent<UnityEngine.UI.Image>();
            if (image == null) {
                image = rect.gameObject.AddComponent<UnityEngine.UI.Image>();
            }
            image.raycastTarget = false;
            return rect;
        }

        static RectTransform NewRect(string name, Transform parent) {
            var rect = new GameObject(name, typeof(RectTransform)).GetComponent<RectTransform>();
            rect.gameObject.layer = parent.gameObject.layer;
            rect.SetParent(parent, false);
            return rect;
        }

        static void CopyRect(RectTransform source, RectTransform target) {
            target.anchorMin = source.anchorMin;
            target.anchorMax = source.anchorMax;
            target.pivot = source.pivot;
            target.sizeDelta = source.sizeDelta;
            target.anchoredPosition3D = source.anchoredPosition3D;
            target.localRotation = source.localRotation;
            target.localScale = source.localScale;
        }
    }
}
