using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayCelebration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //first - eating capacity ; first
            // second - plates ; last

            int wastedFood = 0;
            var guests = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray().Reverse());
            var plates = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());

            while (guests.Count > 0 && plates.Count > 0)
            {
                var currentGuest = guests.Pop();
                var currentPlate = plates.Pop();

                if(currentGuest > currentPlate)
                {
                    currentGuest -= currentPlate;
                    guests.Push(currentGuest);
                }
                else
                {
                    wastedFood += currentPlate - currentGuest;
                }
            }

            if(guests.Count > 0)
                Console.WriteLine($"Guests: {string.Join(" ", guests)}");
            else if(plates.Count > 0)
                Console.WriteLine($"Plates: {string.Join(" ", plates)}");

            Console.WriteLine($"Wasted grams of food: {wastedFood}");
        }
    }
}
