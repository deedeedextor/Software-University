using System;
using System.Collections.Generic;

namespace _3.DecimalToBinaryConverterL
{
    class Program
    {
        static void Main(string[] args)
        {
            int decimalNumber = int.Parse(Console.ReadLine());

            var binaryStack = new Stack<int>();

            if (decimalNumber == 0)
            {
                Console.WriteLine("0");
            }

            while (decimalNumber != 0)
            {
                binaryStack.Push(decimalNumber % 2);
                decimalNumber /= 2;
            }

            while (binaryStack.Count != 0)
            {
                Console.Write(binaryStack.Pop());
            }
            Console.WriteLine();
        }
    }
}
