using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedRacing
{
    public class Car
    {
        public Car(string model, double fuelAmount, double fuelConsumption)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKilometer = fuelConsumption;
            this.TravelledDistance = 0;
        }

        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance { get; set; }

        
    }

    public static class Methods
    {
        public static void Drive(this Car car, double distance)
        {
            var fuelCost = distance * car.FuelConsumptionPerKilometer;
            if (car.FuelAmount >= fuelCost)
            {
                car.FuelAmount -= fuelCost;
                car.TravelledDistance += distance;
            }
            else Console.WriteLine("Insufficient fuel for the drive");
        }
    }

}
