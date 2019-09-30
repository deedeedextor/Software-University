using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.RemoveNegativesAndReverseL
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> positiveNumbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .Where(number => number >= 0)
                .ToList();

            positiveNumbers.Reverse();

            if (positiveNumbers.Count == 0)
            {
                Console.WriteLine("empty");
            }
            else
            {
                Console.WriteLine(string.Join(" ", positiveNumbers));
            }
        }
    }
}
