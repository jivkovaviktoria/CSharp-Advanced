using System;
using System.Collections.Generic;

namespace GenericCountMethodStrings
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> strings = new List<string>();

            for (int i = 0; i < n; i++) strings.Add(Console.ReadLine());

            string element = Console.ReadLine();
            Console.WriteLine(GetCount(strings, element));
        }

        public static int GetCount<T>(List<T> collection, T element) where T : IComparable<T>
        {
            int count = 0;
            foreach(var x in collection)
            {
                if (x.CompareTo(element) > 0)
                    count++;
            }

            return count;
        }
    }
}
