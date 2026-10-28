using UnityEngine;
namespace Hamdoku {
    [CreateAssetMenu(menuName = "Hamdoku/CampaignConfig")]
    public sealed class CampaignConfigSO : ScriptableObject {
        public int[] puzzleIds;
        public int[] campaignSizes;
        public int[] campaignGradeCeilings;
        public int[] campaignSkillCeilings;
        public int[] campaignFixedLevels;
        public int campaignRewardStep;
        public int campaignRewardHints;
        public int campaignRewardGuides;
        public int campaignInitialSkill;
        public int campaignAdaptiveStartLevel;
        public int campaignCleanClearsToPromote;
        public int campaignLaterPromotionStartLevel;
        public int campaignLaterCleanClearsToPromote;
        public int campaignTransformStartLevel;
        public int campaignFailureThreshold;
        public int campaignReliefStartLevel;
        public int campaignLaterFailureThreshold;
        public int campaignHistoryLimit;
        public int campaignCursorSlots;
    }
}
