using System;
using System.Collections.Generic;

namespace SpeedRacing
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            string[] data;
            for (int i = 0; i < n; i++)
            {
                data = Console.ReadLine().Split();

                var model = data[0];
                var fuelAmount = double.Parse(data[1]);
                var fuelConsumption = double.Parse(data[2]);

                cars.Add(new Car(model, fuelAmount, fuelConsumption));
            }

            var cmd = Console.ReadLine();
            while (cmd != "End")
            {
                data = cmd.Split();

                var carModel = data[1];
                var km = double.Parse(data[2]);

                var carToDrive = cars.Find(x => x.Model == carModel);
                carToDrive.Drive(km);

                cmd = Console.ReadLine();
            }

            foreach(var car in cars)
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
        }
    }
}
