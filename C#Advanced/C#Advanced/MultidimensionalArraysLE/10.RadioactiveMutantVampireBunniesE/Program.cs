using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.RadioactiveMutantVampireBunniesE
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];

            char[,] matrix = new char[rows, cols];

            int playerRow = -1;
            int playerCol = -1;

            for (int row = 0; row < rows; row++)
            {
                var elements = Console.ReadLine().Replace(" ", "").ToCharArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = elements[col];

                    if (elements[col].Equals('P'))
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            matrix[playerRow, playerCol] = '.';

            var commands = Console.ReadLine().ToCharArray();

            var queue = new Queue<char>(commands);

            var newPlayerRow = playerRow;
            var newPlayerCol = playerCol;

            while (queue.Count > 0)
            {
                switch (queue.Dequeue())
                {
                    case 'U': newPlayerRow -= 1; break;
                    case 'D': newPlayerRow += 1; break;
                    case 'L': newPlayerCol -= 1; break;
                    case 'R': newPlayerCol += 1; break;
                }

                matrix = MultyplyBunnies(matrix, rows, cols);

                if (newPlayerRow >= 0 && newPlayerRow < matrix.GetLength(0)
                    && newPlayerCol >= 0 && newPlayerCol < matrix.GetLength(1))
                {
                    playerRow = newPlayerRow;
                    playerCol = newPlayerCol;

                    if (matrix[playerRow, playerCol] == 'B')
                    {
                        PrintMatrix(matrix, rows, cols);
                        Console.WriteLine($"dead: {playerRow} {playerCol}");
                        return;
                    }
                }
                else
                {
                    PrintMatrix(matrix, rows, cols);
                    Console.WriteLine($"won: {playerRow} {playerCol}");
                    return;
                }

            }
        }
        public static char[,] MultyplyBunnies(char[,] matrix, int rows, int cols)
        {
            var newMatrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    newMatrix[row, col] = matrix[row, col];
                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        if (row - 1 >= 0)
                        {
                            newMatrix[row - 1, col] = 'B';
                        }
                        if (col - 1 >= 0)
                        {
                            newMatrix[row, col - 1] = 'B';
                        }
                        if (col + 1 < cols)
                        {
                            newMatrix[row, col + 1] = 'B';
                        }
                        if (row + 1 < rows)
                        {
                            newMatrix[row + 1, col] = 'B';
                        }
                    }
                }
            }
            return newMatrix;
        }
        public static void PrintMatrix(char[,] matrix, int rows, int cols)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}