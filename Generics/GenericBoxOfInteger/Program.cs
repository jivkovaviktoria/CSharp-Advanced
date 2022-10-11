using System;

namespace GenericBoxOfInteger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Box<int> integers = new Box<int>();
                integers.value = int.Parse(Console.ReadLine());

                Console.WriteLine(integers.ToString());
            }
        }
    }
}
