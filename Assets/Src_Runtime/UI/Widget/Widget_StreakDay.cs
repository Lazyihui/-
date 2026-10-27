using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Hamdoku {
    public sealed class Widget_StreakDay : MonoBehaviour {
        public TMP_Text weekday;
        public Image disc;
        public Image check;
        public Image gift;
        public Button button;
        public Action<int> rewardHandle;
        int slot;
        float stampElapsed;
        bool animateStamp;
        Vector3 checkScale;

        public void Ctor(int slot) {
            this.slot = slot;
            checkScale = check.transform.localScale;
            button.onClick.AddListener(ReportReward);
        }

        public void Show(string day, bool completed, bool today, Sprite giftSprite, StreakConfigSO config, bool stamp) {
            weekday.text = day;
            weekday.color = today ? config.todayColor : config.weekdayColor;
            disc.color = completed ? config.completedColor : config.emptyColor;
            check.gameObject.SetActive(completed);
            gift.sprite = giftSprite;
            gift.gameObject.SetActive(!completed && giftSprite != null);
            button.interactable = giftSprite != null;
            animateStamp = completed && stamp;
            stampElapsed = 0;
            check.transform.localScale = animateStamp ? Vector3.zero : checkScale;
        }

        public void Tick(float deltaTime, float duration) {
            if (!animateStamp) {
                return;
            }
            stampElapsed += deltaTime;
            float t = Mathf.Clamp01(stampElapsed / duration);
            float scale = t < 0.7f ? Mathf.Lerp(0, 1.18f, t / 0.7f) : Mathf.Lerp(1.18f, 1, (t - 0.7f) / 0.3f);
            check.transform.localScale = checkScale * scale;
            animateStamp = t < 1;
        }

        void ReportReward() {
            rewardHandle?.Invoke(slot);
        }

        public void TearDown() {
            button.onClick.RemoveListener(ReportReward);
            rewardHandle = null;
        }
    }
}
