using System;
using System.Collections.Generic;

namespace Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> clothesByColor = new Dictionary<string, Dictionary<string, int>>();

            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                string[] data = Console.ReadLine().Split(" -> ");
                var color = data[0];

                string[] clothes = data[1].Split(",");

                if (!clothesByColor.ContainsKey(color))
                    clothesByColor.Add(color, new Dictionary<string, int>());

                foreach (var item in clothes)
                {
                    if (!clothesByColor[color].ContainsKey(item))
                        clothesByColor[color].Add(item, 0);

                    clothesByColor[color][item]++;
                }
            }

            string[] tokens = Console.ReadLine().Split();
            string colorOfItem = tokens[0];
            string itemToFind = tokens[1];

            foreach (var item in clothesByColor)
            {
                Console.WriteLine($"{item.Key} clothes:");
                foreach (var cloth in item.Value)
                {
                    if (colorOfItem == item.Key && itemToFind == cloth.Key)
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value} (found!)");
                    else
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value}");

                }
            }
        }
    }
}