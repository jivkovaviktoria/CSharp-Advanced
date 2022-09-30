using System;
using System.Collections.Generic;
using System.Linq;

namespace BakeryShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var water = new Queue<double>(Console.ReadLine().Split().Select(double.Parse).ToList());
            var flour = new Stack<double>(Console.ReadLine().Split().Select(double.Parse).ToList());

            Dictionary<string, int> productsCount = new Dictionary<string, int>()
            {
                {"Croissant", 0 },
                {"Muffin", 0 },
                {"Baguette", 0 },
                {"Bagel", 0 }
            };

            while (water.Any() && flour.Any())
            {
                var currentWater = water.Peek();
                var currentFlour = flour.Peek();

                var ratio = CalculatePercentage(currentWater, currentFlour);

                if (ratio[0] == ratio[1])
                {
                    productsCount["Croissant"]++;
                    water.Dequeue();
                    flour.Pop();
                }
                else if(ratio[0] == 40 && ratio[1] == 60)
                {
                    productsCount["Muffin"]++;
                    water.Dequeue();
                    flour.Pop();
                }
                else if (ratio[0] == 30 && ratio[1] == 70)
                {
                    productsCount["Baguette"]++;
                    water.Dequeue();
                    flour.Pop();
                }
                else if (ratio[0] == 20 && ratio[1] == 80)
                {
                    productsCount["Bagel"]++;
                    water.Dequeue();
                    flour.Pop();
                }
                else
                {
                    var flourLeft = currentFlour - currentWater;

                    currentFlour -= currentFlour - currentWater;
                    
                    productsCount["Croissant"]++;
                    water.Dequeue();
                    flour.Pop();

                    flour.Push(flourLeft);
                }
            }

            foreach(var (product, amount) in productsCount.Where(x => x.Value != 0).OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                Console.WriteLine($"{product}: {amount}");

            if (water.Any()) Console.WriteLine($"Water left: {string.Join(", ", water)}");
            else Console.WriteLine($"Water left: None");

            if(flour.Any()) Console.WriteLine($"Flour left: {string.Join(", ", flour)}");
            else Console.WriteLine($"Flour left: None");
        }

        static double[] CalculatePercentage(double water, double flour)
        {
            double[] result = new double[2];

            double total = flour + water;

            result[0] = (water / total) * 100;
            result[1] = (flour / total) * 100;

            return result;
        }
    }

    
}