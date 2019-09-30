using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.CountSameValueInArrayL
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbersCount = new Dictionary<double, int>();

            double[] numbers = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();

            foreach (var number in numbers)
            {
                if (!numbersCount.ContainsKey(number))
                {
                    numbersCount[number] = 0;
                }

                numbersCount[number]++;
            }

            foreach (var numberKvp in numbersCount)
            {
                double number = numberKvp.Key;
                int count = numberKvp.Value;

                Console.WriteLine($"{number} - {count} times");
            }
        }
    }
}
