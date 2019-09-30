namespace _5.MordorsCruelPlanE
{
    using _5.MordorsCruelPlanE.Foods;
    using _5.MordorsCruelPlanE.Moods;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        static void Main(string[] args)
        {
            List<Food> foodsEaten = new List<Food>();
            FoodFactory foodFactory = new FoodFactory();

            string[] foods = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var food in foods)
            {
                Food foodToAdd = foodFactory.GetFood(food);

                foodsEaten.Add(foodToAdd);
            }

            int happinessFood = foodsEaten
                .Select(x => x == null ? -1 : x.Happiness)
                .Sum();

            Console.WriteLine(happinessFood);

            if (happinessFood < -5)
            {
                Console.WriteLine(nameof(Angry));
            }

            else if (happinessFood >= -5 && happinessFood <= 0)
            {
                Console.WriteLine(nameof(Sad));
            }

            else if (happinessFood >= 1 && happinessFood <= 15)
            {
                Console.WriteLine(nameof(Happy));
            }

            else if (happinessFood > 15)
            {
                Console.WriteLine(nameof(JavaScript));
            }
        }
    }
}
