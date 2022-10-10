using System;

namespace Armory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] x = new int[] { -1, 1, 0, 0 };
            int[] y = new int[] { 0, 0, -1, 1 };

            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];
            FillMatrix(matrix);

            int[] officer = FindOfficer(matrix);

            int swords = 0;

            while (swords < 65)
            {
                var cmd = Console.ReadLine();
                int row = 0, col = 0;
                if (cmd == "up")
                {
                    row = officer[0] + x[0];
                    col = officer[1] + y[0];
                }
                else if (cmd == "down")
                {
                    row = officer[0] + x[1];
                    col = officer[1] + y[1];
                }
                else if (cmd == "left")
                {
                    row = officer[0] + x[2];
                    col = officer[1] + y[2];
                }
                else if (cmd == "right")
                {
                    row = officer[0] + x[3];
                    col = officer[1] + y[3];
                }

                if (row >= 0 && row < n && col >= 0 && col < n)
                {
                    if (char.IsDigit(matrix[row, col]))
                    {
                        swords += matrix[row, col] - '0';

                        matrix[row, col] = 'A';
                        matrix[officer[0], officer[1]] = '-';
                        officer[0] = row;
                        officer[1] = col;
                    }
                    else if (matrix[row, col] == 'M')
                    {
                        matrix[row, col] = '-';
                        matrix[officer[0], officer[1]] = '-';

                        for (int r = 0; r < n; r++)
                        {
                            for (int c = 0; c < n; c++)
                            {
                                if (matrix[r, c] == 'M')
                                {
                                    matrix[r, c] = 'A';
                                    officer[0] = r;
                                    officer[1] = c;
                                }
                            }
                        }
                    }
                    else
                    {
                        matrix[row, col] = 'A';
                        matrix[officer[0], officer[1]] = '-';
                        officer[0] = row;
                        officer[1] = col;
                    }
                }
                else
                {
                    matrix[officer[0], officer[1]] = '-';
                    break;
                }
            }

            if (swords >= 65) Console.WriteLine($"Very nice swords, I will come back for more!");
            else Console.WriteLine($"I do not need more swords!");

            Console.WriteLine($"The king paid {swords} gold coins.");
            PrintMatrix(matrix);
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static int[] FindOfficer(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 'A')
                    {
                        return new int[] { i, j };
                    }
                }
            }

            return null;
        }

        private static void FillMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string data = Console.ReadLine();
                for (int j = 0; j < matrix.GetLength(1); j++) matrix[i, j] = data[j];
            }
        }
    }
}
