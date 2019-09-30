using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetricConvertor
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            string inUnit = Console.ReadLine().ToLower();
            string outUnit = Console.ReadLine().ToLower();
            double inValue = 1;
            double outValue = 1;

            if (inUnit == "mm")
            {
                inValue = 1000;
            }
            else if (inUnit == "cm")
            {
                inValue = 100;
            }
            else if (inUnit == "mi")
            {
                inValue = 0.000621371192;
            }
            else if (inUnit == "in")
            {
                inValue = 39.3700787;
            }
            else if (inUnit == "km")
            {
                inValue = 0.001;
            }
            else if (inUnit == "ft")
            {
                inValue = 3.2808399;
            }
            else if (inUnit == "yd")
            {
                inValue = 1.0936133;
            }

            if (outUnit == "mm")
            {
                outValue = 1000;
            }
            else if (outUnit == "cm")
            {
                outValue = 100;
            }
            else if (outUnit == "mi")
            {
                outValue = 0.000621371192;
            }
            else if (outUnit == "in")
            {
                outValue = 39.3700787;
            }
            else if (outUnit == "km")
            {
                outValue = 0.001;
            }
            else if (outUnit == "ft")
            {
                outValue = 3.2808399;
            }
            else if (outUnit == "yd")
            {
                outValue = 1.0936133;
            }

            Console.WriteLine($"{(number / inValue * outValue):F8}");
        }
    }
}
