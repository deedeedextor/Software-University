using System;

namespace _4.RefactoringPrimeChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            long number = Math.Abs(long.Parse(Console.ReadLine()));


            for (int i = 2; i <= number; i++)
            {
                string isPrime = "true";

                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = "false";
                        break;
                    }
                }
                Console.WriteLine($"{i} -> {isPrime}");
            }
        }
    }
}
