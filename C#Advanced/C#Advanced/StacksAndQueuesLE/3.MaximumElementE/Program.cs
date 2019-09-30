using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.MaximumElementE
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());

            var numberStack = new Stack<int>();

            for (int i = 0; i < numberOfLines; i++)
            {
                int[] input = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                int command = input[0];

                if (command == 1)
                {
                    int numberToPush = input[1];

                    numberStack.Push(numberToPush);
                }

                else if (command == 2)
                {
                    numberStack.Pop();
                }

                else if (command == 3)
                {
                    Console.WriteLine($"{numberStack.Max()}");
                }
            }
        }
    }
}
