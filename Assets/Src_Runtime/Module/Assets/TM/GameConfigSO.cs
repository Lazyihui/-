using UnityEngine;
namespace Hamdoku {
    [CreateAssetMenu(menuName = "Hamdoku/Game Config")]
    public sealed class GameConfigSO : ScriptableObject {
        public SystemLanguage defaultLanguage;
        public int saveVersion;
        public string saveFileName;
    }
}
