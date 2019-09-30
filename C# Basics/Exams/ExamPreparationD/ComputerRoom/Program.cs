using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerRoom
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int hours = int.Parse(Console.ReadLine());
            int gamers = int.Parse(Console.ReadLine());
            string time = Console.ReadLine();
            double price = 0;
            double totalSum = 0;

            if (time == "day")
            {
                if (month == "march" || month == "april" || month == "may")
                {
                    price = 10.50;               
                }

                else if (month == "june" || month == "july" || month == "august")
                {
                    price = 12.60;                          
                }
            }

            else if (time == "night")
            {
                if (month == "march" || month == "april" || month == "may")
                {
                    price = 8.40;            
                }

                else if (month == "june" || month == "july" || month == "august")
                {
                    price = 10.20;
                }
            }

            if (gamers >= 4)
            {
                price *= 0.90;
            }
            if (hours >= 5)
            {
                price = price * 0.50;
            }
            totalSum = price * hours * gamers;

            Console.WriteLine($"Price per person for one hour: {price:F2}");
            Console.WriteLine($"Total cost of the visit: {totalSum:F2}");

        }
    }
}
