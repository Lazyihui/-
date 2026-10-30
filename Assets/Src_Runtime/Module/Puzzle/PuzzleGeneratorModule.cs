using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
namespace Hamdoku {
    public sealed class PuzzleGeneratorModule {
        public GeneratedPuzzleModel Generate(int n, int seed, int attempts, int repairStepsPerCell, int maxTier, bool preferHard, int hardCandidates, CancellationToken cancellation) {
            if (n < 4 || n > 12 || attempts < 1 || repairStepsPerCell < 1 || maxTier < 1 || maxTier > 2 || hardCandidates < 1) {
                throw new ArgumentException("Invalid generation configuration.");
            }
            var random = new Random(seed);
            var solver = new PuzzleSolverModule();
            var logic = new PuzzleLogicModule();
            GeneratedPuzzleModel best = null;
            int wanted = preferHard ? hardCandidates : 1;
            for (int candidate = 0; candidate < wanted; candidate++) {
                GeneratedPuzzleModel generated = null;
                for (int attempt = 0; attempt < attempts; attempt++) {
                    cancellation.ThrowIfCancellationRequested();
                    var answer = new int[n];
                    if (!Solution(n, 0, answer, 0, random)) {
                        throw new InvalidDataException("Cannot create a non-touching solution.");
                    }
                    int singleton = random.Next(n);
                    var regions = Grow(n, answer, singleton, random);
                    bool unique = false;
                    for (int step = 0; step <= repairStepsPerCell * n * n; step++) {
                        cancellation.ThrowIfCancellationRequested();
                        var alternate = solver.FindDifferentSolution(n, regions, answer);
                        if (alternate == null) {
                            unique = true;
                            break;
                        }
                        if (step == repairStepsPerCell * n * n || !Repair(n, regions, answer, alternate, singleton, random)) {
                            break;
                        }
                    }
                    if (!unique) {
                        continue;
                    }
                    var analysis = logic.Analyze(n, regions);
                    if (!analysis.solved || analysis.tier > maxTier) {
                        continue;
                    }
                    generated = new GeneratedPuzzleModel {
                        board = new PuzzleBoardModel { id = 0, identityId = 0, size = n, grade = analysis.tier,
                            regions = regions, solutionColumns = answer, preplacedRows = Array.Empty<int>() },
                        logicTier = analysis.tier, attempts = attempt + 1
                    };
                    break;
                }
                if (generated == null) {
                    if (best != null) {
                        break;
                    }
                    throw new InvalidDataException("No unique, logically solvable puzzle was generated within the configured attempts.");
                }
                if (best == null || generated.logicTier > best.logicTier) {
                    best = generated;
                }
                if (!preferHard || best.logicTier > 1) {
                    break;
                }
            }
            return best;
        }
        bool Solution(int n, int row, int[] answer, int used, Random random) {
            if (row == n) {
                return true;
            }
            var columns = new int[n];
            for (int i = 0; i < n; i++) {
                columns[i] = i;
            }
            for (int i = n - 1; i > 0; i--) {
                int j = random.Next(i + 1);
                int value = columns[i];
                columns[i] = columns[j];
                columns[j] = value;
            }
            foreach (int col in columns) {
                if ((used & (1 << col)) != 0 || (row > 0 && Math.Abs(col - answer[row - 1]) <= 1)) {
                    continue;
                }
                answer[row] = col;
                if (Solution(n, row + 1, answer, used | (1 << col), random)) {
                    return true;
                }
            }
            return false;
        }
        int[] Grow(int n, int[] answer, int singleton, Random random) {
            var regions = new int[n * n];
            Array.Fill(regions, -1);
            var frontier = new List<int>();
            for (int row = 0; row < n; row++) {
                regions[row * n + answer[row]] = row;
            }
            for (int row = 0; row < n; row++) {
                if (row != singleton) {
                    AddNeighbors(n, regions, row * n + answer[row], row, frontier);
                }
            }
            while (frontier.Count > 0) {
                int choice = random.Next(frontier.Count);
                int entry = frontier[choice];
                frontier[choice] = frontier[frontier.Count - 1];
                frontier.RemoveAt(frontier.Count - 1);
                int index = entry / n;
                int region = entry % n;
                if (regions[index] != -1) {
                    continue;
                }
                regions[index] = region;
                AddNeighbors(n, regions, index, region, frontier);
            }
            if (Array.IndexOf(regions, -1) >= 0) {
                throw new InvalidDataException("Region growth left an uncovered cell.");
            }
            return regions;
        }
        void AddNeighbors(int n, int[] regions, int index, int region, List<int> frontier) {
            if (index / n > 0 && regions[index - n] < 0) {
                frontier.Add((index - n) * n + region);
            }
            if (index / n < n - 1 && regions[index + n] < 0) {
                frontier.Add((index + n) * n + region);
            }
            if (index % n > 0 && regions[index - 1] < 0) {
                frontier.Add((index - 1) * n + region);
            }
            if (index % n < n - 1 && regions[index + 1] < 0) {
                frontier.Add((index + 1) * n + region);
            }
        }
        bool Repair(int n, int[] regions, int[] answer, int[] alternate, int singleton, Random random) {
            var choices = new List<int>();
            for (int row = 0; row < n; row++) {
                int index = row * n + alternate[row];
                if (alternate[row] == answer[row] || regions[index] == singleton || !ConnectedWithout(n, regions, index)) {
                    continue;
                }
                if (index / n > 0) {
                    AddRepair(regions, index, index - n, singleton, n, choices);
                }
                if (index / n < n - 1) {
                    AddRepair(regions, index, index + n, singleton, n, choices);
                }
                if (index % n > 0) {
                    AddRepair(regions, index, index - 1, singleton, n, choices);
                }
                if (index % n < n - 1) {
                    AddRepair(regions, index, index + 1, singleton, n, choices);
                }
            }
            if (choices.Count == 0) {
                return false;
            }
            int choice = choices[random.Next(choices.Count)];
            regions[choice / n] = choice % n;
            return true;
        }
        void AddRepair(int[] regions, int index, int neighbor, int singleton, int n, List<int> choices) {
            int target = regions[neighbor];
            if (target != singleton && target != regions[index]) {
                choices.Add(index * n + target);
            }
        }
        bool ConnectedWithout(int n, int[] regions, int removed) {
            int region = regions[removed];
            int count = 0;
            int start = -1;
            for (int i = 0; i < regions.Length; i++) {
                if (i != removed && regions[i] == region) {
                    start = i;
                    count++;
                }
            }
            if (start < 0) {
                return false;
            }
            var visited = new bool[regions.Length];
            var queue = new Queue<int>();
            queue.Enqueue(start);
            visited[start] = true;
            int reached = 0;
            while (queue.Count > 0) {
                int i = queue.Dequeue();
                reached++;
                for (int direction = 0; direction < 4; direction++) {
                    int next = direction == 0 ? i - n : direction == 1 ? i + n : direction == 2 ? i - 1 : i + 1;
                    if (next < 0 || next >= regions.Length || (direction >= 2 && next / n != i / n) || next == removed || visited[next] || regions[next] != region) {
                        continue;
                    }
                    visited[next] = true;
                    queue.Enqueue(next);
                }
            }
            return reached == count;
        }
    }
}
