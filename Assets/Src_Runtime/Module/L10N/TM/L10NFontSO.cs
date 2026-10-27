using TMPro;
using UnityEngine;

namespace Hamdoku {
    [CreateAssetMenu(fileName = "Font", menuName = "Hamdoku/Localization/Font")]
    public sealed class L10NFontSO : ScriptableObject {
        public SystemLanguage language;
        public TMP_FontAsset font;
    }
}
