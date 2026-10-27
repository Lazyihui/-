using UnityEngine;

namespace Hamdoku {
    [CreateAssetMenu(fileName = "LogoConfig", menuName = "Hamdoku/Logo Config")]
    public sealed class LogoConfigSO : ScriptableObject {
        [Header("Loading screen")]
        public HomeConfigSO startupHomeConfig;
        public L10NSO[] startupTexts;
        public L10NFontSO[] startupFonts;
        public int seedCount;
        public float seedPopScale;
        public float seedPopSeconds;
        public float seedIdlePulse;
        public float finishHoldSeconds;
        [Header("Playback")]
        public bool playIntro;
        public bool oncePerSession;
        public float startDelay;
        public Sprite baseLogo;
        public Vector2 canvasSize;
        [Header("Original logo pieces: sprite, size and center")]
        public Sprite hamsterMask;
        public Vector2 hamsterMaskSize;
        public Vector2 hamsterMaskCenter;
        public Sprite hamsterBody;
        public Vector2 hamsterBodySize;
        public Vector2 hamsterBodyCenter;
        public Sprite eyesOpen;
        public Vector2 eyesOpenSize;
        public Vector2 eyesOpenCenter;
        public Sprite eyesBlink;
        public Vector2 eyesBlinkSize;
        public Vector2 eyesBlinkCenter;
        public Sprite boardBack;
        public Vector2 boardBackSize;
        public Vector2 boardBackCenter;
        public Sprite bellyOverlay;
        public Vector2 bellyOverlaySize;
        public Vector2 bellyOverlayCenter;
        public Sprite boardFront;
        public Vector2 boardFrontSize;
        public Vector2 boardFrontCenter;
        public Sprite xMark;
        public Vector2 xMarkSize;
        public Vector2 xMarkCenter;
        [Header("Hamster entrance")]
        public float hideOffset;
        public float earPeek;
        public float earPeekHoldSeconds;
        public float earDip;
        public float earDipSeconds;
        public float overshoot;
        public float riseStretch;
        public float boardPopSeconds;
        public float boardPopFrom;
        public float boardPopTo;
        public float earPeekSeconds;
        public float riseSeconds;
        public float landSeconds;
        public float impactSeconds;
        public float landSquash;
        public float squashStretchRatio;
        public float bellyFadeSeconds;
        public float bounceSeconds;
        public float bounceAmplitude;
        public float bouncePeriod;
        public float hamsterWobble;
        public float hamsterWobbleLag;
        public float hamsterWobbleSeconds;
        public float hamsterWobblePeriod;
        public bool xPunchAtImpact;
        public float xStampDelay;
        public float xPunchDelayAfterLand;
        public float xPunchSeconds;
        public float xPunchScale;
        public float xLandSquash;
        public float xLandBounceSeconds;
        public float xSfxLeadSeconds;
        public float xSfxDelaySeconds;
        [Header("Blink and settle")]
        public bool useBlink;
        public float blinkSeconds;
        public float settleSeconds;
        [Header("Sound cues")]
        public bool sfxRise;
        public float sfxRiseVolume;
        public float riseSfxLeadSeconds;
        public float riseSfxDelaySeconds;
        public bool sfxLand;
        public bool sfxXPunch;
        public float sfxXPunchVolume;
        [Header("Startup duration and idle animation")]
        public float minShowSeconds;
        public float breatheAmount;
        public float breatheSpeed;
        public float bobHeight;
        public float bobSpeed;
        public float logoPopFrom;
        public float logoPopSeconds;
        public float logoPopDelaySeconds;
        [Header("Audio assets")]
        public AudioClip riseClip;
        public AudioClip landClip;
        public AudioClip xPunchClip;
        [Range(0, 1)] public float landVolume;
    }
}
