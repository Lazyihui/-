using System;
using UnityEngine;

namespace Hamdoku {
    public sealed class LoadingState {
        public LoadingStatus status;
        public float elapsedSeconds;
        public bool logoCompleted;
        public bool readyNotified;
        public bool assetsLoaded;
        public Exception error;
        public Rect safeArea;
        public int screenWidth;
        public int screenHeight;
    }
}
