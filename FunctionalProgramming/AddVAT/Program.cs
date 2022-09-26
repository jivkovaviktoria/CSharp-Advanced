using System;
using System.Collections.Generic;
using System.Linq;

namespace AddVAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] prices = Console.ReadLine().Split(", ").Select(double.Parse).ToArray();
            var pricesWithVat = prices.AddVatToAll();

            foreach (var price in pricesWithVat)
                Console.WriteLine($"{price:f2}");
        }
    }

    public static class ExtensionMethods
    {
        public static IEnumerable<double> AddVatToAll(this IEnumerable<double> prices)
        {
            //Returns a collection where vat is added to all of the prices.

            var result = new List<double>();

            foreach (var price in prices)
                result.Add(price + price*0.20);

            return result;
        }
    }
}
