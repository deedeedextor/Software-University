using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.HelloFrance
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> items = Console.ReadLine().Split("|").ToList();

            List<double> newPrices = new List<double>();

            double budget = double.Parse(Console.ReadLine());
            double increasedPrice = 0;
            double profit = 0;

            for (int i = 0; i < items.Count; i++)
            {
                string[] item = items[i].Split("->");

                string type = item[0];
                double priceItem = double.Parse(item[1]);

                if (type == "Clothes")
                {
                    if (priceItem <= 50.00 && priceItem <= budget)
                    {
                        budget -= priceItem;
                        increasedPrice = priceItem * 0.40;
                        profit += increasedPrice;
                        priceItem += increasedPrice;
                        newPrices.Add(priceItem);
                    }
                }
                else if (type == "Shoes")
                {
                    if (priceItem <= 35.00 && priceItem <= budget)
                    {
                        budget -= priceItem;
                        increasedPrice = priceItem * 0.40;
                        profit += increasedPrice;
                        priceItem += increasedPrice;
                        newPrices.Add(priceItem);
                    }
                }
                else if (type == "Accessories")
                {
                    if (priceItem <= 20.50 && priceItem <= budget)
                    {
                        budget -= priceItem;
                        increasedPrice = priceItem * 0.40;
                        profit += increasedPrice;
                        priceItem += increasedPrice;
                        newPrices.Add(priceItem);
                    }
                }
            }
            
            Console.WriteLine(string.Join(" ", newPrices.Select(x => $"{x:F2}")));
            Console.WriteLine($"Profit: {profit:F2}");

            double prices = newPrices.Sum();

            if (budget + prices >= 150)
            {
                Console.WriteLine("Hello, France!");
            }
            else
            {
                Console.WriteLine("Time to go.");
            }
        }
    }
}
