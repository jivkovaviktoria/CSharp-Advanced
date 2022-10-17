using System;
using System.Collections.Generic;
using System.Linq;

namespace Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var bombEffects = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse).ToArray().Reverse());
            var bombCasing = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse).ToArray());

            Dictionary<int, string> bombs = new Dictionary<int, string>()
            {
                {40, "Datura Bombs" },
                {60, "Cherry Bombs" },
                {120, "Smoke Decoy Bombs" }
            };
            Dictionary<string, int> bombsCreated = new Dictionary<string, int>()
            {
                {"Datura Bombs", 0 },
                {"Cherry Bombs", 0 },
                {"Smoke Decoy Bombs", 0 }
            };

            bool hasAll = false;
            while (bombEffects.Count > 0 && bombCasing.Count > 0 && !hasAll)
            {
                var currentEffect = bombEffects.Peek();
                var currentCasing = bombCasing.Pop();
                var sum = currentEffect + currentCasing;

                if (bombs.ContainsKey(sum))
                {
                    bombsCreated[bombs[sum]]++;
                    bombEffects.Pop();
                }
                else
                {
                    currentCasing -= 5;
                    bombCasing.Push(currentCasing);
                }

                hasAll = true;
                foreach(var x in bombsCreated)
                {
                    if (x.Value < 3) hasAll = false;
                }
            }

            if(!hasAll)
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            else Console.WriteLine("Bene! You have successfully filled the bomb pouch!");

            if(bombEffects.Count == 0)
                Console.WriteLine("Bomb Effects: empty");
            else Console.WriteLine($"Bomb Effects: {string.Join(", ", bombEffects)}");

            if (bombCasing.Count == 0)
                Console.WriteLine("Bomb Casings: empty");
            else Console.WriteLine($"Bomb Casings: {string.Join(", ", bombCasing)}");

            foreach (var x in bombsCreated.OrderBy(x => x.Key)) Console.WriteLine($"{x.Key}: {x.Value}");
            
        }
    }
}
