using System;

namespace DefiningClasses
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            Family family = new Family();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                var name = tokens[0];
                var age = int.Parse(tokens[1]);

                Person person = new Person(name, age);
                family.AddMember(person);
            }

            Person oldestMember = family.GetOldestMember();
            Console.WriteLine(oldestMember.Name + " " + oldestMember.Age);
        }
    }
}
