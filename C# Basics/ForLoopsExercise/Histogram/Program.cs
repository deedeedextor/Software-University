using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Histogram
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int countP1 = 0;
            int countP2 = 0;
            int countP3 = 0;
            int countP4 = 0;
            int countP5 = 0;


            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (number < 200)
                {
                    countP1++;
                }
                else if (number >= 200 && number <= 399)
                {
                    countP2++;
                }
                else if (number >= 400 && number <= 599)
                {
                    countP3++;
                }
                else if (number >= 600 && number <= 799)
                {
                    countP4++;
                }
                else
                {
                    countP5++;
                }               
            }

            double p1Percent = countP1 * 100.0/n;
            double p2Percent = countP2 * 100.0/n;
            double p3Percent = countP3 * 100.0/n;
            double p4Percent = countP4 * 100.0/n;
            double p5Percent = countP5 * 100.0/n;

            Console.WriteLine($"{p1Percent:F2}%");
            Console.WriteLine($"{p2Percent:F2}%");
            Console.WriteLine($"{p3Percent:F2}%");
            Console.WriteLine($"{p4Percent:F2}%");
            Console.WriteLine($"{p5Percent:F2}%");
        }
    }
}
