using System;

namespace _4.PrintTriangleL
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            PrintTriangle(number);
            PrintReversedTriangle(number-1);
        }

        public static void PrintTriangle(int number)
        {
            for (int row = 1; row <= number; row++)
                PrintRowWithNumbers(row);
        }

        public static void PrintReversedTriangle(int number)
        {
            for (int row = number; row >= 1; row--)
            {
                PrintRowWithNumbers(row);
            }
        }

        private static void PrintRowWithNumbers(int row)
        {
            for (int col = 1; col <= row; col++)
            {
                Console.Write(col + " ");
            }
            Console.WriteLine();
        }
    }
}
