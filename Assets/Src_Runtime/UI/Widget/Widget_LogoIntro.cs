using System;
using UnityEngine;

namespace Hamdoku {
    public sealed class Widget_LogoIntro : MonoBehaviour {
        [SerializeField] public RectTransform motionRoot;
        [SerializeField] public RectTransform partsRoot;
        [SerializeField] public RectTransform hamsterRoot;
        [SerializeField] public RectTransform boardRoot;
        [SerializeField] public UnityEngine.UI.Image baseLogo;
        [SerializeField] public UnityEngine.UI.Image belly;
        [SerializeField] public UnityEngine.UI.Image eyesOpen;
        [SerializeField] public UnityEngine.UI.Image eyesBlink;
        [SerializeField] public RectTransform xMark;
        public Action completedHandle;
        public Action<AudioClip, float> audioHandle;
        LogoConfigSO config;
        Vector2 basePosition;
        Vector3 baseScale;
        float elapsed;
        float riseAt;
        float landAt;
        float impactAt;
        float xAt;
        float endAt;
        bool playing;
        bool completed;
        bool introEnabled;
        bool playedThisSession;
        bool riseSoundPlayed;
        bool landSoundPlayed;
        bool xSoundPlayed;

        public void Init(LogoConfigSO config) {
            if (motionRoot == null || partsRoot == null || hamsterRoot == null || boardRoot == null ||
                baseLogo == null || belly == null || eyesOpen == null || eyesBlink == null || xMark == null) {
                throw new InvalidOperationException("Widget_LogoIntro has unassigned authored parts.");
            }
            if (playing) {
                motionRoot.anchoredPosition = basePosition;
                motionRoot.localScale = baseScale;
            }
            this.config = config;
            basePosition = motionRoot.anchoredPosition;
            baseScale = motionRoot.localScale;
            elapsed = 0;
            completed = false;
            riseSoundPlayed = false;
            landSoundPlayed = false;
            xSoundPlayed = false;
            introEnabled = config.playIntro && (!config.oncePerSession || !playedThisSession);
            baseLogo.sprite = config.baseLogo;
            baseLogo.enabled = !introEnabled;
            partsRoot.gameObject.SetActive(introEnabled);
            riseAt = config.startDelay + config.boardPopSeconds + config.earPeekSeconds +
                config.earPeekHoldSeconds + config.earDipSeconds;
            landAt = riseAt + config.riseSeconds;
            impactAt = landAt + config.landSeconds;
            xAt = (config.xPunchAtImpact ? impactAt : impactAt + config.xPunchDelayAfterLand) + config.xStampDelay;
            endAt = Mathf.Max(impactAt + config.impactSeconds + config.bounceSeconds,
                impactAt + config.hamsterWobbleLag + config.hamsterWobbleSeconds,
                xAt + config.xPunchSeconds + config.xLandBounceSeconds);
            endAt += config.settleSeconds + (config.useBlink ? config.blinkSeconds : 0);
            if (!introEnabled) {
                endAt = config.logoPopDelaySeconds + config.logoPopSeconds;
            }
            playing = true;
            if (introEnabled) {
                playedThisSession = true;
            }
            Present(0);
        }

        public void Tick(float deltaTime) {
            if (!playing) {
                return;
            }
            elapsed += deltaTime;
            Present(elapsed);
            if (introEnabled && !completed) {
                PlayCues(elapsed);
            }
            if (!completed && elapsed >= endAt) {
                completed = true;
                // Keep the settled layers so the entrance and idle poses share identical geometry.
                completedHandle?.Invoke();
            }
        }

        void Present(float time) {
            if (completed) {
                float idle = time - endAt;
                motionRoot.anchoredPosition = basePosition + Vector2.up * Mathf.Sin(idle * config.bobSpeed) * config.bobHeight;
                motionRoot.localScale = baseScale * (1 + Mathf.Sin(idle * config.breatheSpeed) * config.breatheAmount);
                if (introEnabled) {
                    float pawScale = 1 + Mathf.Sin(idle * config.xIdlePulseSpeed) * config.xIdlePulseAmount;
                    xMark.localScale = Vector3.one * pawScale;
                }
                return;
            }
            if (!introEnabled) {
                float pop = Progress(time - config.logoPopDelaySeconds, config.logoPopSeconds);
                float back = pop - 1;
                float eased = 1 + 2.70158f * back * back * back + 1.70158f * back * back;
                motionRoot.localScale = baseScale * Mathf.LerpUnclamped(config.logoPopFrom, 1, eased);
                return;
            }
            float boardTime = time - config.startDelay;
            float boardProgress = Progress(boardTime, config.boardPopSeconds);
            float boardScale;
            if (boardProgress < 0.65f) {
                boardScale = Mathf.Lerp(config.boardPopFrom, config.boardPopTo, Smooth(boardProgress / 0.65f));
            } else {
                boardScale = Mathf.Lerp(config.boardPopTo, 1, Smooth((boardProgress - 0.65f) / 0.35f));
            }
            boardRoot.localScale = Vector3.one * boardScale;
            boardRoot.gameObject.SetActive(boardTime >= 0);
            float peekAt = config.startDelay + config.boardPopSeconds;
            float dipAt = riseAt - config.earDipSeconds;
            float y = -config.hideOffset;
            float stretch = 1;
            if (time >= riseAt && time < landAt) {
                float progress = Progress(time - riseAt, config.riseSeconds);
                y = Mathf.Lerp(-config.hideOffset + config.earPeek - config.earDip, config.overshoot,
                    1 - Mathf.Pow(1 - progress, 3));
                stretch += config.riseStretch * Mathf.Sin(progress * Mathf.PI);
            } else if (time >= landAt && time < impactAt) {
                float progress = Progress(time - landAt, config.landSeconds);
                y = Mathf.Lerp(config.overshoot, 0, progress * progress);
            } else if (time >= impactAt) {
                float impact = Progress(time - impactAt, config.impactSeconds);
                float rebound = time - impactAt - config.impactSeconds;
                stretch = 1 - config.landSquash * Mathf.Sin(impact * Mathf.PI);
                if (rebound >= 0) {
                    float damped = Damped(rebound, config.bounceSeconds, config.bouncePeriod);
                    stretch += config.landSquash * config.bounceAmplitude * damped;
                }
                float wobble = time - impactAt - config.hamsterWobbleLag;
                if (wobble >= 0) {
                    stretch += config.hamsterWobble * Damped(wobble, config.hamsterWobbleSeconds, config.hamsterWobblePeriod);
                }
                y = 0;
            } else if (time >= dipAt) {
                y += config.earPeek - config.earDip * Smooth(Progress(time - dipAt, config.earDipSeconds));
            } else if (time >= peekAt) {
                y += config.earPeek * Smooth(Progress(time - peekAt, config.earPeekSeconds));
            }
            hamsterRoot.anchoredPosition = Vector2.up * y;
            float width = time < impactAt ? 1 : 1 - (stretch - 1) * config.squashStretchRatio;
            hamsterRoot.localScale = new Vector3(width, stretch, 1);
            Color bellyColor = belly.color;
            bellyColor.a = Progress(time - impactAt, config.bellyFadeSeconds);
            belly.color = bellyColor;
            float punchTime = time - xAt;
            xMark.gameObject.SetActive(punchTime >= 0);
            float punch = Progress(punchTime, config.xPunchSeconds);
            float xScale = Mathf.Lerp(config.xPunchScale, 1, Smooth(punch));
            float xBounce = punchTime - config.xPunchSeconds;
            float xSquash = 0;
            if (xBounce >= 0) {
                xSquash = config.xLandSquash * Mathf.Sin(Progress(xBounce, config.xLandBounceSeconds) * Mathf.PI);
            }
            xMark.localScale = new Vector3(xScale + xSquash, xScale - xSquash, 1);
            bool blink = config.useBlink && time >= endAt - config.settleSeconds - config.blinkSeconds &&
                time < endAt - config.settleSeconds;
            eyesOpen.enabled = !blink;
            eyesBlink.enabled = blink;
        }

        void PlayCues(float time) {
            float riseSoundAt = riseAt - config.riseSfxLeadSeconds + config.riseSfxDelaySeconds;
            if (!riseSoundPlayed && time >= riseSoundAt) {
                riseSoundPlayed = true;
                if (config.sfxRise) {
                    audioHandle?.Invoke(config.riseClip, config.sfxRiseVolume);
                }
            }
            if (!landSoundPlayed && time >= impactAt) {
                landSoundPlayed = true;
                if (config.sfxLand) {
                    audioHandle?.Invoke(config.landClip, config.landVolume);
                }
            }
            if (!xSoundPlayed && time >= xAt - config.xSfxLeadSeconds + config.xSfxDelaySeconds) {
                xSoundPlayed = true;
                if (config.sfxXPunch) {
                    audioHandle?.Invoke(config.xPunchClip, config.sfxXPunchVolume);
                }
            }
        }

        float Progress(float time, float duration) {
            if (time < 0) {
                return 0;
            }
            if (duration <= 0) {
                return 1;
            }
            return Mathf.Clamp01(time / duration);
        }

        float Smooth(float value) {
            return value * value * (3 - 2 * value);
        }

        float Damped(float time, float duration, float period) {
            if (time < 0 || duration <= 0 || period <= 0 || time >= duration) {
                return 0;
            }
            return Mathf.Sin(time * Mathf.PI * 2 / period) * Mathf.Exp(-6 * time / duration) * (1 - time / duration);
        }

        public void TearDown() {
            if (playing && motionRoot != null) {
                motionRoot.anchoredPosition = basePosition;
                motionRoot.localScale = baseScale;
            }
            playing = false;
            config = null;
            completedHandle = null;
            audioHandle = null;
        }
    }
}
