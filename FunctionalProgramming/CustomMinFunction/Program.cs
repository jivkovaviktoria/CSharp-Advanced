using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomMinFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Func<List<int>, int> GetMinNumber = nums => nums.Min();

            var numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            Console.WriteLine(GetMinNumber(numbers));
        }
    }
}