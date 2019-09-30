using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivisionWitoutRemainder
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int firstCount = 0;
            int secondCount = 0;
            int thirdCount = 0;

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (number % 2 == 0)
                {
                    firstCount++;
                }
                if (number % 3 == 0)
                {
                    secondCount++;
                }
                if (number % 4 == 0)
                {
                    thirdCount++;
                }
            }

            double percentFirst = firstCount * 100.0 / n;
            double percentSecond = secondCount * 100.0 / n;
            double percentThird = thirdCount * 100.0 / n;

            Console.WriteLine($"{percentFirst:F2}%");
            Console.WriteLine($"{percentSecond:F2}%");
            Console.WriteLine($"{percentThird:F2}%");
        }
    }
}
