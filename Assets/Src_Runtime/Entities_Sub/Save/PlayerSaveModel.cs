using System.Runtime.Serialization;
using System;
using UnityEngine;

namespace Hamdoku {
    [Serializable]
    [DataContract]
    public sealed class PlayerSaveModel {
        [DataMember] public EndlessSaveModel endless;
        [DataMember] public DailySaveModel daily;
        [DataMember] public CampaignSaveModel campaign;
        [DataMember] public SettingsSaveModel settings;
        [DataMember] public ProfileSaveModel profile;
        [DataMember]
        public RankingSaveModel ranking;
        [DataMember]
        public int version;
        [DataMember]
        public int campaignClears;
        [DataMember]
        public bool tutorialCompleted;
        [DataMember]
        public SystemLanguage language;
        [DataMember]
        public int dailyStreak;
        [DataMember]
        public StreakSaveModel streak;
        [DataMember]
        public PuzzleSaveModel activePuzzle;
        [DataMember]
        public int previousPuzzleId;
    }
}
