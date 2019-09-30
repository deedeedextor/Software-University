using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            string coins = Console.ReadLine();
            decimal coinsSum = 0;

            while (coins != "Start")
            {
                if (coins == "0.1" || coins == "0.2" || coins == "0.5" || coins == "1" || coins == "2")
                {
                    coinsSum += decimal.Parse(coins);
                }
                else
                {
                    Console.WriteLine($"Cannot accept {coins}");
                }
                coins = Console.ReadLine();
            }

            string purchase = Console.ReadLine().ToLower();
            decimal purchasePrice = 0;

            while (purchase != "end")
            {
                switch (purchase)
                {
                    case "nuts":
                        purchasePrice = 2.0m;
                        break;
                    case "water":
                        purchasePrice = 0.7m;
                        break;
                    case "crisps":
                        purchasePrice = 1.5m;
                        break;
                    case "soda":
                        purchasePrice = 0.8m;
                        break;
                    case "coke":
                        purchasePrice = 1.0m;
                        break;
                    default:                      
                        Console.WriteLine("Invalid product");
                        break;
                }

                if (coinsSum >= purchasePrice && purchasePrice > 0)
                {
                    Console.WriteLine($"Purchased {purchase}");
                    coinsSum -= purchasePrice;                  
                }
                else if (purchasePrice > 0)
                {
                    Console.WriteLine("Sorry, not enough money");             
                }

                purchase = Console.ReadLine().ToLower();
            }

            Console.WriteLine($"Change: {coinsSum:F2}");
        }
    }
}
