using System;

namespace _11.MathOperationsL
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            string symbol = Console.ReadLine();
            int secondNumber = int.Parse(Console.ReadLine());

            double result = CalculateNumbers(firstNumber, symbol, secondNumber);
            Console.WriteLine($"{result}");
        }

        public static double CalculateNumbers(int first, string @operator, int second)
        {
            double result = 0;

            switch (@operator)
            {
                case "+":
                    result = first + second;
                    break;
                case "-":
                    result = first - second;
                    break;
                case "*":
                    result = first * second;
                    break;
                case "/":
                    result = first / second;
                    break;               
            }
            return result;
        }
    }
}
