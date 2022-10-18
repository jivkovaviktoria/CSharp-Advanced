namespace SkiRental
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class SkiRental
    {
        public SkiRental(string name, int capacity)
        {
            this.data = new List<Ski>();
            this.Name = name;
            this.Capacity = capacity;
        }
        private readonly List<Ski> data;
        public string Name { get; set; }
        public int Capacity { get; set; }

        public int Count => this.data.Count;

        public void Add(Ski ski)
        {
            if(this.Count < this.Capacity) this.data.Add(ski);
        }

        public bool Remove(string manufacturer, string model)
        {
            var skiToRemove = this.data.Find(x => (x.Manufacturer == manufacturer) && (x.Model == model));
            if (skiToRemove == null) return false;
            else this.data.Remove(skiToRemove);

            return true;
        }

        public Ski GetNewestSki()
        {
            if (this.Count == 0) return null;
            return this.data.OrderByDescending(x => x.Year).FirstOrDefault();
        }

        public Ski GetSki(string manufacturer, string model) => this.data.Find(x => (x.Manufacturer == manufacturer) && (x.Model == model));

        public string GetStatistics()
        {
            var sb = new StringBuilder();
            
            sb.AppendLine($"The skis stored in {this.Name}:");
            foreach (var ski in this.data) sb.AppendLine(ski.ToString());

            return sb.ToString().TrimEnd();
        }

    }
}