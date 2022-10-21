using System;

namespace SuperMario
{
    class Program
    {
        static void Main(string[] args)
        {
            int lives = int.Parse(Console.ReadLine());

            int n = int.Parse(Console.ReadLine());
            char[][] matrix = new char[n][];

            int[] mario = new int[2];

            for (int row = 0; row < n; row++)
            {
                char[] rowData = Console.ReadLine().ToCharArray();
                matrix[row] = rowData;

                for (int col = 0; col < rowData.Length; col++)
                {
                    if (matrix[row][col] == 'M')
                    {
                        mario[0] = row;
                        mario[1] = col;
                    }
                }
            }
            
            bool hasWon = false, isDead = false;
            int mRow = mario[0], mCol = mario[1];
            
            while (!hasWon && !isDead)
            {
                var data = Console.ReadLine().Split();
                
                var cmd = data[0];
                var row = int.Parse(data[1]);
                var col = int.Parse(data[2]);

                matrix[row][col] = 'B';
                lives--;

                bool isOut = false;
                if (cmd == "W" && mario[0] - 1 >= 0) mRow--;
                else if (cmd == "S" && mario[0] + 1 < n) mRow++;
                else if (cmd == "A" && mario[1] - 1 >= 0) mCol--;
                else if (cmd == "D" && mario[1] + 1 < matrix[mario[0]].Length) mCol++;
                else isOut = true;

                if (!isOut)
                {
                    if (matrix[mRow][mCol] == 'B')
                    {
                        lives -= 2;
                        
                        matrix[mario[0]][mario[1]] = '-';
                        matrix[mRow][mCol] = 'M';
                        mario[0] = mRow;
                        mario[1] = mCol;
                    }
                    else if (matrix[mRow][mCol] == 'P')
                    {
                        matrix[mario[0]][mario[1]] = '-';
                        matrix[mRow][mCol] = '-';
                        hasWon = true;
                        break;
                    }
                    else
                    {
                        matrix[mario[0]][mario[1]] = '-';
                        matrix[mRow][mCol] = 'M';
                        mario[0] = mRow;
                        mario[1] = mCol;
                    }
                }

                if (lives <= 0)
                {
                    matrix[mario[0]][mario[1]] = '-';
                    matrix[mRow][mCol] = 'X';
                    isDead = true;
                }
            }

            if (isDead) Console.WriteLine($"Mario died at {mRow};{mCol}.");
            else if(hasWon) Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lives}");

            for (int row = 0; row < n; row++)
            {
                for(int col = 0; col < matrix[row].Length; col++) Console.Write(matrix[row][col]);
                Console.WriteLine();
            }
        }
    }
}