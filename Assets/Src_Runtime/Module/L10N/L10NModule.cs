using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Hamdoku {
    public sealed class L10NModule {
        readonly Dictionary<UINameType, L10NSO> texts = new Dictionary<UINameType, L10NSO>();
        readonly Dictionary<SystemLanguage, TMP_FontAsset> fonts = new Dictionary<SystemLanguage, TMP_FontAsset>();
        readonly List<TMP_Text> registered = new List<TMP_Text>();
        SystemLanguage language;

        public void AddAll(IReadOnlyList<L10NSO> entries, IReadOnlyList<L10NFontSO> fontEntries) {
            foreach (var entry in entries) {
                texts.Add(entry.id, entry);
            }
            foreach (var entry in fontEntries) {
                fonts.Add(entry.language, entry.font);
            }
        }

        public void Language_Set(SystemLanguage value) {
            if (value != SystemLanguage.ChineseSimplified && value != SystemLanguage.English) {
                throw new NotSupportedException("Unsupported home language: " + value);
            }
            language = value;
            var font = fonts[language];
            foreach (var text in registered) {
                text.font = font;
            }
        }

        public bool TryGet(UINameType id, out string text) {
            if (!texts.TryGetValue(id, out var entry)) {
                text = null;
                return false;
            }
            text = language == SystemLanguage.ChineseSimplified ? entry.chinese : entry.english;
            return true;
        }

        public void TMP_Register(TMP_Text text) {
            text.font = fonts[language];
            registered.Add(text);
        }

        public void TMP_Unregister(TMP_Text text) {
            registered.Remove(text);
        }

        public void Release() {
            registered.Clear();
            texts.Clear();
            fonts.Clear();
        }
    }
}
