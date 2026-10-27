using UnityEngine;

namespace Hamdoku {
    public sealed class StreakState {
        public bool isOpen;
        public bool disposed;
        public bool pagePending;
        public bool continueCampaign;
        public int displayedDay;
        public UINameType notice;
        public int previewSlot;
        public Rect safeArea;
        public int screenWidth;
        public int screenHeight;
    }
}
