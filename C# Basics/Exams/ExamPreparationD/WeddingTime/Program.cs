using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingTime
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceWhisky = double.Parse(Console.ReadLine());
            double water = double.Parse(Console.ReadLine());
            double wine = double.Parse(Console.ReadLine());
            double shampane = double.Parse(Console.ReadLine());
            double whisky = double.Parse(Console.ReadLine());

            double priceShampane = priceWhisky * 0.5;
            double priceWine = priceShampane * 0.40;
            double priceWater = priceShampane * 0.10;

            double totalSum = priceWhisky * whisky + priceShampane * shampane + priceWine * wine + priceWater * water;

            Console.WriteLine($"{totalSum:F2}");
        }
    }
}
