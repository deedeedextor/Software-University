using System;

namespace _2.Helen_sAbduction
{
    class Program
    {
        private static int playersEnergy;
        private static int rowPlayer;
        private static int colPlayer;
        private static bool isFinished;
        private static char[][] sparta;
        private static int rows;
        private static int row;
        private static int col;

        static void Main(string[] args)
        {
            playersEnergy = int.Parse(Console.ReadLine());

            rows = int.Parse(Console.ReadLine());

            sparta = new char[rows][];

            for (row = 0; row < sparta.Length; row++)
            {
                char[] input = Console.ReadLine().ToCharArray();

                sparta[row] = new char[input.Length];

                for (col = 0; col < sparta[row].Length; col++)
                {
                    sparta[row][col] = input[col];

                    if (input[col] == 'P')
                    {
                        rowPlayer = row;
                        colPlayer = col;
                    }
                }
            }

            isFinished = false;

            while (!isFinished)
            {
                string[] tokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string direction = tokens[0];
                int rowSpartan = int.Parse(tokens[1]);
                int colSpartan = int.Parse(tokens[2]);

                sparta[rowSpartan][colSpartan] = 'S';
                sparta[rowPlayer][colPlayer] = '-';

                if (direction == "up" && IsInsideSparta(sparta, rowPlayer - 1, colPlayer))
                {
                    rowPlayer = (rowPlayer - 1);
                    CheckSpartanOrHelen();
                }

                else if (direction == "down" && IsInsideSparta(sparta, rowPlayer + 1, colPlayer))
                {
                    rowPlayer = (rowPlayer + 1);
                    CheckSpartanOrHelen();
                }

                else if (direction == "left" && IsInsideSparta(sparta, rowPlayer, colPlayer - 1))
                {
                    colPlayer = (colPlayer - 1);
                    CheckSpartanOrHelen();
                }

                else if (direction == "right" && IsInsideSparta(sparta, rowPlayer, colPlayer + 1))
                {
                    colPlayer = (colPlayer + 1);
                    CheckSpartanOrHelen();
                }

                else
                {
                    ReduceEnergy();
                }

                if (isFinished)
                {
                    break;
                }
            }

            PrintSparta(sparta);
        }

        private static void PrintSparta(char[][] sparta)
        {
            for (int row = 0; row < sparta.Length; row++)
            {
                for (int col = 0; col < sparta[row].Length; col++)
                {
                    Console.Write(sparta[row][col]);
                }
                Console.WriteLine();
            }
        }

        private static void CheckSpartanOrHelen()
        {
            ReduceEnergy();

            if (sparta[rowPlayer][colPlayer] == 'S')
            {
                playersEnergy -= 2;

                if (playersEnergy <= 0)
                {
                    PlayerIsDead();
                }

                else
                {
                    sparta[rowPlayer][colPlayer] = 'P';
                }
            }

            else if (sparta[rowPlayer][colPlayer] == 'H')
            {
                SavedHelen();
            }
        }

        private static void ReduceEnergy()
        {
            playersEnergy--;

            if (playersEnergy <= 0)
            {
                PlayerIsDead();
            }
        }

        private static void PlayerIsDead()
        {
            isFinished = true;
            sparta[rowPlayer][colPlayer] = 'X';

            Console.WriteLine($"Paris died at {rowPlayer};{colPlayer}.");
        }

        private static void SavedHelen()
        {
            isFinished = true;
            sparta[rowPlayer][colPlayer] = '-';

            Console.WriteLine($"Paris has successfully abducted Helen! Energy left: {playersEnergy}");
        }

        private static bool IsInsideSparta(char[][] sparta, int row, int col)
        {
            return row >= 0 && row < sparta.Length && col >= 0 && col < sparta[row].Length;
        }
    }
}
