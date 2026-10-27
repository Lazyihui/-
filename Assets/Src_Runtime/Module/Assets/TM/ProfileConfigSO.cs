using UnityEngine;

namespace Hamdoku {
    [CreateAssetMenu(menuName = "Hamdoku/Profile Config")]
    public sealed class ProfileConfigSO : ScriptableObject {
        public Sprite[] avatars;
        public Sprite[] frames;
        public Sprite[] costumes;
        public Color[] avatarColors;
        public int[] avatarUnlockClears;
        public int[] frameUnlockClears;
        public int[] frameRankWins;
        public UINameType[] mottos;
        public UINameType[] costumeNames;
        public int clubAvatarStart;
        public int hiddenAvatarId;
        public int clubFrameId;
        public int nameMaxChars;
        public Color selectedColor;
        public Color idleColor;
        public float lockedAlpha;
        public float noticeSeconds;
    }
}
