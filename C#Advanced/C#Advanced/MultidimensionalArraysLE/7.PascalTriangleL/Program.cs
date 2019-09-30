using System;

namespace _7.PascalTriangleL
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            long[][] pascalArray = new long[rows][];
            pascalArray[0] = new long[1];
            pascalArray[0][0] = 1;

            for (int row = 1; row < rows; row++)
            {
                pascalArray[row] = new long[row + 1];
                pascalArray[row][0] = 1;
                pascalArray[row][pascalArray[row].Length - 1] = 1;

                for (int col = 1; col < pascalArray[row].Length - 1; col++)
                {
                    pascalArray[row][col] += pascalArray[row - 1][col]
                        + pascalArray[row -1][col - 1];
                }
            }

            foreach (var row in pascalArray)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
