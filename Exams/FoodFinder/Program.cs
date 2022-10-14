using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var vowels = new Queue<char>(Console.ReadLine().Split().Select(char.Parse).ToArray());
            var consonants = new Stack<char>(Console.ReadLine().Split().Select(char.Parse).ToArray());

            var wordsCount = new Dictionary<string, int>()
            {
                { "pear", 0 },
                {"flour", 0 },
                {"pork", 0 },
                {"olive", 0 }
            };
            var wordsChars = new Dictionary<string, List<char>>()
            {
                {"pear", new List<char> { 'p', 'e', 'a', 'r'} },
                {"flour", new List<char>{'f', 'l', 'o', 'u', 'r'} },
                {"pork", new List<char>{'p', 'o', 'r', 'k'} },
                {"olive", new List<char>{'o', 'l', 'i', 'v', 'e'} }
            };

            while (vowels.Count > 0 && consonants.Count > 0)
            {
                var curV = vowels.Dequeue();
                var curC = consonants.Pop();

                foreach (var word in wordsChars)
                {
                    if (word.Value.Contains(curV))
                        word.Value.Remove(curV);
                    if (word.Value.Contains(curC))
                        word.Value.Remove(curC);

                    if (word.Value.Count == 0)
                    {
                        wordsCount[word.Key]++;

                        foreach (var x in word.Key)
                            word.Value.Add(x);
                    }
                }

                vowels.Enqueue(curV);
            }

            int found = wordsCount.Where(x => x.Value > 0).Count();

            Console.WriteLine($"Words found: {found}");
            foreach (var word in wordsCount.Where(x => x.Value > 0))
                Console.WriteLine(word.Key);
        }
    }
}
