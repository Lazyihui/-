using UnityEngine;
namespace Hamdoku {
    [CreateAssetMenu(menuName = "Hamdoku/Puzzle")]
    public sealed class PuzzleSO : ScriptableObject {
        public int id;
        public int size;
        public int[] regions;
        public int[] solutionColumns;
        public int[] preplacedRows;
        public string source;
    }
}
