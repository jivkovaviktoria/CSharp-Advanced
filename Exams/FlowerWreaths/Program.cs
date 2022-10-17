using System;
using System.Collections.Generic;
using System.Linq;

namespace FlowerWreaths
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var lilies = new Stack<int>(Console.ReadLine().Split(',').Select(int.Parse).ToArray());
            var roses = new Stack<int>(Console.ReadLine().Split(',').Select(int.Parse).ToArray().Reverse());

            int storedFlowers = 0, wreaths = 0;
            while (lilies.Count > 0 && roses.Count > 0)
            {
                var currentLilie = lilies.Pop();
                var currentRose = roses.Peek();
                var sum = currentLilie + currentRose;

                if (sum == 15)
                {
                    wreaths++;
                    roses.Pop();
                }
                else if (sum > 15)
                {
                    currentLilie -= 2;
                    lilies.Push(currentLilie);
                }
                else
                {
                    storedFlowers += sum;
                    roses.Pop();
                }
            }

            if(storedFlowers > 15) wreaths += storedFlowers / 15;
            
            if(wreaths >= 5)
                Console.WriteLine($"You made it, you are going to the competition with {wreaths} wreaths!");
            else Console.WriteLine($"You didn't make it, you need {5-wreaths} wreaths more!");
        }
    }
}
