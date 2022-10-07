using System;
using System.Collections.Generic;

namespace RawData
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var data = Console.ReadLine().Split();
                var model = data[0];

                var engineSpeed = int.Parse(data[1]);
                var enginePower = int.Parse(data[2]);

                var cargoWeight = double.Parse(data[3]);
                var cargoType = data[4];

                for (int j = 0; j < 4; j++)
                {

                }
            }
        }
    }
}
