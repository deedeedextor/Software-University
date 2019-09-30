using System;

namespace _6.CalculateRectangleAreaL
{
    class Program
    {
        static void Main(string[] args)
        {
            double width = int.Parse(Console.ReadLine());
            double heigth = int.Parse(Console.ReadLine());

            double area = CalculateRectangleArea(width, heigth);
            Console.WriteLine(area);
        }

        public static double CalculateRectangleArea(double width, double heigth)
        {
            return width * heigth;            
        }
    }
}
