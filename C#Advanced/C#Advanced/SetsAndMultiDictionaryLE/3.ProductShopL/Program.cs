using System;
using System.Collections.Generic;

namespace _3.ProductShopL
{
    class Program
    {
        static void Main(string[] args)
        {
            var shopAndProduct = new SortedDictionary<string, List<string>>();
            var shopAndPrice = new SortedDictionary<string, List<double>>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Revision")
            {
                string[] tokens = input.Split(new[] { ',',' '},StringSplitOptions.RemoveEmptyEntries);

                string shop = tokens[0];
                string product = tokens[1];
                double price = double.Parse(tokens[2]);

                if (!shopAndProduct.ContainsKey(shop))
                {
                    shopAndProduct[shop] = new List<string>();
                    shopAndPrice[shop] = new List<double>();
                }

                shopAndProduct[shop].Add(product);
                shopAndPrice[shop].Add(price);
            }

            foreach (var shopKvp in shopAndProduct)
            {
                string shopName = shopKvp.Key;
                List<string> allProducts = shopKvp.Value;
                List<double> allPrices = shopAndPrice[shopName];

                Console.WriteLine($"{shopName}->");

                for (int product = 0, price = 0; product < allProducts.Count; product++, price++)
                {
                    Console.WriteLine($"Product: {allProducts[product]}, Price: {allPrices[price]} ");
                }
            }
        }
    }
}
