using System;

namespace _2._2PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int tempNumber = 1;

            for (int row = 0; row < number; row++)
            {
                for (int col = 0; col <= row; col++)
                {
                    if (row == 0 || col == 0)
                    {
                        tempNumber = 1;
                        Console.Write(tempNumber + " ");
                    }
                    else
                    {
                        tempNumber = tempNumber * (row - col + 1) / col;
                        Console.Write(tempNumber + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
