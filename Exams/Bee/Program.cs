using System;

namespace Bee
{
    using System.Data;

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string rowData = Console.ReadLine();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = rowData[j];
                }
            }

            int[] bee = new int[2];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 'B')
                    {
                        bee = new int[] { i, j };
                        break;
                    }
                }
            }
            int flowers = 0, row = 0, col = 0;
            bool gotLost = false;
            
            var cmd = Console.ReadLine();
            while (cmd != "End")
            {
                row = bee[0];
                col = bee[1];
                
                if (cmd == "up")
                {
                    row--;
                    if (row < 0)
                    {
                        gotLost = true;
                        break;
                    }
                    if (matrix[row, col] == 'O')
                    {
                        matrix[row, col] = '.';
                        row--;
                    }
                }
                else if (cmd == "down")
                {
                    row++;
                    if (row >= n)
                    {
                        gotLost = true;
                        break;
                    };
                    if (matrix[row, col] == 'O')
                    {
                        matrix[row, col] = '.';
                        row++;
                    }
                }
                else if (cmd == "left")
                {
                    col--;
                    if (col < 0)
                    {
                        gotLost = true;
                        break;
                    }
                    if (matrix[row, col] == 'O')
                    {
                        matrix[row, col] = '.';
                        col--;
                    }
                }
                else if (cmd == "right")
                {
                    col++;
                    if (col >= n)
                    {
                        gotLost = true;
                        break;
                    }
                    if (matrix[row, col] == 'O')
                    {
                        matrix[row, col] = '.';
                        col++;
                    }
                }
                
                
                if (matrix[row, col] == 'f') flowers++;
                
                matrix[row, col] = 'B';
                matrix[bee[0], bee[1]] = '.';
                bee[0] = row;
                bee[1] = col;
                
                cmd = Console.ReadLine();
            }

            if (gotLost)
            {
                Console.WriteLine("The bee got lost!");
                matrix[bee[0], bee[1]] = '.';
            }
            if (flowers < 5) Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - flowers} flowers more");
            else Console.WriteLine($"Great job, the bee managed to pollinate {flowers} flowers!");
            
            PrintMatrix(matrix);

        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }

                Console.WriteLine();
            }
        }
    }
}