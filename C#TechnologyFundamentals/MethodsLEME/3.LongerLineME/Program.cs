using System;

namespace _3.LongerLineME
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());

            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            double x3 = double.Parse(Console.ReadLine());
            double y3 = double.Parse(Console.ReadLine());

            double x4 = double.Parse(Console.ReadLine());
            double y4 = double.Parse(Console.ReadLine());

            PrintTheCloserPoint(x1, y1, x2, y2, x3, y3, x4, y4);
        }    

        private static void PrintTheCloserPoint(double x1, double y1, double x2, double y2,
            double x3, double y3, double x4, double y4)
        {
            double lineOne = Math.Sqrt(Math.Pow((x2-x1), 2) + Math.Pow((y2-y1), 2));
            double lineTwo = Math.Sqrt(Math.Pow((x4 - x3), 2) + Math.Pow((y4 - y3), 2));

            if (lineOne >= lineTwo)
            {
                double areaOne = x1 * x1 + y1 * y1;
                double areaTwo = x2 * x2 + y2 * y2;

                if (areaOne <= areaTwo)
                {
                    Console.WriteLine($"({x1}, {y1})({x2}, {y2})");
                }
                else
                {
                    Console.WriteLine($"({x2}, {y2})({x1}, {y1})");
                }
            }

            else
            {
                double areaOne = x3 * x3 + y3 * y3;
                double areaTwo = x4 * x4 + y4 * y4;

                if (areaOne <= areaTwo)
                {
                    Console.WriteLine($"({x3}, {y3})({x4}, {y4})");
                }
                else
                {
                    Console.WriteLine($"({x4}, {y4})({x3}, {y3})");
                }
            }
        }
    }
}
