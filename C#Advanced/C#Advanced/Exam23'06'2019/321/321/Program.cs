using System;

namespace _321
{
    class Program
    {
        private static char[,] galaxy;
        private static int rowPlayer;
        private static int colPlayer;
        private static int neededStars;
        private static int collectedStars;
        private static bool isStarsOrVoid;

        static void Main(string[] args)
        {
            CreateGalaxy();

            isStarsOrVoid = false;
            neededStars = 50;

            while (!isStarsOrVoid)
            {
                string input = Console.ReadLine();

                galaxy[rowPlayer, colPlayer] = '-';

                if (input == "up" && IsInside(galaxy, rowPlayer - 1, colPlayer))
                {
                    rowPlayer = (rowPlayer - 1);
                    CheckPlace();
                }

                else if (input == "down" && IsInside(galaxy, rowPlayer + 1, colPlayer))
                {
                    rowPlayer = (rowPlayer + 1);
                    CheckPlace();
                }

                else if (input == "left" && IsInside(galaxy, rowPlayer, colPlayer - 1))
                {
                    colPlayer = (colPlayer - 1);
                    CheckPlace();
                }

                else if (input == "right" && IsInside(galaxy, rowPlayer, colPlayer + 1))
                {
                    colPlayer = (colPlayer + 1);
                    CheckPlace();
                }

                else
                {
                    isStarsOrVoid = true;
                    Console.WriteLine($"Bad news, the spaceship went to the void.");
                }

                if (isStarsOrVoid)
                {
                    break;
                }
            }

            Console.WriteLine($"Star power collected: {collectedStars}");

            PrintGalaxy();
        }

        private static void PrintGalaxy()
        {
            for (int row = 0; row < galaxy.GetLength(0); row++)
            {
                for (int col = 0; col < galaxy.GetLength(1); col++)
                {
                    Console.Write( galaxy[row, col]);
                }

                Console.WriteLine();
            }
        }

        private static void CheckPlace()
        {
            if (char.IsDigit(galaxy[rowPlayer, colPlayer]))
            {
                int currentChar = (int)char.GetNumericValue(galaxy[rowPlayer, colPlayer]);

                collectedStars += currentChar;
                galaxy[rowPlayer, colPlayer] = '-';

                if (collectedStars >= neededStars)
                {
                    isStarsOrVoid = true;
                    galaxy[rowPlayer, colPlayer] = 'S';
                    Console.WriteLine($"Good news! Stephen succeeded in collecting enough star power!");
                }
            }

            else if (galaxy[rowPlayer, colPlayer] == 'O')
            {
                galaxy[rowPlayer, colPlayer] = '-';

                for (int row = 0; row < galaxy.GetLength(0); row++)
                {
                    for (int col = 0; col < galaxy.GetLength(1); col++)
                    {
                        if (row != rowPlayer && col != colPlayer && galaxy[row, col] == 'O')
                        {
                            rowPlayer = row;
                            colPlayer = col;

                            galaxy[row, col] = 'S';
                        }
                    }
                }
            }
        }

        private static bool IsInside(char[,] galaxy, int row, int col)
        {
            return row >= 0 && row < galaxy.GetLength(0) && col >= 0 && col < galaxy.GetLength(1);
        }

        private static void CreateGalaxy()
        {
            int rows = int.Parse(Console.ReadLine());

            galaxy = new char[rows, rows];

            for (int row = 0; row < rows; row++)
            {
                char[] currentRow = Console.ReadLine().Replace(" ", "").ToCharArray();

                for (int col = 0; col < rows; col++)
                {
                    galaxy[row, col] = currentRow[col];

                    if (galaxy[row, col] == 'S')
                    {
                        rowPlayer = row;
                        colPlayer = col;
                    }
                }
            }
        }
    }
}
