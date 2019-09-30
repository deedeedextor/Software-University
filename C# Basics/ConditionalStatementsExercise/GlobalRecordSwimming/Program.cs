using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalRecordSwimming
{
    class Program
    {
        static void Main(string[] args)
        {
            double record = double.Parse(Console.ReadLine());
            double distanceMeters = double.Parse(Console.ReadLine());
            double secsPerMeter = double.Parse(Console.ReadLine());

            double swimmingTime = distanceMeters * secsPerMeter + Math.Floor(distanceMeters / 15) * 12.5;
            

            if (record > swimmingTime)
            {
               Console.WriteLine($"Yes, he succeeded! The new world record is {swimmingTime:F2} seconds.", swimmingTime);
            }
            else
            {
                double differenceTime = Math.Abs(swimmingTime - record);
                Console.WriteLine($"No, he failed! He was {differenceTime:F2} seconds slower.", differenceTime - record);
            }
        }
    }
}
