using System;
using System.Collections.Generic;
using System.Linq;

namespace LootBox
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var firstLootbox = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToList());
            var secondLootbox = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToList());

            int sum = 0;

            while (firstLootbox.Any() && secondLootbox.Any())
            {
                var currentFirst = firstLootbox.Peek();
                var currentSecond = secondLootbox.Peek();
                var total = currentFirst + currentSecond;

                if(total % 2 == 0)
                {
                    firstLootbox.Dequeue();
                    secondLootbox.Pop();
                    sum += total;
                }
                else
                {
                    secondLootbox.Pop();
                    firstLootbox.Enqueue(currentSecond);
                }
            }

            if (firstLootbox.Count == 0) Console.WriteLine("First lootbox is empty");
            if (secondLootbox.Count == 0) Console.WriteLine("Second lootbox is empty");

            if(sum > 100)
                Console.WriteLine($"Your loot was epic! Value: {sum}");
            else Console.WriteLine($"Your loot was poor... Value: {sum}");
        }
    }
}