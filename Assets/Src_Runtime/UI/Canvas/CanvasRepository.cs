using System.Collections.Generic;
using UnityEngine;

namespace Hamdoku {
    public sealed class CanvasRepository {
        readonly Dictionary<int, CanvasEntity> byOrder = new Dictionary<int, CanvasEntity>();
        readonly Dictionary<CanvasType, CanvasEntity> firstByType = new Dictionary<CanvasType, CanvasEntity>();

        public void Add(CanvasEntity canvas) {
            byOrder.Add(canvas.order, canvas);
            firstByType.TryAdd(canvas.type, canvas);
        }

        public bool TryGetByOrder(int order, out CanvasEntity canvas) {
            return byOrder.TryGetValue(order, out canvas);
        }

        public CanvasEntity GetByOrder(int order) {
            return byOrder[order];
        }

        public Transform GetScreen() {
            return firstByType[CanvasType.ScreenSpace].Root();
        }
    }
}
