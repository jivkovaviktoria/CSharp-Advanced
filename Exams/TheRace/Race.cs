using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        public Race(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            Data = new List<Racer>();
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<Racer> Data { get; set; }

        public List<Racer> data;
        public int Count => this.Data.Count;

        public void Add(Racer racer)
        {
            if (this.Data.Count != this.Capacity)
                this.Data.Add(racer);
        }

        public bool Remove(string name)
        {
            var racerToRemove = this.Data.Find(x => x.Name == name);
            if (racerToRemove != null)
            {
                this.Data.Remove(racerToRemove);
                return true;
            }

            return false;
        }

        public Racer GetOldestRacer() => this.Data.OrderByDescending(x => x.Age).FirstOrDefault();

        public Racer GetRacer(string name) => this.Data.Find(x => x.Name == name);

        public Racer GetFastestRacer() => this.Data.OrderByDescending(x => x.Car.Speed).FirstOrDefault();

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Racers participating at {this.Name}:");
            foreach (var racer in this.Data)
                sb.AppendLine(racer.ToString());

            return sb.ToString().TrimEnd();
        }
    }
}
