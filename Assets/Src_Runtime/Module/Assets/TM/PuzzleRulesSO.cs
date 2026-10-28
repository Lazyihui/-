using UnityEngine;
namespace Hamdoku {
    [CreateAssetMenu(menuName = "Hamdoku/PuzzleRules")]
    public sealed class PuzzleRulesSO : ScriptableObject {
        public int tutorialPuzzleId;
        public int[] tutorialPlaceIndices;
        public int[] tutorialLineIndices;
        public int tutorialPlaceIndex;
        public int tutorialTapIndex;
        public int[] tutorialDragIndices;
        public float tutorialCrossSettleSeconds;
        public float tutorialIdleHintSeconds;
        public int maxHearts;
        public int hintsPerLevel;
        public int guidesPerLevel;
        public int startRevealLevels;
        public int clearAutoCrossLevels;
        public int scoreBase;
        public int scoreStep;
        public float doubleTapSeconds;
        public float dragThreshold;
    }
}
