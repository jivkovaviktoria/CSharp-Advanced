using System;
using System.Collections.Generic;
using System.Linq;

namespace MealPlan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] meals = Console.ReadLine().Split();

            int[] caloriesIntakesPerDay = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> days = new Stack<int>(caloriesIntakesPerDay);

            Dictionary<string, int> mealsCalories = new Dictionary<string, int>()
            {
                {"salad", 350 },
                {"soup", 490 },
                {"pasta", 680 },
                {"steak", 790 }
            };

            Queue<Meal> mealsToEat = new Queue<Meal>();
            AddMeals(meals, mealsToEat, mealsCalories);
            
            int countOfEatenMeals = 0;

            while (mealsToEat.Count > 0 && days.Count > 0)
                EatMeal(days, mealsToEat, ref countOfEatenMeals);

            PrintInfo(mealsToEat, countOfEatenMeals, days);
            
        }

        private static void EatMeal(Stack<int> days, Queue<Meal> mealsToEat, ref int count)
        {
            var currentDay = days.Pop();
            var currentMeal = mealsToEat.Peek();

            if (currentMeal.Calories < currentDay)
            {
                currentDay -= currentMeal.Calories;
                mealsToEat.Dequeue();
                days.Push(currentDay);
                count++;
            }
            else if (currentMeal.Calories > currentDay)
            {
                currentMeal.Calories -= currentDay;
                if (days.Count == 0)
                {
                    mealsToEat.Dequeue();
                    count++;
                }
            }
            else
            {
                mealsToEat.Dequeue();
                count++;
            }
        }

        private static void AddMeals(string[] meals, Queue<Meal> mealsToEat, Dictionary<string, int> mealsCalories)
        {
            for (int i = 0; i < meals.Length; i++)
            {
                var currentMeal = meals[i];
                Meal meal = new Meal(currentMeal, mealsCalories[currentMeal]);
                mealsToEat.Enqueue(meal);
            }
        }

        private static void PrintInfo(Queue<Meal> mealsToEat, int countOfEatenMeals, Stack<int> days)
        {
            if (mealsToEat.Count == 0)
            {
                Console.WriteLine($"John had {countOfEatenMeals} meals.");
                Console.WriteLine($"For the next few days, he can eat {string.Join(", ", days)} calories.");
            }
            else
            {
                Console.WriteLine($"John ate enough, he had {countOfEatenMeals} meals.");
                Console.WriteLine($"Meals left: {string.Join(", ", mealsToEat.Select(x => x.Type))}.");
            }
        }
    }

    public class Meal
    {
        public Meal(string type, int calories)
        {
            Type = type;
            Calories = calories;
        }
        public string Type { get; set; }
        public int Calories { get; set; }
    }
}