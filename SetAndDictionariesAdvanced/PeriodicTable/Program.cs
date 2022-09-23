using System;
using System.Collections.Generic;
using System.Linq;

namespace PeriodicTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> setOfElements = new HashSet<string>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] elements = Console.ReadLine().Split();
                foreach (var el in elements) setOfElements.Add(el);
            }

            Console.WriteLine(string.Join(" ", setOfElements.OrderBy(x => x).ToArray()));
        }
    }
}