using System;

namespace PawnWars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] chessBoard = new char[8, 8];
            int whiteX = 0, whiteY = 0, blackX = 0, blackY = 0;

            for (int row = 0; row < 8; row++)
            {
                string rowData = Console.ReadLine();
                for (int col = 0; col < 8; col++)
                {
                    chessBoard[row, col] = rowData[col];
                    if (chessBoard[row, col] == 'w')
                    {
                        whiteX = row;
                        whiteY = col;
                    }
                    else if (chessBoard[row, col] == 'b')
                    {
                        blackX = row;
                        blackY = col;
                    }
                }
            }

            bool whiteTurn = true;
            while(true)
            {
                if (whiteTurn)
                {
                    if(whiteX == 0)
                    {
                        Console.WriteLine($"Game over! White pawn is promoted to a queen at {(char)(97+whiteY)}8.");
                        return;
                    }
                    if(IsValidCell(whiteX-1, whiteY-1, chessBoard) && chessBoard[whiteX-1, whiteY-1] == 'b')
                    {
                        whiteX--;
                        whiteY--;
                        Console.WriteLine($"Game over! White capture on {(char)(97+whiteY)}{8-whiteX}.");
                        return;
                    }
                    else if (IsValidCell(whiteX - 1, whiteY + 1, chessBoard) && chessBoard[whiteX - 1, whiteY + 1] == 'b')
                    {
                        whiteX--;
                        whiteY++;
                        Console.WriteLine($"Game over! White capture on {(char)(97+whiteY)}{8 - whiteX}.");
                        return;
                    }

                    whiteX--;
                    chessBoard[whiteX, whiteY] = 'w';
                }
                else
                {
                    if(blackX == 7)
                    {
                        Console.WriteLine($"Game over! Black pawn is promoted to a queen at {(char)(97+blackY)}1.");
                        return;
                    }
                    
                    if (IsValidCell(blackX + 1, blackY - 1, chessBoard) && chessBoard[blackX + 1, blackY - 1] == 'w')
                    {
                        blackX++;
                        blackY--;
                        Console.WriteLine($"Game over! Black capture on {(char)(97 + blackY)}{8 - blackX}.");
                        return;
                    }
                    else if (IsValidCell(blackX + 1, blackY + 1, chessBoard) && chessBoard[blackX + 1, blackY + 1] == 'w')
                    {
                        blackX++;
                        blackY++;
                        Console.WriteLine($"Game over! Black capture on {(char)(97 + blackY)}{8 - blackX}.");
                        return;
                    }

                    blackX++;
                    chessBoard[blackX, blackY] = 'b';
                }

                whiteTurn = !whiteTurn;
            }
        }

        public static bool IsValidCell(int row, int col, char[,] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
