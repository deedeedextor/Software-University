using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.PrintEvenNumbersL
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var evenNumbersQueue = new Queue<int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                int currentNumber = numbers[i];

                if (currentNumber % 2 == 0)
                {
                    evenNumbersQueue.Enqueue(numbers[i]);
                }
            }

            Console.WriteLine(string.Join(", ", evenNumbersQueue));
        }
    }
}
