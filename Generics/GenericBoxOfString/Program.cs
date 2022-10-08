using System;

namespace GenericBoxOfString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for(int i = 0; i < n; i++)
            {
                Box<string> strings = new Box<string>();
                strings.value = Console.ReadLine();

                Console.WriteLine(strings.ToString());
            }
        }
    }
}
