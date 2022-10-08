using System;
using System.Collections.Generic;
using System.Linq;

namespace Cooking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> food = new Dictionary<int, string>()
            {
                {25, "Bread" },
                {50, "Cake" },
                {75, "Pastry" },
                {100, "Fruit Pie" }
            };
            var cookedFood = new Dictionary<string, int>()
            {
                {"Bread", 0 },
                {"Cake", 0 },
                {"Pastry", 0 },
                {"Fruit Pie", 0 }
            };

            var liquids = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            var ingredients = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

            while (liquids.Count > 0 && ingredients.Count > 0)
            {
                var currentLiquid = liquids.Dequeue();
                var currentIngredient = ingredients.Pop();

                var sum = currentIngredient + currentLiquid;

                if (food.ContainsKey(sum))
                    cookedFood[food[sum]]++;
                else
                {
                    currentIngredient += 3;
                    ingredients.Push(currentIngredient);
                }
            }
            bool isEnoughtFood = true;
            foreach (var (foodName, count) in cookedFood) if (count == 0) isEnoughtFood = false;

            if(isEnoughtFood)
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            else Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");


            if (liquids.Count > 0) Console.WriteLine($"Liquids left: {string.Join(", ", liquids)}");
            else Console.WriteLine("Liquids left: none");

            if (ingredients.Count > 0) Console.WriteLine($"Ingredients left: {string.Join(", ", ingredients)}");
            else Console.WriteLine("Ingredients left: none");


            foreach(var (foodType, amount) in cookedFood.OrderBy(x => x.Key))
                Console.WriteLine($"{foodType}: {amount}");
        }
    }
}
