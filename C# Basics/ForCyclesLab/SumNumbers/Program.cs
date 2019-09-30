using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("n= ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the numbers:");
            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                sum = sum + num;
            }

            Console.WriteLine("sum = " + sum);
        }
    }
}
