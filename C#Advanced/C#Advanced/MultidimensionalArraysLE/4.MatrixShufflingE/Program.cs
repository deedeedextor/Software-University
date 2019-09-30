using System;
using System.Linq;

namespace _4.MatrixShufflingE
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];

            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] input = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            string props = string.Empty;

            while ((props = Console.ReadLine().ToLower()) != "end")
            {
                string[] commandProps = props.Split();

                if (commandProps.Length == 5 && commandProps[0].Contains("swap"))
                {
                    int firstRowIndex = int.Parse(commandProps[1]);
                    int firstColIndex = int.Parse(commandProps[2]);
                    int secondRowIndex = int.Parse(commandProps[3]);
                    int secondColIndex = int.Parse(commandProps[4]);

                    if (firstRowIndex < 0 || firstRowIndex >= matrix.GetLength(0)
                        || firstColIndex < 0 || firstColIndex >= matrix.GetLength(1)
                        || secondRowIndex < 0 || secondRowIndex >= matrix.GetLength(0)
                        || secondColIndex < 0 || secondColIndex >= matrix.GetLength(1))
                    {
                        Console.WriteLine("Invalid input!");
                        continue;
                    }

                    var temp = matrix[firstRowIndex, firstColIndex];
                    matrix[firstRowIndex, firstColIndex] = matrix[secondRowIndex, secondColIndex];
                    matrix[secondRowIndex, secondColIndex] = temp;

                    for (int row = 0; row < rows; row++)
                    {
                        for (int col = 0; col < cols; col++)
                        {
                            Console.Write(matrix[row, col] + " ");
                        }
                        Console.WriteLine();
                    }
                }

                else
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
            }
        }
    }
}
