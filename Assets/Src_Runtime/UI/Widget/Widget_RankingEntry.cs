using System;
using TMPro;
using UnityEngine;
namespace Hamdoku {
    public sealed class Widget_RankingEntry : MonoBehaviour {
        public UnityEngine.UI.Image background;
        public UnityEngine.UI.Image avatar;
        public UnityEngine.UI.Image costume;
        public UnityEngine.UI.Image medal;
        public UnityEngine.UI.Image gift;
        public TMP_Text rankLabel;
        public TMP_Text nameLabel;
        public TMP_Text seedsLabel;
        public UnityEngine.UI.Button giftButton;
        public Action<int> giftHandle;
        int displayedRank;
        Color ordinaryRankColor;
        public void Ctor() {
            ordinaryRankColor = rankLabel.color;
            giftButton.onClick.AddListener(ReportGift);
        }
        public void Show(RankingEntryModel entry, RankingConfigSO config, bool mine, string missing) {
            displayedRank = entry == null ? 0 : entry.rank;
            bool top = displayedRank >= 1 && displayedRank <= 3;
            rankLabel.gameObject.SetActive(true);
            rankLabel.color = top ? Color.white : ordinaryRankColor;
            rankLabel.text = displayedRank == 0 ? missing : displayedRank.ToString();
            nameLabel.text = entry == null ? missing : entry.displayName;
            seedsLabel.text = entry == null ? missing : entry.seeds.ToString();
            avatar.gameObject.SetActive(entry != null);
            costume.gameObject.SetActive(entry != null && entry.costumeId != 0);
            if (entry != null) {
                avatar.sprite = config.avatars[entry.avatarId];
                if (entry.costumeId != 0) {
                    costume.sprite = config.costumes[entry.costumeId];
                }
            }
            medal.gameObject.SetActive(top);
            gift.gameObject.SetActive(top);
            giftButton.interactable = top;
            if (top) {
                medal.sprite = config.medals[displayedRank - 1];
                gift.sprite = config.gifts[displayedRank - 1];
            }
            background.color = mine ? config.myRowColor : top ? config.rowColors[displayedRank - 1] : Color.white;
        }
        void ReportGift() {
            giftHandle?.Invoke(displayedRank);
        }
        public void TearDown() {
            giftButton.onClick.RemoveListener(ReportGift);
            giftHandle = null;
        }
    }
}
