namespace Hamdoku {
    public sealed class GameState {
        public UnityEngine.Rect safeArea;
        public int screenWidth;
        public int screenHeight;
        public bool isOpen;
        public bool disposed;
        public bool isTutorial;
        public int level;
        public PuzzleSO puzzle;
        public CellStatus[] cells;
        public int hearts;
        public int mistakes;
        public int hints;
        public int guides;
        public int score;
        public float elapsed;
        public int tutorialStep;
        public bool tutorialHintVisible;
        public bool tutorialHintUsed;
        public float tutorialIdleElapsed;
        public bool tutorialTransitionPending;
        public float tutorialTransitionRemaining;
        public GameStatus status;
        public GameDialogType dialog;
        public UINameType notice;
    }
}
