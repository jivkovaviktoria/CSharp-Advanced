using System;
using System.Collections.Generic;

namespace RecordUniqueNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            HashSet<string> uniqueNames = new HashSet<string>();

            for(int i = 0; i < count; i++)
                uniqueNames.Add(Console.ReadLine());

            foreach (var name in uniqueNames)
                Console.WriteLine(name);
        }
    }
}