using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        private readonly ICollection<Fish> fish;
        
        public Net(string material, int capacity)
        {
            Material = material;
            Capacity = capacity;
        }
        public string Material { get; set; }
        public int Capacity { get; set; }

        public IReadOnlyCollection<Fish> Fish => (IReadOnlyCollection<Fish>)this.fish;
        public int Count => Fish.Count;

        public string AddFish(Fish fish)
        {
            if (this.Count < this.Capacity)
            {
                if (string.IsNullOrEmpty(fish.FishType) || fish.Weight <= 0 || fish.Length <= 0)
                {
                    return $"Invalid fish.";
                }
                else
                {
                    this.fish.Add(fish);
                    return $"Successfully added {fish.FishType} to the fishing net.";
                }
            }

            return $"Fishing net is full.";
        }

        public bool ReleaseFish(double weight)
        {
            var fish = this.fish.FirstOrDefault(x => x.Weight <= weight);
            if(fish != null)
            {
                this.fish.Remove(fish);
                return true;
            }

            return false;
        }

        public Fish GetFish(string fishType)
        {
            return this.Fish.FirstOrDefault(fish => fish.FishType == fishType);
        }

        public Fish GetBiggestFish()
        {
            return this.Fish.OrderByDescending(x => x.Length).FirstOrDefault();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Into the {this.Material}:");

            foreach (var item in Fish.OrderByDescending(x => x.Length))
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().TrimEnd();

        }
    }
}
