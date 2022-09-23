using System;
using System.Collections.Generic;

namespace TruffleHunter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            string[,] forest = new string[size, size];
            FillForest(forest);

            Dictionary<string, int> trufflesCount = new Dictionary<string, int>(){
                {"W", 0 },
                {"B", 0 },
                {"S", 0 }
            };
            int wbCount = 0;

            var input = Console.ReadLine();
            while (input != "Stop the hunt")
            {
                var tokens = input.Split();
                var cmd = tokens[0];
                var row = int.Parse(tokens[1]);
                var col = int.Parse(tokens[2]);

                if (cmd == "Collect")
                    Collect(forest, row, col, trufflesCount);
                else if (cmd == "Wild_Boar")
                {
                    var direction = tokens[3];
                    WildBoar(forest, row, col, direction, ref wbCount);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Peter manages to harvest {trufflesCount["B"]} black, {trufflesCount["S"]} summer, and {trufflesCount["W"]} white truffles.");
            Console.WriteLine($"The wild boar has eaten {wbCount} truffles.");

            PrintForest(forest);
        }

        private static void PrintForest(string[,] forest)
        {
            for (int row = 0; row < forest.GetLength(0); row++)
            {
                for (int col = 0; col < forest.GetLength(1); col++)
                    Console.Write($"{forest[row, col]} ");

                Console.WriteLine();
            }
        }

        private static void WildBoar(string[,] forest, int row, int col, string direction, ref int wbCount)
        {
            int lastCellRow;
            int lastCellCol;

            if (direction == "up")
            {
                lastCellRow = 0;
                for (int x = row; x >= lastCellRow; x -= 2)
                {
                    if (forest[x, col] != "-")
                    {
                        wbCount++;
                        forest[x, col] = "-";
                    }
                }
            }
            else if (direction == "down")
            {
                lastCellRow = forest.GetLength(0) - 1;
                for (int x = row; x <= lastCellRow; x += 2)
                {
                    if (forest[x, col] != "-")
                    {
                        wbCount++;
                        forest[x, col] = "-";
                    }
                }
            }
            else if (direction == "right")
            {
                lastCellCol = forest.GetLength(1) - 1;
                for (int x = col; x <= lastCellCol; x += 2)
                {
                    if (forest[row, x] != "-")
                    {
                        wbCount++;
                        forest[row, x] = "-";
                    }
                }
            }
            else if (direction == "left")
            {
                lastCellCol = 0;
                for (int x = col; x >= 0; x -= 2)
                {
                    if (forest[row, x] != "-")
                    {
                        wbCount++;
                        forest[row, x] = "-";
                    }
                }
            }
        }

        private static void Collect(string[,] forest, int row, int col, Dictionary<string, int> trufflesCount)
        {
            if (forest[row, col] == "W") trufflesCount["W"]++;
            else if (forest[row, col] == "B") trufflesCount["B"]++;
            else if (forest[row, col] == "S") trufflesCount["S"]++;

            forest[row, col] = "-";
        }

        private static void FillForest(string[,] forest)
        {
            for (int row = 0; row < forest.GetLength(0); row++)
            {
                string[] rowInfo = Console.ReadLine().Split();
                for (int col = 0; col < forest.GetLength(1); col++) forest[row, col] = rowInfo[col];
            }
        }
    }
}