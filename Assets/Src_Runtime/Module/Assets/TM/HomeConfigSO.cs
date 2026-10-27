using UnityEngine;

namespace Hamdoku {
    [CreateAssetMenu(fileName = "HomeConfig", menuName = "Hamdoku/Home Config")]
    public sealed class HomeConfigSO : ScriptableObject {
        [Header("Original unlock conditions")]
        public int dailyUnlockClears;
        public int rankingUnlockClears;
        public int endlessUnlockClears;
        public int hardLevelStart;
        public int hardLevelInterval;
        [Header("Local progress")]
        public string saveFileName;
        public int saveVersion;
        public SystemLanguage defaultLanguage;
        [Header("Presentation")]
        public float noticeSeconds;
        public AudioClip buttonClip;
        [Range(0, 1)] public float buttonVolume;
        public Sprite levelNormal;
        public Sprite levelHard;
        public Sprite logoNormal;
        public Sprite logoHard;
        public Color lockedTint;
        public float idleBreatheAmount;
        public float idleBreatheSpeed;
    }
}
