using UnityEngine;

namespace Hamdoku {
    public sealed class CanvasEntity : MonoBehaviour {
        [SerializeField] public int order;
        [SerializeField] public CanvasType type;

        public Transform Root() {
            return transform;
        }
    }
}
