using System;
using UnityEngine;

namespace Hamdoku.Controllers {
    public static class PanelFactory {
        public static UIOpenType TryOpen<T>(GameContext ctx, PanelType type, out T panel) where T : Component, IPanelAsset {
            var panels = ctx.panelRepository;
            var assets = ctx.assetModule;
            var canvases = ctx.canvasRepository;
            if (panels.TryGet(type, out panel)) {
                return UIOpenType.AlreadyOpen;
            }
            if (!assets.Panel_TryGet(type, out var prefab)) {
                throw new InvalidOperationException("No default prefab registered for panel " + type);
            }
            var instance = UnityEngine.Object.Instantiate(prefab, canvases.GetScreen());
            panel = instance.GetComponent<T>();
            if (panel == null) {
                UnityEngine.Object.Destroy(instance);
                throw new InvalidOperationException("Panel prefab is missing " + typeof(T).Name);
            }
            instance.transform.SetAsLastSibling();
            panels.Add(panel);
            return UIOpenType.FirstOpen;
        }
    }
}
