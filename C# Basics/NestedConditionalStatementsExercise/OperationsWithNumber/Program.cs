using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationsWithNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            double num1 = double.Parse(Console.ReadLine());
            double num2 = double.Parse(Console.ReadLine());
            char operation = Convert.ToChar(Console.ReadLine());

            double result = 0.0;

            if (operation == '+')
            {
                result = num1 + num2;
            }

            else if (operation == '-')
            {
                result = num1 - num2;
            }

            else if (operation == '*')
            {
                result = num1 * num2;
            }

            if (operation == '+' || operation == '-' || operation == '*')
            {
                if (result % 2 == 0)
                {
                    Console.WriteLine($"{num1} {operation} {num2} = {result} - even");
                }
                else
                {
                    Console.WriteLine($"{num1} {operation} {num2} = {result} - odd");
                }
            }
               

            else if (operation == '/')
            {
                result = num1 / num2;

                if (num2 != 0)
                {
                    Console.WriteLine($"{num1} / {num2} = {result:f2}");
                }
                else
                {
                    Console.WriteLine($"Cannot divide {num1} by zero");
                }
            }
            else if (operation == '%')
            {
                result = num1 % num2;

                if (num2 != 0)
                {
                    Console.WriteLine($"{num1} % {num2} = {result}");
                }
                else
                {
                    Console.WriteLine($"Cannot divide {num1} by zero");
                }
            }
        }
    }
}
