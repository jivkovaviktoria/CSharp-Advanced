using System;
using System.Collections.Generic;
using System.Linq;

namespace LargestThreeNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> integers = Console.ReadLine().Split().Select(int.Parse).OrderByDescending(x => x).ToList();
            for (int x = 0; x < integers.Count; x++)
            {
                if (x == 3) break;
                Console.Write($"{integers[x]} ");
            }

        }
    }
}