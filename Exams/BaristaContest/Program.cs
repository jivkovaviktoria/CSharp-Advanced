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
            Dictionary<int, string> beverageSetup = new Dictionary<int, string>();
            beverageSetup[50] = "Cortado";
            beverageSetup[75] = "Espresso";
            beverageSetup[100] = "Capuccino";
            beverageSetup[150] = "Americano";
            beverageSetup[200] = "Latte";


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

                var currentSum = currentCoffee + currentMilk;
                if (beverageSetup.ContainsKey(currentSum))
                {
                    string beverageName = beverageSetup[currentSum];
                    if (!drinks.ContainsKey(beverageName)) drinks.Add(beverageName, 1);
                    else drinks[beverageName]++;
                }
                else milk.Push(currentMilk - 5);
            }

            if (coffee.Count == 0 && milk.Count == 0)
                Console.WriteLine("Nina is going to win! She used all the coffee and milk!");
            else
                Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");

            if (coffee.Count > 0) Console.WriteLine($"Coffee left: {string.Join(", ", coffee)}");
            else Console.WriteLine("Coffee left: none");

            if (milk.Count > 0) Console.WriteLine($"Milk left: {string.Join(", ", milk)}");
            else Console.WriteLine("Milk left: none");

            var ordered = drinks.OrderBy(x => x.Value).ThenByDescending(x => x.Key);
            foreach (var drink in ordered) Console.WriteLine($"{drink.Key}: {drink.Value}");
        }
    }
}