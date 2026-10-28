using UnityEngine;
namespace Hamdoku {
    public sealed class Widget_BoardCell : MonoBehaviour {
        public UnityEngine.UI.Image[] regionEdges;
        public UnityEngine.UI.Image background;
        public UnityEngine.UI.Image pattern;
        public UnityEngine.UI.Image hamster;
        public UnityEngine.UI.Image cross;
        public UnityEngine.UI.Image crossSecond;
        public UnityEngine.UI.Image focus;
        public UnityEngine.UI.Image given;
        public UnityEngine.UI.Image tutorialDim;
        public UnityEngine.UI.Image[] tutorialStars;
        bool animateTutorial;
        bool initialized;
        CellStatus displayedStatus;
        float changedAt;
        float markSeconds;
        float placeSeconds;
        float dimSeconds;
        float dimTarget;
        float dimFrom;
        float dimStarted;
        bool dimInitialized;
        float dimAlpha;
        float celebrateStarted;
        float celebrateSeconds;
        public void ConfigureTutorial(float markSeconds, float placeSeconds, float dimSeconds, bool animated) {
            if (tutorialStars == null || tutorialStars.Length != 6) {
                throw new System.InvalidOperationException("Board cell requires six bound tutorial sparkle images.");
            }
            foreach (var star in tutorialStars) {
                if (star == null || star.sprite == null) {
                    throw new System.InvalidOperationException("Board cell has a missing tutorial sparkle binding.");
                }
            }
            this.markSeconds = markSeconds;
            this.placeSeconds = placeSeconds;
            this.dimSeconds = dimSeconds;
            animateTutorial = animated;
            if (!dimInitialized) {
                dimAlpha = tutorialDim.color.a;
            }
        }
        public void ShowRegionBorder(bool visible, Color color, float width, bool top, bool right, bool bottom, bool left) {
            for (int i = 0; i < regionEdges.Length; i++) {
                var edge = regionEdges[i];
                edge.enabled = visible && (i == 0 ? top : i == 1 ? right : i == 2 ? bottom : left);
                edge.color = color;
                var rect = edge.rectTransform;
                rect.sizeDelta = i % 2 == 0 ? new Vector2(0, width) : new Vector2(width, 0);
            }
        }
        public void SetDimmed(bool dimmed) {
            float target = dimmed ? dimAlpha : 0;
            if (!dimInitialized || !animateTutorial) {
                var color = tutorialDim.color;
                color.a = target;
                tutorialDim.color = color;
                tutorialDim.enabled = dimmed;
                dimFrom = target;
                dimTarget = target;
                dimStarted = Time.unscaledTime;
                dimInitialized = true;
            } else if (dimTarget != target) {
                dimFrom = tutorialDim.color.a;
                dimTarget = target;
                dimStarted = Time.unscaledTime;
                tutorialDim.enabled = true;
            }
        }
        public void SetPressed(bool pressed) {
            transform.localScale = Vector3.one * (pressed ? 0.94f : 1);
        }
        public void Show(Color color, Sprite motif, CellStatus status, bool highlighted, bool fixedHamster) {
            if (initialized && displayedStatus != status && animateTutorial) {
                changedAt = Time.unscaledTime;
            } else if (!initialized) {
                changedAt = float.NegativeInfinity;
            }
            displayedStatus = status;
            initialized = true;
            background.color = color;
            pattern.sprite = motif;
            pattern.color = new Color(color.r * 0.65f, color.g * 0.65f, color.b * 0.65f, 0.26f);
            pattern.enabled = status == CellStatus.None && motif != null;
            hamster.enabled = status == CellStatus.Hamster;
            cross.enabled = status == CellStatus.Cross;
            cross.gameObject.SetActive(status == CellStatus.Cross);
            crossSecond.enabled = status == CellStatus.Cross;
            crossSecond.gameObject.SetActive(status == CellStatus.Cross);
            focus.enabled = highlighted;
            given.enabled = fixedHamster;
            Update();
        }
        public void Celebrate(float seconds) {
            if (displayedStatus == CellStatus.Hamster) {
                celebrateStarted = Time.unscaledTime;
                celebrateSeconds = seconds;
            }
        }
        void Update() {
            if (!animateTutorial) {
                return;
            }
            float elapsed = Time.unscaledTime - changedAt;
            if (displayedStatus == CellStatus.Cross) {
                float progress = Mathf.Clamp01(elapsed / markSeconds);
                cross.rectTransform.localScale = new Vector3(Mathf.Clamp01(progress * 2), 1, 1);
                crossSecond.rectTransform.localScale = new Vector3(Mathf.Clamp01(progress * 2 - 1), 1, 1);
            }
            if (displayedStatus == CellStatus.Hamster) {
                float progress = Mathf.Clamp01(elapsed / placeSeconds);
                float pop = progress < 0.6f ? Mathf.Lerp(0.45f, 1.2f, Mathf.SmoothStep(0, 1, progress / 0.6f)) : Mathf.Lerp(1.2f, 1, Mathf.SmoothStep(0, 1, (progress - 0.6f) / 0.4f));
                float celebration = celebrateSeconds > 0 ? Mathf.Clamp01((Time.unscaledTime - celebrateStarted) / celebrateSeconds) : 1;
                float wave = Mathf.Sin(celebration * Mathf.PI * 6) * (1 - celebration);
                hamster.rectTransform.localScale = Vector3.one * (pop + Mathf.Abs(wave) * 0.12f);
                hamster.rectTransform.localRotation = Quaternion.Euler(0, 0, wave * 12);
            }
            float burst = Mathf.Clamp01(elapsed / placeSeconds);
            bool sparkle = displayedStatus == CellStatus.Hamster && burst < 1;
            for (int i = 0; i < tutorialStars.Length; i++) {
                var star = tutorialStars[i];
                star.enabled = sparkle;
                if (sparkle) {
                    float angle = (i * 60 + 15) * Mathf.Deg2Rad;
                    float radius = Mathf.Lerp(0.32f, 0.7f, burst) * ((RectTransform)transform).rect.width;
                    star.rectTransform.anchoredPosition = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * radius;
                    star.rectTransform.localScale = Vector3.one * Mathf.Sin(burst * Mathf.PI);
                    star.rectTransform.localRotation = Quaternion.Euler(0, 0, i * 32 + burst * 35);
                    var tint = star.color;
                    tint.a = 1 - burst;
                    star.color = tint;
                }
            }
            if (dimInitialized) {
                var color = tutorialDim.color;
                color.a = Mathf.Lerp(dimFrom, dimTarget, Mathf.SmoothStep(0, 1, (Time.unscaledTime - dimStarted) / dimSeconds));
                tutorialDim.color = color;
                tutorialDim.enabled = color.a > 0;
            }
        }
    }
}
