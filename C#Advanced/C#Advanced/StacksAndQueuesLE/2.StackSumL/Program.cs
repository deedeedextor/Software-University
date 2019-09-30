using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.StackSumL
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Stack<int> numberStack = new Stack<int>(numbers);

            string input = string.Empty;

            while ((input = Console.ReadLine().ToLower()) != "end")
            {
                string[] tokens = input.Split();
                string command = tokens[0];

                if (command == "add")
                {
                    int firstNumber = int.Parse(tokens[1]);
                    int secondNumber = int.Parse(tokens[2]);

                    numberStack.Push(firstNumber);
                    numberStack.Push(secondNumber);
                }

                else if (command == "remove")
                {
                    int numberToRemove = int.Parse(tokens[1]);

                    if (numberToRemove <= numberStack.Count)
                    {
                        for (int i = 0; i < numberToRemove; i++)
                        {
                            numberStack.Pop();
                        }
                    }
                }
            }

            Console.WriteLine($"Sum: {numberStack.Sum()}");
        }
    }
}
