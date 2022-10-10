using System;
using System.Collections.Generic;
using System.Linq;

public static class Program
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        char[,] matrix = new char[n, n];

        string[] attackCommands = Console.ReadLine().Split(',');

        int player1ShipsCount = 0, player2ShipsCount = 0;
        for (int i = 0; i < n; i++)
        {
            string row = Console.ReadLine();
            for (int j = 0; j < n; j++)
            {
                var current = row[j * 2];
                if (current == '<') player1ShipsCount++;
                else if (current == '>') player2ShipsCount++;

                matrix[i, j] = current;
            }
        }

        int totalDestroyedShips = 0;
        for (int i = 0; i < attackCommands.Length && player1ShipsCount > 0 && player2ShipsCount > 0; i++)
        {
            int[] data = attackCommands[i].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int x = data[0], y = data[1];
            if (x < 0 || x >= n || y < 0 || y >= n) continue;

            if (matrix[x, y] == '<')
            {
                player1ShipsCount--;
                totalDestroyedShips++;
                matrix[x, y] = 'X';
            }
            else if (matrix[x, y] == '>')
            {
                player2ShipsCount--;
                totalDestroyedShips++;
                matrix[x, y] = 'X';
            }
            else if (matrix[x, y] == '#')
            {
                for (int rowDirection = -1; rowDirection <= 1; rowDirection++)
                {
                    for (int colDirection = -1; colDirection <= 1; colDirection++)
                    {
                        int r = x + rowDirection, c = y + colDirection;
                        if (r >= 0 && r < n && c >= 0 && c < n)
                        {
                            if (matrix[r, c] == '<')
                            {
                                player1ShipsCount--;
                                totalDestroyedShips++;
                                matrix[r, c] = 'X';
                            }
                            else if (matrix[r, c] == '>')
                            {
                                player2ShipsCount--;
                                totalDestroyedShips++;
                                matrix[r, c] = 'X';
                            }
                        }
                    }
                }
            }
        }

        if (player2ShipsCount == 0) Console.WriteLine($"Player One has won the game! {totalDestroyedShips} ships have been sunk in the battle.");
        else if (player1ShipsCount == 0) Console.WriteLine($"Player Two has won the game! {totalDestroyedShips} ships have been sunk in the battle.");
        else Console.WriteLine($"It's a draw! Player One has {player1ShipsCount} ships left. Player Two has {player2ShipsCount} ships left.");
    }
}