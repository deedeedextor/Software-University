using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoom
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            double nights = double.Parse(Console.ReadLine());

            double priceStudio = 0;
            double priceApartment = 0;
            
            if (month == "May" || month == "October")
            {
                    priceStudio = nights * 50;
                    priceApartment = nights * 65;

                    if (nights > 7 && nights <= 14)
                    {
                        priceStudio *= 0.95;
                    }
                    else if (nights > 14)
                    {
                        priceStudio *= 0.70;
                        priceApartment *= 0.90;
                    }
            }

            else if (month == "June" || month == "September")
            {
                
                    priceStudio = nights * 75.20;
                    priceApartment = nights * 68.70;

                if (nights > 14)
                {
                        priceStudio *= 0.80;
                        priceApartment *= 0.90;
                }
            }

            else if (month == "July" || month == "August")
            {
                    priceStudio = nights * 76;
                    priceApartment = nights * 77;
                
                if (nights > 14)
                {
                    priceApartment *= 0.90;
                }
            }
            
            Console.WriteLine($"Apartment: {priceApartment:F2} lv.");
            Console.WriteLine($"Studio: {priceStudio:F2} lv.");
        }
    }
}
