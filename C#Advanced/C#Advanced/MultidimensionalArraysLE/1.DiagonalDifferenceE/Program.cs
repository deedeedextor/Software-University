using System;
using System.Linq;

namespace _1.DiagonalDifferenceE
{
    class Program
    {
        static void Main(string[] args)
        {
            int dimensions = int.Parse(Console.ReadLine());

            int[,] matrix = new int[dimensions, dimensions];

            for (int row = 0; row < dimensions; row++)
            {
                int[] currentRow = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < dimensions; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            int startRow = 0;
            int startCol = 0;

            int startRowSecond = 0;
            int startColSecond = matrix.GetLength(1) - 1;

            int primarySum = 0;
            int secondarySum = 0;

            while (true)
            {
                if (startRow < 0 || startRow >= matrix.GetLength(0) || startCol < 0 || startCol >= matrix.GetLength(1))
                {
                    break;
                }

                primarySum += matrix[startRow, startCol];

                startRow++;
                startCol++;

                if (startRowSecond < 0 || startRowSecond >= matrix.GetLength(0) || startRowSecond < 0 || startRowSecond >= matrix.GetLength(1))
                {
                    break;
                }

                secondarySum += matrix[startRowSecond, startColSecond];

                startRowSecond++;
                startColSecond--;
            }

            Console.WriteLine($"{Math.Abs(primarySum - secondarySum)}");
        }
    }
}
