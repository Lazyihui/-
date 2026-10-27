using UnityEngine;
namespace Hamdoku {
    [CreateAssetMenu(menuName = "Hamdoku/Ranking Config")]
    public sealed class RankingConfigSO : ScriptableObject {
        public int assetVersion;
        public int visibleRows = 3;
        public float refreshSeconds = 1;
        public Sprite[] avatars;
        public Sprite[] costumes;
        public Sprite[] medals;
        public Sprite[] gifts;
        public Color[] rowColors;
        public Color myRowColor;
    }
}
