using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceTransport
{
    class Program
    {
        static void Main(string[] args)
        {
            int km = int.Parse(Console.ReadLine());
            string dayOrNight = Console.ReadLine();
            double price = 0;
            double taxiRate = 0;

            if (dayOrNight == "day")
            {
                taxiRate = 0.79;
            }
            else
            {
                taxiRate = 0.90;
            }

            if (km < 20)
            {
                price = 0.70 + km * taxiRate;
            }
            else if (km < 100)
            {
                price = km * 0.09;
            }
            else
            {
                price = km * 0.06;
            }

            Console.WriteLine(price);
                

        }
    }
}
