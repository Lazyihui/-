using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Hamdoku {
    public sealed class AssetModule {
        readonly Dictionary<PanelType, GameObject> panels = new Dictionary<PanelType, GameObject>();
        readonly List<L10NSO> texts = new List<L10NSO>();
        readonly List<L10NFontSO> fonts = new List<L10NFontSO>();
        AsyncOperationHandle<IList<UnityEngine.Object>> defaultHandle;
        HomeConfigSO homeConfig;
        bool registered;

        public void BeginLoadAll() {
            if (defaultHandle.IsValid()) {
                throw new InvalidOperationException("Default assets are already loading.");
            }
            defaultHandle = Addressables.LoadAssetsAsync<UnityEngine.Object>(AAConst.LABEL_DEFAULT, null);
        }

        public bool IsLoadDone() {
            return defaultHandle.IsDone;
        }

        public void CompleteLoadAll() {
            if (registered) {
                return;
            }
            if (defaultHandle.Status != AsyncOperationStatus.Succeeded) {
                throw new InvalidOperationException("Failed to load default assets.", defaultHandle.OperationException);
            }
            foreach (var asset in defaultHandle.Result) {
                if (asset is GameObject prefab) {
                    var panel = prefab.GetComponent<IPanelAsset>();
                    if (panel != null) {
                        panels.Add(panel.Type, prefab);
                    }
                } else if (asset is HomeConfigSO config) {
                    if (homeConfig != null) {
                        throw new InvalidOperationException("More than one HomeConfigSO has the default label.");
                    }
                    homeConfig = config;
                } else if (asset is L10NSO text) {
                    texts.Add(text);
                } else if (asset is L10NFontSO font) {
                    fonts.Add(font);
                }
            }
            registered = true;
        }

        public bool Panel_TryGet(PanelType type, out GameObject prefab) {
            return panels.TryGetValue(type, out prefab);
        }

        public HomeConfigSO GetHomeConfig() {
            if (homeConfig == null) {
                throw new InvalidOperationException("HomeConfigSO is missing from the default assets.");
            }
            return homeConfig;
        }

        public IReadOnlyList<L10NSO> L10N_GetAll() {
            return texts;
        }

        public IReadOnlyList<L10NFontSO> L10NFont_GetAll() {
            return fonts;
        }

        public void Release() {
            panels.Clear();
            texts.Clear();
            fonts.Clear();
            homeConfig = null;
            registered = false;
            if (defaultHandle.IsValid()) {
                Addressables.Release(defaultHandle);
                defaultHandle = default;
            }
        }
    }
}
