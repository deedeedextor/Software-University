﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBiggerNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("n =");
            int n = int.Parse(Console.ReadLine());
            var max = -10000000000000;

            for (int i = 1; i <= n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (num > max)
                {
                    max = num;
                }
            }

            Console.WriteLine("max = " + max);
        }
    }
}
