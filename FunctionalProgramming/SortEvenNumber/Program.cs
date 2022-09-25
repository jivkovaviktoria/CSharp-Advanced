using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SortEvenNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] x = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            x = x.SortEven().ToArray();

            Console.WriteLine(string.Join(", ", x));
        }
    }

    public static class Methods
    {
        public static List<int> SortEven(this int[] collection)
        {
            var result = new List<int>();

            foreach(var item in collection)
            {
                if (item % 2 == 0)
                    result.Add(item);
            }

            result.Sort();
            return result;
        }
    }
}
