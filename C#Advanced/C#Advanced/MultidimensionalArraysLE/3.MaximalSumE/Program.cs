using System;
using System.Linq;

namespace _3.MaximalSumE
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] symbols = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = symbols[col];
                }
            }

            int maxSum = int.MinValue;
            int startRowIndex = 0;
            int startColIndex = 0;

            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    int currentSum = matrix[row, col]
                        + matrix[row, col + 1]
                        + matrix[row, col + 2]
                        + matrix[row + 1, col]
                        + matrix[row + 1, col + 1]
                        + matrix[row + 1, col + 2]
                        + matrix[row + 2, col]
                        + matrix[row + 2, col + 1]
                        + matrix[row + 2, col + 2];

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;

                        startRowIndex = row;
                        startColIndex = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");

            Console.WriteLine($"{matrix[startRowIndex, startColIndex]} {matrix[startRowIndex, startColIndex + 1]} {matrix[startRowIndex, startColIndex + 2]}");
            Console.WriteLine($"{matrix[startRowIndex + 1, startColIndex]} {matrix[startRowIndex + 1, startColIndex + 1]} {matrix[startRowIndex + 1, startColIndex + 2]}");
            Console.WriteLine($"{matrix[startRowIndex + 2, startColIndex]} {matrix[startRowIndex + 2, startColIndex + 1]} {matrix[startRowIndex + 2, startColIndex + 2]}");
        }
    }
}
