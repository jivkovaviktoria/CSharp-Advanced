using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniExamResult
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var participants = new Dictionary<string, decimal>();
            var languages = new Dictionary<string, int>();

            var input = Console.ReadLine();
            while (input != "exam finished")
            {
                string[] tokens = input.Split("-", StringSplitOptions.RemoveEmptyEntries);

                //string username = "";
                //string language = "";
                //decimal points = 0;
                //string userToBan = "";
                string username = tokens[0];
                string language = tokens[1];

                if (language == "banned")
                    participants.Remove(username);
                else
                {
                    var points = decimal.Parse(tokens[2]);

                    if (participants.ContainsKey(username))
                    {
                        if (participants[username] < points)
                            participants[username] = points;
                    }
                    else participants.Add(username, points);


                    if (languages.ContainsKey(language))
                        languages[language]++;
                    else languages.Add(language, 1);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Results:");
            foreach (var (user, points) in participants.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                Console.WriteLine($"{user} | {points}");

            Console.WriteLine("Submissions:");
            foreach (var (language, submissions) in languages.Where(x => x.Value > 0).OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                Console.WriteLine($"{language} - {submissions}");
        }
    }

}