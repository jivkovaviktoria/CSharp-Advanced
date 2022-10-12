using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetRacing
{
    internal class Race
    {
        public Race(string name, string type, int laps, int capacity, int maxhp)
        {
            Participants = new List<Car>();
            Name = name;
            Type = type;
            Laps = laps;
            Capacity = capacity;
            MaxHorsePower = maxhp;
        }
        public List<Car> Participants { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Laps { get; set; }
        public int Capacity { get; set; }
        public int MaxHorsePower { get; set; }
        public int Count => Participants.Count;

        public void Add(Car car)
        {
            var sameCar = Participants.Find(x => x.LicensePlate == car.LicensePlate);
            if(sameCar == null && Participants.Count < Capacity && car.HorsePower <= MaxHorsePower)
            {
                Participants.Add(car);
            }
        }

        public bool Remove(string licensePlate)
        {
            var car = Participants.Find(x => x.LicensePlate == licensePlate);
            if (car != null)
            {
                Participants.Remove(car);
                return true;
            }

            return false;
        }

        public Car FindParticipant(string licensePlate) => Participants.Find(x => x.LicensePlate == licensePlate);

        public Car GetMostPowerfulCar() => Participants.OrderByDescending(x => x.HorsePower).FirstOrDefault();
        
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Race: {Name} - Type: {Type} (Laps: {Laps})");
            foreach (var car in Participants)
                sb.AppendLine(car.ToString());

            return sb.ToString().TrimEnd();
        }

    }
}
