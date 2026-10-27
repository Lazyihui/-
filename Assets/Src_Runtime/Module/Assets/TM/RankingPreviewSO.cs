using UnityEngine;
namespace Hamdoku {
    // Editor fixture only: never default-labelled, never used as an online response.
    [CreateAssetMenu(menuName = "Hamdoku/Ranking Preview")]
    public sealed class RankingPreviewSO : ScriptableObject {
        public int remainingSeconds = 235041;
        public RankingEntryModel[] entries;
        public RankingEntryModel me;
    }
}
