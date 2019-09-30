using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvenOrOddPositions
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double oddSum = 0;
            double oddMin = double.MaxValue;
            double oddMax = double.MinValue;
            double evenSum = 0;
            double evenMin = double.MaxValue;
            double evenMax = double.MinValue;

            for (int i = 1; i <= n; i++)
            {
                double number = double.Parse(Console.ReadLine());

                if (i%2==0)
                {
                    evenSum += number;
                    if(number < evenMin)
                    {
                        evenMin = number;
                    }
                    if (number > evenMax)
                    {
                        evenMax = number;
                    }
                }

                else
                {
                    oddSum += number;
                    if (number < oddMin)
                    {
                        oddMin = number;
                    }
                    if (number > oddMax)
                    {
                        oddMax = number;
                    }
                }
            }
            if (oddSum == 0)
            {
                Console.WriteLine($"OddSum={oddSum},");
                Console.WriteLine($"OddMin=No,");
                Console.WriteLine($"OddMax=No,");
            }
            else
            {
                Console.WriteLine($"OddSum={oddSum},");
                Console.WriteLine($"OddMin={oddMin},");
                Console.WriteLine($"OddMax={oddMax},");
            }

            if (evenSum == 0)
            {
                Console.WriteLine($"EvenSum={evenSum},");
                Console.WriteLine($"EvenMin=No,");
                Console.WriteLine($"EvenMax=No,");
            }
            else
            {
                Console.WriteLine($"EvenSum={evenSum},");
                Console.WriteLine($"EvenMin={evenMin},");
                Console.WriteLine($"EvenMax={evenMax},");
            }

        }
    }
}
