using UnityEngine;
using UnityEngine.UI;

namespace Hamdoku {
    public sealed class Widget_StreakPlant : MonoBehaviour {
        public RectTransform motionRoot;
        public Image main;
        public Image aura;
        public Image[] companions;
        public Image[] butterflies;
        public RectTransform petalRoot;
        public Image flowerHead;
        public RectTransform[] petals;
        StreakConfigSO config;
        float elapsed;
        Vector3 baseScale;

        public void Init(StreakConfigSO config, int cut, int companionsCount, int butterflyCount, bool sparkle, int petalCount) {
            this.config = config;
            elapsed = 0;
            main.sprite = config.plants[cut];
            main.rectTransform.sizeDelta = main.sprite.rect.size * config.plantSize / config.plantReferencePixels;
            baseScale = Vector3.one;
            motionRoot.localScale = baseScale;
            motionRoot.localRotation = Quaternion.identity;
            aura.color = config.auraColor;
            for (int i = 0; i < companions.Length; i++) {
                companions[i].gameObject.SetActive(i < companionsCount);
            }
            for (int i = 0; i < butterflies.Length; i++) {
                butterflies[i].gameObject.SetActive(i < butterflyCount);
            }
            aura.gameObject.SetActive(cut > 0 || sparkle);
            petalRoot.gameObject.SetActive(cut == 4);
            for (int i = 0; i < petals.Length; i++) {
                petals[i].gameObject.SetActive(i < petalCount);
                petals[i].localScale = Vector3.zero;
            }
        }

        public void Tick(float deltaTime) {
            elapsed += deltaTime;
            float wave = Mathf.Sin(elapsed * Mathf.PI * 2 / config.swaySeconds);
            float intro = Mathf.SmoothStep(0, 1, Mathf.Clamp01(elapsed / config.introSeconds));
            motionRoot.localScale = baseScale * intro;
            motionRoot.localRotation = Quaternion.Euler(0, 0, wave * config.swayDegrees);
            var color = config.auraColor;
            color.a *= 1 + wave * config.auraBreath;
            aura.color = color;
            for (int i = 0; i < petals.Length; i++) {
                float t = Mathf.Clamp01((elapsed - i * config.petalInterval) / config.stampSeconds);
                petals[i].localScale = Vector3.one * Mathf.SmoothStep(0, 1, t);
            }
            for (int i = 0; i < butterflies.Length; i++) {
                var butterfly = butterflies[i];
                if (!butterfly.gameObject.activeSelf) {
                    continue;
                }
                float phase = elapsed * Mathf.PI * 2 / config.butterflySeconds + i * Mathf.PI;
                butterfly.rectTransform.anchoredPosition = new Vector2(Mathf.Cos(phase) * config.butterflyRange.x,
                    Mathf.Sin(phase * 2) * config.butterflyRange.y + config.butterflyHeight);
                int frame = (int)(elapsed / config.butterflyFlapSeconds) % 2;
                butterfly.sprite = config.butterflies[i * 2 + frame];
            }
        }
    }
}
