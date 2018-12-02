﻿using System.Collections.Generic;
using System.Linq;

namespace NonogramSolver
{
    public class Problem
    {
        public int[][] ColumnHint { get; set; }
        public int[][] RowHint { get; set; }

        public bool?[,] Blocks { get; set; }
        public bool IsSolved { get; set; }

        public Problem(string name)
        {
            switch (name)
            {
                case "Rocket":
                    ColumnHint = new int[][] {
                        new int[] { 5, 19 }, new int[] { 4, 4, 6 }, new int[] { 5, 4, 5, 7 },new int[] { 10, 4, 8 },new int[] { 9, 5, 9 },
                        new int[] { 4, 4 }, new int[] { 2, 2, 9, 1, 3 }, new int[] { 1, 4, 9, 6 },new int[] { 5, 4, 2 },new int[] { 5, 4, 6, 3, 1 },
                        new int[] { 5, 4, 6, 6 }, new int[] { 5, 4, 3 }, new int[] { 1, 4, 1, 6, 6 },new int[] { 2, 2, 9, 1, 3 },new int[] { 4, 4},
                        new int[] { 9, 5, 7 }, new int[] { 2, 7, 4, 8 }, new int[] { 1, 6, 5, 7 },new int[] { 2, 8, 6 },new int[] { 25 }
                    };

                    RowHint = new int[][] {
                        new int[] { 8, 8 }, new int[] { 7, 4, 4, 2 }, new int[] { 6, 6, 2, 1 },new int[] { 6, 6, 3, 2 },new int[] { 1, 3, 8, 5 },
                        new int[] { 2, 8, 5 }, new int[] { 1, 3, 5 }, new int[] { 5, 8, 5 },new int[] { 5, 6, 1, 5 },new int[] { 4, 6, 1, 4 },
                        new int[] { 2, 1, 8, 1, 2 }, new int[] { 1, 2, 2, 2, 2, 1 }, new int[] { 1, 3, 2, 2, 2, 3, 1 },new int[] {1, 3, 2, 2, 2, 3, 1  },new int[] {1, 3, 2, 2, 2, 3, 1 },
                        new int[] { 1, 1, 2, 2, 2, 1, 1  }, new int[] { 1, 1, 1, 2, 1, 1, 1  }, new int[] { 1, 5, 2, 5, 1 },new int[] { 1, 4, 2, 2, 4, 1 },new int[] { 6, 6, 6},
                        new int[] { 6, 1, 4, 6 }, new int[] { 5, 1, 2, 1, 5 }, new int[] { 5, 2, 1, 2, 5},new int[] { 5, 1, 1, 1, 4},new int[] { 5, 1, 2, 1, 4 }
                    };
                    break;

                case "Musician":
                    ColumnHint = new int[][] {
                        new int[] { 16, 2, 17 }, new int[] {7, 5, 3,2,10,3 }, new int[] { 5,4,1,3,8,3 },new int[] { 5,8,1,7,3 },new int[] { 2,11,1,1,7,3 },
                        new int[] { 1,3,10,3 }, new int[] { 1,2,2,5,3,3 }, new int[] { 7,3,1,2,3 },new int[] { 5,3,3,2 },new int[] { 2,3,3,2 },
                        new int[] { 3,1,2,3,1,2,2 }, new int[] {6,6,2,1,1,1}, new int[] { 1,1,1,1,2,1 },new int[] {3,1,1,1,2,2 },new int[] { 4,7,2,1,2,4},
                        new int[] { 5,2,1,2,1,1,4 }, new int[] { 2,3,3,3,1,1,2,1 }, new int[] { 2,4,2,2,1,2,1 },new int[] { 3,4,1,2,2,2 },new int[] { 1,2,3,2,2,3 },
                        new int[] { 5,4,5,2,3 }, new int[] { 1,16,8,1 }, new int[] { 1,16,9,2 },new int[] { 1,17,8,2 },new int[] { 1,12,5,6,3,3},
                        new int[] { 6,5,9,4,3 }, new int[] { 3,4,3,12,3}, new int[] { 4,2,4,2,7,3},new int[] { 5,3,3,3,2,1,3 },new int[] { 5,3,3,4,1,3,3 }
                    };

                    RowHint = new int[][] {
                        new int[] { 7,7 }, new int[] { 5,1,5 }, new int[] { 4,2,9 },new int[] { 4,1,1,2,3,3 },new int[] { 4,2,2,3,5,2 },
                        new int[] { 2,3,2,4,8 }, new int[] { 2,2,9,5,2 }, new int[] { 1,1,3,1,9,4 },new int[] { 1,1,5,7,2 },new int[] { 1,5,10 },
                        new int[] { 2,3,7}, new int[] {3,2,8 }, new int[] {5,6,3 },new int[] {5,6,2  },new int[] {5,4,1 },
                        new int[] { 1,2,5 }, new int[] { 2,5  }, new int[] { 2,10,1 },new int[] { 1,2,14},new int[] { 10,9,6},
                        new int[] { 2,7,6,2,2,2 }, new int[] {2,4,2,1,1,2,4 }, new int[] { 1,3,1,1,2,6 },new int[] { 3,1,1,1,7},new int[] {3,2,1,1,6 },
                        new int[] { 1,3,2,3,3,4 }, new int[] { 6,1,2,4,2,1 }, new int[] { 7,2,4,3,3,1 },new int[] {7,5,3,2 },new int[] {5,2,2,3,1 },
                        new int[] { 5,2,9,2,2 }, new int[] { 4,1,2,1  }, new int[] { 3,2,6,2,1 },new int[] { 3,1,2,2 },new int[] { 2,2,2},
                        new int[] { 2,3,2 }, new int[] {1,7,1 }, new int[] { 8,5,2,6},new int[] { 11,2,3,8},new int[] { 13,6,9 }
                    };
                    break;

                case "President":
                    ColumnHint = new int[][] {
                        new int[] { 5, 2, 9 }, new int[] {18, 2 }, new int[] { 19, 3 },new int[] { 22, 3, 1 },new int[] { 10, 2, 10, 1 },
                        new int[] { 8, 6 }, new int[] { 7, 8 }, new int[] { 6, 5, 8, 2 },new int[] { 6, 4, 8, 3 },new int[] { 5, 5, 12 },
                        new int[] { 5, 4, 1, 1, 1, 9 }, new int[] {6, 6, 1, 4, 8}, new int[] { 6, 6, 3, 2, 8 },new int[] {6, 6, 3, 1, 7 },new int[] { 6, 5, 2, 1, 1, 7},
                        new int[] { 6, 2, 1, 1, 1, 9 }, new int[] { 6, 2, 1, 1, 6 }, new int[] { 6, 3, 1, 1, 6 },new int[] { 6, 1, 2, 1, 1, 7 },new int[] { 5, 6, 6, 1, 1, 7 },
                        new int[] { 5, 5, 9, 1, 1, 7 }, new int[] { 4, 4, 1, 3, 3, 3, 7 }, new int[] { 3, 4, 1, 1, 2, 2, 7 },new int[] { 3, 5, 1, 1, 2, 1, 9 },new int[] { 4, 7, 1, 2, 1, 8},
                        new int[] { 4, 6, 15 }, new int[] { 5, 5, 3, 9 }, new int[] { 7, 5, 3, 11 },new int[] { 7, 3, 4, 14, 1 },new int[] { 5, 7, 2, 15, 4},
                        new int[] { 20, 13, 3 }, new int[] { 26, 1, 2 }, new int[] { 23, 2, 1},new int[] { 4, 13, 4 },new int[] { 5, 1 }
                    };

                    RowHint = new int[][] {
                        new int[] { 24 }, new int[] { 27 }, new int[] { 30 },new int[] {20, 9 },new int[] { 19, 8 },
                        new int[] { 8, 8, 7 }, new int[] { 6, 2, 4 }, new int[] { 5, 1, 4 },new int[] { 4, 4 },new int[] { 4, 5 },
                        new int[] { 4, 5 }, new int[] { 4, 6 }, new int[] { 4, 5 },new int[] { 4, 5 },new int[] { 4, 6 },
                        new int[] { 4, 5 }, new int[] { 4, 2, 3, 5  }, new int[] { 4, 6, 8 ,5 },new int[] { 4, 9, 10, 5},new int[] { 4, 9, 16 },
                        new int[] { 5, 8, 15 }, new int[] { 5, 3, 5, 2, 5, 4 }, new int[] { 2, 2, 1, 2, 1, 3, 3 },new int[] { 1, 1, 3, 3, 3 },new int[] { 1, 2, 1, 3, 3 },
                        new int[] { 1, 2, 2, 3, 2 }, new int[] { 1, 3, 2, 3, 1 }, new int[] { 2, 1, 2, 1, 1, 4 },new int[] { 6, 1, 4 },new int[] { 4, 20 },
                        new int[] {4, 2, 2, 6 }, new int[] { 6, 2, 1, 1, 3, 2,  4 }, new int[] { 3,2,6,2,1 },new int[] { 3,1,2,2 },new int[] { 2,2,2},
                        new int[] { 5,2,9,2,2 }, new int[] { 4, 8, 1, 6  }, new int[] { 6, 1, 7 },new int[] { 8, 12 },new int[] { 22 },
                        new int[] { 21 }, new int[] {19, 1 }, new int[] { 19, 2 },new int[] { 2, 16, 3 },new int[] { 2, 16, 5 }
                    };
                    break;
            }

            Blocks = new bool?[ColumnHint.Length, RowHint.Length];
        }

        public void Solve()
        {
            IsSolved = true;

            bool?[] line;

            for (int x = 0; x < ColumnHint.Length; x++)
            {
                line = Enumerable.Range(0, Blocks.GetUpperBound(1) + 1).Select(i => Blocks[x, i]).ToArray();
                line = SolveLine(line, ColumnHint[x]);

                for (int i = 0; i < line.Length; i++)
                    Blocks[x, i] = line[i];
            }

            for (int y = 0; y < RowHint.Length; y++)
            {
                line = Enumerable.Range(0, Blocks.GetUpperBound(0) + 1).Select(i => Blocks[i, y]).ToArray();
                line = SolveLine(line, RowHint[y]);

                for (int i = 0; i < line.Length; i++)
                    Blocks[i, y] = line[i];
            }
        }

        private bool?[] SolveLine(bool?[] line, int[] hint)
        {
            bool?[] result = line;

            if (result.Count(x => x == null) != 0)
                result = HintNumbersSum(result, hint);

            if (result.Count(x => x == null) != 0)
            {
                result = Edge(result, hint);
                result = Edge(result.Reverse().ToArray(), hint.Reverse().ToArray()).Reverse().ToArray();
            }

            if (result.Count(x => x == null) != 0)
            {
                result = Elimination(result, hint);
                result = Elimination(result.Reverse().ToArray(), hint.Reverse().ToArray()).Reverse().ToArray();
            }

            if (result.Count(x => x == true) == hint.Sum(x => x))
            {
                for (int i = 0; i < result.Length; i++)
                    if (result[i] == null) result[i] = false;
            }
            else if (result.Count(x => x == true) + result.Count(x => x == null) == hint.Sum(x => x))
            {
                for (int i = 0; i < result.Length; i++)
                    if (result[i] == null) result[i] = true;
            }
            else
            {
                IsSolved = false;
            }

            return result;
        }

        private bool?[] HintNumbersSum(bool?[] line, int[] hint)
        {
            bool?[] result = line;

            if (hint.Sum(x => x) + hint.Length - 1 == result.Length)
            {
                int idx = 0;

                for (int i = 0; i < hint.Length; i++)
                {
                    for (int j = 0; j < hint[i]; j++)
                    {
                        result[idx] = true;
                        idx++;
                    }

                    if (idx != result.Length)
                    {
                        result[idx] = false;
                        idx++;
                    }
                }
            }

            return result;
        }


        private bool?[] Edge(bool?[] line, int[] hint)
        {
            List<int> hints = hint.ToList();
            bool?[] result = line;
            int idx = 0;

            while (hints.Count != 0 && idx < line.Length)
            {
                if (result[idx] == null) break;

                if (result[idx] == true)
                {
                    for (int i = 0; i < hints[0]; i++)
                    {
                        result[idx] = true;
                        idx++;
                    }

                    if (idx != result.Length)
                    {
                        result[idx] = false;
                        idx++;
                    }

                    idx--;
                    hints.RemoveAt(0);
                }

                idx++;
            }

            return result;
        }

        private bool?[] Elimination(bool?[] line, int[] hint)
        {
            List<int> hints = hint.ToList();
            bool?[] result = line;

            bool isEdge = true;
            int empty = 0;
            int idx = 0;

            while (hints.Count != 0 && idx < line.Length)
            {
                switch (result[idx])
                {
                    case null:
                        isEdge = false;
                        empty++;
                        break;
                    case true:
                        if (isEdge)
                        {
                            for (int i = 0; i < hints[0]; i++)
                                idx++;

                            idx--;
                            hints.RemoveAt(0);
                        }
                        else if (empty != 0)
                        {
                            idx = line.Length;
                        }

                        empty = 0;
                        isEdge = false;
                        break;
                    case false:
                        if (empty != 0)
                        {
                            if (empty < hints[0])
                            {
                                for (int i = 0; i < idx; i++)
                                    if (result[i] == null) result[i] = false;
                            }
                            else
                            {
                                idx = line.Length;
                            }
                        }

                        empty = 0;
                        isEdge = true;
                        break;
                }

                idx++;
            }

            return result;
        }
    }
}