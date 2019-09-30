using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SushiTime
{
    class Program
    {
        static void Main(string[] args)
        {
            string sushi = Console.ReadLine();
            string restaurant = Console.ReadLine();
            int portions = int.Parse(Console.ReadLine());
            char symbol = char.Parse(Console.ReadLine());
            double price = 0;
            double discount = 0;
            double totalSum = 0;

            if (restaurant != "Sushi Zone" && restaurant != "Sushi Time" && restaurant != "Sushi Bar" && restaurant != "Asian Pub")
            {
                Console.WriteLine($"{restaurant} is invalid restaurant!");
                return;
            }

            if (restaurant == "Sushi Zone")
            {
                if (sushi == "sashimi")
                {
                    price = portions * 4.99;
                }
                else if (sushi == "maki")
                {
                    price = portions * 5.29;
                }
                else if (sushi == "uramaki")
                {
                    price = portions * 5.99;
                }
                else if (sushi == "temaki")
                {
                    price = portions * 4.29;
                }
            }

            else if(restaurant == "Sushi Time")
            {
                if (sushi == "sashimi")
                {
                    price = portions * 5.49;
                }
                else if (sushi == "maki")
                {
                    price = portions * 4.69;
                }
                else if (sushi == "uramaki")
                {
                    price = portions * 4.49;
                }
                else if (sushi == "temaki")
                {
                    price = portions * 5.19;
                }
            }

            else if (restaurant == "Sushi Bar")
            {
                if (sushi == "sashimi")
                {
                    price = portions * 5.25;
                }
                else if (sushi == "maki")
                {
                    price = portions * 5.55;
                }
                else if (sushi == "uramaki")
                {
                    price = portions * 6.25;
                }
                else if (sushi == "temaki")
                {
                    price = portions * 4.75;
                }
            }

            else if (restaurant == "Asian Pub")
            {
                if (sushi == "sashimi")
                {
                    price = portions * 4.50;
                }
                else if (sushi == "maki")
                {
                    price = portions * 4.80;
                }
                else if (sushi == "uramaki")
                {
                    price = portions * 5.50;
                }
                else if (sushi == "temaki")
                {
                    price = portions * 5.50;
                }
            }

            if (symbol == 'Y')
            {
                discount = price * 0.20;
                totalSum = Math.Ceiling(price + discount);
                Console.WriteLine($"Total price: {totalSum} lv.");
            }

            else
            {
                Console.WriteLine($"Total price: {Math.Ceiling(price)} lv.");
            }

        }
    }
}
