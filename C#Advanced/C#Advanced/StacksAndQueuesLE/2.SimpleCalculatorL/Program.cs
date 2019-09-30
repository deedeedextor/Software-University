using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.SimpleCalculatorL
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var values = input.Split(' ');

            var calculatorStack = new Stack<string>(values.Reverse());

            while (calculatorStack.Count > 1)
            {
                int first = int.Parse(calculatorStack.Pop());
                string sign = calculatorStack.Pop();
                int second = int.Parse(calculatorStack.Pop());

                switch (sign)
                {
                    case "+":
                        calculatorStack.Push((first + second).ToString());
                        break;
                    case "-":
                        calculatorStack.Push((first - second).ToString());
                        break;
                }
            }

            Console.WriteLine(calculatorStack.Pop());
        }
    }
}
