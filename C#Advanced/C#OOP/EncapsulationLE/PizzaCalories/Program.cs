namespace PizzaCalories
{
    using System;

    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] pizzaTokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string pizzaName = pizzaTokens[1];

                string[] doughTokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string flourType = doughTokens[1];
                string bakingTechnique = doughTokens[2];
                double weight = double.Parse(doughTokens[3]);

                Dough dough = new Dough(flourType, bakingTechnique, weight);

                Pizza pizza = new Pizza(pizzaName, dough);

                string input = string.Empty;

                while ((input = Console.ReadLine()) != "END")
                {
                    string[] toppingTokens = input
                     .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    string toppingType = toppingTokens[1];
                    double toppingWeight = double.Parse(toppingTokens[2]);

                    Topping topping = new Topping(toppingType, toppingWeight);
                    pizza.AddTopping(topping);
                }

                Console.WriteLine($"{pizza.Name} - {pizza.GetTotalCalories():F2} Calories.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
