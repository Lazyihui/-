using UnityEngine;
namespace Hamdoku {
    [CreateAssetMenu(menuName = "Hamdoku/Game Config")]
    public sealed class GameConfigSO : ScriptableObject {
        public PuzzleSO tutorial;
        public PuzzleSO[] puzzles;
        public int[] campaignSizes;
        public int tutorialPlaceIndex;
        public int tutorialTapIndex;
        public int[] tutorialDragIndices;
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
