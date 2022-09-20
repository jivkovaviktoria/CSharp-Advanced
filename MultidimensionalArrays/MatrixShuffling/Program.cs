using System;
using System.Linq;

namespace MatrixShuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = size[0];
            int cols = size[1];

            string[,] matrix = new string[rows,cols];

            for (int row = 0; row < rows; row++)
            {
                string[] data = Console.ReadLine().Split();
                for (int col = 0; col < cols; col++) matrix[row, col] = data[col];
            }

            var input = Console.ReadLine();
            while (input!="END")
            {
                string[] tokens = input.Split();
                var cmd = tokens[0];

                if (tokens.Length < 5 || tokens.Length > 5 || cmd != "swap" || !isValidCoordinates(matrix, tokens[1], tokens[2], tokens[3], tokens[3]))
                    Console.WriteLine("Invalid input!");
                else
                {
                    var row1 = int.Parse(tokens[1]);
                    var col1 = int.Parse(tokens[2]);

                    var row2 = int.Parse(tokens[3]);
                    var col2 = int.Parse(tokens[4]);

                    var x = matrix[row1, col1];
                    matrix[row1, col1] = matrix[row2, col2];
                    matrix[row2, col2] = x;

                    PrintMatrix(matrix);
                }

                input = Console.ReadLine();
            }
        }

        private static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                    Console.Write(matrix[row, col] + " ");

                Console.WriteLine();
            }
        }

        private static bool isValidCoordinates(string[,] matrix, string x1, string x2, string y1, string y2)
        {
            int row1 = int.Parse(x1);
            int col1 = int.Parse(x2);

            int row2 = int.Parse(y1);
            int col2 = int.Parse(y2);

            if (row1 < 0 || row1 >= matrix.GetLength(0)) return false;
            if (col1 < 0 || col1 >= matrix.GetLength(1)) return false;
            if (row2 < 0 || row2 >= matrix.GetLength(0)) return false;
            if (col2 < 0 || col2 > matrix.GetLength(1)) return false;

            return true;
        }
    }
}