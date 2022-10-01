using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace WarmWinter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> hats = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToList());
            Queue<int> scarfs = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToList());

            List<int> setsPrices = new List<int>();

            while (hats.Any() && scarfs.Any())
            {
                var currentHat = hats.Peek();
                var currentScarf = scarfs.Peek();

                if(currentHat > currentScarf)
                {
                    setsPrices.Add(currentHat+currentScarf);
                    hats.Pop();
                    scarfs.Dequeue();
                }
                else if(currentScarf > currentHat)
                {
                    hats.Pop();
                }
                else
                {
                    scarfs.Dequeue();

                    currentHat = hats.Pop();
                    currentHat++;
                    hats.Push(currentHat);
                }
            }

            Console.WriteLine($"The most expensive set is: {setsPrices.OrderByDescending(x=>x).FirstOrDefault()}");
            Console.WriteLine(String.Join(" ", setsPrices));
        }
    }
}