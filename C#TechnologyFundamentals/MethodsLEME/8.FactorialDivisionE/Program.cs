using System;

namespace _8.FactorialDivisionE
{
    class Program
    {
        static void Main(string[] args)
        {
            long firstNumber = long.Parse(Console.ReadLine());
            long secondNumber = long.Parse(Console.ReadLine());

            long firstFactorial = CalculateFactorial(firstNumber);
            long secondFactorial = CalculateFactorial(secondNumber);
            double finalResult = (double)firstFactorial / secondFactorial;

            Console.WriteLine($"{finalResult:F2}");
        }

        private static long CalculateFactorial(long firstInt)
        {
            long factorial = 1;

            for (int i = 2; i <= firstInt; i++)
            {
                factorial *= i;
            }
            return factorial;
        }
    }
}
