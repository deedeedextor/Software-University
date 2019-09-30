using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.BasicStackOperationsE
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numberCommands = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int numberToPush = numberCommands[0];
            int numberToPop = numberCommands[1];
            int numberToCheck = numberCommands[2];

            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var numberStack = new Stack<int>();

            for (int i = 0; i < numberToPush; i++)
            {
                numberStack.Push(numbers[i]);
            }

            for (int j = 0; j < numberToPop; j++)
            {
                numberStack.Pop();
            }

            if (numberStack.Contains(numberToCheck))
            {
                Console.WriteLine("true");
            }

            else
            {
                if (numberStack.Count == 0)
                {
                    Console.WriteLine("0");
                }

                else
                {
                    Console.WriteLine($"{numberStack.Min()}");
                }
            }
        }
    }
}
