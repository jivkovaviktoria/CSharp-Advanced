using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace StackSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> nums = new Stack<int>(input);

            string command = Console.ReadLine();
            while (command.ToLower()!="end")
            {
                string[] tokens = command.Split();
                string type = tokens[0];
                
                if(type.ToLower() == "add")
                {
                    nums.Push(int.Parse(tokens[1]));
                    nums.Push(int.Parse(tokens[2]));
                }
                else if(type.ToLower() == "remove" && nums.Count >= int.Parse(tokens[1]))
                {
                    for (int i = 0; i < int.Parse(tokens[1]); i++)
                        nums.Pop();
                }
                command = Console.ReadLine();
            }

            int sum = 0;

            for (int i = 0; i < nums.Count; )
                sum += nums.Pop();

            Console.WriteLine($"Sum: {sum}");
        }
    }
}