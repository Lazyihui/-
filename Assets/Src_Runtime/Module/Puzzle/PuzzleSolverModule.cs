using System;
namespace Hamdoku {
    public sealed class PuzzleSolverModule {
        public int CountSolutions(int size, int[] regions, int limit, out int[] solution) {
            if (size < 4 || size > 12 || regions == null || regions.Length != size * size || limit < 1) {
                throw new ArgumentException("Invalid solver input.");
            }
            foreach (int region in regions) {
                if (region < 0 || region >= size) {
                    throw new ArgumentException("Invalid region ID.");
                }
            }
            var columns = new int[size];
            solution = null;
            int count = 0;
            Search(size, regions, 0, 0, 0, columns, limit, ref count, ref solution);
            return count;
        }
        void Search(int size, int[] regions, int row, int usedColumns, int usedRegions, int[] columns, int limit, ref int count, ref int[] solution) {
            if (row == size) {
                count++;
                if (solution == null) {
                    solution = (int[])columns.Clone();
                }
                return;
            }
            for (int col = 0; col < size && count < limit; col++) {
                int region = regions[row * size + col];
                if ((usedColumns & (1 << col)) != 0 || (usedRegions & (1 << region)) != 0 ||
                    (row > 0 && Math.Abs(col - columns[row - 1]) <= 1)) {
                    continue;
                }
                columns[row] = col;
                Search(size, regions, row + 1, usedColumns | (1 << col), usedRegions | (1 << region), columns, limit, ref count, ref solution);
            }
        }
        public int[] FindDifferentSolution(int size, int[] regions, int[] expected) {
            int[] different = null;
            FindDifferent(size, regions, expected, 0, 0, 0, new int[size], false, ref different);
            return different;
        }
        bool FindDifferent(int n, int[] regions, int[] expected, int row, int usedColumns, int usedRegions, int[] columns, bool differs, ref int[] result) {
            if (row == n) {
                if (differs) {
                    result = (int[])columns.Clone();
                }
                return differs;
            }
            for (int col = 0; col < n; col++) {
                int region = regions[row * n + col];
                if ((usedColumns & (1 << col)) != 0 || (usedRegions & (1 << region)) != 0 ||
                    (row > 0 && Math.Abs(col - columns[row - 1]) <= 1)) {
                    continue;
                }
                columns[row] = col;
                if (FindDifferent(n, regions, expected, row + 1, usedColumns | (1 << col), usedRegions | (1 << region), columns, differs || col != expected[row], ref result)) {
                    return true;
                }
            }
            return false;
        }
    }
}
