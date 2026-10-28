using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
namespace Hamdoku.Editor {
    public static class GameAnimationSetupEM {
        [MenuItem("Hamdoku/Setup/Configure Board Animation")]
        public static void Apply() {
            var config = AssetDatabase.LoadAssetAtPath<PuzzlePresentationSO>("Assets/Res_Runtime/Config/PuzzlePresentation.asset");
            config.hamsterIdleFrames = new Sprite[8];
            for (int i = 0; i < 8; i++) {
                config.hamsterIdleFrames[i] = Frame("hamster_idle_" + (i + 1).ToString("00"));
            }
            config.hamsterAppearFrame = Frame("hamster_appear_01");
            config.hamsterWrongFrame = Frame("hamster_wrong_01");
            // Serialized original HamsterAnimator__sharedassets2.assets__32.json.
            config.hamsterIdleFrameSeconds = 0.35f;
            config.hamsterAppearSeconds = 0.4f;
            config.hamsterWrongSeconds = 1;
            config.hamsterWrongShake = 8;
            config.hamsterBobSpeed = 2.6f;
            config.hamsterBobHeight = 7;
            config.hamsterBreathe = 0.045f;
            config.hamsterClearPeakScale = 1.45f;
            config.hamsterClearGrowSeconds = 0.22f;
            config.hamsterClearHoldSeconds = 0.19f;
            config.hamsterClearShrinkSeconds = 0.16f;
            config.hamsterClearHops = 3;
            config.hamsterClearHopSeconds = 0.32f;
            config.hamsterClearHopHeight = 28;
            config.comboStart = 3;
            config.comboMaxTier = 12;
            config.comboConfettiStart = 8;
            // Curves/colors below are project presentation choices, not recovered original values.
            config.comboColors = new[] {
                new Color(1, 0.64f, 0.18f), new Color(1, 0.5f, 0.27f), new Color(1, 0.4f, 0.38f),
                new Color(1, 0.35f, 0.58f), new Color(0.82f, 0.4f, 0.9f), new Color(0.62f, 0.45f, 1),
                new Color(0.3f, 0.68f, 1), new Color(0.2f, 0.8f, 0.7f), new Color(1, 0.66f, 0.22f),
                new Color(1, 0.35f, 0.5f)
            };
            config.comboPopSeconds = 0.22f;
            config.comboPeakScale = 1.18f;
            config.comboHoldRatio = 0.62f;
            config.comboSeconds = 1.2f;
            config.comboConfettiSeconds = 1.2f;
            config.comboConfettiSpeed = 330;
            config.comboConfettiGravity = 520;
            config.comboConfettiSpin = 300;
            config.comboSparkleSize = 42;
            config.comboCelebrationFrames = new[] { Frame("clap_01"), Frame("clap_02"), Frame("cheer_01"), Frame("cheer_02"),
                Frame("dance_01"), Frame("dance_02"), Frame("dance_03"), Frame("rainbow_01"), Frame("sprout_01"), Frame("sunflower_01") };
            config.comboCelebrationFrameCounts = new[] { 2, 2, 3, 1, 1, 1 };
            config.comboCelebrationFrameSeconds = 0.16f;
            config.comboCelebrationSeconds = 1.2f;
            config.comboCelebrationSize = 1;
            config.comboCelebrationRise = 1.5f;
            // Let all three clear hops finish before displaying the result dialog.
            config.resultDelay = Mathf.Max(config.resultDelay, 1.65f);
            EditorUtility.SetDirty(config);
            const string path = "Assets/Res_Runtime/UI/Game/Panel_Game.prefab";
            var root = PrefabUtility.LoadPrefabContents(path);
            try {
                var panel = root.GetComponent<Panel_Game>();
                panel.comboSparkles = new Image[4];
                panel.comboConfetti = new Image[32];
                var star = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Res_Runtime/UI/Game/Img_Game_TutorialStar.png");
                if (star == null) {
                    throw new InvalidOperationException("Missing existing game effect sprite.");
                }
                // The original effects are created dynamically by ComboTextFx / ComboCelebrateFx;
                // retain the existing panel hierarchy and serialize their decoration nodes here.
                for (int i = 0; i < panel.comboSparkles.Length; i++) {
                    panel.comboSparkles[i] = Effect(panel, "ComboSparkle" + i, star, Vector2.one * 42);
                }
                // A solid UI rectangle uses the existing rounded UI sprite, not a runtime texture.
                var solid = panel.board.cellPrefab.cross.sprite;
                for (int i = 0; i < panel.comboConfetti.Length; i++) {
                    panel.comboConfetti[i] = Effect(panel, "ComboConfetti" + i, solid, new Vector2(12, 22));
                    panel.comboConfetti[i].preserveAspect = false;
                }
                panel.comboCelebration = Effect(panel, "ComboCelebration", config.comboCelebrationFrames[0], Vector2.one * 100);
                panel.gainLabel.transform.SetAsLastSibling();
                panel.comboLabel.transform.SetAsLastSibling();
                panel.comboLabel.enableAutoSizing = false;
                panel.comboLabel.fontStyle = TMPro.FontStyles.Bold;
                PrefabUtility.SaveAsPrefabAsset(root, path);
            } finally {
                PrefabUtility.UnloadPrefabContents(root);
            }
            AssetDatabase.SaveAssets();
            Debug.Log("[BoardAnimation] Saved formal config and all 37 effect bindings.");
        }
        static Sprite Frame(string name) {
            var sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Res_Runtime/UI/Game/Animation/" + name + ".png");
            if (sprite == null) {
                throw new InvalidOperationException("Missing character / combo frame " + name);
            }
            return sprite;
        }
        static Image Effect(Panel_Game panel, string name, Sprite sprite, Vector2 size) {
            var found = panel.contentRoot.Find(name);
            var image = found == null ? new GameObject(name, typeof(RectTransform), typeof(CanvasRenderer), typeof(Image)).GetComponent<Image>() : found.GetComponent<Image>();
            image.transform.SetParent(panel.contentRoot, false);
            image.gameObject.layer = LayerMask.NameToLayer("UI");
            image.rectTransform.anchorMin = Vector2.one * 0.5f;
            image.rectTransform.anchorMax = Vector2.one * 0.5f;
            image.rectTransform.pivot = Vector2.one * 0.5f;
            image.rectTransform.anchoredPosition = Vector2.zero;
            image.rectTransform.sizeDelta = size;
            image.sprite = sprite;
            image.preserveAspect = true;
            image.raycastTarget = false;
            image.enabled = false;
            return image;
        }
    }
}
