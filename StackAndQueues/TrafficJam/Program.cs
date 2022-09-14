using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace HotPotato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();

            var cars = new Queue<string>();

            int passedCarsCount = 0;

            while (command!="end")
            {
                if (command != "green")
                    cars.Enqueue(command);
                else if(command == "green")
                {
                    for (int i = 0; i < count; i++)
                    {
                        if (cars.Count > 0)
                        {
                            Console.WriteLine($"{cars.Dequeue()} passed!");
                            passedCarsCount++;
                        }
                        else
                            break;
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"{passedCarsCount} cars passed the crossroads.");
        }
    }
}