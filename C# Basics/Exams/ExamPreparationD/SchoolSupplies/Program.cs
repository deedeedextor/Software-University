using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSupplies
{
    class Program
    {
        static void Main(string[] args)
        {
            int pens = int.Parse(Console.ReadLine());
            int markers = int.Parse(Console.ReadLine());
            double cleaner = double.Parse(Console.ReadLine());
            int percent = int.Parse(Console.ReadLine());

            double totalSum = pens * 5.80 + markers * 7.20 + cleaner * 1.20;
            double discountSum = totalSum - ((totalSum * percent) / 100);

            Console.WriteLine($"{discountSum:F3}");
        }
    }
}
