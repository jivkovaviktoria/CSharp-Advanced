using System;

namespace WallDestroyer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] x = new int[] { -1, 1, 0, 0 };
            int[] y = new int[] { 0, 0, -1, 1 };

            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];

            for (int i = 0; i < n; i++)
            {
                string data = Console.ReadLine();
                for (int j = 0; j < n; j++) matrix[i, j] = data[j];
            }

            var vankoPosition = FindVanko(matrix);

            int holesCount = 1, rodsCount = 0, row = 0, col = 0;
            bool isDead = false;

            var cmd = Console.ReadLine();
            while (cmd != "End" && !isDead)
            {
                if (cmd == "up")
                {
                    row = vankoPosition[0] + x[0];
                    col = vankoPosition[1] + y[1];
                }
                else if (cmd == "down")
                {
                    row = vankoPosition[0] + x[1];
                    col = vankoPosition[1] + y[1];
                }
                else if (cmd == "left")
                {
                    row = vankoPosition[0] + x[2];
                    col = vankoPosition[1] + y[2];
                }
                else if (cmd == "right")
                {
                    row = vankoPosition[0] + x[3];
                    col = vankoPosition[1] + y[3];
                }

                if (row >= 0 && row < n && col >= 0 && col < n)
                {
                    if (matrix[row, col] == 'R')
                    {
                        Console.WriteLine("Vanko hit a rod!");
                        rodsCount++;
                    }
                    else if (matrix[row, col] == '*')
                    {
                        matrix[vankoPosition[0], vankoPosition[1]] = '*';
                        vankoPosition[0] = row;
                        vankoPosition[1] = col;
                        matrix[row, col] = 'V';
                        Console.WriteLine($"The wall is already destroyed at position [{row}, {col}]!");
                    }
                    else if (matrix[row, col] == 'C')
                    {
                        matrix[row, col] = 'E';
                        holesCount++;

                        matrix[vankoPosition[0], vankoPosition[1]] = '*';
                        isDead = true;
                    }
                    else
                    {
                        matrix[row, col] = 'V';
                        matrix[vankoPosition[0], vankoPosition[1]] = '*';
                        vankoPosition[0] = row;
                        vankoPosition[1] = col;
                        holesCount++;
                    }
                }

                cmd = Console.ReadLine();
            }

            if (isDead) Console.WriteLine($"Vanko got electrocuted, but he managed to make {holesCount} hole(s).");
            else Console.WriteLine($"Vanko managed to make {holesCount} hole(s) and he hit only {rodsCount} rod(s).");

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

        private static int[] FindVanko(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 'V')
                        return new int[] { i, j };
                }
            }

            return null;
        }
    }
}
