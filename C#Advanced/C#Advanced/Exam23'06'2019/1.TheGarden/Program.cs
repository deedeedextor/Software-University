using System;
using System.Linq;

namespace _1.TheGarden
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int countCarrots = 0;
            int countPotatoes = 0;
            int countLettuce = 0;
            int harmedVegetables = 0;

            char[][] garden = new char[rows][];

            CreateGarden(rows, garden);

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End of Harvest" )
            {
                string[] commandsTokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = commandsTokens[0];

                if (command == "Harvest")
                {
                    int row = int.Parse(commandsTokens[1]);
                    int col = int.Parse(commandsTokens[2]);

                    if (IsInside(garden, row, col))
                    {
                        if (garden[row][col] == 'L')
                        {
                            countLettuce++;
                        }

                        else if (garden[row][col] == 'P')
                        {
                            countPotatoes++;
                        }

                        else if (garden[row][col] == 'C')
                        {
                            countCarrots++;
                        }

                        garden[row][col] = ' ';
                    }
                }

                else if (command == "Mole")
                {
                    int row = int.Parse(commandsTokens[1]);
                    int col = int.Parse(commandsTokens[2]);
                    string direction = commandsTokens[3];

                    if (IsInside(garden, row, col))
                    {
                        if (direction == "up")
                        {
                            harmedVegetables = MoveUp(harmedVegetables, garden, row, col);
                        }

                        else if (direction == "down")
                        {
                            harmedVegetables = MoveDown(harmedVegetables, garden, row, col);
                        }

                        else if (direction == "left")
                        {
                            harmedVegetables = MoveLeft(harmedVegetables, garden, row, col);
                        }

                        else if (direction == "right")
                        {
                            harmedVegetables = MoveRight(harmedVegetables, garden, row, col);
                        }
                    }
                }
            }

            PrintGarden(garden);
            PrintInformation(countCarrots, countLettuce, countPotatoes, harmedVegetables);
        }

        private static void PrintInformation(int countCarrots, int countLettuce, int countPotatoes, int harmedVegetables)
        {
            Console.WriteLine($"Carrots: {countCarrots}\nPotatoes: {countPotatoes}\nLettuce: {countLettuce}" +
                $"\nHarmed vegetables: {harmedVegetables}");
        }

        private static void PrintGarden(char[][] garden)
        {
            foreach (var row in garden)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }

        private static int MoveRight(int harmedVegetables, char[][] garden, int row, int col)
        {
            for (int currentCol = col; currentCol < garden[row].Length; currentCol += 2)
            {
                if (garden[row][currentCol] == 'L' || garden[row][currentCol] == 'P' || garden[row][currentCol] == 'C')
                {
                    harmedVegetables++;
                    garden[row][currentCol] = ' ';
                }
            }

            return harmedVegetables;
        }

        private static int MoveLeft(int harmedVegetables, char[][] garden, int row, int col)
        {
            for (int currentCol = col; currentCol >= 0; currentCol -= 2)
            {
                if (garden[row][currentCol] == 'L' || garden[row][currentCol] == 'P' || garden[row][currentCol] == 'C')
                {
                    harmedVegetables++;
                    garden[row][currentCol] = ' ';
                }
            }

            return harmedVegetables;
        }

        private static int MoveDown(int harmedVegetables, char[][] garden, int row, int col)
        {
            for (int currentRow = row; currentRow < garden.Length; currentRow+=2)
            {
                if (garden[currentRow][col] == 'L' || garden[currentRow][col] == 'P' || garden[currentRow][col] == 'C')
                {
                    harmedVegetables++;
                    garden[currentRow][col] = ' ';
                }
            }

            return harmedVegetables;
        }

        private static int MoveUp(int harmedVegetables, char[][] garden, int row, int col)
        {
            for (int currentRow = row; currentRow >= 0; currentRow-=2)
            {
                if (garden[currentRow][col] == 'L' || garden[currentRow][col] == 'P' || garden[currentRow][col] == 'C')
                {
                    harmedVegetables++;
                    garden[currentRow][col] = ' ';
                }
            }

            return harmedVegetables;
        }

        private static bool IsInside(char[][] garden, int row, int col)
        {
            return row >= 0 && row < garden.Length && col >= 0 && col < garden[row].Length;
        }

        private static void CreateGarden(int rows, char[][] garden)
        {
            for (int row = 0; row < rows; row++)
            {
                var vegetables = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                garden[row] = new char[vegetables.Length];

                for (int col = 0; col < garden[row].Length; col++)
                {
                    garden[row][col] = vegetables[col];
                }
            }
        }
    }
}
