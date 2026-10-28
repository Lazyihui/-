using UnityEngine;
namespace Hamdoku {
    [CreateAssetMenu(menuName = "Hamdoku/Result Config")]
    public sealed class ResultConfigSO : ScriptableObject {
        public Sprite clearHero;
        public Sprite failHero;
        public float titleAnchorY;
        public float clearHeroAnchorY;
        public float clearHeroSize;
        public float failHeroAnchorY;
        public float failHeroSize;
        public float messageAnchorY;
        public float statRowAnchorY;
        public float clearButtonAnchorY;
        public float failRemainingAnchorY;
        public float failMessageAnchorY;
        public float failContinueAnchorY;
        public float failRestartAnchorY;
        public float revealHeroAt;
        public float revealStatsAt;
        public float revealButtonAt;
        public float revealFadeSeconds;
        public float statCountUpSeconds;
        public float failButtonsAt;
    }
}
