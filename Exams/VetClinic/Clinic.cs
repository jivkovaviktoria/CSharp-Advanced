namespace VetClinic
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Clinic
    {
        public Clinic(int capacity)
        {
            this.data = new List<Pet>();
            this.Capacity = capacity;
        }
        private readonly List<Pet> data;
        public int Capacity { get; set; }

        public int Count => this.data.Count;

        public void Add(Pet pet)
        {
            if(this.Count < this.Capacity) this.data.Add(pet);
        }

        public bool Remove(string name)
        {
            var petToRemove = this.data.Find(x => x.Name == name);

            if (petToRemove == null) return false;
            else this.data.Remove(petToRemove);

            return true;
        }
        
        public Pet GetPet(string name, string owner) => this.data.Find(x => (x.Name == name)&&(x.Owner == owner));

        public Pet GetOldestPet()
        {
            if (this.Count == 0) return null;
            else return this.data.OrderByDescending(x => x.Age).FirstOrDefault();
        }

        public string GetStatistics()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"The clinic has the following patients:");
            foreach (var pet in this.data) sb.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");

            return sb.ToString().TrimEnd();
        }
        
    }
}