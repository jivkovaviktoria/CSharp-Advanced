using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakeMoves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = size[0];
            int cols = size[1];

            char[,] isle = new char[rows, cols];

            Queue<char> snake = new Queue<char>();
            string x = Console.ReadLine();
            for (int i = 0; i < x.Length; i++) snake.Enqueue(x[i]);

            MoveSnake(isle, snake);
            PrintIsle(isle);
        }

        private static void MoveSnake(char[,] isle, Queue<char> snake)
        {
            var rows = isle.GetLength(0);
            var cols = isle.GetLength(1);

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (row % 2 == 0)
                        isle[row, col] = snake.Peek();
                    else
                        isle[row, cols - col - 1] = snake.Peek();

                    snake.Enqueue(snake.Dequeue());
                }
            }
        }

        private static void PrintIsle(char[,] isle)
        {
            var rows = isle.GetLength(0);
            var cols = isle.GetLength(1);

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++) Console.Write(isle[row, col]);
                Console.WriteLine();
            }
        }
    }
}