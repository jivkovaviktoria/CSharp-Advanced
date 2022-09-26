using System;
using System.Collections.Generic;

namespace CountUppercaseWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Console.WriteLine(string.Join(Environment.NewLine, input.PrintAllWithCapitalFirstLetter()));
        }
    }

    public static class ExtensionMethods
    {
        public static bool IsCapitalFirstLetter(this string word)
        {
            //Returns true if the first letter of the word is capital.

            var firstLetter = word[0];
            for (char i = 'A'; i <= 'Z'; i++)
            {
                if (firstLetter == i)
                    return true;
            }

            return false;
        }

        public static IEnumerable<string> PrintAllWithCapitalFirstLetter(this string input)
        {
            //Returs a collection only with the words (from the input) which starts with capital letter.

            IEnumerable<string> collection = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            List<string> result = new List<string>();

            foreach (var word in collection)
            {
                var firstLetter = word[0];
                for (char i = 'A'; i <= 'Z'; i++)
                {
                    if (firstLetter == i && word.Length > 0)
                        result.Add(word);
                }
            }

            return result;
        }
    }
}
