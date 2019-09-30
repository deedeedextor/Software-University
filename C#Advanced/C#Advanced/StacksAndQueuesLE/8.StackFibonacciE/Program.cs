using System;
using System.Collections.Generic;

namespace _8.StackFibonacciE
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            var fibonacciStack = new Stack<long>();

            fibonacciStack.Push(0);
            fibonacciStack.Push(1);

            for (int i = 0; i < number - 1; i++)
            {
                long firstNumber = fibonacciStack.Pop();
                long secondNumber = fibonacciStack.Peek();

                fibonacciStack.Push(firstNumber);
                fibonacciStack.Push(firstNumber + secondNumber);
            }

            Console.WriteLine(fibonacciStack.Peek());
        }
    }
}
