using UnityEngine;
namespace Hamdoku {
    [CreateAssetMenu(menuName = "Hamdoku/CampaignConfig")]
    public sealed class CampaignConfigSO : ScriptableObject {
        public int[] puzzleIds;
        public int[] campaignSizes;
        public int[] campaignGradeCeilings;
        public int[] campaignSkillCeilings;
        public int[] campaignFixedLevels;
        public int[] campaignExpertSizes;
        public int campaignExpertStartLevel;
        public int campaignExpertGrade;
        public int campaignHardGrade;
        public int campaignHardStartLevel;
        public int campaignHardInterval;
        public int campaignMinimumSkillStartLevel;
        public int campaignLaterMinimumSkill;
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
