using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGreasestCommonDivider1
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            if (a != b)
            {
                while ((a != 0) && (b != 0))
                {
                    int a1 = a;
                    a = a % b;
                    b = b % a1;
                }

                if (a == 0)
                {
                    Console.WriteLine(b);
                }
                else
                {
                    Console.WriteLine(a);
                }
            }

            else
            {
                Console.WriteLine(a);
            }
     
        }

    }
}
