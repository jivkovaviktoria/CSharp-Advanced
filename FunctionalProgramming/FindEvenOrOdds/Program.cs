using System;
using System.Collections.Generic;
using System.Linq;

namespace FindEvenOrOdds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] range = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var cmd = Console.ReadLine();

            Console.WriteLine(String.Join(" ", range.GetEvenOrOdd(cmd)));
        }
    }

    public static class ExtensionMethods
    {
        public static List<int> GetEvenOrOdd(this int[] range, string cmd)
        {
            List<int> result = new List<int>();

            if(cmd == "even")
            {
                for (int i = range[0]; i <= range[1]; i++)
                {
                    if (i % 2 == 0) result.Add(i);
                }
            }
            else if(cmd == "odd")
            {
                for (int i = range[0]; i <= range[1]; i++)
                {
                    if (i % 2 != 0) result.Add(i);
                }
            }

            return result;

        }
    }
}