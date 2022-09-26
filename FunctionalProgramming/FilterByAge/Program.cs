using System;
using System.Collections.Generic;
using System.Linq;

namespace FilterByAge
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(", ");
                var name = tokens[0];
                var age = int.Parse(tokens[1]);
                people.Add(new Person(name, age));
            }

            string condition = Console.ReadLine();
            int ageFilter = int.Parse(Console.ReadLine());
            string[] filterForPrint = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            people = people.FilterByAge(condition, ageFilter).ToList();
            people.PrintByCondition(filterForPrint);
        }
    }
    public static class ExtensionMethods
    {
        public static IEnumerable<Person> FilterByAge(this IEnumerable<Person> people, string condition, int ageFilter)
        {
            //Filters the collection by the given condition.

            Func<Person, int, bool> filter;

            if (condition == "younger")
            {
                //We set the filter to filter the people by age (person's age < given age /younger/).
                filter = (person, givenAge) => person.Age < givenAge;

                //Filter the collection.
                people = people.Where(x => filter(x, ageFilter)).ToList();
            }
            else if (condition == "older")
            {
                //We set the filter to filter the people by age (person's age >= given age /older/).
                filter = (person, givenAge) => person.Age >= givenAge;

                //Filter the collection.
                people = people.Where(p => filter(p, ageFilter)).ToList();
            }

            return people;
        }

        public static void PrintByCondition(this IEnumerable<Person> people, string[] filter)
        {
            //Prints all people by condition /only name, only age or name and age.

            foreach (var person in people)
            {
                List<string> result = new List<string>();

                if (filter.Contains("name"))
                    result.Add(person.Name);

                if (filter.Contains("age"))
                    result.Add(person.Age.ToString());


                Console.WriteLine(string.Join(" - ", result));
            }
        }
    }

    public class Person
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
