using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CirclePerimeter
{
    class Program
    {
        static void Main(string[] args)
        {
            double radius = double.Parse(Console.ReadLine());

            double area = Math.PI * radius * radius;
            double perimeter = 2 * Math.PI * radius;

            Console.WriteLine($"Area = {area}");
            Console.WriteLine($"Perimeter = {perimeter}");
        }
    }
}
