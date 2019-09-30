﻿using System;
using System.Numerics;

namespace _3.BigFactorialL
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            BigInteger factorial = 1;

            for (int i = 2; i <= number; i++)
            {
                factorial = factorial * i;
            }
            Console.WriteLine(factorial);
        }
    }
}
