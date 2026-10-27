using System;
using UnityEngine;

namespace Hamdoku {
    public sealed class Panel_Logo : MonoBehaviour {
        [SerializeField] public RectTransform safeRoot;
        [SerializeField] public Widget_LogoIntro logoIntro;
        public Action completedHandle;
        public Action<AudioClip, float> audioHandle;

        public void Ctor() {
            if (safeRoot == null || logoIntro == null) {
                throw new InvalidOperationException("Panel_Logo must bind its SafeRoot and Widget_LogoIntro.");
            }
            logoIntro.completedHandle = () => {
                completedHandle?.Invoke();
            };
            logoIntro.audioHandle = (clip, volume) => {
                audioHandle?.Invoke(clip, volume);
            };
        }

        public void Init(LogoConfigSO config) {
            logoIntro.Init(config);
        }

        public void Tick(float deltaTime) {
            logoIntro.Tick(deltaTime);
        }

        public void ApplySafeArea(Rect area, int width, int height) {
            if (width <= 0 || height <= 0) {
                throw new InvalidOperationException("Logo viewport must have a positive size.");
            }
            safeRoot.anchorMin = new Vector2(area.xMin / width, area.yMin / height);
            safeRoot.anchorMax = new Vector2(area.xMax / width, area.yMax / height);
            safeRoot.offsetMin = Vector2.zero;
            safeRoot.offsetMax = Vector2.zero;
        }

        public void TearDown() {
            if (logoIntro != null) {
                logoIntro.TearDown();
            }
            completedHandle = null;
            audioHandle = null;
        }
    }
}
