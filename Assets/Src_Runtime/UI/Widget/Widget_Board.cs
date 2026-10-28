using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.UI;
namespace Hamdoku {
    public sealed class Widget_Board : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler, IInitializePotentialDragHandler {
        public Widget_BoardCell cellPrefab;
        public RectTransform gridRoot;
        public Action<int, bool, bool> inputHandle;
        public Action<int, bool> dragHandle;
        public Func<int, bool> eraseHandle;
        Widget_BoardCell[] cells;
        bool eraseDrag;
        Vector2 previousPosition;
        int size;
        int pointerId;
        int pressedCell;
        int lastTapCell = -1;
        float lastTapTime;
        float doubleTapSeconds;
        float dragThreshold;
        bool tapReleased;
        int lastTapDevice;
        bool pressed;
        bool dragging;
        bool[] visited;
        Vector2 downPosition;
        public void Init(int size, float doubleTapSeconds, float dragThreshold) {
            if (cellPrefab == null || cellPrefab.tutorialDim == null || gridRoot == null || size < 1 || gridRoot.rect.width <= 0) {
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
        public int Size {
            get {
                return size;
            }
        }
        public void SweepClear(GameConfigSO config, int[] indices) {
            foreach (int i in indices) {
                float delay = config.clearAutoCrossSweepStep * (size - 1 - i / size + i % size);
                cells[i].PlayClearSweep(delay, config.clearGlowSeconds, config.clearGlowColor);
            }
        }
        public void ShowCell(int index, Color color, Sprite pattern, CellStatus status, bool highlighted, bool given) {
            cells[index].Show(color, pattern, status, highlighted, given);
        }
        public void ConfigureTutorial(GameConfigSO config, bool animated) {
            foreach (var cell in cells) {
                cell.ConfigureTutorial(config.tutorialMarkSeconds, config.tutorialPlaceSeconds, config.tutorialDimFadeSeconds, true);
            }
        }
        public void CelebrateTutorial(float seconds) {
            foreach (var cell in cells) {
                cell.Celebrate(seconds);
            }
        }
        public void ShowRegionBorder(int index, bool visible, int[] regions, int boardSize, Color color, float width) {
            int region = regions[index];
            cells[index].ShowRegionBorder(visible, color, width,
                index < boardSize || regions[index - boardSize] != region,
                index % boardSize == boardSize - 1 || regions[index + 1] != region,
                index >= regions.Length - boardSize || regions[index + boardSize] != region,
                index % boardSize == 0 || regions[index - 1] != region);
        }
        public void CancelGesture() {
            if (pressed && cells != null) {
                cells[pressedCell].SetPressed(false);
            }
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
            eraseDrag = eraseHandle != null && eraseHandle(pressedCell);
            cells[pressedCell].SetPressed(true);
            pointerId = data.pointerId;
            downPosition = data.position;
            dragging = false;
            Array.Clear(visited, 0, visited.Length);
            float time = Time.unscaledTime;
            int deviceId = data is ExtendedPointerEventData pointer && pointer.device != null ? pointer.device.deviceId : data.pointerId;
            bool twice = tapReleased && lastTapDevice == deviceId && lastTapCell == pressedCell && time - lastTapTime <= doubleTapSeconds;
            lastTapCell = twice ? -1 : pressedCell;
            lastTapTime = time;
            lastTapDevice = deviceId;
            tapReleased = false;
            inputHandle?.Invoke(pressedCell, twice, false);
        }
        public void OnDrag(PointerEventData data) {
            if (!pressed || pointerId != data.pointerId) {
                return;
            }
            if (!dragging) {
                RectTransformUtility.ScreenPointToLocalPointInRectangle(gridRoot, downPosition, data.pressEventCamera, out var downLocal);
                RectTransformUtility.ScreenPointToLocalPointInRectangle(gridRoot, data.position, data.pressEventCamera, out var currentLocal);
                if (Vector2.Distance(currentLocal, downLocal) < gridRoot.rect.width / size * dragThreshold) {
                    return;
                }
            }
            if (!dragging) {
                dragging = true;
                lastTapCell = -1;
                previousPosition = downPosition;
                ReportDrag(pressedCell);
            }
            float pitch = gridRoot.rect.width / size;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(gridRoot, previousPosition, data.pressEventCamera, out var from);
            RectTransformUtility.ScreenPointToLocalPointInRectangle(gridRoot, data.position, data.pressEventCamera, out var to);
            int samples = Mathf.Max(1, Mathf.CeilToInt(Vector2.Distance(from, to) / (pitch * 0.25f)));
            for (int i = 1; i <= samples; i++) {
                int current = CellAt(Vector2.Lerp(previousPosition, data.position, (float)i / samples), data.pressEventCamera);
                if (current >= 0) {
                    ReportDrag(current);
                }
            }
            previousPosition = data.position;
        }
        void ReportDrag(int index) {
            if (visited[index]) {
                return;
            }
            visited[index] = true;
            dragHandle?.Invoke(index, eraseDrag);
        }
        public void OnPointerUp(PointerEventData data) {
            if (!pressed || pointerId != data.pointerId) {
                return;
            }
            cells[pressedCell].SetPressed(false);
            pressed = false;
            int index = CellAt(data.position, data.pressEventCamera);
            if (dragging || index != pressedCell) {
                lastTapCell = -1;
                return;
            }
            tapReleased = true;
        }
        void OnDisable() {
            CancelGesture();
        }
        void OnApplicationFocus(bool focused) {
            if (!focused) {
                CancelGesture();
            }
        }
        public Vector3 CellPosition(int index) {
            return cells[index].transform.position;
        }
        public void DimCell(int index, bool dimmed) {
            cells[index].SetDimmed(dimmed);
        }
        public void TearDown() {
            CancelGesture();
            inputHandle = null;
            dragHandle = null;
            eraseHandle = null;
        }
    }
}
