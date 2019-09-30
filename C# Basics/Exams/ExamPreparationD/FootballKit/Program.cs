using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballKit
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceTshirt = double.Parse(Console.ReadLine());
            double amountTarget = double.Parse(Console.ReadLine());

            double priceShorts = priceTshirt * 0.75;
            double priceSocks = priceShorts * 0.20;
            double priceBoots = (priceTshirt + priceShorts) * 2;
            double sumDiscount = (priceTshirt + priceShorts + priceSocks + priceBoots) * 0.85;
            
            if (sumDiscount >= amountTarget)
            {
                Console.WriteLine($"Yes, he will earn the world-cup replica ball!");
                Console.WriteLine($"His sum is {sumDiscount:F2} lv.");
            }
            else
            {
                Console.WriteLine($"No, he will not earn the world-cup replica ball.");
                Console.WriteLine($"He needs {(amountTarget-sumDiscount):F2} lv. more.");
            }
        }
    }
}
