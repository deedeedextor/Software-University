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
            double priceBalloons = 0;
            double priceFlowers = 0;
            double priceCandles = 0;
            double priceRibbon = 0;
            double totalSum = 0;
            int counter = 0;
            int numBalloons = 0;
            int numFlowers = 0;
            int numCandles = 0;
            int meterRibbon = 0;
            int countBallons = 0;
            int countFlowers = 0;
            int countCandles = 0;
            int countRibbon = 0;


            while (true)
            {
                string purchase = Console.ReadLine();

                if (purchase == "stop")
                {
                    Console.WriteLine($"Spend money: {totalSum:F2}");
                    Console.WriteLine($"Money left: {budget:F2}");
                    Console.WriteLine($"Purchased decoration is {countBallons} balloons, {countRibbon} m ribbon, {countFlowers} flowers and {countCandles} candles.");
                    return;
                }
                int numPurchase = int.Parse(Console.ReadLine());
             
                if (purchase == "balloons")
                {
                    numBalloons = numPurchase;
                    priceBalloons = numBalloons * 0.10;
                    budget -= priceBalloons;
                    countBallons += numBalloons;
                    totalSum += priceBalloons;
                }
                else if (purchase == "flowers")
                {
                    numFlowers = numPurchase;
                    priceFlowers = numFlowers * 1.50;
                    budget -= priceFlowers;
                    countFlowers += numFlowers;
                    totalSum += priceFlowers;
                }
                else if (purchase == "candles")
                {
                    numCandles = numPurchase;
                    priceCandles = numCandles * 0.50;
                    budget -= priceCandles;
                    countCandles += numCandles;
                    totalSum += priceCandles;
                }
                else if (purchase == "ribbon")
                {
                    meterRibbon = numPurchase;
                    priceRibbon = meterRibbon * 2.00;
                    budget -= priceRibbon;
                    countRibbon += meterRibbon;
                    totalSum += priceRibbon;
                }

                if (priceBalloons >= budget && priceFlowers >= budget && priceCandles >= budget && priceRibbon >= budget)
                {
                    Console.WriteLine("All money is spent!");
                    Console.WriteLine($"Purchased decoration is {countBallons} balloons, {countRibbon} m ribbon, {countFlowers} flowers and {countCandles} candles.");
                    return;
                }           
                counter++;
            }                     
        }
    }
}
