using System;
using System.Collections.Generic;
using System.Linq;

namespace SetsOfElements
{
    internal class Program
    {
        public static object HashSet { get; private set; }

        static void Main(string[] args)
        {
            int[] lengths = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var firstSetLength = lengths[0];
            var secondSetLength = lengths[1];

            HashSet<int> first = new HashSet<int>();
            HashSet<int> second = new HashSet<int>();

            for (int i = 0; i < firstSetLength; i++) first.Add(int.Parse(Console.ReadLine()));

            for (int i = 0; i < secondSetLength; i++) second.Add(int.Parse(Console.ReadLine()));

            first.IntersectWith(second);
            Console.WriteLine(String.Join(" ", first));
        }
    }
}