using UnityEngine;

namespace Hamdoku {
    public sealed class Widget_ProfileNewDot : MonoBehaviour {
        public ProfileConfigSO config;
        float elapsed;

        void OnEnable() {
            elapsed = 0;
            transform.localScale = Vector3.one;
        }

        void Update() {
            elapsed += Time.unscaledDeltaTime;
            float wave = .5f - .5f * Mathf.Cos(elapsed / config.newDotPulseSeconds * Mathf.PI * 2);
            transform.localScale = Vector3.one * Mathf.Lerp(1, config.newDotPulseScale, wave);
        }
    }
}
