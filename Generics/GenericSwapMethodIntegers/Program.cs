using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<int> inputs = new List<int>();

            for (int i = 0; i < n; i++)
            {
                var input = int.Parse(Console.ReadLine());
                inputs.Add(input);
            }

            int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Swap(inputs, indexes);

            foreach (var item in inputs)
                Console.WriteLine($"{item.GetType()}: {item}");
        }

        public static void Swap<T>(List<T> collection, int[] indexes)
        {
            var index1 = indexes[0];
            var index2 = indexes[1];

            (collection[index1], collection[index2]) = (collection[index2], collection[index1]);
        }
    }
}
