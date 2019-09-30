using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLowerNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int min = int.MaxValue;

            for (int i = 0; i < number; i++)
            {
                int singleNumber = int.Parse(Console.ReadLine());

                if (singleNumber < min)
                {
                    min = singleNumber;
                }
            }

            Console.WriteLine("min = " + min);
        }
    }
}
