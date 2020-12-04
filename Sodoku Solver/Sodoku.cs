using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sodoku_Solver
{
    class Sodoku
    {
        public int[,] board = new int[9, 9];

        public Sodoku(int[,] startingBoard)
        {
            board = startingBoard;
        }

        public int Get(int i, int j)
        {
            return board[i,j];
        }

        public void Put(int i, int j, int value)
        {
            board[i, j] = value;
        }

        public List<int> GetNumbersMissingFromEveryDemension(int i, int j)
        {
            List<int> missingFromRow = GetMissingNumbers(GetRow(i));
            List<int> missingFromColumn = GetMissingNumbers(GetColumn(j));
            List<int> missingFromBlock = GetMissingNumbers(GetBlock(GetBlockNumber(i, j)));

            List<int> missing = new List<int>();

            for(int num = 1; num <= 9; num++)
            {
                if (missingFromRow.Contains(num) && missingFromColumn.Contains(num) && missingFromBlock.Contains(num))
                {
                    missing.Add(num);
                }
            }

            return missing;
        }

        public int GetBlockNumber(int i, int j)
        {
            if(i < 3)
            {
                if (j < 3)
                {
                    return 0;
                }
                else if (j < 6)
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
            }
            else if(i < 6)
            {
                if (j < 3)
                {
                    return 3;
                }
                else if (j < 6)
                {
                    return 4;
                }
                else
                {
                    return 5;
                }
            }
            else
            {
                if (j < 3)
                {
                    return 6;
                }
                else if (j < 6)
                {
                    return 7;
                }
                else
                {
                    return 8;
                }
            }
        }

        public List<int> GetMissingNumbers(int[] _input)
        {
            List<int> input = _input.ToList();
            List<int> missingNumbers = new List<int>();

            for(int i = 1; i <= 9; i++)
            {
                if (!input.Contains(i))
                {
                    missingNumbers.Add(i);
                }
            }

            return missingNumbers;
        }

        public int[] GetRow(int rowNumber)
        {
            return Enumerable.Range(0, 9)
                    .Select(x => board[rowNumber, x])
                    .ToArray();
        }

        public int[] GetColumn(int columnNumber)
        {
            return Enumerable.Range(0, 9)
                    .Select(x => board[x, columnNumber])
                    .ToArray();
        }

        public int[] GetBlock(int blockNumber)
        {
            int[] block = new int[9];

            if(blockNumber == 0)
            {
                block[0] = board[0, 0];
                block[1] = board[0, 1];
                block[2] = board[0, 2];
                block[3] = board[1, 0];
                block[4] = board[1, 1];
                block[5] = board[1, 2];
                block[6] = board[2, 0];
                block[7] = board[2, 1];
                block[8] = board[2, 2];
            }
            else if (blockNumber == 1)
            {
                block[0] = board[0, 3];
                block[1] = board[0, 4];
                block[2] = board[0, 5];
                block[3] = board[1, 3];
                block[4] = board[1, 4];
                block[5] = board[1, 5];
                block[6] = board[2, 3];
                block[7] = board[2, 4];
                block[8] = board[2, 5];
            }
            else if (blockNumber == 2)
            {
                block[0] = board[0, 6];
                block[1] = board[0, 7];
                block[2] = board[0, 8];
                block[3] = board[1, 6];
                block[4] = board[1, 7];
                block[5] = board[1, 8];
                block[6] = board[2, 6];
                block[7] = board[2, 7];
                block[8] = board[2, 8];
            }

            else if (blockNumber == 3)
            {
                block[0] = board[3, 0];
                block[1] = board[3, 1];
                block[2] = board[3, 2];
                block[3] = board[4, 0];
                block[4] = board[4, 1];
                block[5] = board[4, 2];
                block[6] = board[5, 0];
                block[7] = board[5, 1];
                block[8] = board[5, 2];
            }
            else if (blockNumber == 4)
            {
                block[0] = board[3, 3];
                block[1] = board[3, 4];
                block[2] = board[3, 5];
                block[3] = board[4, 3];
                block[4] = board[4, 4];
                block[5] = board[4, 5];
                block[6] = board[5, 3];
                block[7] = board[5, 4];
                block[8] = board[5, 5];
            }
            else if (blockNumber == 5)
            {
                block[0] = board[3, 6];
                block[1] = board[3, 7];
                block[2] = board[3, 8];
                block[3] = board[4, 6];
                block[4] = board[4, 7];
                block[5] = board[4, 8];
                block[6] = board[5, 6];
                block[7] = board[5, 7];
                block[8] = board[5, 8];
            }

            else if (blockNumber == 6)
            {
                block[0] = board[6, 0];
                block[1] = board[6, 1];
                block[2] = board[6, 2];
                block[3] = board[7, 0];
                block[4] = board[7, 1];
                block[5] = board[7, 2];
                block[6] = board[8, 0];
                block[7] = board[8, 1];
                block[8] = board[8, 2];
            }
            else if (blockNumber == 7)
            {
                block[0] = board[6, 3];
                block[1] = board[6, 4];
                block[2] = board[6, 5];
                block[3] = board[7, 3];
                block[4] = board[7, 4];
                block[5] = board[7, 5];
                block[6] = board[8, 3];
                block[7] = board[8, 4];
                block[8] = board[8, 5];
            }
            else if (blockNumber == 8)
            {
                block[0] = board[6, 6];
                block[1] = board[6, 7];
                block[2] = board[6, 8];
                block[3] = board[7, 6];
                block[4] = board[7, 7];
                block[5] = board[7, 8];
                block[6] = board[8, 6];
                block[7] = board[8, 7];
                block[8] = board[8, 8];
            }

            return block;
        }
    }
}
