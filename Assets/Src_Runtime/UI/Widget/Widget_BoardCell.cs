using UnityEngine;
namespace Hamdoku {
    public sealed class Widget_BoardCell : MonoBehaviour {
        public UnityEngine.UI.Image[] regionEdges;
        public UnityEngine.UI.Image background;
        public UnityEngine.UI.Image pattern;
        public UnityEngine.UI.Image hamster;
        public UnityEngine.UI.Image cross;
        public UnityEngine.UI.Image crossSecond;
        public UnityEngine.UI.Image focus;
        public UnityEngine.UI.Image given;
        public UnityEngine.UI.Image tutorialDim;
        public void ShowRegionBorder(bool visible, Color color, float width, bool top, bool right, bool bottom, bool left) {
            for (int i = 0; i < regionEdges.Length; i++) {
                var edge = regionEdges[i];
                edge.enabled = visible && (i == 0 ? top : i == 1 ? right : i == 2 ? bottom : left);
                edge.color = color;
                var rect = edge.rectTransform;
                rect.sizeDelta = i % 2 == 0 ? new Vector2(0, width) : new Vector2(width, 0);
            }
        }
        public void SetDimmed(bool dimmed) {
            tutorialDim.enabled = dimmed;
        }
        public void SetPressed(bool pressed) {
            transform.localScale = Vector3.one * (pressed ? 0.94f : 1);
        }
        public void Show(Color color, Sprite motif, CellStatus status, bool highlighted, bool fixedHamster) {
            background.color = color;
            pattern.sprite = motif;
            pattern.color = new Color(color.r * 0.65f, color.g * 0.65f, color.b * 0.65f, 0.26f);
            pattern.enabled = status == CellStatus.None && motif != null;
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
