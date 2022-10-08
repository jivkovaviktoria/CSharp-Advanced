using System;
using System.Collections.Generic;
using System.Linq;

namespace TheFightForGondor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int wavesCount = int.Parse(Console.ReadLine());
            LinkedList<int> plates = new LinkedList<int>();
            Stack<int> orks = new Stack<int>();

            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            foreach (var x in input) plates.AddLast(x);

            int wave = 0;
            for (int i = 0; i < wavesCount; i++)
            {
                if (plates.Count == 0) break;
                input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                orks = new Stack<int>(input);

                wave++;
                if (wave == 3)
                {
                    plates.AddLast(int.Parse(Console.ReadLine()));
                    wave = 0;
                }

                while (orks.Count > 0 && plates.Count > 0)
                {
                    var ork = orks.Peek();
                    var plate = plates.ElementAt(0);

                    if (ork == plate)
                    {
                        orks.Pop();
                        plates.RemoveFirst();
                    }
                    else if (ork > plate)
                    {
                        plates.RemoveFirst();
                        ork -= plate;
                        orks.Pop();
                        orks.Push(ork);
                    }
                    else if (plate > ork)
                    {
                        orks.Pop();
                        plates.RemoveFirst();

                        plate -= ork;
                        plates.AddFirst(plate);
                    }
                }
            }


            if (plates.Count == 0)
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
            else Console.WriteLine("The people successfully repulsed the orc's attack.");

            if (orks.Count > 0) Console.WriteLine($"Orcs left: {string.Join(", ", orks)}");

            if (plates.Count > 0) Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
        }
    }

}
