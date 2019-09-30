using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[size, size];

            for (int row = 0; row < size; row++)
            {
                int[] currentRow = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            string[] coordinates = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int rowIndex = 0;
            int colIndex = 0;

            for (int i = 0; i < coordinates.Length; i++)
            {
                string[] bombsIndexes = coordinates[i].Split(',', StringSplitOptions.RemoveEmptyEntries);

                rowIndex = int.Parse(bombsIndexes[0]);
                colIndex = int.Parse(bombsIndexes[1]);

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

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
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

            StringBuilder sb = new StringBuilder();

            for (int row = 0; row < size; row++)
            {
                List<int> line = new List<int>();

                for (int col = 0; col < size; col++)
                {
                    line.Add(matrix[row, col]);
                }

                sb.AppendLine(string.Join(" ", line));
            }

            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}
