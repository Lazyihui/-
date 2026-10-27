using UnityEngine;
namespace Hamdoku {
    public sealed class Widget_BoardCell : MonoBehaviour {
        public UnityEngine.UI.Image background;
        public UnityEngine.UI.Image pattern;
        public UnityEngine.UI.Image hamster;
        public UnityEngine.UI.Image cross;
        public UnityEngine.UI.Image crossSecond;
        public UnityEngine.UI.Image focus;
        public UnityEngine.UI.Image given;
        public void Show(Color color, Sprite motif, CellStatus status, bool highlighted, bool fixedHamster) {
            background.color = color;
            pattern.sprite = motif;
            pattern.color = new Color(color.r * 0.65f, color.g * 0.65f, color.b * 0.65f, 0.26f);
            pattern.enabled = status == CellStatus.None;
            hamster.enabled = status == CellStatus.Hamster;
            cross.enabled = status == CellStatus.Cross;
            cross.gameObject.SetActive(status == CellStatus.Cross);
            crossSecond.enabled = status == CellStatus.Cross;
            crossSecond.gameObject.SetActive(status == CellStatus.Cross);
            focus.enabled = highlighted;
            given.enabled = fixedHamster;
        }
    }
}
