using System;
using System.Linq;

namespace SumNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            Console.WriteLine(numbers.CountNumbers());
            Console.WriteLine(numbers.SumNumbers());
        }
    }
    public static class Methods
    {
        public static int SumNumbers(this int[] collection)
        {
            //Returns the sum of the numbers in the collection.

            var result = 0;

            foreach (var item in collection)
                result += item;

            return result;
        }

        public static int CountNumbers(this int[] collection)
        {
            //Returns the count of the numbers in the collection.

            var result = 0;

            foreach (var item in collection)
                result++;

            return result;
        }
    }
}
