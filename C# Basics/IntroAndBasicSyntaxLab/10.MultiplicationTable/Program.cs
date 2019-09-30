using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.MultiplicationTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int result = 0;

            for (int i = 1; i <= 10; i++)
            {
                result = n * i;
                Console.WriteLine($"{n} X {i} = {result}");
            }
        }
    }
}
