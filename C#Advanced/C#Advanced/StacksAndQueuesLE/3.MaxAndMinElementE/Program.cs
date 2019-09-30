using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.MaxAndMinElementE
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberStack = new Stack<int>();

            int numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 1; i <= numberOfLines; i++)
            {
                int[] tokens = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

                int command = tokens[0];

                if (command == 1)
                {
                    int numberToPush = tokens[1];

                    numberStack.Push(numberToPush);
                }

                else if (command == 2)
                {
                    if (numberStack.Count > 0)
                    {
                        numberStack.Pop();
                    }
                }

                else if (command == 3)
                {
                    if (numberStack.Count > 0)
                    {
                        Console.WriteLine($"{numberStack.Max()}");
                    }
                }

                else if (command == 4)
                {
                    if (numberStack.Count > 0)
                    {
                        Console.WriteLine($"{numberStack.Min()}");
                    }
                }

                if (i == numberOfLines)
                {
                    Console.WriteLine(string.Join(", ", numberStack));
                }
            }
        }
    }
}
