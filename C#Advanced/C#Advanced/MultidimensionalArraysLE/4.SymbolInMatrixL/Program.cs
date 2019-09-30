using System;

namespace _4.SymbolInMatrixL
{
    class Program
    {
        static void Main(string[] args)
        {
            int dimensions = int.Parse(Console.ReadLine());

            char[,] matrix = new char[dimensions, dimensions];

            bool isMatch = false;

            for (int row = 0; row < dimensions; row++)
            {
                string input = Console.ReadLine();

                for (int col = 0; col < dimensions; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            char symbol = char.Parse(Console.ReadLine());
            string indexes = string.Empty;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col].Equals(symbol))
                    {
                        indexes = $"({row.ToString()}, {col.ToString()})";
                        isMatch = true;
                        break;
                    }
                }

                if (isMatch)
                {
                    break;
                }
                
            }

            if (indexes.Length != 0)
            {
                Console.WriteLine($"{indexes}");
            }

            else
            {
                Console.WriteLine($"{symbol} does not occur in the matrix");
            }
        }
    }
}
