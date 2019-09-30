using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddOrEven
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("n =");
            int n = int.Parse(Console.ReadLine());
            int evenSum = 0;
            int oddSum = 0;

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (i % 2 == 0)
                {
                    evenSum += num;
                }
                else
                {
                    oddSum += num;
                }
            }

            if (evenSum == oddSum)
            {
                Console.WriteLine("Yes, sum = " + evenSum);
            }
            else
            {
                int difference = Math.Abs(evenSum - oddSum);
                Console.WriteLine("No, diff = " + difference);
            }
        }
    }
}
