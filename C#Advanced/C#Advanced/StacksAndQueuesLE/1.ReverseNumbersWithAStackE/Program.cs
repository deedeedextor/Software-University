using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.ReverseNumbersWithAStackE
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var numbersStack = new Stack<int>();

            foreach (var number in numbers)
            {
                numbersStack.Push(number);
            }

            Console.WriteLine(string.Join(" ", numbersStack));
        }
    }
}
