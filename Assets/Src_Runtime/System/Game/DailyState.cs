using UnityEngine;

namespace Hamdoku {
    public sealed class DailyState {
        public bool isOpen;
        public int selectedDay;
        public int seasonIndex;
        public int rewardIndex;
        public int shownUnits;
        public float refreshElapsed;
        public float noticeRemaining;
        public UINameType notice;
        public Rect safeArea;
        public int screenWidth;
        public int screenHeight;
    }
}
