using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.SnakeMovesE
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

            char[,] matrix = new char[rows, cols];

            string input = Console.ReadLine();

            Queue<char> snake = new Queue<char>(input);

            //int counter = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0, i= 0; col < cols; col++, i++)
                {
                    //if (counter >= input.Length)
                    //{
                         //couter = 0;
                    //}

                 //matrix[row, col] = input[counter++];

                    char currentChar = snake.Peek();

                    Console.Write($"{matrix[row, col] = snake.Dequeue()}"); 
                    snake.Enqueue(currentChar);
                }
                Console.WriteLine();
            }
        }
    }
}
