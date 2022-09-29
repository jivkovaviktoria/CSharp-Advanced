using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomMinFunction_exMethod_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            Console.WriteLine(numbers.GetMinNumber());
        }
    }

    public static class ExtensionMethods
    {
        public static int GetMinNumber(this List<int> numbers)
        {
            int result = int.MaxValue;
            for (int i = 0; i < numbers.Count(); i++)
            {
                if (numbers[i] < result) result = numbers[i];
            }

            return result;
        } 
    }
}