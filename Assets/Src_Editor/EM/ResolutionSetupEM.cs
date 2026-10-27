using System;
using System.IO;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace Hamdoku.Editor {
    public static class ResolutionSetupEM {
        [InitializeOnLoadMethod]
        static void ApplyRequestedPreview() {
            EditorApplication.delayCall += ApplyPending;
        }

        static void ApplyPending() {
            if (!File.Exists("Library/ResolutionSetup.request")) {
                return;
            }
            if (EditorApplication.isPlayingOrWillChangePlaymode) {
                EditorApplication.playModeStateChanged -= ApplyAfterPlay;
                EditorApplication.playModeStateChanged += ApplyAfterPlay;
                return;
            }
            ConfigurePreview();
            File.Delete("Library/ResolutionSetup.request");
        }

        static void ApplyAfterPlay(PlayModeStateChange change) {
            if (change == PlayModeStateChange.EnteredEditMode) {
                EditorApplication.playModeStateChanged -= ApplyAfterPlay;
                ApplyPending();
            }
        }

        [MenuItem("Hamdoku/Preview/1080 x 1920 Portrait")]
        public static void ConfigurePreview() {
            // Game view size selection is an editor API; no runtime resolution is forced.
            var assembly = typeof(UnityEditor.Editor).Assembly;
            var sizesType = assembly.GetType("UnityEditor.GameViewSizes", true);
            var singletonType = typeof(ScriptableSingleton<>).MakeGenericType(sizesType);
            var sizes = singletonType.GetProperty("instance").GetValue(null);
            var groupType = assembly.GetType("UnityEditor.GameViewSizeGroupType", true);
            var currentGroup = sizesType.GetProperty("currentGroupType", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).GetValue(sizes);
            var group = sizesType.GetMethod("GetGroup").Invoke(sizes, new[] { currentGroup });
            var groupClass = group.GetType();
            int count = (int)groupClass.GetMethod("GetTotalCount").Invoke(group, null);
            int selected = -1;
            for (int i = 0; i < count; i++) {
                var size = groupClass.GetMethod("GetGameViewSize").Invoke(group, new object[] { i });
                var sizeClass = size.GetType();
                int width = (int)sizeClass.GetProperty("width").GetValue(size);
                int height = (int)sizeClass.GetProperty("height").GetValue(size);
                int kind = Convert.ToInt32(sizeClass.GetProperty("sizeType").GetValue(size));
                if (width == UIResolutionConst.WIDTH && height == UIResolutionConst.HEIGHT && kind == 1) {
                    selected = i;
                    break;
                }
            }
            if (selected < 0) {
                var sizeType = assembly.GetType("UnityEditor.GameViewSize", true);
                var kindType = assembly.GetType("UnityEditor.GameViewSizeType", true);
                var size = Activator.CreateInstance(sizeType,
                    new object[] { Enum.ToObject(kindType, 1), UIResolutionConst.WIDTH, UIResolutionConst.HEIGHT, "Hamdoku 1080 x 1920" });
                groupClass.GetMethod("AddCustomSize").Invoke(group, new[] { size });
                selected = count;
                sizesType.GetMethod("SaveToHDD", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).Invoke(sizes, null);
            }
            var gameViewType = assembly.GetType("UnityEditor.GameView", true);
            var window = EditorWindow.GetWindow(gameViewType);
            gameViewType.GetProperty("selectedSizeIndex", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).SetValue(window, selected);
            window.Repaint();
            Directory.CreateDirectory("Logs/ResolutionValidation");
            File.WriteAllText("Logs/ResolutionValidation/preview.txt", "Game view selected: 1080 x 1920 fixed resolution. Group: " + currentGroup + "; index: " + selected);
            Debug.Log("[ResolutionSetup] Game view set to 1080 x 1920 portrait.");
        }
    }
}
