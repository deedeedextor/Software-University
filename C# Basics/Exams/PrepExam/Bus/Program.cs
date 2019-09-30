using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberPassengers = int.Parse(Console.ReadLine());
            int numberStops = int.Parse(Console.ReadLine());
            int passengers = 0;

            for (int i = 1; i <= numberStops; i++)
            {
                int passengersOut = int.Parse(Console.ReadLine());
                int passengersIn = int.Parse(Console.ReadLine());

                if (i == 1)
                {
                    passengers = (numberPassengers - passengersOut) + (passengersIn + 2);
                }
                else if (i % 2 != 0)
                {
                    passengers = (passengers - passengersOut) + (passengersIn + 2);
                }
                else if (i%2 == 0)
                {
                    passengers = ((passengers-passengersOut)-2) + passengersIn;
                }              
            }
            Console.WriteLine($"The final number of passengers is : {passengers}");
        }
    }
}
