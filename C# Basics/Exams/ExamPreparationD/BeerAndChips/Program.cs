using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerAndChips
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            double budget = double.Parse(Console.ReadLine());
            int beers = int.Parse(Console.ReadLine());
            int chips = int.Parse(Console.ReadLine());

            double priceBeers = beers * 1.20;
            double priceChips = Math.Ceiling((priceBeers * 0.45) * chips);
            double totalSum = priceBeers + priceChips;
            double difference = Math.Abs(budget - totalSum);

            if (totalSum <= budget)
            {
                Console.WriteLine($"{name} bought a snack and has {difference:F2} leva left.");
            }
            else
            {
                Console.WriteLine($"{name} needs {difference:F2} more leva!");
            }          
        }
    }
}
