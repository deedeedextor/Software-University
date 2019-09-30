using System;

namespace _3._3._1RecursiveFibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine(Fibonacci(number-1));
        }

        private static int Fibonacci(int x)
        {
            if (x <= 1)
            {
                return 1;
                return Fibonacci(x - 1) + Fibonacci(x - 2);
            }
        }
    }
}
