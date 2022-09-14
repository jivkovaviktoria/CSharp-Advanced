using System;
using System.Collections;
using System.Collections.Generic;

namespace MatchingBrackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var stack = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                    stack.Push(i);
                else if (input[i] == ')')
                    Console.WriteLine(input.Substring(stack.Peek(), i - stack.Pop() + 1));
            }
        }
    }
}