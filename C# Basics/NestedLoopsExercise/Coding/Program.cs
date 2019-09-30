using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int lenghtOfNum = num.ToString().Length;

            for (int i = 0; i < lenghtOfNum; i++)
            {
                int lastNum = num % 10;
                if (lastNum != 0)
                {
                    for (int j = 0; j < lastNum; j++)
                    {
                        Console.Write((char)(lastNum + 33));
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("ZERO");
                }

                
                num /= 10;
            }

        }
    }
}
