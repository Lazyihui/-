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
        float sweepStarted = float.NegativeInfinity;
        float sweepSeconds;
        Color sweepColor;
        bool focusHighlighted;
        bool animateTutorial;
        bool initialized;
        bool characterForeground;
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
        PuzzlePresentationSO animationConfig;
        Vector2 hamsterOrigin;
        float idlePhase;
        float wrongStarted = float.NegativeInfinity;
        public void ConfigureAnimation(PuzzlePresentationSO config, int index) {
            if (config.hamsterIdleFrames == null || config.hamsterIdleFrames.Length != 8 ||
                config.hamsterAppearFrame == null || config.hamsterWrongFrame == null ||
                config.hamsterIdleFrameSeconds <= 0 || config.hamsterAppearSeconds <= 0 ||
                config.hamsterWrongSeconds <= 0 || config.hamsterClearHopSeconds <= 0 ||
                config.hamsterClearGrowSeconds <= 0 || config.hamsterClearShrinkSeconds <= 0) {
                throw new System.InvalidOperationException("Invalid board character animation configuration.");
            }
            foreach (var frame in config.hamsterIdleFrames) {
                if (frame == null) {
                    throw new System.InvalidOperationException("Missing board character idle frame.");
                }
            }
            if (animationConfig == null) {
                hamsterOrigin = hamster.rectTransform.anchoredPosition;
            }
            animationConfig = config;
            idlePhase = index * 0.73f;
            initialized = false;
            changedAt = float.NegativeInfinity;
            wrongStarted = float.NegativeInfinity;
            celebrateSeconds = 0;
            sweepStarted = float.NegativeInfinity;
            hamster.rectTransform.anchoredPosition = hamsterOrigin;
            hamster.rectTransform.localScale = Vector3.one;
            hamster.rectTransform.localRotation = Quaternion.identity;
        }
        public void PlayWrong() {
            wrongStarted = Time.unscaledTime;
            Update();
        }
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
                wrongStarted = float.NegativeInfinity;
                celebrateSeconds = 0;
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
            SetCharacterForeground(hamster.enabled);
            cross.enabled = status == CellStatus.Cross;
            cross.gameObject.SetActive(status == CellStatus.Cross);
            crossSecond.enabled = status == CellStatus.Cross;
            crossSecond.gameObject.SetActive(status == CellStatus.Cross);
            focusHighlighted = highlighted;
            focus.enabled = highlighted;
            given.enabled = fixedHamster;
            Update();
        }
        public void PlayClearSweep(float delay, float seconds, Color color) {
            if (displayedStatus != CellStatus.Cross) {
                return;
            }
            sweepStarted = Time.unscaledTime + delay;
            sweepSeconds = seconds;
            sweepColor = color;
        }
        void SetCharacterForeground(bool foreground) {
            if (characterForeground == foreground) {
                return;
            }
            characterForeground = foreground;
            // Keep the whole cell above empty / crossed neighbours so its character
            // can grow beyond the cell without changing board coordinates or input indices.
            if (foreground) {
                transform.SetAsLastSibling();
            } else {
                transform.SetAsFirstSibling();
            }
        }
        public void Celebrate() {
            if (displayedStatus == CellStatus.Hamster) {
                celebrateStarted = Time.unscaledTime;
                var config = animationConfig;
                celebrateSeconds = config.hamsterClearGrowSeconds + config.hamsterClearHoldSeconds +
                    config.hamsterClearShrinkSeconds + config.hamsterClearHops * config.hamsterClearHopSeconds;
            }
        }
        void AnimateCharacter(float elapsed) {
            var config = animationConfig;
            var rect = hamster.rectTransform;
            float unit = ((RectTransform)transform).rect.width / 100;
            float wrongElapsed = Time.unscaledTime - wrongStarted;
            bool wrong = wrongElapsed < config.hamsterWrongSeconds;
            bool visible = displayedStatus == CellStatus.Hamster;
            hamster.enabled = visible || wrong;
            SetCharacterForeground(hamster.enabled);
            cross.enabled = displayedStatus == CellStatus.Cross && !wrong;
            crossSecond.enabled = cross.enabled;
            Vector2 position = hamsterOrigin;
            Vector3 scale = Vector3.one;
            float rotation = 0;
            if (wrong) {
                hamster.sprite = config.hamsterWrongFrame;
                float progress = wrongElapsed / config.hamsterWrongSeconds;
                position.x += Mathf.Sin(progress * Mathf.PI * 12) * config.hamsterWrongShake * unit * (1 - progress);
            } else if (visible) {
                float phase = Time.unscaledTime * config.hamsterBobSpeed + idlePhase;
                int frame = Mathf.FloorToInt((Time.unscaledTime + idlePhase) / config.hamsterIdleFrameSeconds) % config.hamsterIdleFrames.Length;
                hamster.sprite = elapsed < config.hamsterAppearSeconds ? config.hamsterAppearFrame : config.hamsterIdleFrames[frame];
                position.y += Mathf.Sin(phase) * config.hamsterBobHeight * unit;
                float breathe = Mathf.Sin(phase) * config.hamsterBreathe;
                scale = new Vector3(1 - breathe * 0.5f, 1 + breathe, 1);
                float progress = Mathf.Clamp01(elapsed / placeSeconds);
                float pop = progress < 0.6f ? Mathf.Lerp(0.45f, 1.2f, Mathf.SmoothStep(0, 1, progress / 0.6f)) :
                    Mathf.Lerp(1.2f, 1, Mathf.SmoothStep(0, 1, (progress - 0.6f) / 0.4f));
                scale *= pop;
                float celebration = Time.unscaledTime - celebrateStarted;
                if (celebrateSeconds > 0 && celebration < celebrateSeconds) {
                    float grow = config.hamsterClearGrowSeconds;
                    float hold = grow + config.hamsterClearHoldSeconds;
                    float shrink = hold + config.hamsterClearShrinkSeconds;
                    float peak = config.hamsterClearPeakScale;
                    float size = celebration < grow ? Mathf.Lerp(1, peak, Mathf.SmoothStep(0, 1, celebration / grow)) :
                        celebration < hold ? peak : Mathf.Lerp(peak, 1, Mathf.SmoothStep(0, 1, (celebration - hold) / config.hamsterClearShrinkSeconds));
                    scale = Vector3.one * size;
                    position = hamsterOrigin;
                    if (celebration >= shrink) {
                        float hop = Mathf.Repeat((celebration - shrink) / config.hamsterClearHopSeconds, 1);
                        position.y += Mathf.Sin(hop * Mathf.PI) * config.hamsterClearHopHeight * unit;
                        rotation = Mathf.Sin(hop * Mathf.PI * 2) * 8;
                    }
                }
            }
            rect.anchoredPosition = position;
            rect.localScale = scale;
            rect.localRotation = Quaternion.Euler(0, 0, rotation);
        }
        void Update() {
            float sweepElapsed = Time.unscaledTime - sweepStarted;
            bool sweeping = sweepElapsed >= 0 && sweepElapsed < sweepSeconds;
            focus.enabled = focusHighlighted || sweeping;
            focus.color = sweeping ? sweepColor : Color.white;
            if (sweeping) {
                var color = focus.color;
                color.a *= Mathf.Sin(Mathf.PI * sweepElapsed / sweepSeconds);
                focus.color = color;
            }
            if (!animateTutorial) {
                return;
            }
            float elapsed = Time.unscaledTime - changedAt;
            if (displayedStatus == CellStatus.Cross) {
                float progress = Mathf.Clamp01(elapsed / markSeconds);
                cross.rectTransform.localScale = new Vector3(Mathf.Clamp01(progress * 2), 1, 1);
                crossSecond.rectTransform.localScale = new Vector3(Mathf.Clamp01(progress * 2 - 1), 1, 1);
            }
            AnimateCharacter(elapsed);
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
