using UnityEngine;

namespace Hamdoku {
    public sealed class HomeState {
        public bool isOpen;
        public bool disposed;
        public bool saveInitialized;
        public bool dailyUnlocked;
        public bool rankingUnlocked;
        public bool endlessUnlocked;
        public HomeRequestType pendingRequest;
        public float noticeRemaining;
        public int noticeRequirement;
        public UINameType noticeType;
        public int displayedDate;
        public Rect safeArea;
        public int screenWidth;
        public int screenHeight;
    }
}
