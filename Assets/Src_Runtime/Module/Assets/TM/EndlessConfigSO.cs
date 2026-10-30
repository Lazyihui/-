using UnityEngine;
namespace Hamdoku {
    [CreateAssetMenu(menuName = "Hamdoku/EndlessConfig")]
    public sealed class EndlessConfigSO : ScriptableObject {
        public int startSize;
        public int maxSize;
        public int stepEvery;
        public int generationAttempts;
        public int repairStepsPerCell;
        public int hardCandidates;
        public float advanceSeconds;
        public float failureSeconds;
    }
}
