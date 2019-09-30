using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.CookingMasterclass
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double priceFlour = double.Parse(Console.ReadLine());
            double priceEgg = double.Parse(Console.ReadLine());
            double priceApron = double.Parse(Console.ReadLine());
            
            double freePackageFlour = students / 5;

            double totalCost = priceApron * Math.Ceiling((students + (students * 0.20)))
                    + priceEgg * 10 * students
                    + priceFlour * (students - freePackageFlour);

            if (totalCost <= budget)
            {
                Console.WriteLine($"Items purchased for {totalCost:F2}$.");
            }
            else 
            {
                Console.WriteLine($"{(totalCost - budget):F2}$ more needed.");
            }
        }
    }
}

