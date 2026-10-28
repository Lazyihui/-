using UnityEngine;
namespace Hamdoku {
    [CreateAssetMenu(menuName = "Hamdoku/Result Config")]
    public sealed class ResultConfigSO : ScriptableObject {
        public Sprite clearHero;
        public Sprite[] clearHeroes;
        public int[] perfectHeroIds;
        public int[] hardFirstHeroIds;
        public int[] retryHeroIds;
        public int[] highHeroIds;
        public int[] midHeroIds;
        public int[] lowHeroIds;
        public int[] allHeroIds;
        public float heroBandHigh;
        public float heroBandMid;
        public float heroRankMid;
        public float heroRankSharp;
        public float heroTimePower;
        public float heroTimeScale;
        public float heroScoreWeight;
        public float heroTimeWeight;
        public int heroPickSalt;
        public float clearHeroTextGap;
        public Sprite failHero;
        public Sprite rewardHero;
        public float rewardHeroSize;
        public float rewardHeroAnchorY;
        public float rewardMessageAnchorY;
        public float rewardContentLiftY;
        public Color rewardTickColor;
        public Color rewardTickColorEmpty;
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
