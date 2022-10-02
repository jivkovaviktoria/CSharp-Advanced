using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOfPredicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var num = int.Parse(Console.ReadLine());
            var dividers = Console.ReadLine().Split().Select(x => int.Parse(x)).ToList();

            Stack<int> result = new Stack<int>();

            Action<Stack<int>> print = x => Console.WriteLine(string.Join(" ", x.Reverse()));

            for (int i = 1; i <= num; i++)
            {
                Predicate<int> isDivisible = x => i % x == 0;

                result.Push(i);

                for (int j = 0; j < dividers.Count; j++)
                {
                    if (!isDivisible(dividers[j]))
                    {
                        result.Pop();
                        break;
                    }
                }
            }

            print(result);
        }
    }
}