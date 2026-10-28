using UnityEngine;

namespace Hamdoku {
    [CreateAssetMenu(fileName = "HomeConfig", menuName = "Hamdoku/Home Config")]
    public sealed class HomeConfigSO : ScriptableObject {
        [Header("Original unlock conditions")]
        public int dailyUnlockClears;
        public int rankingUnlockClears;
        public int endlessUnlockClears;
        public int hardLevelStart;
        public int hardLevelInterval;
        [Header("Presentation")]
        public float noticeSeconds;
        public AudioClip buttonClip;
        [Range(0, 1)] public float buttonVolume;
        public Sprite levelNormal;
        public Sprite levelHard;
        public Sprite logoNormal;
        public Sprite logoHard;
        public Color lockedTint;
        public float idleBreatheAmount;
        public float idleBreatheSpeed;
        public float idleBobHeight;
        public float idleBobSpeed;
        [Header("Original lobby sunflower (UiSway / UiSparkles)")]
        public float sunflowerSwayDegrees;
        public float sunflowerSwaySeconds;
        public float sunflowerSwayPivotY;
        public float sunflowerSwayHarmonicAmount;
        public float sunflowerSwayHarmonicSpeed;
        public float sunflowerSwayHarmonicPhase;
        public int sunflowerSparkleCount;
        public Color sunflowerSparkleColor;
        public Vector2 sunflowerSparkleSize;
        public float sunflowerSparkleInnerScale;
        public float sunflowerSparkleAreaScale;
        public float sunflowerSparkleRadiusGap;
        public float sunflowerSparkleInitialDelay;
        public Vector2 sunflowerSparkleFadeIn;
        public Vector2 sunflowerSparkleHold;
        public Vector2 sunflowerSparkleFadeOut;
        public Vector2 sunflowerSparkleRest;
    }
}
