using System;
using System.Collections.Generic;
using System.Linq;

namespace Scheduling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var tasks = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse).ToArray());
            var threads = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());

            int task = int.Parse(Console.ReadLine());
            bool isFound = false;
            int threadValue = 0;
            while (threads.Count > 0 && !isFound)
            {
                var currentTask = tasks.Peek();
                var currentThread = threads.Peek();

                if (currentTask == task)
                {
                    isFound = true;
                    threadValue = currentThread;
                    break;
                }
                if (currentThread >= currentTask)
                {
                    tasks.Pop();
                    threads.Dequeue();
                }
                else
                {
                    threads.Dequeue();
                }
            }

            if (isFound)
            {
                Console.WriteLine($"Thread with value {threadValue} killed task {task}");
                Console.WriteLine(String.Join(" ", threads));
            }

        }
    }
}
