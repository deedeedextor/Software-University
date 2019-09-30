using System;
using System.Linq;

namespace _6.JaggedArrayModificationL
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

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] matrixProps = input.Split();

                string command = matrixProps[0];
                int currRow = int.Parse(matrixProps[1]);
                int currCol = int.Parse(matrixProps[2]);
                int value = int.Parse(matrixProps[3]);

                if (currRow >= 0 && currRow <= matrix.GetLength(0) - 1 && currCol >= 0 && currCol <= matrix.GetLength(1) - 1)
                {
                    if (command == "Add")
                    {
                        matrix[currRow, currCol] += value;
                    }

                    else if (command == "Subtract")
                    {
                        matrix[currRow, currCol] -= value;
                    }
                }

                else
                {
                    Console.WriteLine("Invalid coordinates");
                    continue;
                }
            }

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
