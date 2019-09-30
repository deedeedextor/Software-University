using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travelling
{
    class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();

            while (destination != "End")
            {
                double budget = double.Parse(Console.ReadLine());
                double sum = 0;

                while (sum < budget)
                {
                    double num = double.Parse(Console.ReadLine());
                    sum += num;
                }

                Console.WriteLine($"Going to {destination}!");
                destination = Console.ReadLine();                
            }           
        }
    }
}
