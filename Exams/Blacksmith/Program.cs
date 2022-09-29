using System;
using System.Collections.Generic;
using System.Linq;

namespace Blacksmith
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var steel = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToList());
            var carbon = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToList());

            var swords = new Dictionary<int, string>()
            {
                {70, "Gladius" },
                {80, "Shamshir" },
                {90, "Katana" },
                {110, "Sabre" },
                {150, "Broadsword" }
            };

            var swordsCount = new Dictionary<string, int>();
            int allSwordsCount = 0;

            while (steel.Count > 0 && carbon.Count > 0)
            {
                var currentSteel = steel.Dequeue();
                var currentCarbon = carbon.Pop();

                var sum = currentSteel + currentCarbon;

                if (swords.ContainsKey(sum))
                {
                    var key = swords[sum];
                    if (!swordsCount.ContainsKey(key))
                        swordsCount.Add(key, 0);

                    swordsCount[key]++;
                    allSwordsCount++;
                }
                else
                {
                    currentCarbon += 5;
                    carbon.Push(currentCarbon);
                }
            }

            if(allSwordsCount > 0)
                Console.WriteLine($"You have forged {allSwordsCount} swords.");
            else 
                Console.WriteLine("You did not have enough resources to forge a sword.");

            if(steel.Count > 0) 
                Console.WriteLine($"Steel left: {string.Join(", ", steel)}");
            else
                Console.WriteLine("Steel left: none");

            if(carbon.Count > 0)
                Console.WriteLine($"Carbon left: {string.Join(", ", carbon)}");
            else
                Console.WriteLine("Carbon left: none");

            foreach (var (sword, count) in swordsCount.OrderBy(x => x.Key))
                Console.WriteLine($"{sword}: {count}");
            
        }
    }
}