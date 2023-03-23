using System;

namespace Lab1_ai
{
    public class Board
    {
        private Queen[] queens;
        private int size;

        public Board(int size)
        {
            this.size = size;
            queens = new Queen[size];
        }

        public int GetSize()
        {
            return size;
        }

        public void PlaceQueenOnSquare(int row, int col)
        {
            queens[row] = new Queen(row, col);
        }

        public bool IsQueenOnSquare(int row, int col)
        {
            for (int i = 0; i < size; i++)
            {
                if (queens[i] != null && queens[i].GetRow() == row && queens[i].GetColumn() == col)
                {
                    return true;
                }
            }
            return false;
        }

        public int GetQueenColumnForRow(int row)
        {
            return queens[row].GetColumn();
        }

        public int GetAttackingPairs()
        {
            int count = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = i + 1; j < size; j++)
                {
                    if (queens[i].IsAttacking(queens[j]))
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public void Print()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (IsQueenOnSquare(i, j))
                    {
                        Console.Write("Q ");
                    }
                    else
                    {
                        Console.Write(". ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
