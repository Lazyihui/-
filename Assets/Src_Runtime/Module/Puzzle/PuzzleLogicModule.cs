using System;
using System.Collections.Generic;
namespace Hamdoku {
    public sealed class PuzzleLogicModule {
        public PuzzleAnalysisModel Analyze(int n, int[] regions) {
            var candidates = new bool[n * n];
            Array.Fill(candidates, true);
            var rows = new bool[n];
            var cols = new bool[n];
            var groups = new bool[n];
            int placed = 0;
            int tier = 1;
            while (placed < n) {
                bool progress = false;
                for (int group = 0; group < n * 3; group++) {
                    if (Done(group, n, rows, cols, groups)) {
                        continue;
                    }
                    int only = -1;
                    int count = 0;
                    for (int i = 0; i < candidates.Length; i++) {
                        if (candidates[i] && Belongs(i, group, n, regions)) {
                            only = i;
                            count++;
                        }
                    }
                    if (count == 0) {
                        return new PuzzleAnalysisModel { placed = placed, tier = tier };
                    }
                    if (count != 1) {
                        continue;
                    }
                    rows[only / n] = true;
                    cols[only % n] = true;
                    groups[regions[only]] = true;
                    placed++;
                    for (int i = 0; i < candidates.Length; i++) {
                        if (Conflicts(i, only, n, regions)) {
                            candidates[i] = false;
                        }
                    }
                    progress = true;
                    break;
                }
                if (progress) {
                    continue;
                }
                // A row, column or region must contain one hamster. Remove any outside cell
                // conflicting with every remaining candidate of that group (line/region locks
                // and common adjacent exclusions), without searching a hypothetical answer.
                for (int group = 0; group < n * 3 && !progress; group++) {
                    if (Done(group, n, rows, cols, groups)) {
                        continue;
                    }
                    var indices = new List<int>();
                    for (int i = 0; i < candidates.Length; i++) {
                        if (candidates[i] && Belongs(i, group, n, regions)) {
                            indices.Add(i);
                        }
                    }
                    if (indices.Count == 0) {
                        return new PuzzleAnalysisModel { placed = placed, tier = tier };
                    }
                    for (int i = 0; i < candidates.Length; i++) {
                        if (!candidates[i] || Belongs(i, group, n, regions)) {
                            continue;
                        }
                        bool excluded = true;
                        foreach (int candidate in indices) {
                            if (!Conflicts(i, candidate, n, regions)) {
                                excluded = false;
                                break;
                            }
                        }
                        if (excluded) {
                            candidates[i] = false;
                            progress = true;
                            tier = 2;
                        }
                    }
                }
                if (!progress) {
                    break;
                }
            }
            return new PuzzleAnalysisModel { solved = placed == n, placed = placed, tier = tier };
        }
        bool Done(int group, int n, bool[] rows, bool[] cols, bool[] regions) {
            return group < n ? rows[group] : group < n * 2 ? cols[group - n] : regions[group - n * 2];
        }
        bool Belongs(int index, int group, int n, int[] regions) {
            return group < n ? index / n == group : group < n * 2 ? index % n == group - n : regions[index] == group - n * 2;
        }
        bool Conflicts(int a, int b, int n, int[] regions) {
            return a / n == b / n || a % n == b % n || regions[a] == regions[b] ||
                (Math.Abs(a / n - b / n) <= 1 && Math.Abs(a % n - b % n) <= 1);
        }
    }
}
