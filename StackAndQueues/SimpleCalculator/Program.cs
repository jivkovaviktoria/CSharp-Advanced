﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>();

            string name = Console.ReadLine();
            while(name!="End")
            {
                if (name != "Paid")
                    queue.Enqueue(name);
                else
                {
                    Console.WriteLine(string.Join(Environment.NewLine, queue));
                    queue.Clear();
                }

                name = Console.ReadLine();
            }

            Console.WriteLine(queue.Count);
        }
    }
}