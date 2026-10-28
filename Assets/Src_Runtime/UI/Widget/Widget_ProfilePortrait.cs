using UnityEngine;
using TMPro;

namespace Hamdoku {
    public sealed class Widget_ProfilePortrait : MonoBehaviour {
        public UnityEngine.UI.Image plate;
        public UnityEngine.UI.Mask clipMask;
        public UnityEngine.UI.Image face;
        public UnityEngine.UI.Image costume;
        public UnityEngine.UI.Image hand;
        public UnityEngine.UI.Image frame;
        public UnityEngine.UI.Image aura;
        public UnityEngine.UI.Image[] sparkles;
        public TMP_Text winsBadge;
        ProfileConfigSO config;
        int frameId;
        float opacity;
        float elapsed;

        public void Show(ProfileConfigSO source, int avatarId, int selectedFrame, int costumeId, float alpha, int wins) {
            config = source;
            frameId = selectedFrame;
            opacity = alpha;
            face.sprite = source.avatars[avatarId];
            face.color = new Color(1, 1, 1, alpha);
            plate.color = source.avatarColors[avatarId % source.avatarColors.Length];
            clipMask.enabled = selectedFrame >= 0;
            bool crowned = selectedFrame >= 0 && source.crownFrames[selectedFrame];
            SetBox(plate.rectTransform, Vector2.one * .5f, crowned ? source.crownPlateScale : 1);
            SetBox(face.rectTransform, Vector2.one * .5f, source.portraitFaceScale);
            frame.gameObject.SetActive(selectedFrame >= 0);
            if (selectedFrame >= 0) {
                frame.sprite = source.frames[selectedFrame];
                frame.color = new Color(1, 1, 1, alpha);
                float scale = crowned ? source.crownFrameScale : source.ringOpeningOfPlate / source.frameOpenings[selectedFrame];
                Vector2 opening = source.crownOpeningCenter;
                Vector2 center = crowned ? new Vector2(.5f - (opening.x - .5f) * scale, .5f + (opening.y - .5f) * scale) : Vector2.one * .5f;
                SetBox(frame.rectTransform, center, scale);
                bool badge = crowned;
                winsBadge.gameObject.SetActive(badge);
                if (badge) {
                    int requirement = source.frameRankWins[selectedFrame];
                    winsBadge.text = wins >= 0 ? wins.ToString() : requirement > 0 ? requirement.ToString() : "—";
                    SetBox(winsBadge.rectTransform, source.badgeCenters[selectedFrame], source.crownBadgeScale);
                    winsBadge.color = source.badgeColors[selectedFrame];
                }
            } else {
                winsBadge.gameObject.SetActive(false);
            }
            bool dressed = costumeId >= 0;
            costume.gameObject.SetActive(dressed);
            hand.gameObject.SetActive(dressed && source.hands[avatarId] != null);
            if (dressed) {
                costume.sprite = source.costumes[costumeId];
                costume.color = new Color(1, 1, 1, alpha);
                hand.sprite = source.hands[avatarId];
                hand.color = new Color(1, 1, 1, alpha);
                int fitId = avatarId >= source.clubAvatarStart && avatarId < source.clubAvatarStart + 6 ? avatarId - source.clubAvatarStart : avatarId;
                var fit = source.costumeFits[costumeId * source.avatars.Length + fitId];
                Rect rect = source.costumeRects[costumeId];
                Vector2 pivot = source.costumeHeadPivot;
                Vector2 size = rect.size * fit.scale;
                Vector2 center = pivot + fit.offset + (rect.center - pivot) * fit.scale;
                var costumeRect = costume.rectTransform;
                costumeRect.anchorMin = center - size * .5f;
                costumeRect.anchorMax = center + size * .5f;
                costumeRect.pivot = new Vector2((pivot.x + fit.offset.x - costumeRect.anchorMin.x) / size.x,
                    (pivot.y + fit.offset.y - costumeRect.anchorMin.y) / size.y);
                costumeRect.offsetMin = Vector2.zero;
                costumeRect.offsetMax = Vector2.zero;
                costumeRect.localRotation = Quaternion.Euler(0, 0, fit.rotation);
            }
            bool animated = selectedFrame >= 0 && source.frameAuras[selectedFrame] != null;
            aura.gameObject.SetActive(animated);
            if (animated) {
                aura.sprite = source.frameAuras[selectedFrame];
                SetBox(aura.rectTransform, Vector2.one * .5f, source.auraScale);
            }
            foreach (var sparkle in sparkles) {
                sparkle.gameObject.SetActive(crowned);
            }
            Animate();
        }

        static void SetBox(RectTransform rect, Vector2 center, float scale) {
            rect.anchorMin = center - Vector2.one * scale * .5f;
            rect.anchorMax = center + Vector2.one * scale * .5f;
            rect.offsetMin = Vector2.zero;
            rect.offsetMax = Vector2.zero;
        }

        void Update() {
            if (config == null) {
                return;
            }
            elapsed += Time.unscaledDeltaTime;
            Animate();
        }

        void Animate() {
            if (config == null || frameId < 0) {
                return;
            }
            int tier = config.frameAuraTiers[frameId];
            if (aura.gameObject.activeSelf) {
                Color color = Color.HSVToRGB(Mathf.Repeat(config.auraHueBase[tier] + Mathf.Sin(elapsed * config.auraSpeed[tier] * Mathf.PI * 2) * config.auraHueRange[tier], 1), config.auraSaturation, config.auraValue);
                color.a = config.auraAlpha[tier] * opacity;
                aura.color = color;
            }
            for (int i = 0; i < sparkles.Length; i++) {
                var sparkle = sparkles[i];
                if (!sparkle.gameObject.activeSelf) {
                    continue;
                }
                float wave = .5f + .5f * Mathf.Sin(elapsed * config.sparkleSpeed + i * 2.1f);
                sparkle.color = new Color(1, 1, 1, wave * opacity);
                sparkle.rectTransform.localScale = Vector3.one * Mathf.Lerp(config.sparkleMinScale, 1, wave);
            }
        }
    }
}
