using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                var name = tokens[0];
                var age = int.Parse(tokens[1]);

                var person = new Person(name, age);
                people.Add(person);
            }

            foreach (var person in people.Where(x => x.Age > 30).OrderBy(x => x.Name))
                Console.WriteLine($"{person.Name} - {person.Age}");
            
        }
    }
}
