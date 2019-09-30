using System;

namespace _4.TribonacciSequenceME
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int[] tribonacci = new int[num + 1];
            tribonacci[0] = 0;

            PrintTribonacciSequence(tribonacci, num);
        }

        private static void PrintTribonacciSequence(int[] tribonacci, int num) 
        {          
            for (int i = 1; i < tribonacci.Length; i++)
            {
                if (i <= 2)
                {
                    tribonacci[i] = 1;
                    Console.Write(tribonacci[i] + " ");
                }

                else
                {
                    tribonacci[i] = tribonacci[i - 3] + tribonacci[i - 2] + tribonacci[i - 1];
                    Console.Write(tribonacci[i] + " ");
                }
            }
        }
    }
}
