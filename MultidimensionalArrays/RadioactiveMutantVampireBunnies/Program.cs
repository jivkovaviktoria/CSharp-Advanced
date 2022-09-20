using System;
using System.Collections.Generic;
using System.Linq;

namespace RadioactiveMutantVampireBunnies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = size[0];
            int cols = size[1];

            char[,] lair = new char[rows, cols];

            Queue<(int Row, int Col)> bunnies = new Queue<(int Row, int Col)>();

            int playerRow = 0;
            int playerCol = 0;

            for (int row = 0; row < rows; row++)
            {
                string line = Console.ReadLine();
                for (int col = 0; col < cols; col++)
                {
                    lair[row, col] = line[col];

                    if (line[col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                    else if (line[col] == 'B') bunnies.Enqueue((row, col));
                }
            }

            string commands = Console.ReadLine();
            Dictionary<char, (int Row, int Col)> directions = new Dictionary<char, (int Row, int Col)>();
            directions['U'] = (-1, 0);
            directions['D'] = (1, 0);
            directions['L'] = (0, -1);
            directions['R'] = (0, 1);

            foreach (char commandName in commands)
            {
                int newPlayerRow = playerRow + directions[commandName].Row;
                int newPlayerCol = playerCol + directions[commandName].Col;

                lair[playerRow, playerCol] = '.';
                bool hasWon = newPlayerRow < 0 || newPlayerRow >= rows || newPlayerCol < 0 || newPlayerCol >= cols;
                bool isDead = hasWon == false && lair[newPlayerRow, newPlayerCol] == 'B';

                if (!hasWon)
                {
                    if (!isDead) lair[newPlayerRow, newPlayerCol] = 'P';
                    playerRow = newPlayerRow;
                    playerCol = newPlayerCol;
                }

                // Spread bunnies
                int bunniesCount = bunnies.Count;
                for (int j = 0; j < bunniesCount; j++)
                {
                    var bunnyCoordinates = bunnies.Dequeue();
                    foreach (var direction in directions.Values)
                    {
                        int newBunnyRow = bunnyCoordinates.Row + direction.Row;
                        int newBunnyCol = bunnyCoordinates.Col + direction.Col;

                        if (newBunnyRow < 0 || newBunnyRow >= rows || newBunnyCol < 0 || newBunnyCol >= cols || lair[newBunnyRow, newBunnyCol] == 'B') continue;

                        if (lair[newBunnyRow, newBunnyCol] == 'P') isDead = true;
                        lair[newBunnyRow, newBunnyCol] = 'B';
                        bunnies.Enqueue((newBunnyRow, newBunnyCol));
                    }
                }

                if (hasWon || isDead)
                {
                    PrintLair(lair);
                    if (hasWon) Console.WriteLine($"won: {playerRow} {playerCol}");
                    if (isDead) Console.WriteLine($"dead: {playerRow} {playerCol}");
                    break;
                }
            }
        }

        private static void PrintLair(char[,] lair)
        {
            for (int row = 0; row < lair.GetLength(0); row++)
            {
                for (int col = 0; col < lair.GetLength(1); col++) Console.Write(lair[row, col]);
                Console.WriteLine();
            }
        }
    }
}