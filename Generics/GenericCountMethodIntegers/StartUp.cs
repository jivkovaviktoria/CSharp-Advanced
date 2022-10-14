using System;
using System.Collections.Generic;

namespace GenericCountMethodIntegers
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<double> doubles = new List<double>();

            for (int i = 0; i < n; i++) doubles.Add(double.Parse(Console.ReadLine()));

            double element = double.Parse(Console.ReadLine());
            Console.WriteLine(GetCount(doubles, element));
        }

        public static int GetCount<T>(List<T> collection, T element) where T : IComparable<T>
        {
            int count = 0;
            foreach (var x in collection)
            {
                if (x.CompareTo(element) > 0)
                    count++;
            }

            return count;
        }
    }
}
