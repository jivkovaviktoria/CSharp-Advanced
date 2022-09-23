using System;
using System.Collections.Generic;
using System.Linq;

namespace CountSymbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            Dictionary<char, int> symbolsCount = new Dictionary<char, int>();

            for (int i = 0; i < text.Length; i++)
            {
                var currentSymbol = text[i];

                if (!symbolsCount.ContainsKey(currentSymbol))
                    symbolsCount.Add(currentSymbol, 1);
                else symbolsCount[currentSymbol]++;

            }

            foreach (var symbol in symbolsCount.OrderBy(x => x.Key).ToDictionary(x => x.Key, y => y.Value))
                Console.WriteLine($"{symbol.Key}: {symbol.Value} time/s");
            
        }
    }
}