using System;

namespace StackQueue
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            // var coffee = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse).ToArray());
            // var energyDrinks = new Queue<int>(Console.ReadLine().Split(", ").Select(int.Parse).ToArray());
            //
            // int max = 300;
            // int total = 0;
            // while (coffee.Count > 0 && energyDrinks.Count > 0)
            // {
            //     int currentCoffee = coffee.Pop();
            //     int currentDrink = energyDrinks.Dequeue();
            //
            //     var drink = currentCoffee * currentDrink;
            //     if (drink <= max)
            //     {
            //         total += drink;
            //         max -= drink;
            //     }
            //     else
            //     {
            //      energyDrinks.Enqueue(currentDrink);
            //      if (total - 30 < 0)
            //      {
            //          max += total;
            //          total = 0;
            //      }
            //      else
            //      {
            //          total -= 30;
            //          max += 30;
            //      }
            //     }
            // }
            //
            // if(energyDrinks.Count > 0) Console.WriteLine($"Drinks left: {string.Join(", ", energyDrinks)}");
            // else Console.WriteLine("At least Stamat wasn't exceeding the maximum caffeine.");
            //
            // Console.WriteLine($"Stamat is going to sleep with {total} mg caffeine.");

        }
    }
}