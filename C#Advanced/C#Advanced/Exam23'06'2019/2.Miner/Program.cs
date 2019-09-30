using System;

namespace _2.Miner
{
    class Program
    {
        private static int size;
        private static char[,] mine;
        private static int rowMiner;
        private static int colMiner;
        private static int leftCoals;
        private static bool isOver;


        static void Main(string[] args)
        {
            size = int.Parse(Console.ReadLine());

            string[] commands = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            CreateMine();

            isOver = false;

            for (int i = 0; i < commands.Length; i++)
            {
                string currentCommand = commands[i];

                if (currentCommand == "up" && IsInside(mine, rowMiner - 1, colMiner))
                {
                    rowMiner = (rowMiner - 1);
                    CheckMine();
                }

                else if (currentCommand == "down" && IsInside(mine, rowMiner + 1, colMiner))
                {
                    rowMiner = (rowMiner + 1);
                    CheckMine();
                }

                else if (currentCommand == "left" && IsInside(mine, rowMiner, colMiner - 1))
                {
                    colMiner = (colMiner - 1);
                    CheckMine();
                }

                else if (currentCommand == "right" && IsInside(mine, rowMiner, colMiner + 1))
                {
                    colMiner = (colMiner + 1);
                    CheckMine();
                }

                if (isOver)
                {
                    break;
                }

                if (i == commands.Length - 1 && !isOver)
                {
                    Console.WriteLine($"{leftCoals} coals left. ({rowMiner}, {colMiner})");
                }
            }
        }

        private static void CheckMine()
        {
            if (mine[rowMiner, colMiner] == 'c')
            {
                leftCoals--;
                mine[rowMiner, colMiner] = '*';

                if (leftCoals == 0)
                {
                    isOver = true;
                    Console.WriteLine($"You collected all coals! ({rowMiner}, {colMiner})");
                }
            }

            else if (mine[rowMiner, colMiner] == 'e')
            {
                isOver = true;
                Console.WriteLine($"Game over! ({rowMiner}, {colMiner})");
            }
        }

        private static bool IsInside(char[,] mine, int row, int col)
        {
            return row >= 0 && row < mine.GetLength(0) && col >= 0 && col < mine.GetLength(1);
        }

        private static void CreateMine()
        {
            mine = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                char[] currentRow = Console.ReadLine().Replace(" ", "").ToCharArray();

                for (int col = 0; col < size; col++)
                {
                    mine[row, col] = currentRow[col];

                    if (mine[row, col] == 's')
                    {
                        rowMiner = row;
                        colMiner = col;
                    }

                    else if (mine[row, col] == 'c')
                    {
                        leftCoals++;
                    }
                }
            }
        }
    }
}
