using System;
using System.Collections.Generic;
using System.Linq;

namespace CountSameValuesInArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<double, int> valuesCount = new Dictionary<double, int>();

            double[] values = Console.ReadLine().Split().Select(double.Parse).ToArray();

            foreach (var value in values)
            {
                if (!valuesCount.ContainsKey(value))
                    valuesCount.Add(value, 1);
                else
                    valuesCount[value]++;
            }

            foreach (var value in valuesCount)
                Console.WriteLine($"{value.Key} - {value.Value} times");
        }
    }
}