using System;

namespace TheBattleOfTheFiveArmies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] x = new int[] { -1, 1, 0, 0 };
            int[] y = new int[] { 0, 0, -1, 1 };

            int e = int.Parse(Console.ReadLine());

            int n = int.Parse(Console.ReadLine());
            char[][] matrix = new char[n][];
            FillMatrix(matrix);
            var army = FindArmy(matrix);

            bool isDead = false, hasWon = false;
            int r = 0, c = 0;

            while (!hasWon)
            {
                var data = Console.ReadLine().Split();
                var cmd = data[0];
                var row = int.Parse(data[1]);
                var col = int.Parse(data[2]);

                matrix[row][col] = 'O';
                e--;

                if (cmd == "up")
                {
                    r = army[0] + x[0];
                    c = army[1] + y[0];

                    if (r >= 0 && r < n && c >= 0 && c < n)
                    {
                        if (matrix[r][c] == 'O')
                        {
                            e -= 2;
                            if (e <= 0)
                            {
                                isDead = true;
                                matrix[r][c] = 'X';
                                matrix[army[0]][army[1]] = '-';
                                break;
                            }

                            matrix[r][c] = 'A';
                            matrix[army[0]][army[1]] = '-';
                            army[0] = r;
                            army[1] = c;
                        }
                        else
                        {
                            if (matrix[r][c] == 'M')
                            {
                                hasWon = true;
                                matrix[army[0]][army[1]] = '-';
                                matrix[r][c] = '-';
                                break;
                            }
                            matrix[army[0]][army[1]] = '-';
                            army[0] = r;
                            army[1] = c;
                            matrix[r][c] = 'A';

                            if (e <= 0)
                            {
                                matrix[r][c] = 'X';
                                isDead = true;
                                break;
                            }
                        }
                    }
                }
                else if (cmd == "down")
                {
                    r = army[0] + x[1];
                    c = army[1] + y[1];

                    if (r >= 0 && r < n && c >= 0 && c < n)
                    {
                        if (matrix[r][c] == 'O')
                        {
                            e -= 2;
                            if (e <= 0)
                            {
                                isDead = true;
                                matrix[r][c] = 'X';
                                matrix[army[0]][army[1]] = '-';
                                break;
                            }

                            matrix[r][c] = 'A';
                            matrix[army[0]][army[1]] = '-';
                            army[0] = r;
                            army[1] = c;
                        }
                        else
                        {
                            if (matrix[r][c] == 'M')
                            {
                                hasWon = true;
                                matrix[army[0]][army[1]] = '-';
                                matrix[r][c] = '-';
                                break;
                            }
                            matrix[army[0]][army[1]] = '-';
                            army[0] = r;
                            army[1] = c;
                            matrix[r][c] = 'A';
                            if (e <= 0)
                            {
                                matrix[r][c] = 'X';
                                isDead = true;
                                break;
                            }
                        }
                    }
                }
                else if (cmd == "left")
                {
                    r = army[0] + x[2];
                    c = army[1] + y[2];

                    if (r >= 0 && r < n && c >= 0 && c < n)
                    {
                        if (matrix[r][c] == 'O')
                        {
                            e -= 2;
                            if (e <= 0)
                            {
                                isDead = true;
                                matrix[r][c] = 'X';
                                matrix[army[0]][army[1]] = '-';
                                break;
                            }

                            matrix[r][c] = 'A';
                            matrix[army[0]][army[1]] = '-';
                            army[0] = r;
                            army[1] = c;
                        }
                        else
                        {
                            if (matrix[r][c] == 'M')
                            {
                                hasWon = true;
                                matrix[army[0]][army[1]] = '-';
                                matrix[r][c] = '-';
                                break;
                            }
                            matrix[army[0]][army[1]] = '-';
                            army[0] = r;
                            army[1] = c;
                            matrix[r][c] = 'A';
                            if (e <= 0)
                            {
                                matrix[r][c] = 'X';
                                isDead = true;
                                break;
                            }
                        }
                    }
                
                }
                else if (cmd == "right")
                {
                    r = army[0] + x[3];
                    c = army[1] + y[3];

                    if (r >= 0 && r < n && c >= 0 && c < n)
                    {
                        if (matrix[r][c] == 'O')
                        {
                            e -= 2;
                            if (e <= 0)
                            {
                                isDead = true;
                                matrix[r][c] = 'X';
                                matrix[army[0]][army[1]] = '-';
                                break;
                            }

                            matrix[r][c] = 'A';
                            matrix[army[0]][army[1]] = '-';
                            army[0] = r;
                            army[1] = c;
                        }
                        else
                        {
                            if (matrix[r][c] == 'M')
                            {
                                hasWon = true;
                                matrix[army[0]][army[1]] = '-';
                                matrix[r][c] = '-';
                                break;
                            }
                            matrix[army[0]][army[1]] = '-';
                            army[0] = r;
                            army[1] = c;
                            matrix[r][c] = 'A';
                            if (e <= 0)
                            {
                                matrix[r][c] = 'X';
                                isDead = true;
                                break;
                            }
                        }
                    }
                }
            }

            if (isDead) Console.WriteLine($"The army was defeated at {r};{c}.");
            else if (hasWon) Console.WriteLine($"The army managed to free the Middle World! Armor left: {e}");

            PrintMatrix(matrix);
        }

        private static void PrintMatrix(char[][] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write($"{matrix[row][col]}");
                }
                Console.WriteLine();
            }
        }

        private static int[] FindArmy(char[][] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'A')
                        return new int[] { row, col };
                }
            }

            return null;
        }

        private static void FillMatrix(char[][] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] rowData = Console.ReadLine().ToCharArray();
                matrix[row] = rowData;
            }
        }
    }
}
