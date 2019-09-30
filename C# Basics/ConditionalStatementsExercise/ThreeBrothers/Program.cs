using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeBrothers
{
    class Program
    {
        static void Main(string[] args)
        {
            double hours1 = double.Parse(Console.ReadLine());
            double hours2 = double.Parse(Console.ReadLine());
            double hours3 = double.Parse(Console.ReadLine());
            double hoursFish = double.Parse(Console.ReadLine());

            double totalHours = 1 / (1 / hours1 + 1 / hours2 + 1 / hours3);
            double hoursWithRest = totalHours + (totalHours * 0.15);
            double hoursLeft = Math.Abs(hoursFish - hoursWithRest);
            
            if (hoursFish > hoursWithRest)
            {
                Console.WriteLine($"Cleaning time: {hoursWithRest:F2}");
                Console.WriteLine("Yes, there is a surprise - time left -> {0:F0} hours.", Math.Floor(hoursLeft));
            }
            else
            {
                Console.WriteLine($"Cleaning time: {hoursWithRest:F2}");
                Console.WriteLine("No, there isn't a surprise - shortage of time -> {0:F0} hours.",  Math.Ceiling(hoursLeft));
            }          
        }
    }
}
