using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.MultiplicationTable2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int multiplier = int.Parse(Console.ReadLine());
            int result = 0;

            if (multiplier > 10)
            {
                result = n * multiplier;
                Console.WriteLine($"{n} X {multiplier} = {result}");
            }

            for (int i = multiplier; i <= 10; i++)
            {
                result = n * i;
                Console.WriteLine($"{n} X {i} = {result}");
            }
        }
    }
}
