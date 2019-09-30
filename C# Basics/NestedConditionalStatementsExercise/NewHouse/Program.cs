using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            string flowers = Console.ReadLine();
            int numFlowers = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());

            double rosePrice = 5.00;
            double dahliaPrice = 3.80;
            double tulipPrice = 2.80;
            double narcissusPrice = 3.00;
            double gladiolusPrice = 2.50;

            double price = 0;
            
            if (flowers == "Roses")
            {
                price = numFlowers * rosePrice;
      
                if (numFlowers > 80)
                {
                    price *= 0.90;
                }
            }

            else if (flowers == "Dahlias")
            {
                price = numFlowers * dahliaPrice;

                if (numFlowers > 90)
                {
                    price *= 0.85;
                }
            }

            else if (flowers == "Tulips")
            {
                price = numFlowers * tulipPrice;

                if (numFlowers > 80)
                {
                    price *= 0.85;
                }
            }

            else if (flowers == "Narcissus")
            {
                price = numFlowers * narcissusPrice;

                if (numFlowers < 120)
                {
                    price *= 1.15;
                }
            }

            else if (flowers == "Gladiolus")
            {
                price = numFlowers * gladiolusPrice;

                if (numFlowers < 80)
                {
                    price *= 1.20;
                }
                
            }

            if (price > budget)
            {
                Console.WriteLine($"Not enough money, you need {price - budget:F2} leva more.");
            }
            else
            {
                Console.WriteLine($"Hey, you have a great garden with {numFlowers} {flowers} and {budget - price:F2} leva left.");
            }
        }
    }
}
