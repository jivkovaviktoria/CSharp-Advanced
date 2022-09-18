using System;
using System.Linq;

namespace HelpAMole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x = int.Parse(Console.ReadLine());
            char[,] field = new char[x, x];

            int moleRow = 0;
            int moleCol = 0;

            int points = 0;

            for (int row = 0; row < x; row++)
            {
                string data = Console.ReadLine();
                for (int col = 0; col < x; col++)
                {
                    field[row, col] = data[col];
                    if (data[col] == 'M')
                    {
                        moleCol = col;
                        moleRow = row;
                    }
                }
            }

            string command = Console.ReadLine();
            while (command != "End")
            {
                if (command == "right")
                {
                    moleCol++;
                    if (moleCol >= field.GetLength(0))
                    {
                        Console.WriteLine("Don't try to escape the playing field!");
                        moleCol--;
                    }
                    else
                    {
                        if (char.IsDigit(field[moleRow, moleCol])) points += int.Parse(field[moleRow, moleCol].ToString());
                        field[moleRow, moleCol - 1] = '-';
                    }
                }
                else if (command == "left")
                {
                    moleCol--;
                    if (moleCol < 0)
                    {
                        Console.WriteLine("Don't try to escape the playing field!");
                        moleCol++;
                    }
                    else
                    {
                        if (char.IsDigit(field[moleRow, moleCol])) points += int.Parse(field[moleRow, moleCol].ToString());
                        field[moleRow, moleCol + 1] = '-';
                    }
                }
                else if (command == "up")
                {
                    moleRow--;
                    if (moleRow < 0)
                    {
                        Console.WriteLine("Don't try to escape the playing field!");
                        moleRow++;
                    }
                    else
                    {
                        if (char.IsDigit(field[moleRow, moleCol])) points += int.Parse(field[moleRow, moleCol].ToString());
                        field[moleRow + 1, moleCol] = '-';
                    }
                }
                else if (command == "down")
                {
                    moleRow++;
                    if (moleRow >= field.GetLength(1))
                    {
                        Console.WriteLine("Don't try to escape the playing field!");
                        moleRow--;
                    }
                    else
                    {
                        if (char.IsDigit(field[moleRow, moleCol])) points += int.Parse(field[moleRow, moleCol].ToString());
                        field[moleRow - 1, moleCol] = '-';
                    }
                }

                if (field[moleRow, moleCol] == 'S')
                {
                    field[moleRow, moleCol] = '-';
                    for (int row = 0; row < x; row++)
                    {
                        for (int col = 0; col < x; col++)
                            if (field[row, col] == 'S')
                            {
                                field[row, col] = 'M';
                                moleCol = col;
                                moleRow = row;
                            }
                    }

                    points -= 3;
                }
                else field[moleRow, moleCol] = 'M';





                if (points < 25) command = Console.ReadLine();
                else break;
            }

            if (points >= 25)
            {
                Console.WriteLine("Yay! The Mole survived another game!");
                Console.WriteLine($"The Mole managed to survive with a total of {points} points.");
            }
            else
            {
                Console.WriteLine("Too bad! The Mole lost this battle!");
                Console.WriteLine($"The Mole lost the game with a total of {points} points.");
            }

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    Console.Write(field[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}