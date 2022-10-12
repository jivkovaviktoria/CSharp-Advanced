using System;
using System.Collections.Generic;
using System.Linq;

namespace Garden
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] x = new int[] { -1, 1, 0, 0 };
            int[] y = new int[] { 0, 0, -1, 1 };

            int[] tokens = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = tokens[0];
            int m = tokens[1];

            int[,] garden = new int[n, m];
            FillGarden(garden);

            var flowers = new List<Tuple<int, int>>();
            var cmd = Console.ReadLine();
            while (cmd != "Bloom Bloom Plow")
            {
                var data = cmd.Split();
                var row = int.Parse(data[0]);
                var col = int.Parse(data[1]);

                if(row >= 0 && row < n && col >= 0 && col < m)
                    flowers.Add(Tuple.Create(row, col));
                else Console.WriteLine("Invalid coordinates.");

                
                cmd = Console.ReadLine();
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < m; col++)
                {
                    var coo = new Tuple<int, int>(row, col);
                    if(flowers.Contains(coo))
                    {
                        var up = row-1;
                        var down = row+1;
                        var left = col-1;
                        var right = col+1;
                        garden[row, col]++;
                        
                        while(up >= 0)
                        {
                            garden[up, col]++;
                            up--;
                        }
                        while(down < n)
                        {
                            garden[down, col]+=1;
                            down++;
                        }
                        while(left >= 0)
                        {
                            garden[row, left]+=1;
                            left--;
                        }
                        while(right < m)
                        {
                            garden[row, right]+=1;
                            right++;
                        }
                    }
                }
            }

            PrintGarden(garden);
        }

        private static void PrintGarden(int[,] garden)
        {
            for (int row = 0; row < garden.GetLength(0); row++)
            {
                for (int col = 0; col < garden.GetLength(1); col++)
                {
                    Console.Write(garden[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        private static void FillGarden(int[,] garden)
        {
            for (int row = 0; row < garden.GetLength(0); row++)
            {
                for (int col = 0; col < garden.GetLength(1); col++)
                {
                    garden[row, col] = 0;
                }
            }
        }
    }
}
