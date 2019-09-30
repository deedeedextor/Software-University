namespace P03_JediGalaxy
{
    using System;
    using System.Linq;

    public class Program
    {
        static void Main()
        {
            int[,] matrix = CreateGalaxy();

            string input = string.Empty;
            long sum = 0;

            while ((input = Console.ReadLine()) != "Let the Force be with you")
            {
                int[] coordinatesIvo = input
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int[] coordinatesEvel = Console.ReadLine()
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int rowEvel = coordinatesEvel[0];
                int colEvel = coordinatesEvel[1];

                while (rowEvel >= 0 && colEvel >= 0)
                {
                    if (rowEvel >= 0 && rowEvel < matrix.GetLength(0) && colEvel >= 0 && colEvel < matrix.GetLength(1))
                    {
                        matrix[rowEvel, colEvel] = 0;
                    }

                    rowEvel--;
                    colEvel--;
                }

                int rowIvo = coordinatesIvo[0];
                int colIvo = coordinatesIvo[1];

                while (rowIvo >= 0 && colIvo < matrix.GetLength(1))
                {
                    if (rowIvo >= 0 && rowIvo < matrix.GetLength(0) && colIvo >= 0 && colIvo < matrix.GetLength(1))
                    {
                        sum += matrix[rowIvo, colIvo];
                    }

                    colIvo++;
                    rowIvo--;
                }
            }

            Console.WriteLine(sum);

        }

        private static int[,] CreateGalaxy()
        {
            int[] dimestions = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = dimestions[0];
            int cols = dimestions[1];

            int[,] galaxy = new int[rows, cols];

            int value = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    galaxy[row, col] = value++;
                }
            }

            return galaxy;
        }
    }
}
