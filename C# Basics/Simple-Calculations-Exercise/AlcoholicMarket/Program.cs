using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlcoholicMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceWhisky = double.Parse(Console.ReadLine());
            double beerLiters = double.Parse(Console.ReadLine());
            double wineLiters = double.Parse(Console.ReadLine());
            double rakiaLiters = double.Parse(Console.ReadLine());
            double whiskyLiters = double.Parse(Console.ReadLine());

            var priceRakia = priceWhisky / 2;
            var priceWine = priceRakia - (0.4 * priceRakia);
            var priceBeer = priceRakia - (0.8 * priceRakia);

            var amountRakia = rakiaLiters * priceRakia;
            var amountWine = wineLiters * priceWine;
            var amountBeer = beerLiters * priceBeer;
            var amountWhiskey = whiskyLiters * priceWhisky;

            var totalAmount = amountRakia + amountWine + amountBeer + amountWhiskey;

            Console.WriteLine($"{totalAmount:F2}");
        }
    }
}
