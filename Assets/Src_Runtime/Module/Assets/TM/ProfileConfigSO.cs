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
        public int helpMemberDays;
        public int helpRewardMax;
        public int helpRewardHint;
        public int helpRewardGuide;
        public int helpEligibleStreak;
        public Color helpBackdropColor;
        public Color editBackdropColor;
        public Sprite tabOn;
        public Sprite tabOff;
        public Color tabOnText;
        public Color tabOffText;
        public Sprite[] hands;
        public ProfileCostumeFitModel[] costumeFits;
        public Rect[] costumeRects;
        public Vector2 costumeHeadPivot;
        public int[] costumeSeasons;
        public int[] costumeSourceIds;
        public bool[] crownFrames;
        public float[] frameOpenings;
        public Vector2[] badgeCenters;
        public Color[] badgeColors;
        public Sprite[] frameAuras;
        public int[] frameAuraTiers;
        public float crownPlateScale;
        public float crownFrameScale;
        public Vector2 crownOpeningCenter;
        public float crownBadgeScale;
        public float ringOpeningOfPlate;
        public float portraitFaceScale;
        public float auraScale;
        public float[] auraAlpha;
        public float[] auraSpeed;
        public float[] auraHueBase;
        public float[] auraHueRange;
        public float auraSaturation;
        public float auraValue;
        public float sparkleSpeed;
        public float sparkleMinScale;
        public float newDotPulseScale;
        public float newDotPulseSeconds;
    }
}
