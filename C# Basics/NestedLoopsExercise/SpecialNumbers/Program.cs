using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.SpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int num = 1111; num <= 9999; num++)
            {

                int a = num % 10 / 1;
                int b = num % 100 / 10;
                int c = num % 1000 / 100;
                int d = num % 10000 / 1000;

                if (a == 0 || b == 0 || c == 0 || d == 0)
                { continue; }
                if (n % a == 0 && n % b == 0 && n % c == 0 && n % d == 0)
                {
                    Console.Write($"{num} ");
                }
            }
            Console.WriteLine();
        }
    }
}