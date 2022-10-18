namespace Parking
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Parking
    {
        public Parking(string type, int capacity)
        {
            this.data = new List<Car>();
            this.Type = type;
            this.Capacity = capacity;
        }
        private readonly List<Car> data;
        public string Type { get; set; }
        public int Capacity { get; set; }
        public int Count => this.data.Count;

        public void Add(Car car)
        {
            if(this.Count < this.Capacity) this.data.Add(car);
        }

        public bool Remove(string manufacturer, string model)
        {
            var carToRemove = this.data.Find(x => (x.Manufacturer == manufacturer) && (x.Model == model));
            
            if (carToRemove == null) return false;
            else this.data.Remove(carToRemove);

            return true;
        }

        public Car GetLatestCar() => this.data.OrderByDescending(x => x.Year).FirstOrDefault();

        public Car GetCar(string manufacturer, string model) => this.data.Find(x => (x.Manufacturer == manufacturer) && (x.Model == model));

        public string GetStatistics()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"The cars are parked in {this.Type}:");
            foreach (var car in this.data) sb.AppendLine(car.ToString());

            return sb.ToString().TrimEnd();
        }
    }
}