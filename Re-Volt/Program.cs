using System;
using System.Linq;

namespace Re_Volt
{
    using System.Data;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[][] matrix = new char[n][];

            int commandsCount = int.Parse(Console.ReadLine());

            FillMatrix(matrix, n);

            int[] player = FindPlayer(matrix);

            bool hasWon = false;
            int row = 0, col = 0;



            while (commandsCount > 0)
            {
                var cmd = Console.ReadLine();
                row = player[0];
                col = player[1];

                if (cmd == "up")
                {
                    row--;
                    if (row < 0) row = matrix.GetLength(0) - 1;
                    if (matrix[row][col] == 'B') row--;
                    if (row >= 0 && row < matrix.GetLength(0) && matrix[row][col] == 'T') row++;

                }
                else if (cmd == "down")
                {
                    row++;
                    if (row >= matrix.GetLength(0)) row = 0;
                    if (matrix[row][col] == 'B') row++;
                    if (row >= 0 && row < matrix[row].Length && matrix[row][col] == 'T') row--;
                }
                else if (cmd == "left")
                {
                    col--;
                    if (col < 0) col = matrix[row].Length - 1;
                    if (matrix[row][col] == 'B') col--;
                    if (col >= 0 && col < matrix[row].Length && matrix[row][col] == 'T') col++;
                }
                else if (cmd == "right")
                {
                    col++;
                    if (col >= matrix[row].Length) col = 0;
                    if (matrix[row][col] == 'B') col++;
                    if (col >= 0 && col < matrix[row].Length && matrix[row][col] == 'T') col--;
                }

                if (row >= matrix.GetLength(0)) row = 0;
                else if (row < 0) row = matrix.GetLength(0) - 1;
                else if (col >= matrix[row].Length) col = 0;
                else if (col < 0) col = matrix[row].Length - 1;

                if (matrix[row][col] == 'F') hasWon = true;
                
                matrix[player[0]][player[1]] = '-';
                matrix[row][col] = 'f';

                player[0] = row;
                player[1] = col;

                commandsCount--;
                if (hasWon) break;
            }
            
            if(commandsCount == 0 && !hasWon) Console.WriteLine("Player lost!");
            else if(hasWon) Console.WriteLine("Player won!");
            
            PrintMatrix(matrix);
        }

        private static void PrintMatrix(char[][] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)  Console.Write(matrix[i][j]);
                Console.WriteLine();
            }
        }

        private static int[] FindPlayer(char[][] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 'f')
                        return new int[] { i, j };
                }
            }

            return null;
        }

        private static void FillMatrix(char[][] matrix, int n)
        {
            for (int i = 0; i < n; i++)
            {
                var rowData = Console.ReadLine().ToCharArray();
                matrix[i] = rowData;
            }
            
        }
    }
}