using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
namespace Hamdoku {
    public sealed class Panel_Ranking : MonoBehaviour, IPanelAsset {
        public RectTransform safeRoot;
        public RectTransform contentRoot;
        public TMP_Text titleLabel;
        public TMP_Text timeLabel;
        public TMP_Text statusLabel;
        public TMP_Text previewLabel;
        public TMP_Text collectLabel;
        public TMP_Text retryLabel;
        public TMP_Text myLabel;
        public UnityEngine.UI.Button backButton;
        public UnityEngine.UI.Button infoButton;
        public UnityEngine.UI.Button collectButton;
        public UnityEngine.UI.Button retryButton;
        public UnityEngine.UI.Button rewardButton;
        public TMP_Text rewardLabel;
        public Action rewardHandle;
        public Widget_RankingEntry[] podium;
        public Widget_RankingEntry myEntry;
        public Widget_RankingEntry entryPrefab;
        public RectTransform listRoot;
        public UnityEngine.UI.ScrollRect scroll;
        public Action backHandle;
        public Action infoHandle;
        public Action collectHandle;
        public Action retryHandle;
        public Action<int> giftHandle;
        readonly List<Widget_RankingEntry> rows = new List<Widget_RankingEntry>();
        L10NModule localization;
        public PanelType Type {
            get {
                return PanelType.Ranking;
            }
        }
        public void Ctor(L10NModule localization) {
            this.localization = localization;
            RegisterTexts(gameObject);
            backButton.onClick.AddListener(ReportBack);
            infoButton.onClick.AddListener(ReportInfo);
            collectButton.onClick.AddListener(ReportCollect);
            retryButton.onClick.AddListener(ReportRetry);
            rewardButton.onClick.AddListener(ReportReward);
            foreach (var entry in podium) {
                entry.Ctor();
                entry.giftHandle = ReportGift;
            }
            myEntry.Ctor();
            myEntry.giftHandle = ReportGift;
        }
        void RegisterTexts(GameObject root) {
            foreach (var text in root.GetComponentsInChildren<TMP_Text>(true)) {
                localization.TMP_Register(text);
            }
        }
        public void Init() {
            ApplySafeArea();
        }
        public void ShowEntries(RankingEntryModel[] entries, RankingEntryModel me, RankingConfigSO config, string missing) {
            int count = entries == null ? 0 : entries.Length;
            while (rows.Count < count) {
                var row = Instantiate(entryPrefab, listRoot);
                row.Ctor();
                row.giftHandle = ReportGift;
                RegisterTexts(row.gameObject);
                rows.Add(row);
            }
            for (int i = 0; i < rows.Count; i++) {
                rows[i].gameObject.SetActive(i < count);
                if (i < count) {
                    rows[i].Show(entries[i], config, me != null && entries[i].playerId == me.playerId, missing);
                }
            }
            for (int i = 0; i < podium.Length; i++) {
                RankingEntryModel winner = null;
                if (entries != null) {
                    foreach (var entry in entries) {
                        if (entry.rank == i + 1) {
                            winner = entry;
                            break;
                        }
                    }
                }
                podium[i].Show(winner, config, false, missing);
            }
            myEntry.Show(me, config, true, missing);
            scroll.vertical = count > config.visibleRows;
        }
        public void ApplySafeArea() {
            Rect area = Screen.safeArea;
            safeRoot.anchorMin = new Vector2(area.xMin / Screen.width, area.yMin / Screen.height);
            safeRoot.anchorMax = new Vector2(area.xMax / Screen.width, area.yMax / Screen.height);
            safeRoot.offsetMin = Vector2.zero;
            safeRoot.offsetMax = Vector2.zero;
            Canvas.ForceUpdateCanvases();
            Vector2 available = safeRoot.rect.size;
            Vector2 authored = contentRoot.sizeDelta;
            contentRoot.localScale = Vector3.one * Mathf.Min(available.x / authored.x, available.y / authored.y);
        }
        void ReportBack() {
            backHandle?.Invoke();
        }
        void ReportInfo() {
            infoHandle?.Invoke();
        }
        void ReportCollect() {
            collectHandle?.Invoke();
        }
        void ReportRetry() {
            retryHandle?.Invoke();
        }
        void ReportReward() {
            rewardHandle?.Invoke();
        }
        void ReportGift(int rank) {
            giftHandle?.Invoke(rank);
        }
        public void TearDown() {
            backButton.onClick.RemoveListener(ReportBack);
            infoButton.onClick.RemoveListener(ReportInfo);
            collectButton.onClick.RemoveListener(ReportCollect);
            retryButton.onClick.RemoveListener(ReportRetry);
            rewardButton.onClick.RemoveListener(ReportReward);
            rewardHandle = null;
            foreach (var entry in podium) {
                entry.TearDown();
            }
            myEntry.TearDown();
            foreach (var row in rows) {
                row.TearDown();
            }
            rows.Clear();
            foreach (var text in GetComponentsInChildren<TMP_Text>(true)) {
                localization.TMP_Unregister(text);
            }
            backHandle = null;
            infoHandle = null;
            collectHandle = null;
            retryHandle = null;
            giftHandle = null;
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
