using UnityEngine;

namespace Hamdoku {
    [CreateAssetMenu(menuName = "Hamdoku/Daily Config")]
    public sealed class DailyConfigSO : ScriptableObject {
        public int firstDay;
        public int[] dayToPuzzle;
        public DailySeasonSO[] seasons;
        public Sprite background;
        public Sprite card;
        public Sprite calendarCard;
        public Sprite circle;
        public Sprite clearStamp;
        public Sprite perfectStamp;
        public Sprite clearIcon;
        public Sprite perfectIcon;
        public Sprite back;
        public Sprite history;
        public Sprite clock;
        public Sprite start;
        public float revealSeconds;
        public float noticeSeconds;
        public float revealScale;
        public Color availableDayColor;
        public Color futureDayColor;
        public Color selectedDayColor;
        public Color availableNumberColor;
        public Color futureNumberColor;
    }
}
