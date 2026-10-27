using System.Collections.Generic;

namespace Hamdoku {
    public sealed class PanelRepository {
        readonly Dictionary<PanelType, IPanelAsset> panels = new Dictionary<PanelType, IPanelAsset>();
        readonly List<IPanelAsset> all = new List<IPanelAsset>();

        public void Add(IPanelAsset panel) {
            panels.Add(panel.Type, panel);
            all.Add(panel);
        }

        public void Remove(IPanelAsset panel) {
            panels.Remove(panel.Type);
            all.Remove(panel);
        }

        public bool TryGet<T>(PanelType type, out T panel) where T : class, IPanelAsset {
            if (panels.TryGetValue(type, out var existing)) {
                panel = (T)existing;
                return true;
            }
            panel = null;
            return false;
        }

        public IReadOnlyList<IPanelAsset> GetAll() {
            return all;
        }
    }
}
