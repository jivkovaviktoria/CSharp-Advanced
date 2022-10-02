using System;
using System.Collections.Generic;
using System.Linq;

namespace ReverseAndExclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            int divisor = int.Parse(Console.ReadLine());
            numbers.Reverse();

            bool IsDivisor(int x)
            {
                if (x % divisor != 0) return true;
                else return false;
            }

            var predicate = new Predicate<int>(IsDivisor);
            var result = new List<int>();

            foreach (var num in numbers)
            {
                var isDivisor = predicate(num);
                if (isDivisor) result.Add(num);
            }
            Console.WriteLine(String.Join(" ", result));
        }

       
    }
}