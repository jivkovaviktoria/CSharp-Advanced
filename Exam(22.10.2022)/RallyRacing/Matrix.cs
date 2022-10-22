using System;
using System.Linq;
using System.Collections.Generic;


namespace Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] x = new int[] { -1, 1 };
            int[] y = new int[] { -1, 1 };

            int n = int.Parse(Console.ReadLine());
            string racerNum = Console.ReadLine();

            char[,] matrix = new char[n, n];
            FillMatrix(matrix);

            int km = 0;
            int[] car = new[] { 0, 0 };
            int row = 0, col = 0;
            bool hasWon = false;

            var cmd = Console.ReadLine();
            matrix[0, 0] = 'C';
            while (true)
            {
                
                if (cmd != "End")
                {
                    row = car[0];
                    col = car[1];
                    km += 10;


                    if (cmd == "up") row += x[0];
                    else if (cmd == "down") row += x[1];
                    else if (cmd == "left") col += y[0];
                    else if (cmd == "right") col += y[1];


                    if (matrix[row, col] == '.')
                    {
                        matrix[car[0], car[1]] = '.';
                        matrix[row, col] = 'C';

                        car[0] = row;
                        car[1] = col;
                    }
                    else if (matrix[row, col] == 'T')
                    {
                        matrix[row, col] = '.';
                        int[] tcoo = Find(matrix);

                        matrix[car[0], car[1]] = '.';
                        matrix[tcoo[0], tcoo[1]] = 'C';
                        car[0] = tcoo[0];
                        car[1] = tcoo[1];

                        km += 20;
                    }
                    else if (matrix[row, col] == 'F')
                    {
                        matrix[row, col] = 'C';
                        matrix[car[0], car[1]] = '.';
                        hasWon = true;
                        break;
                    }
                }


                if (cmd == "End")
                {
                    Console.WriteLine($"Racing car {racerNum} DNF.");
                    break;
                }

                cmd = Console.ReadLine();
            }

            if(hasWon) Console.WriteLine($"Racing car {racerNum} finished the stage!");
            Console.WriteLine($"Distance covered {km} km.");
            PrintMatrix(matrix);
        }

        public static void FillMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] rowData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++) matrix[row, col] = rowData[col];
            }
        }

        public static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++) Console.Write(matrix[row, col]);
                Console.WriteLine();
            }
        }

        public static int[] Find(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'T') return new int[] { row, col };
                }
            }

            return null;
        }

        //If need to check diagonals too
        // for (int rowDirection = -1; rowDirection <= 1; rowDirection++)
        // {
        //     for (int colDirection = -1; colDirection <= 1; colDirection++)
        //     {
        //         int r = x + rowDirection, c = y + colDirection;
        //         if (r >= 0 && r < n && c >= 0 && c < n)
        //         {
        //             //code...
        //         }
        //     }
        // }
    }
}