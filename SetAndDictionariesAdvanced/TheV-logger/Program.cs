using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Dictionary<string, SortedSet<string>> vloggersFollowers = new Dictionary<string, SortedSet<string>>();
        Dictionary<string, SortedSet<string>> vloggersFollowing = new Dictionary<string, SortedSet<string>>();

        string input;
        while ((input = Console.ReadLine()) != "Statistics")
        {
            string[] tokens = input.Split();
            string name = tokens[0];
            string cmd = tokens[1];
            string toFollow = tokens[2];

            if (cmd == "joined" && !vloggersFollowers.ContainsKey(name))
            {
                vloggersFollowers.Add(name, new SortedSet<string>());
                vloggersFollowing.Add(name, new SortedSet<string>());
            }
            else if (cmd == "followed" && vloggersFollowers.ContainsKey(name) && vloggersFollowing.ContainsKey(toFollow) && name != toFollow)
            {
                vloggersFollowers[name].Add(toFollow);
                vloggersFollowing[toFollow].Add(name);
            }
        }

        Console.WriteLine($"The V-Logger has a total of {vloggersFollowers.Count} vloggers in its logs.");

        int place = 1;
        foreach (var vlogger in vloggersFollowing.OrderByDescending(x => x.Value.Count).ThenBy(x => vloggersFollowers[x.Key].Count))
        {
            Console.WriteLine($"{place}. {vlogger.Key} : {vlogger.Value.Count} followers, {vloggersFollowers[vlogger.Key].Count} following");
            if (place == 1)
                Console.WriteLine(String.Join(Environment.NewLine, vlogger.Value.Select(x => $"*  {x}")));

            place++;
        }
    }
}