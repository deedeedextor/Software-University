using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._EvenTimesE
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new Dictionary<int, int>();

            int numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (!numbers.ContainsKey(number))
                {
                    numbers[number] = 0;
                }

                numbers[number]++;
            }

            // int evenTimesNumber = numbers.SingleOrDefault(number => number.Value % 2 == 0).Key;
            // cw(evenTimesNumber);

            foreach (var numberKvp in numbers)
            {
                int numberToCheck = numberKvp.Key;
                int evenTimes = numberKvp.Value;

                if (evenTimes % 2 == 0)
                {
                    Console.WriteLine(numberToCheck);
                }
            }
        }
    }
}
