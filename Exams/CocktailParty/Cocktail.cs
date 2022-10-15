using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    internal class Cocktail
    {
        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.MaxAlcoholLevel = maxAlcoholLevel;
            this.Ingredients = new List<Ingredient>();
        }
        public List<Ingredient> Ingredients { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int MaxAlcoholLevel { get; set; }
        public int CurrentAlcoholLevel => this.Ingredients.Select(x => x.Alcohol).Sum();

        public void Add(Ingredient ingredient)
        {
            if (this.Ingredients.Find(x => x.Name == ingredient.Name) == null
                && this.CurrentAlcoholLevel + ingredient.Alcohol <= this.MaxAlcoholLevel
                && this.Ingredients.Count < this.Capacity)
            {
                this.Ingredients.Add(ingredient);
            }
        }

        public bool Remove(string name)
        {
            var ingredientToRemove = this.Ingredients.Find(x => x.Name == name);
            if (ingredientToRemove == null) return false;
            else this.Ingredients.Remove(ingredientToRemove);

            return true;
        }

        public Ingredient FindIngredient(string name) => this.Ingredients.Find(x => x.Name == name);

        public Ingredient GetMostAlcoholicIngredient() => this.Ingredients.OrderByDescending(x => x.Alcohol).FirstOrDefault();

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Cocktail: {this.Name} - Current Alcohol Level: {this.CurrentAlcoholLevel}");

            foreach (var x in this.Ingredients)
                sb.AppendLine(x.ToString());

            return sb.ToString().TrimEnd();
        }
    }
}
