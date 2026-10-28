using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.AddressableAssets;
using UnityEngine;

namespace Hamdoku.Editor {
    public static class PuzzleConfigSetupEM {
        [MenuItem("Hamdoku/Setup/Register Puzzle Configuration")]
        public static void Register() {
            var settings = AddressableAssetSettingsDefaultObject.Settings;
            if (settings == null) {
                throw new InvalidOperationException("Missing formal Addressables settings.");
            }
            var ids = new HashSet<int>();
            var paths = AssetDatabase.FindAssets("t:PuzzleSO", new[] { "Assets/Res_Runtime/Puzzle" })
                .Select(AssetDatabase.GUIDToAssetPath).OrderBy(path => path).ToList();
            foreach (string path in paths) {
                var puzzle = AssetDatabase.LoadAssetAtPath<PuzzleSO>(path);
                if (puzzle == null || puzzle.id <= 0 || !ids.Add(puzzle.id)) {
                    throw new InvalidOperationException("Invalid or duplicate independent puzzle: " + path);
                }
                if (AssetDatabase.LoadAllAssetsAtPath(path).OfType<PuzzleSO>().Count() != 1) {
                    throw new InvalidOperationException("Puzzle assets must contain exactly one map: " + path);
                }
            }
            paths.AddRange(new[] {
                "Assets/Res_Runtime/Config/GameConfig.asset",
                "Assets/Res_Runtime/Config/PuzzleRules.asset",
                "Assets/Res_Runtime/Config/CampaignConfig.asset",
                "Assets/Res_Runtime/Config/PuzzlePresentation.asset",
                "Assets/Res_Runtime/Config/ResultConfig.asset"
            });
            var group = settings.FindGroup("Gameplay");
            if (group == null) {
                throw new InvalidOperationException("Missing formal Gameplay Addressables group.");
            }
            foreach (string path in paths) {
                if (AssetDatabase.LoadMainAssetAtPath(path) == null) {
                    throw new InvalidOperationException("Missing formal puzzle configuration: " + path);
                }
                string guid = AssetDatabase.AssetPathToGUID(path);
                var entry = settings.FindAssetEntry(guid);
                if (entry == null) {
                    entry = settings.CreateOrMoveEntry(guid, group);
                }
                entry.address = path;
                entry.SetLabel(AAConst.LABEL_DEFAULT, true, true);
            }
            EditorUtility.SetDirty(settings);
            AssetDatabase.SaveAssets();
            Debug.Log("[PuzzleConfig] Registered " + ids.Count + " independent maps and separated formal configurations.");
        }
    }
}
