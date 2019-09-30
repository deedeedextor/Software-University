using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyBooster
{
    class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine();
            string size = Console.ReadLine();
            int number = int.Parse(Console.ReadLine());
            double price = 0;

            if (size == "small")
            {
                if (fruit == "Watermelon")
                {
                    price = number * (2 * 56.00);
                }
                else if (fruit == "Mango")
                {
                    price = number * (2 * 36.66);
                }
                else if (fruit == "Pineapple")
                {
                    price = number * (2 * 42.10);
                }
                else if (fruit == "Raspberry")
                {
                    price = number * (2 * 20.00);
                }
            }
            else if (size == "big")
            {
                if (fruit == "Watermelon")
                {
                    price = number * (5 * 28.70);
                }
                else if (fruit == "Mango")
                {
                    price = number * (5 * 19.60);
                }
                else if (fruit == "Pineapple")
                {
                    price = number * (5 * 24.80);
                }
                else if (fruit == "Raspberry")
                {
                    price = number * (5 * 15.20);
                }
            }

            if (price >= 400 && price <= 1000)
            {
                price *= 0.85;
            }
            else if (price > 1000)
            {
                price *= 0.50;
            }
            
            Console.WriteLine($"{price:F2} lv.");
        }
    }
}
