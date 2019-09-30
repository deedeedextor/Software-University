using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingDecoration
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            
            double price = 0;
            double moneySpend = 0;

            int countBalloons = 0;
            int countFlowers = 0;
            int countCandles = 0;
            int countRibbon = 0;

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "stop")
                {                                                           
                    Console.WriteLine($"Spend money: {moneySpend:F2}");
                    Console.WriteLine($"Money left: {budget:F2}");
                    Console.WriteLine($"Purchased decoration is {countBalloons} balloons, {countRibbon} m ribbon, {countFlowers} flowers and {countCandles} candles.");
                    return;
                }

                int numberOfStock = int.Parse(Console.ReadLine());

                if (command == "balloons")
                {
                    countBalloons += numberOfStock;
                    price = numberOfStock * 0.10;                                                       
                }
                else if (command == "flowers")
                {
                    countFlowers += numberOfStock;
                    price = numberOfStock * 1.50;
                }
                else if (command == "candles")
                {
                    countCandles += numberOfStock;
                    price = numberOfStock * 0.50;
                }
                else if (command == "ribbon")
                {
                    countRibbon += numberOfStock;
                    price = numberOfStock * 2.00;
                }

                moneySpend += price;
                budget -= price;

                if (price >= budget || budget == 0)
                {
                    Console.WriteLine("All money is spent!");
                    Console.WriteLine($"Purchased decoration is {countBalloons} balloons, {countRibbon} m ribbon, {countFlowers} flowers and {countCandles} candles.");
                    return;
                }
            
            }
        }
    }
}
