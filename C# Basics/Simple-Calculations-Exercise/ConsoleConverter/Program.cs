using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            double amount = double.Parse(Console.ReadLine());
            double USD = 1.79549;
            double BGN = amount * USD;

            Console.WriteLine($"{BGN:F2} BGN");
        }
    }
}
