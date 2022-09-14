using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SimpleCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var operations = Console.ReadLine().Split().ToArray();
            var stack = new Stack<string>(operations.Reverse());

            int ans = int.Parse(stack.Pop());
            while (stack.Count > 0)
            {
                if (stack.Peek() == "+")
                {
                    stack.Pop();
                    ans += int.Parse(stack.Pop());
                }
                else if(stack.Peek() == "-")
                {
                    stack.Pop();
                    ans -= int.Parse(stack.Pop());
                }
            }

            Console.WriteLine(ans);
              
        }
    }
}