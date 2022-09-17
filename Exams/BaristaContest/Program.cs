using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BaristaContest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] coffeeArray = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            Array.Reverse(coffeeArray);
            Stack<int> coffee = new Stack<int>(coffeeArray);

            int[] milkArray = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            Stack<int> milk = new Stack<int>(milkArray);

            Dictionary<string, int> drinks = new Dictionary<string, int>();

            while(coffee.Count > 0 && milk.Count > 0)
            { 
                var currentCoffee = coffee.Pop();
                var currentMilk = milk.Pop();

                if (currentCoffee + currentMilk == 50)
                {
                    if (!drinks.ContainsKey("Cortado")) drinks.Add("Cortado", 1);
                    else drinks["Cortado"]++;
                }
                else if (currentCoffee + currentMilk == 75)
                {
                    if (!drinks.ContainsKey("Espresso")) drinks.Add("Espresso", 1);
                    else drinks["Espresso"]++;
                }
                else if (currentCoffee + currentMilk == 100)
                {
                    if (!drinks.ContainsKey("Capuccino")) drinks.Add("Capuccino", 1);
                    else drinks["Capuccino"]++;
                }
                else if (currentCoffee + currentMilk == 150)
                {
                    if (!drinks.ContainsKey("Americano")) drinks.Add("Americano", 1);
                    else drinks["Americano"]++;
                }
                else if (currentCoffee + currentMilk == 200)
                {
                    if (!drinks.ContainsKey("Latte")) drinks.Add("Latte", 1);
                    else drinks["Latte"]++;
                }
                else milk.Push(currentMilk - 5);
            }

            if (coffee.Count == 0 && milk.Count == 0)
            {
                Console.WriteLine("Nina is going to win! She used all the coffee and milk!");
                Console.WriteLine("Coffee left: none");
                Console.WriteLine("Milk left: none");
            }
            else
            {
                Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");
                if (coffee.Count > 0) Console.WriteLine($"Coffee left: {string.Join(", ", coffee)}");
                else Console.WriteLine("Coffee left: none");

                if (milk.Count > 0) Console.WriteLine($"Milk left: {string.Join(", ", milk)}");
                else Console.WriteLine("Milk left: none");
            }

            foreach (var drink in drinks.OrderBy(x => x.Value).ThenByDescending(x => x.Key))
                Console.WriteLine($"{drink.Key}: {drink.Value}");
            
        }
    }
}