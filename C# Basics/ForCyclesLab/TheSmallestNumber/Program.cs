using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheSmallestNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("n =");
            int n = int.Parse(Console.ReadLine());
            var min = 10000000000000;

            for (int i = 1; i <= n; i++)
            {
                var num = int.Parse(Console.ReadLine());
                if (num < min)
                {
                    min = num;
                }
            }

            Console.WriteLine("min = " + min);
        }
    }
}
