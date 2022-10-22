using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerArchitecture
{
    using System.Linq;

    public class Computer
    {
        public Computer(string model, int capacity)
        {
            this.Multiprocessor = new List<CPU>();
            this.Model = model;
            this.Capacity = capacity;
        }

        public List<CPU> Multiprocessor { get; set; }
        public string Model { get; set; }
        public int Capacity { get; set; }

        public int Count => this.Multiprocessor.Count;

        public void Add(CPU cpu)
        {
            if(this.Count < this.Capacity) this.Multiprocessor.Add(cpu);
        }

        public bool Remove(string brand)
        {
            var cpu = this.Multiprocessor.Find(x => x.Brand == brand);
            if (cpu == null) return false;

            this.Multiprocessor.Remove(cpu);
            return true;
        }

        public CPU MostPowerful()
        {
            return this.Multiprocessor.OrderByDescending(x => x.Frequency).FirstOrDefault();
        }

        public CPU GetCPU(string brand) => this.Multiprocessor.Find(x => x.Brand == brand);

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"CPUs in the Computer {this.Model}:");
            foreach (var cpu in this.Multiprocessor) sb.AppendLine(cpu.ToString());

            return sb.ToString().TrimEnd();
        }
    }
}