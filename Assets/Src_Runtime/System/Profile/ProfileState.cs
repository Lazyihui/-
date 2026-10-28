namespace Hamdoku {
    public sealed class ProfileState {
        public int savedAvatarId;
        public int savedFrameId;
        public int savedCostumeId;
        public bool isOpen;
        public ProfileTabType tab;
        public ProfileDialogType dialog;
        public UINameType notice;
        public int noticeArgument;
        public float noticeRemaining;
        public int visitedTabs;
    }
}
