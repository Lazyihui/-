using UnityEngine;

namespace Hamdoku {
    [CreateAssetMenu(menuName = "Hamdoku/Daily Season")]
    public sealed class DailySeasonSO : ScriptableObject {
        public int id;
        public UINameType title;
        public Sprite artwork;
        public Sprite lines;
        public Sprite[] pieces;
        public Sprite[] lockedPieces;
        public Rect[] pieceRects;
        public int[] revealOrder;
        public int[] costumeIds;
        public int[] rewardPieces;
    }
}
