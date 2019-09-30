using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingInvestment
{
    class Program
    {
        static void Main(string[] args)
        {
            string limitContract = Console.ReadLine();
            string typeContract = Console.ReadLine();
            string dessert = Console.ReadLine();
            int months = int.Parse(Console.ReadLine());
            double price = 0;

            if (limitContract == "one")
            {
                if (typeContract == "Small")
                {
                    price = 9.98;
                    if (dessert == "yes")
                    {
                        price += 5.50;
                    }
                }
                else if (typeContract == "Middle")
                {
                    price = 18.99;
                    if (dessert == "yes")
                    {
                        price += 4.35;
                    }
                }
                else if (typeContract == "Large")
                {
                    price = 25.98;
                    if (dessert == "yes")
                    {
                        price += 4.35;
                    }
                }
                else if (typeContract == "ExtraLarge")
                {
                    price = 35.99;
                    if (dessert == "yes")
                    {
                        price += 3.85;
                    }
                }
            }

            else if (limitContract == "two")
            {
                if (typeContract == "Small")
                {
                    price = 8.58;
                    if (dessert == "yes")
                    {
                        price += 5.50;
                    }
                }
                else if (typeContract == "Middle")
                {
                    price = 17.09;
                    if (dessert == "yes")
                    {
                        price += 4.35;
                    }
                }
                else if (typeContract == "Large")
                {
                    price = 23.59;
                    if (dessert == "yes")
                    {
                        price += 4.35;
                    }
                }
                else if (typeContract == "ExtraLarge")
                {
                    price = 31.79;
                    if (dessert == "yes")
                    {
                        price += 3.85;
                    }
                }
                price *= 0.9625;
            }

            price *= months;
            Console.WriteLine($"{price:F2} lv.");
        }
    }
}
