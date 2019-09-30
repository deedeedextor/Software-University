using System;

namespace _2.ThroneConquering
{
    class Program
    {
        private static char[][] field;
        private static int rowParis;
        private static int colParis;
        private static int parisEnergy;
        private static bool isFinished;

        static void Main(string[] args)
        {
            parisEnergy = int.Parse(Console.ReadLine());

            CreateField();

            isFinished = false;

            while (!isFinished)
            {
                string[] tokens = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0];
                int rowSpartan = int.Parse(tokens[1]);
                int colSpartan = int.Parse(tokens[2]);

                field[rowSpartan][colSpartan] = 'S';
                field[rowParis][colParis] = '-';

                if (command == "up" && IsInside(field, rowParis - 1, colParis))
                {
                    rowParis = (rowParis - 1);
                    CheckSpartansOrThrone();
                }

                else if (command == "down" && IsInside(field, rowParis + 1, colParis))
                {
                    rowParis = (rowParis + 1);
                    CheckSpartansOrThrone();
                }

                else if (command == "left" && IsInside(field, rowParis, colParis - 1))
                {
                    colParis = (colParis - 1);
                    CheckSpartansOrThrone();
                }

                else if (command == "right" && IsInside(field, rowParis, colParis + 1))
                {
                    colParis = (colParis + 1);
                    CheckSpartansOrThrone();
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

            PrintField();
        }

        private static void PrintField()
        {
            for (int row = 0; row < field.Length; row++)
            {
                for (int col = 0; col < field[row].Length; col++)
                {
                    Console.Write(field[row][col]);
                }
                Console.WriteLine();
            }
        }

        private static bool IsInside(char[][] field, int row, int col)
        {
            return row >= 0 && row < field.Length && col >= 0 && col < field[row].Length;
        }

        private static void CheckSpartansOrThrone()
        {
            ReduceEnergy();

            if (field[rowParis][colParis] == 'S')
            {
                parisEnergy -= 2;

                if (parisEnergy <= 0)
                {
                    IsDead();
                }

                else
                {
                    field[rowParis][colParis] = 'P';
                }
            }

            else if (field[rowParis][colParis] == 'H')
            {
                FoundThrone();

            }
        }

        private static void FoundThrone()
        {
            isFinished = true;
            field[rowParis][colParis] = '-';

            Console.WriteLine($"Paris has successfully sat on the throne! Energy left: {parisEnergy}");
        }

        private static void ReduceEnergy()
        {
            parisEnergy--;

            if (parisEnergy <= 0)
            {
                IsDead();
            }
        }

        private static void IsDead()
        {
            isFinished = true;
            field[rowParis][colParis] = 'X';

            Console.WriteLine($"Paris died at {rowParis};{colParis}.");
        }

        private static void CreateField()
        {
            int dimensions = int.Parse(Console.ReadLine());

            field = new char[dimensions][];

            for (int row = 0; row < dimensions; row++)
            {
                char[] currentRow = Console.ReadLine().ToCharArray();

                field[row] = new char[currentRow.Length];

                for (int col = 0; col < dimensions; col++)
                {
                    field[row][col] = currentRow[col];

                    if (field[row][col] == 'P')
                    {
                        rowParis = row;
                        colParis = col;
                    }
                }
            }
        }
    }
}
