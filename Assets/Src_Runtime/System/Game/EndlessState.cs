using System.Threading;
using System.Threading.Tasks;
namespace Hamdoku {
    public sealed class EndlessState {
        public PuzzleBoardModel suspendedBoard;
        public PuzzleSaveModel suspendedPuzzle;
        public bool recordPending;
        public bool isActive;
        public bool isTestRun;
        public bool generationFailed;
        public int cleared;
        public int found;
        public int bestBeforeRun;
        public float elapsed;
        public float advanceRemaining;
        public float failureRemaining;
        public Task<GeneratedPuzzleModel> generationTask;
        public CancellationTokenSource generationCancellation;
    }
}
