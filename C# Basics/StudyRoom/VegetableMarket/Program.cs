using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegetableMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceKgVegetables = double.Parse(Console.ReadLine());
            double priceKgFruits = double.Parse(Console.ReadLine());
            int totalKgVegetables = int.Parse(Console.ReadLine());
            int totalKgFruits = int.Parse(Console.ReadLine());

            double priceVegetables = priceKgVegetables * totalKgVegetables;
            double priceFruits = priceKgFruits * totalKgFruits;

            double totalAmountBGN = priceVegetables + priceFruits;
            double totalAmountEUR = totalAmountBGN / 1.94;

            Console.WriteLine(totalAmountEUR);
        }
    }
}
