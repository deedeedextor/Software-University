using System;
using System.Linq;

namespace _4.ReverseArrayOfStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] symbols = Console.ReadLine().Split();           

            for (int i = symbols.Length - 1; i >= 0; i--)
            {
                Console.Write(symbols[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
