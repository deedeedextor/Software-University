using System;
using System.Collections.Generic;
using System.Linq;

namespace _4.BasicQueueOperationsE
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberQueue = new Queue<int>();

            int[] numberCommands = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int numberToAdd = numberCommands[0];
            int numberToDelete = numberCommands[1];
            int numberToCheck = numberCommands[2];

            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < numberToAdd; i++)
            {
                numberQueue.Enqueue(numbers[i]);
            }

            for (int j = 0; j < numberToDelete; j++)
            {
                numberQueue.Dequeue();
            }

            if (numberQueue.Contains(numberToCheck))
            {
                Console.WriteLine("true");
            }

            else
            {
                if (numberQueue.Count == 0)
                {
                    Console.WriteLine("0");
                }

                else
                {
                    Console.WriteLine(numberQueue.Min());
                }
            }

        }
    }
}
