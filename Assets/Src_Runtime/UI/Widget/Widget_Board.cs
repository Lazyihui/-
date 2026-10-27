using System;
using UnityEngine;
using UnityEngine.EventSystems;
namespace Hamdoku {
    public sealed class Widget_Board : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler, IInitializePotentialDragHandler {
        public Widget_BoardCell cellPrefab;
        public RectTransform gridRoot;
        public Action<int, bool, bool> inputHandle;
        Widget_BoardCell[] cells;
        int size;
        int pointerId;
        int pressedCell;
        int previousDragCell;
        int lastTapCell = -1;
        float lastTapTime;
        float doubleTapSeconds;
        float dragThreshold;
        bool pressed;
        bool dragging;
        bool[] visited;
        Vector2 downPosition;
        public void Init(int size, float doubleTapSeconds, float dragThreshold) {
            if (cellPrefab == null || gridRoot == null || size < 1 || gridRoot.rect.width <= 0) {
                throw new InvalidOperationException("Widget_Board requires a bound cell prefab and a non-empty grid rect.");
            }
            CancelGesture();
            this.doubleTapSeconds = doubleTapSeconds;
            this.dragThreshold = dragThreshold;
            if (cells != null && this.size == size) {
                return;
            }
            if (cells != null) {
                foreach (var cell in cells) {
                    cell.gameObject.SetActive(false);
                    Destroy(cell.gameObject);
                }
            }
            this.size = size;
            cells = new Widget_BoardCell[size * size];
            visited = new bool[cells.Length];
            float step = gridRoot.rect.width / size;
            for (int i = 0; i < cells.Length; i++) {
                var cell = Instantiate(cellPrefab, gridRoot);
                var rect = (RectTransform)cell.transform;
                rect.anchorMin = new Vector2(0, 1);
                rect.anchorMax = rect.anchorMin;
                rect.pivot = new Vector2(0.5f, 0.5f);
                rect.sizeDelta = Vector2.one * (step - 6);
                rect.anchoredPosition = new Vector2((i % size + 0.5f) * step, -(i / size + 0.5f) * step);
                cells[i] = cell;
            }
        }
        public void ShowCell(int index, Color color, Sprite pattern, CellStatus status, bool highlighted, bool given) {
            cells[index].Show(color, pattern, status, highlighted, given);
        }
        public void CancelGesture() {
            pressed = false;
            dragging = false;
            lastTapCell = -1;
        }
        public int CellAt(Vector2 position, Camera camera) {
            if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(gridRoot, position, camera, out var local)) {
                return -1;
            }
            var rect = gridRoot.rect;
            if (!rect.Contains(local)) {
                return -1;
            }
            int col = Mathf.FloorToInt((local.x - rect.xMin) / rect.width * size);
            int row = Mathf.FloorToInt((rect.yMax - local.y) / rect.height * size);
            return row < 0 || row >= size || col < 0 || col >= size ? -1 : row * size + col;
        }
        public void OnInitializePotentialDrag(PointerEventData data) {
            data.useDragThreshold = false;
        }
        public void OnPointerDown(PointerEventData data) {
            if (pressed || data.button != PointerEventData.InputButton.Left) {
                return;
            }
            pressedCell = CellAt(data.position, data.pressEventCamera);
            if (pressedCell < 0) {
                return;
            }
            pressed = true;
            pointerId = data.pointerId;
            downPosition = data.position;
            dragging = false;
            Array.Clear(visited, 0, visited.Length);
        }
        public void OnDrag(PointerEventData data) {
            if (!pressed || pointerId != data.pointerId) {
                return;
            }
            if (!dragging) {
                RectTransformUtility.ScreenPointToLocalPointInRectangle(gridRoot, downPosition, data.pressEventCamera, out var downLocal);
                RectTransformUtility.ScreenPointToLocalPointInRectangle(gridRoot, data.position, data.pressEventCamera, out var currentLocal);
                if (Vector2.Distance(currentLocal, downLocal) < dragThreshold) {
                    return;
                }
            }
            if (!dragging) {
                dragging = true;
                lastTapCell = -1;
                previousDragCell = pressedCell;
                ReportDrag(pressedCell);
            }
            int current = CellAt(data.position, data.pressEventCamera);
            if (current < 0) {
                previousDragCell = -1;
                return;
            }
            if (previousDragCell >= 0) {
                int row = previousDragCell / size;
                int col = previousDragCell % size;
                int dr = current / size - row;
                int dc = current % size - col;
                int steps = Mathf.Max(Mathf.Abs(dr), Mathf.Abs(dc));
                for (int i = 1; i <= steps; i++) {
                    ReportDrag((row + Mathf.RoundToInt((float)dr * i / steps)) * size + col + Mathf.RoundToInt((float)dc * i / steps));
                }
            } else {
                ReportDrag(current);
            }
            previousDragCell = current;
        }
        void ReportDrag(int index) {
            if (visited[index]) {
                return;
            }
            visited[index] = true;
            inputHandle?.Invoke(index, false, true);
        }
        public void OnPointerUp(PointerEventData data) {
            if (!pressed || pointerId != data.pointerId) {
                return;
            }
            pressed = false;
            int index = CellAt(data.position, data.pressEventCamera);
            if (dragging || index != pressedCell) {
                lastTapCell = -1;
                return;
            }
            float time = Time.unscaledTime;
            bool twice = lastTapCell == index && time - lastTapTime <= doubleTapSeconds;
            lastTapCell = twice ? -1 : index;
            lastTapTime = time;
            inputHandle?.Invoke(index, twice, false);
        }
        public void TearDown() {
            CancelGesture();
            inputHandle = null;
        }
    }
}
