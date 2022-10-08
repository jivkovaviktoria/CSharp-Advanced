using System;
using System.Collections.Generic;
using System.Linq;

namespace Selling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] bakery = new char[n, n];
            List<int> clients = new List<int>();

            FillBakery(bakery, n);

            Tuple<int, int> coordinates = new Tuple<int, int>(0, 0);
            coordinates = FindCoordinates(bakery, coordinates);

            bool hasEnoughMoney = false;
            bool isOut = false;

            var cmd = Console.ReadLine();
            while (!hasEnoughMoney && !isOut)
            {
                if (cmd == "up") isOut = MoveUp(bakery, clients, coordinates, isOut);
                else if (cmd == "down") isOut = MoveDown(bakery, clients, coordinates, isOut);
                else if (cmd == "left") isOut = MoveLeft(bakery, clients, coordinates, isOut);
                else if (cmd == "right") isOut = MoveRight(bakery, clients, coordinates, isOut);

                if (isOut) break;

                coordinates = FindCoordinates(bakery, coordinates);

                if (clients.Sum() >= 50)
                {
                    hasEnoughMoney = true;
                    break;
                }

                cmd = Console.ReadLine();
            }

            if (isOut)
                Console.WriteLine("Bad news, you are out of the bakery.");

            if (clients.Sum() >= 50)
                Console.WriteLine("Good news! You succeeded in collecting enough money!");

            Console.WriteLine($"Money: {clients.Sum()}");
            PrintBakery(bakery);

        }

        private static void PrintBakery(char[,] bakery)
        {
            for (int row = 0; row < bakery.GetLength(0); row++)
            {
                for (int col = 0; col < bakery.GetLength(1); col++)
                {
                    Console.Write(bakery[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static bool MoveRight(char[,] bakery, List<int> clients, Tuple<int, int> coordinates, bool isOut)
        {
            var currentRow = coordinates.Item1;
            var currentCol = coordinates.Item2;

            if (currentCol + 1 > bakery.GetLength(0) - 1)
            {
                isOut = true;
                bakery[currentRow, currentCol] = '-';
                return isOut;
            }

            bakery[currentRow, currentCol] = '-';
            currentCol++;
            if (char.IsDigit(bakery[currentRow, currentCol]))
            {
                clients.Add(bakery[currentRow, currentCol] - '0');
                bakery[currentRow, currentCol] = '-';
            }
            else if (bakery[currentRow, currentCol] == 'O')
            {
                bakery[currentRow, currentCol] = '-';
                var pillar = FindPillar(bakery);
                currentRow = pillar.Item1;
                currentCol = pillar.Item2;
            }

            coordinates = new Tuple<int, int>(currentRow, currentCol);
            bakery[currentRow, currentCol] = 'S';

            return isOut;
        }

        private static bool MoveLeft(char[,] bakery, List<int> clients, Tuple<int, int> coordinates, bool isOut)
        {
            var currentRow = coordinates.Item1;
            var currentCol = coordinates.Item2;

            if (currentCol - 1 < 0)
            {
                isOut = true;
                bakery[currentRow, currentCol] = '-';
                return isOut;
            }

            bakery[currentRow, currentCol] = '-';
            currentCol--;
            if (char.IsDigit(bakery[currentRow, currentCol]))
            {
                clients.Add(bakery[currentRow, currentCol] - '0');
                bakery[currentRow, currentCol] = '-';
            }
            else if (bakery[currentRow, currentCol] == 'O')
            {
                bakery[currentRow, currentCol] = '-';
                var pillar = FindPillar(bakery);
                currentRow = pillar.Item1;
                currentCol = pillar.Item2;
            }

            coordinates = new Tuple<int, int>(currentRow, currentCol);
            bakery[currentRow, currentCol] = 'S';

            return isOut;
        }

        private static bool MoveDown(char[,] bakery, List<int> clients, Tuple<int, int> coordinates, bool isOut)
        {
            var currentRow = coordinates.Item1;
            var currentCol = coordinates.Item2;

            if (currentRow + 1 > bakery.GetLength(0) - 1)
            {
                isOut = true;
                bakery[currentRow, currentCol] = '-';
                return isOut;
            }

            bakery[currentRow, currentCol] = '-';
            currentRow++;
            if (char.IsDigit(bakery[currentRow, currentCol]))
            {
                clients.Add(bakery[currentRow, currentCol] - '0');
                bakery[currentRow, currentCol] = '-';
            }
            else if (bakery[currentRow, currentCol] == 'O')
            {
                bakery[currentRow, currentCol] = '-';
                var pillar = FindPillar(bakery);
                currentRow = pillar.Item1;
                currentCol = pillar.Item2;
            }

            coordinates = new Tuple<int, int>(currentRow, currentCol);
            bakery[currentRow, currentCol] = 'S';

            return isOut;
        }

        private static bool MoveUp(char[,] bakery, List<int> clients, Tuple<int, int> coordinates, bool isOut)
        {
            var currentRow = coordinates.Item1;
            var currentCol = coordinates.Item2;

            if (currentRow - 1 < 0)
            {
                isOut = true;
                bakery[currentRow, currentCol] = '-';
                return isOut;
            }

            bakery[currentRow, currentCol] = '-';
            currentRow--;
            if (char.IsDigit(bakery[currentRow, currentCol]))
            {
                clients.Add(bakery[currentRow, currentCol] - '0');
                bakery[currentRow, currentCol] = '-';
            }
            else if (bakery[currentRow, currentCol] == 'O')
            {
                bakery[currentRow, currentCol] = '-';
                var pillar = FindPillar(bakery);
                currentRow = pillar.Item1;
                currentCol = pillar.Item2;
            }

            coordinates = new Tuple<int, int>(currentRow, currentCol);
            bakery[currentRow, currentCol] = 'S';

            return isOut;
        }

        private static Tuple<int, int> FindPillar(char[,] bakery)
        {
            for (int row = 0; row < bakery.GetLength(0); row++)
            {
                for (int col = 0; col < bakery.GetLength(1); col++)
                {
                    if (bakery[row, col] == 'O')
                        return new Tuple<int, int>(row, col);
                }
            }

            return null;
        }

        private static Tuple<int, int> FindCoordinates(char[,] bakery, Tuple<int, int> coordinates)
        {
            for (int row = 0; row < bakery.GetLength(0); row++)
            {
                for (int col = 0; col < bakery.GetLength(1); col++)
                {
                    if (bakery[row, col] == 'S')
                        return new Tuple<int, int>(row, col);
                }
            }

            return null;
        }

        private static void FillBakery(char[,] bakery, int size)
        {
            for (int row = 0; row < size; row++)
            {
                string rowData = Console.ReadLine();
                for (int col = 0; col < size; col++) bakery[row, col] = rowData[col];
            }
        }
    }
}
