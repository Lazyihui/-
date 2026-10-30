using System;
using TMPro;
using UnityEditor;
using UnityEditor.AddressableAssets;
using UnityEngine;
namespace Hamdoku.Editor {
    public static class GameFlowSetupEM {
        [MenuItem("Hamdoku/Setup/Configure Game Flow")]
        public static void Apply() {
            const string path = "Assets/Res_Runtime/UI/Game/Panel_Game.prefab";
            var root = PrefabUtility.LoadPrefabContents(path);
            try {
                var panel = root.GetComponent<Panel_Game>();
                panel.gainLabel = EnsureText(panel, "ScoreGain", 56, new Color(1, .5919387f, .2122642f, 1));
                panel.comboLabel = EnsureText(panel, "Combo", 85, panel.scoreLabel.color);
                PrefabUtility.SaveAsPrefabAsset(root, path);
            } finally {
                PrefabUtility.UnloadPrefabContents(root);
            }
            var settings = AddressableAssetSettingsDefaultObject.Settings;
            foreach (string name in new[] { "Game_Gain", "Game_Combo" }) {
                string assetPath = "Assets/Res_Runtime/Localization/" + name + ".asset";
                var text = AssetDatabase.LoadAssetAtPath<L10NSO>(assetPath);
                if (text == null) {
                    throw new InvalidOperationException("Missing game feedback localization " + name);
                }
                var entry = settings.CreateOrMoveEntry(AssetDatabase.AssetPathToGUID(assetPath), settings.DefaultGroup);
                entry.SetLabel(AAConst.LABEL_DEFAULT, true, true);
            }
            EditorUtility.SetDirty(settings);
            AssetDatabase.SaveAssets();
            Debug.Log("[GameFlow] Saved bound gain/combo labels and default localization entries.");
        }
        [MenuItem("Hamdoku/Setup/Configure Endless Resources")]
        public static void ConfigureEndless() {
            var settings = AddressableAssetSettingsDefaultObject.Settings;
            if (settings == null) {
                throw new InvalidOperationException("Missing formal Addressables settings.");
            }
            var group = settings.FindGroup("Gameplay");
            if (group == null) {
                throw new InvalidOperationException("Missing formal Gameplay group.");
            }
            string configPath = "Assets/Res_Runtime/Config/EndlessConfig.asset";
            if (AssetDatabase.LoadAssetAtPath<EndlessConfigSO>(configPath) == null) {
                throw new InvalidOperationException("Missing formal EndlessConfig.");
            }
            var entry = settings.CreateOrMoveEntry(AssetDatabase.AssetPathToGUID(configPath), group);
            entry.address = configPath;
            entry.SetLabel(AAConst.LABEL_DEFAULT, true, true);
            foreach (UINameType id in Enum.GetValues(typeof(UINameType))) {
                if ((int)id < (int)UINameType.Endless_Title || (int)id > (int)UINameType.Endless_SaveRetry) {
                    continue;
                }
                string path = "Assets/Res_Runtime/Localization/" + id + ".asset";
                if (AssetDatabase.LoadAssetAtPath<L10NSO>(path) == null) {
                    throw new InvalidOperationException("Missing formal endless localization " + id);
                }
                entry = settings.CreateOrMoveEntry(AssetDatabase.AssetPathToGUID(path), group);
                entry.address = path;
                entry.SetLabel(AAConst.LABEL_DEFAULT, true, true);
            }
            ResultSetupEM.BakeFonts();
            EditorUtility.SetDirty(settings);
            AssetDatabase.SaveAssets();
        }
        static TMP_Text EnsureText(Panel_Game panel, string name, float size, Color color) {
            var found = panel.contentRoot.Find(name);
            var text = found == null ? new GameObject(name, typeof(RectTransform), typeof(TextMeshProUGUI)).GetComponent<TMP_Text>() : found.GetComponent<TMP_Text>();
            text.transform.SetParent(panel.contentRoot, false);
            text.rectTransform.anchorMin = Vector2.one * .5f;
            text.rectTransform.anchorMax = Vector2.one * .5f;
            text.rectTransform.pivot = Vector2.one * .5f;
            text.rectTransform.sizeDelta = new Vector2(850, 150);
            text.rectTransform.anchoredPosition = Vector2.zero;
            text.font = panel.scoreLabel.font;
            text.fontSize = size;
            text.color = color;
            text.alignment = TextAlignmentOptions.Center;
            text.raycastTarget = false;
            text.text = string.Empty;
            text.transform.SetAsLastSibling();
            return text;
        }
    }
}
