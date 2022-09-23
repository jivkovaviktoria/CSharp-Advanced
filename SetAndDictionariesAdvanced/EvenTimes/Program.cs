using System;
using System.Collections.Generic;

namespace EvenTimes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> numbersCount = new Dictionary<int, int>();

            int count = int.Parse(Console.ReadLine());

            for(int i = 0; i < count; i++)
            {
                var num = int.Parse(Console.ReadLine());
                if (!numbersCount.ContainsKey(num))
                    numbersCount.Add(num, 1);
                else
                    numbersCount[num]++;
            }

            foreach(var num in numbersCount)
            {
                if(num.Value%2==0)
                    Console.WriteLine(num.Key);
            }
        }
    }
}