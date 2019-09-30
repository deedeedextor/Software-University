using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeasureUnit
{
    class Program
    {
        static void Main(string[] args)
        {
            double num = double.Parse(Console.ReadLine());
            string firstUnit = Console.ReadLine().ToLower();
            string secondUnit = Console.ReadLine().ToLower();
            double firstValue = 1;
            double secondValue = 1;

            if (firstUnit == "mm")
            {
                firstValue = 1000;
            }
            else if (firstUnit == "cm")
            {
                firstValue = 100;
            }
            else if (firstUnit == "mi")
            {
                firstValue = 0.000621371192;
            }
            else if (firstUnit == "in")
            {
                firstValue = 39.3700787;
            }
            else if (firstUnit == "km")
            {
                firstValue = 0.001;
            }
            else if (firstUnit == "ft")
            {
                firstValue = 3.2808399;
            }
            else if (firstUnit == "yd")
            {
                firstValue = 1.0936133;
            }
           

            if (secondUnit == "mm")
            {
                secondValue = 1000;
            }
            else if ( secondUnit == "cm")
            {
                secondValue = 100;
            }
            else if (secondUnit == "mi")
            {
                secondValue = 0.000621371192;
            }
            else if (secondUnit == "in")
            {
                secondValue = 39.3700787;
            }
            else if (secondUnit == "km")
            {
                secondValue = 0.001;
            }
            else if (secondUnit == "ft")
            {
                secondValue = 3.2808399;
            }
            else if (secondUnit == "yd")
            {
                secondValue = 1.0936133;
            }

            Console.WriteLine(num / firstValue * secondValue);
        } 
    }
}
