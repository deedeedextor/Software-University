using System;

namespace _1.RhombusOfStarsL
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            PrintRow(size);
        }

        private static void PrintRow(int size)
        {
            for (int row = 1; row <= size; row++)
            {
                for (int col = 1; col <= size - row; col++)
                {
                    Console.Write(" ");
                }

                Console.Write("*");

                for (int col = 1; col < row; col++)
                {
                    Console.Write(" *");
                }

                Console.WriteLine();
            }

            for (int row = size - 1; row > 0; row--)
            {
                for (int col = 1; col <= size - row; col++)
                {
                    Console.Write(" ");
                }

                Console.Write("*");

                for (int col = 1; col < row; col++)
                {
                    Console.Write(" *");
                }

                Console.WriteLine();
            }
        }
    }
}
