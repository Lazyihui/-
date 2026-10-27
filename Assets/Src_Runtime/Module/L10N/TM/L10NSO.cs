using UnityEngine;

namespace Hamdoku {
    [CreateAssetMenu(fileName = "Text", menuName = "Hamdoku/Localization/Text")]
    public sealed class L10NSO : ScriptableObject {
        public UINameType id;
        [TextArea] public string chinese;
        [TextArea] public string english;
    }
}
