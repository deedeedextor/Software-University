using System;
using System.Linq;

namespace _5.SquareWithMaximumSumL
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimension = Console.ReadLine()
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = dimension[0];
            int cols = dimension[1];

            int[,] squareMatrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] currentRow = Console.ReadLine()
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    squareMatrix[row, col] = currentRow[col];
                }
            }

            int maxSum = int.MinValue;
            int maxRowIndex = 0;
            int maxColIndex = 0;

            for (int row = 0; row < squareMatrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < squareMatrix.GetLength(1) - 1; col++)
                {
                    var currentSum = squareMatrix[row, col]
                        + squareMatrix[row, col + 1]
                        + squareMatrix[row + 1, col]
                        + squareMatrix[row + 1, col + 1];

                    if (currentSum > maxSum)
                    {
                        if (maxRowIndex > row && maxColIndex > col)
                        {
                            break;
                        }

                        maxSum = currentSum;
                        maxRowIndex = row;
                        maxColIndex = col;
                    }
                }
            }

            Console.WriteLine($"{squareMatrix[maxRowIndex, maxColIndex]} { squareMatrix[maxRowIndex, maxColIndex + 1]}");
            Console.WriteLine($"{squareMatrix[maxRowIndex + 1, maxColIndex]} {squareMatrix[maxRowIndex + 1, maxColIndex + 1]}");
            Console.WriteLine(maxSum);
        }
    }
}
