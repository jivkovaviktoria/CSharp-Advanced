using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;

namespace Drones
{
    public class Airfield
    {
        public Airfield(string name, int capacity, double landingStrip)
        {
            Name = name;
            Capacity = capacity;
            LandingStrip = landingStrip;

            Drones = new List<Drone>();
        }

        private readonly List<Drone> Drones = new List<Drone>();
        public List<Drone> drones => Drones;

        public string Name { get; set; }
        public int Capacity { get; set; }
        public double LandingStrip { get; set; }

        public int Count => this.Drones.Count;

        public string AddDrone(Drone drone)
        {
            if (string.IsNullOrWhiteSpace(drone.Name) || string.IsNullOrWhiteSpace(drone.Brand) || drone.Range < 5 || drone.Range > 15)
                return "Invalid drone.";
            else if (this.Drones.Count >= Capacity)
                return "Airfield is full.";
            else
                this.Drones.Add(drone);

            return $"Successfully added {drone.Name} to the airfield.";
        }

        public bool RemoveDrone(string name)
        {
            List<Drone> dronesToRemove = new List<Drone>();
            dronesToRemove = this.Drones.Where(x => x.Name == name).ToList();
            if (dronesToRemove.Count > 1)
                throw new InvalidOperationException("asdg");
            if (dronesToRemove.Count > 0)
            {
                foreach (var drone in dronesToRemove)
                    this.Drones.Remove(drone);

                return true;
            }

            return false;
        }

        public int RemoveDroneByBrand(string brand)
        {
            List<Drone> dronesToRemove = new List<Drone>();
            dronesToRemove = this.Drones.Where(x => x.Brand == brand).ToList();

            if (dronesToRemove.Count > 0)
            {
                foreach (var drone in dronesToRemove)
                    this.Drones.Remove(drone);

                return dronesToRemove.Count;
            }

            return 0;
        }

        public Drone FlyDrone(string name)
        {
            
            var dronesToFly = this.Drones.Where(x => x.Name == name).ToList();
            if (dronesToFly.Count > 1)
                throw new InvalidOperationException("asdg");
            if (dronesToFly.Count > 0)
            {
                foreach(var drone in dronesToFly)
                {
                    int index = this.Drones.IndexOf(drone);
                    this.Drones[index].Available = false;

                    return drone;
                }
            }

            return null;
        }

        public List<Drone> FlyDronesByRange(int range)
        {
            List<Drone> dronesToFly = this.Drones.Where(x => x.Range >= range).ToList();

            foreach(var drone in dronesToFly)
            {
                var x = this.Drones.IndexOf(drone);
                this.Drones[x].Available = false;
            }

            return dronesToFly;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Drones available at {this.Name}:");

            foreach (var drone in this.Drones.Where(x => x.Available != false))
                sb.AppendLine(drone.ToString());

            return sb.ToString().TrimEnd();
        }

    }
}
