using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            double moneyFood = double.Parse(Console.ReadLine());
            double moneySouvenirs = double.Parse(Console.ReadLine());
            double moneyHotelPerDay = double.Parse(Console.ReadLine());

            double benzin = 420 / 100.00 * 7;
            double moneyBenzin = benzin * 1.85;
            double moneyFoodAndSouvenirs = 3 * moneySouvenirs + 3 * moneyFood;

            double firstDay = moneyHotelPerDay * 0.90;
            double secondDay = moneyHotelPerDay * 0.85;
            double thirdDay = moneyHotelPerDay * 0.80;
            
            double amountNeeded = moneyBenzin + moneyFoodAndSouvenirs + firstDay + secondDay + thirdDay;
            Console.WriteLine($"Money needed: {amountNeeded:F2}");
        }
    }
}
