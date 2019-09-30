using System;
using System.Linq;

namespace _3.PrimaryDiagonalL
{
    class Program
    {
        static void Main(string[] args)
        {
            int dimensions = int.Parse(Console.ReadLine());

            var matrix = new int[dimensions, dimensions];

            for (int row = 0; row < dimensions; row++)
            {
                int[] currentRow = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < dimensions; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            int startRow = 0;
            int startCol = 0;
            int sum = 0;

            while (true)
            {
                if (startRow < 0 || startRow >= matrix.GetLength(0) || startCol < 0 || startCol >= matrix.GetLength(1))
                {
                    break;
                }

                sum += matrix[startRow, startCol];

                startRow++;
                startCol++;
            }

            Console.WriteLine(sum);
        }
    }
}
