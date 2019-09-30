using System;

namespace _3._3RecursiveFibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            GetFibonacci(number);
        }

        static void GetFibonacci(int number)
        {
            int[] result = new int[49];
            result[0] = 1;
            result[1] = 1;

            for (int i = 2; i < number; i++)
            {
                result[i] = result[i - 2] + result[i - 1];
            }
            Console.WriteLine(result[number-1]);
        }
    }
}
