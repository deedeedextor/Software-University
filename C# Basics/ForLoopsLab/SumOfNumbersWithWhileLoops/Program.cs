using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumOfNumbersWithWhileLoops
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            double sum = 0;
            int counter = 0;

            while (counter < number)
            {
                double singleNumber = int.Parse(Console.ReadLine());
                sum += singleNumber;
                counter++;

                if (counter == number)
                {
                    Console.WriteLine(sum);
                    break;
                }
            }
        }
    }
}
