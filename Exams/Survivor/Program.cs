using System;

namespace Survivor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] x = new int[] { -1, -2, -3 };
            int[] y = new int[] { 1, 2, 3 };

            int n = int.Parse(Console.ReadLine());
            char[][] field = new char[n][];
            FillField(field);

            int tokensCount = 0, opponnentTokensCount = 0;

            var input = Console.ReadLine();
            while (input != "Gong")
            {
                var tokens = input.Split();
                var cmd = tokens[0];
                var row = int.Parse(tokens[1]);
                var col = int.Parse(tokens[2]);

                if (cmd == "Find")
                {
                    if (row >= 0 && row < field.Length && col >= 0 && col < field[row].Length)
                    {
                        if (field[row][col] == 'T')
                        {
                            tokensCount++;
                            field[row][col] = '-';
                        }
                    }
                }
                else if (cmd == "Opponent")
                {
                    var direction = tokens[3];

                    if(row >= 0 && row < field.Length && col >= 0 && col < field[row].Length)
                    {
                        if (field[row][col] == 'T')
                        {
                            opponnentTokensCount++;
                            field[row][col] = '-';
                        }

                        if(direction == "up")
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                var newRow = row + x[i];
                                if (newRow >= 0 && newRow < field.Length)
                                {
                                    if (field[newRow][col] == 'T')
                                    {
                                        opponnentTokensCount++;
                                        field[newRow][col] = '-';
                                    }
                                }
                            }
                        }
                        else if(direction == "down")
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                var newRow = row + y[i];
                                if (newRow >= 0 && newRow < field.Length)
                                {
                                    if (field[newRow][col] == 'T')
                                    {
                                        opponnentTokensCount++;
                                        field[newRow][col] = '-';
                                    }
                                }
                            }
                        }
                        else if(direction == "left")
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                var newCol = col + x[i];
                                if (newCol >= 0 && newCol < field[row].Length)
                                {
                                    if (field[row][newCol] == 'T')
                                    {
                                        opponnentTokensCount++;
                                        field[row][newCol] = '-';
                                    }
                                }
                            }
                        }
                        else if(direction == "right")
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                var newCol = col + y[i];
                                if (newCol >= 0 && newCol < field[row].Length)
                                {
                                    if (field[row][newCol] == 'T')
                                    {
                                        opponnentTokensCount++;
                                        field[row][newCol] = '-';
                                    }
                                }
                            }
                        }
                    }
                }

                input = Console.ReadLine();
            }

            PrintField(field);
            Console.WriteLine($"Collected tokens: {tokensCount}");
            Console.WriteLine($"Opponent's tokens: { opponnentTokensCount}");

        }

        private static void PrintField(char[][] field)
        {
            for (int row = 0; row < field.Length; row++)
            {
                for (int col = 0; col < field[row].Length; col++)
                {
                    Console.Write(field[row][col] + " ");
                }
                Console.WriteLine();
            }
        }

        private static void FillField(char[][] field)
        {
            for (int row = 0; row < field.Length; row++)
            {
                char[] rowData = Console.ReadLine().Replace(" ", "").ToCharArray();
                field[row] = rowData;
            }
        }
    }
}
