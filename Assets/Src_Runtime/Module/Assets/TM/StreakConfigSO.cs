using UnityEngine;

namespace Hamdoku {
    [CreateAssetMenu(fileName = "StreakConfig", menuName = "Hamdoku/Streak Config")]
    public sealed class StreakConfigSO : ScriptableObject {
        public int cycleDays;
        public int[] rewardHints;
        public int[] rewardGuides;
        public bool recoveryEnabled;
        public int recoveryMaxGapDays;
        public int recoveryMinStreak;
        public int[] companionDays;
        public Sprite[] plants;
        public Sprite smallGift;
        public Sprite bigGift;
        public Sprite check;
        public Sprite aura;
        public Sprite petal;
        public Sprite flowerHead;
        public Sprite[] butterflies;
        public Color completedColor;
        public Color emptyColor;
        public Color todayColor;
        public Color weekdayColor;
        public Color auraColor;
        public float plantSize;
        public float plantReferencePixels;
        public Vector2 plantPosition;
        public float swayDegrees;
        public float swaySeconds;
        public float auraBreath;
        public float introSeconds;
        public float butterflySeconds;
        public float butterflyFlapSeconds;
        public float stampSeconds;
        public int petalCount;
        public float petalInterval;
        public float petalLength;
        public float petalOutset;
        public Vector2 flowerHeadPosition;
        public float flowerHeadSize;
        public Vector2 butterflyRange;
        public float butterflyHeight;
    }
}
