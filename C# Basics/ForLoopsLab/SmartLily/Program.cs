using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLily
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double priceWashingMachine = double.Parse(Console.ReadLine());
            int priceToy = int.Parse(Console.ReadLine());
            int toysCounter = 0;
            int moneyFromGifts = 0;
            int badBrotherCounter = 0;

            for (int i = 1; i <= age; i++)
            {
                if (i % 2 == 0)
                {
                    badBrotherCounter++;
                    moneyFromGifts += 10 * badBrotherCounter;
                }
                else
                {
                    toysCounter++;
                }
            }

            int moneyForToys = toysCounter * priceToy;
            int totalMoney = (moneyForToys + moneyFromGifts) - badBrotherCounter;

            if (totalMoney >= priceWashingMachine)
            {
                Console.WriteLine($"Yes! {(totalMoney - priceWashingMachine):F2}");
            }
            else
            {
                Console.WriteLine($"No! {(priceWashingMachine-totalMoney):F2}");
            }

        }
    }
}
