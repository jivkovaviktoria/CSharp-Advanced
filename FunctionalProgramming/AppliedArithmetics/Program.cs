using System;
using System.Collections.Generic;
using System.Linq;

namespace AppliedArithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<List<int>, List<int>> Add = x => x.Select(a => a + 1).ToList();
            Func<List<int>, List<int>> Subtract = x => x.Select(a => a - 1).ToList();
            Func<List<int>, List<int>> Multiply = x => x.Select(a => a * 2).ToList();

            var numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            var cmd = Console.ReadLine();
            while (cmd != "end")
            {
                if (cmd == "add") numbers = Add(numbers);
                else if (cmd == "subtract") numbers = Subtract(numbers);
                else if (cmd == "multiply") numbers = Multiply(numbers);
                else if (cmd == "print") Print(numbers);

                cmd = Console.ReadLine();
            }
        }

        private static void Print(List<int> numbers)
        {
            Console.WriteLine(String.Join(" ", numbers));
        }
    }

}