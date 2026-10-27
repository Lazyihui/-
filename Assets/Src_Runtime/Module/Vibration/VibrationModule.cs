using UnityEngine;
namespace Hamdoku {
    public sealed class VibrationModule {
        public void Pulse() {
#if UNITY_ANDROID || UNITY_IOS
            if (Application.isMobilePlatform) {
                Handheld.Vibrate();
            }
#endif
        }
    }
}
