using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.CarRaceME
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> firstRacer = new List<int>();
            List<int> secondRacer = new List<int>();

            double firstSumRacer = 0;
            double secondSumRacer = 0;

            for (int i = 0; i < numbers.Count/2; i++)
            {
                firstRacer.Add(numbers[i]);
            }

            for (int i = numbers.Count - 1; i >= numbers.Count/2 + 1; i--)
            {
                secondRacer.Add(numbers[i]);
            }

            double firstRacerTime = GetSum(firstRacer, firstSumRacer);
            double secondRacerTime = GetSum(secondRacer, secondSumRacer);

            if (firstRacerTime < secondRacerTime)
            {
                Console.WriteLine($"The winner is left with total time: {firstRacerTime}");
            }
            else 
            {
                Console.WriteLine($"The winner is right with total time: {secondRacerTime}");
            }
        }

        private static double GetSum(List<int> lst, double sum)
        {
            for (int i = 0; i < lst.Count; i++)
            {
                int currentNumber = lst[i];
                sum += currentNumber;

                if (currentNumber == 0)
                {
                    sum = sum * 0.80;
                }
            }
            return sum;
        }
    }
}
