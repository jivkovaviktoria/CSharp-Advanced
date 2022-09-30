using System;
using System.Collections.Generic;
using System.Linq;

namespace ActionPoint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var collection = Console.ReadLine().Split().ToList();

            Action<List<string>> Print = x => Console.WriteLine(string.Join(Environment.NewLine, x));

            Print(collection);
        }
    }
}