using System;
using System.Collections.Generic;
using System.Linq;

namespace Sodoku_Solver
{
    class Program
    {
        public static Sodoku puzzle;
        public static List<int>[,] possibilities = new List<int>[9, 9];

        static void Main(string[] args)
        {
            int[,] start = {
                {8,5,0,0,0,1,0,0,6},
                {0,0,7,0,6,4,1,0,0},
                {0,0,4,0,7,0,5,9,0},
                {2,0,0,0,5,6,0,0,4},
                {6,0,0,1,0,9,0,7,0},
                {7,0,1,0,4,0,0,0,9},
                {0,1,0,9,0,0,4,6,0},
                {0,9,6,0,0,8,0,0,7},
                {0,7,0,6,0,0,0,0,1},
            };

            puzzle = new Sodoku(start);

            Print(puzzle);

            while (!IsDone())
            {
                LowHangingFruit();
                Possibilities();
            }

            Print(puzzle, true);
        }

        public static void LowHangingFruit()
        {
            bool hasChanged = true;

            while (hasChanged)
            {
                hasChanged = false;
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (puzzle.Get(i, j) == 0)
                        {
                            List<int> missingNUmbers = puzzle.GetNumbersMissingFromEveryDemension(i, j);

                            if (missingNUmbers.Count == 1)
                            {
                                puzzle.Put(i, j, missingNUmbers[0]);
                                possibilities[i, j] = null;
                                hasChanged = true;
                            }
                            else
                            {
                                possibilities[i, j] = missingNUmbers;
                            }
                        }
                        else
                        {
                            possibilities[i, j] = null;
                        }
                    }
                }
            }
        }

        public static void Possibilities()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (possibilities[i, j] != null)
                    {
                        foreach(int possibility in possibilities[i, j])
                        {
                            if (OnlyPossibleOnce(GetPossibilitiesRow(i), possibility)
                                || OnlyPossibleOnce(GetPossibilitiesColumn(j), possibility)
                                || OnlyPossibleOnce(GetPossibilitiesBlock(puzzle.GetBlockNumber(i, j)), possibility))
                            {
                                puzzle.Put(i, j, possibility);
                                possibilities[i, j] = null;
                                return;
                            }
                        }
                    }
                }
            }
        }

        public static bool IsDone()
        {
            for(int i = 0; i < 9; i++)
            {
                for(int j = 0; j < 9; j++)
                {
                    if(puzzle.board[i,j] == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static bool OnlyPossibleOnce(List<int>[] group, int value)
        {
            int count = 0;
            foreach(List<int> cellGroup in group)
            {
                if(cellGroup != null)
                {
                    foreach (int possibility in cellGroup)
                    {
                        if (possibility == value)
                        {
                            count++;
                        }
                    }
                }
            }

            return (count == 1);
        }

        public static List<int>[] GetPossibilitiesRow(int i)
        {
            return Enumerable.Range(0, 9)
                    .Select(x => possibilities[i, x])
                    .ToArray();
        }

        public static List<int>[] GetPossibilitiesColumn(int j)
        {
            return Enumerable.Range(0, 9)
                    .Select(x => possibilities[x, j])
                    .ToArray();
        }

        public static List<int>[] GetPossibilitiesBlock(int blockNumber)
        {
            List<int>[] block = new List<int>[9];

            if (blockNumber == 0)
            {
                block[0] = possibilities[0, 0];
                block[1] = possibilities[0, 1];
                block[2] = possibilities[0, 2];
                block[3] = possibilities[1, 0];
                block[4] = possibilities[1, 1];
                block[5] = possibilities[1, 2];
                block[6] = possibilities[2, 0];
                block[7] = possibilities[2, 1];
                block[8] = possibilities[2, 2];
            }
            else if (blockNumber == 1)
            {
                block[0] = possibilities[0, 3];
                block[1] = possibilities[0, 4];
                block[2] = possibilities[0, 5];
                block[3] = possibilities[1, 3];
                block[4] = possibilities[1, 4];
                block[5] = possibilities[1, 5];
                block[6] = possibilities[2, 3];
                block[7] = possibilities[2, 4];
                block[8] = possibilities[2, 5];
            }
            else if (blockNumber == 2)
            {
                block[0] = possibilities[0, 6];
                block[1] = possibilities[0, 7];
                block[2] = possibilities[0, 8];
                block[3] = possibilities[1, 6];
                block[4] = possibilities[1, 7];
                block[5] = possibilities[1, 8];
                block[6] = possibilities[2, 6];
                block[7] = possibilities[2, 7];
                block[8] = possibilities[2, 8];
            }

            else if (blockNumber == 3)
            {
                block[0] = possibilities[3, 0];
                block[1] = possibilities[3, 1];
                block[2] = possibilities[3, 2];
                block[3] = possibilities[4, 0];
                block[4] = possibilities[4, 1];
                block[5] = possibilities[4, 2];
                block[6] = possibilities[5, 0];
                block[7] = possibilities[5, 1];
                block[8] = possibilities[5, 2];
            }
            else if (blockNumber == 4)
            {
                block[0] = possibilities[3, 3];
                block[1] = possibilities[3, 4];
                block[2] = possibilities[3, 5];
                block[3] = possibilities[4, 3];
                block[4] = possibilities[4, 4];
                block[5] = possibilities[4, 5];
                block[6] = possibilities[5, 3];
                block[7] = possibilities[5, 4];
                block[8] = possibilities[5, 5];
            }
            else if (blockNumber == 5)
            {
                block[0] = possibilities[3, 6];
                block[1] = possibilities[3, 7];
                block[2] = possibilities[3, 8];
                block[3] = possibilities[4, 6];
                block[4] = possibilities[4, 7];
                block[5] = possibilities[4, 8];
                block[6] = possibilities[5, 6];
                block[7] = possibilities[5, 7];
                block[8] = possibilities[5, 8];
            }

            else if (blockNumber == 6)
            {
                block[0] = possibilities[6, 0];
                block[1] = possibilities[6, 1];
                block[2] = possibilities[6, 2];
                block[3] = possibilities[7, 0];
                block[4] = possibilities[7, 1];
                block[5] = possibilities[7, 2];
                block[6] = possibilities[8, 0];
                block[7] = possibilities[8, 1];
                block[8] = possibilities[8, 2];
            }
            else if (blockNumber == 7)
            {
                block[0] = possibilities[6, 3];
                block[1] = possibilities[6, 4];
                block[2] = possibilities[6, 5];
                block[3] = possibilities[7, 3];
                block[4] = possibilities[7, 4];
                block[5] = possibilities[7, 5];
                block[6] = possibilities[8, 3];
                block[7] = possibilities[8, 4];
                block[8] = possibilities[8, 5];
            }
            else if (blockNumber == 8)
            {
                block[0] = possibilities[6, 6];
                block[1] = possibilities[6, 7];
                block[2] = possibilities[6, 8];
                block[3] = possibilities[7, 6];
                block[4] = possibilities[7, 7];
                block[5] = possibilities[7, 8];
                block[6] = possibilities[8, 6];
                block[7] = possibilities[8, 7];
                block[8] = possibilities[8, 8];
            }

            return block;
        }

        public static void Print(Sodoku puzzle, bool done = false)
        {
            string[] output = new string[9];

            for(int i = 0; i < 9; i++)
            {
                for(int j = 0; j < 9; j++)
                {
                    output[i] += puzzle.Get(i, j) + ", ";
                }
            }

            foreach(string row in output)
            {
                Console.WriteLine(row);
            }
            Console.WriteLine("");

            if (done)
            {
                Console.WriteLine("Done");
            }
            Console.ReadKey();
        }
    }
}
