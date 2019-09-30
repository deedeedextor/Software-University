using System;

namespace _2.CenterPointME
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            double distanceOne = CalculateDistance(x1, y1);
            double distanceTwo = CalculateDistance(x2, y2);

            if (distanceOne >= distanceTwo)
            {
                Console.WriteLine($"{(x2, y2)}");
            }
            else
            {
                Console.WriteLine($"{(x1, y1)}");
            }
        }

        private static double CalculateDistance(double x, double y)
        {
            double distance = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
            return distance;
        }
    }
}
