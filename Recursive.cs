using System;

namespace _8_Queens_Solver
{
    class Recursive
    {
        static int n;
        static int[,] board;

        static void Main()
        {
            n = 8;
            board = new int[n, n];
            CalcSolutions(0, 0);
            Console.ReadKey();
        }

        static void CalcSolutions(int column, int row)
        {
            for (int x = column; x < n; x++)
            {
                if (!HasConflict(x, row))
                {
                    board[x, row] = 1;
                    if (row < n - 1)
                    {
                        CalcSolutions(0, row + 1);
                        board[x, row] = 0;
                    }
                    else
                    {
                        PrintSolution();
                        board[x, row] = 0;
                    }
                }
            }
        }

        static bool HasConflict(int column, int row)
        {
            bool result = false;
            for (int y = 1; y <= row; y++)
            {
                int left = column - y;
                int up = row - y;
                int right = column + y;
                if (up >= 0)
                {
                    if (board[column, up] == 1)
                    {
                        result = true;
                        break;
                    }
                    if (left >= 0 && board[left, up] == 1)
                    {
                        result = true;
                        break;
                    }
                    if (right < n && board[right, up] == 1)
                    {
                        result = true;
                        break;
                    }
                }
            }
            
            return result;
        }

        static void PrintSolution()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (board[j, i] == 1)
                    {
                        Console.Write($"{(char)(j + 65)}{Math.Abs(i - 8)} ");
                        break;
                    }
                }
            }

            Console.WriteLine();
        }
    }
}
