using UnityEngine;
namespace Hamdoku {
    [CreateAssetMenu(menuName = "Hamdoku/Game Config")]
    public sealed class GameConfigSO : ScriptableObject {
        public PuzzleSO tutorial;
        public PuzzleSO[] puzzles;
        public int[] campaignSizes;
        public int[] tutorialPlaceIndices;
        public UINameType[] tutorialPlaceTextTypes;
        public int[] tutorialLineIndices;
        public Color[] tutorialColors;
        public int tutorialPlaceIndex;
        public int tutorialTapIndex;
        public int[] tutorialDragIndices;
        public float tutorialCrossSettleSeconds;
        public float tutorialIdleHintSeconds;
        public float tutorialCardFadeSeconds;
        public float tutorialDimFadeSeconds;
        public float tutorialFingerPressSeconds;
        public float tutorialFingerReleaseSeconds;
        public float tutorialFingerRestSeconds;
        public float tutorialFingerDragSeconds;
        public float tutorialRippleSeconds;
        public float tutorialRippleFrom;
        public float tutorialRippleTo;
        public float tutorialRippleAlpha;
        public float tutorialHandScale;
        public float tutorialMarkSeconds;
        public float tutorialPlaceSeconds;
        public float tutorialCelebrateSeconds;
        public int maxHearts;
        public int hintsPerLevel;
        public int guidesPerLevel;
        public int scoreBase;
        public int scoreStep;
        public float doubleTapSeconds;
        public float dragThreshold;
        public float soundVolume;
        public Color[] regionColors;
        public Sprite[] patterns;
        public AudioClip placeClip;
        public AudioClip markClip;
        public AudioClip mistakeClip;
        public AudioClip clearClip;
    }
}
