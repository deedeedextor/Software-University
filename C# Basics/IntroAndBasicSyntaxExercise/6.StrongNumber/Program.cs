using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.StrongNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int originalNumber = int.Parse(Console.ReadLine());
            int number = originalNumber;
            int factorialSum = 0;
           
            while (number > 0)
            {
                int lastDigit = number % 10;
                number /= 10;

                int currentFactorial = 1;

                for (int i = 2; i <= lastDigit; i++)
                {
                    currentFactorial *= i;
                }

                factorialSum += currentFactorial;
            }

            if (factorialSum == originalNumber)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
