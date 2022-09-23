using System;
using System.Collections.Generic;

namespace UniqueUsernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> uniqueUsernames = new HashSet<string>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                var username = Console.ReadLine();
                uniqueUsernames.Add(username);
            }

            foreach (var user in uniqueUsernames) Console.WriteLine(user);
        }
    }
}