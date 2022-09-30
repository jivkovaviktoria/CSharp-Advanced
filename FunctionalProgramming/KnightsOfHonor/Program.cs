using System;
using System.Collections.Generic;
using System.Linq;

namespace KnightsOfHonor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine().Split().ToList();
            names.ForEach(x => Console.WriteLine($"Sir {x}"));
        }
    }
}