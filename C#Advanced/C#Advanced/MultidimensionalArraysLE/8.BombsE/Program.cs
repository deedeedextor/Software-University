using System;
using System.Linq;

namespace _8.BombsE
{
    class Program
    {
        static void Main(string[] args)
        {
            int dimensions = int.Parse(Console.ReadLine());

            int[,] matrix = new int[dimensions, dimensions];

            for (int row = 0; row < dimensions; row++)
            {
               int[] numbersInput = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < dimensions; col++)
                {
                    matrix[row, col] = numbersInput[col];
                }
            }

            string[] coordinates = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

            int rowIndex = 0;
            int colIndex = 0;

            for (int i = 0; i < coordinates.Length; i++)
            {
                string[] rowsAndCols = coordinates[i].Split(',');

                rowIndex = int.Parse(rowsAndCols[0]);
                colIndex = int.Parse(rowsAndCols[1]);

                if (matrix[rowIndex, colIndex] > 0)
                {
                    int numberToSubtract = matrix[rowIndex, colIndex];

                    for (int direction = 0; direction < 9; direction++)
                    {
                        int newRow = rowIndex + ((direction % 3) - 1);
                        int newCol = colIndex + ((direction / 3) - 1);

                        if (newRow >= 0 && newRow < matrix.GetLength(0) && newCol >= 0 && newCol < matrix.GetLength(1))
                        {
                            if (matrix[newRow, newCol] > 0)
                            {
                                matrix[newRow, newCol] -= numberToSubtract;
                            }
                        }
                    }
                }
            }

            int aliveCells = 0;
            int sum = 0;

            for (int row = 0; row < dimensions; row++)
            {
                for (int col = 0; col < dimensions; col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        aliveCells++;
                        sum += matrix[row, col];
                    }
                }
            }

            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sum}");

            for (int row = 0; row < dimensions; row++)
            {
                for (int col = 0; col < dimensions; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
