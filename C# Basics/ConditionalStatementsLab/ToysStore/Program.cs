using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToysStore
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceExcursion = double.Parse(Console.ReadLine());
            int numPuzzles = int.Parse(Console.ReadLine());
            int numDolls = int.Parse(Console.ReadLine());
            int numBears = int.Parse(Console.ReadLine());
            int numMinions = int.Parse(Console.ReadLine());
            int numTrucks = int.Parse(Console.ReadLine());


            double startingAmount = numPuzzles * 2.60 + numDolls * 3 + numBears * 4.10 + numMinions * 8.20 + numTrucks * 2;
            int numToys = numPuzzles + numDolls + numBears + numMinions + numTrucks;
            double discount = 0;

            if (numToys >= 50)
            {
                discount = startingAmount * 0.25;
            }

            double amountAfterDiscount = startingAmount - discount;
            double profit = amountAfterDiscount * 0.90;

            if (profit >= priceExcursion)
            {
                Console.WriteLine($"Yes! {(profit - priceExcursion):F2} lv left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! {(priceExcursion - profit):F2} lv needed.");
            }
        }
    }
}
