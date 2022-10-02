using System;
using System.Linq;

namespace PredicateForNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var maxLength = int.Parse(Console.ReadLine());
            var names = Console.ReadLine().Split();

            Predicate<string> isValid = x => x.Length <= maxLength;

            Console.WriteLine(string.Join(Environment.NewLine, names.Where(x => isValid(x))));
        }
    }
}