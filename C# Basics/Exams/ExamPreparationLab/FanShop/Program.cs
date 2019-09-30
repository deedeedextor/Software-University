using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanShop
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            int stock = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = 0; i < stock; i++)
            {
                string text = Console.ReadLine();

                if (text == "hoodie")
                {
                    sum += 30;
                }
                else if (text == "keychain")
                {
                    sum += 4;
                }
                else if (text == "T-shirt")
                {
                    sum += 20;
                }
                else if (text == "flag")
                {
                    sum += 15;
                }
                else if (text == "sticker")
                {
                    sum += 1;
                }
            }
            int difference = Math.Abs(budget - sum);

            if (budget >= sum)
            {
                Console.WriteLine($"You bought {stock} items and left with {difference} lv.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {difference} more lv.");
            }
        }
    }
}
