using System;

namespace _2.Sneaking
{
    class Program
    {
        private static char[][] room;
        private static int rowSam;
        private static int colSam;
        private static bool isDead;
        private static int rowNikoladze;
        private static int colNikoladze;
        private static bool isKilled;


        static void Main(string[] args)
        {
            CreateRoom();

            string commands = Console.ReadLine();

            isDead = false;
            isKilled = false;

            for (int i = 0; i < commands.Length; i++)
            {
                char currentCommand = commands[i];

                room[rowSam][colSam] = '.';

                MoveEnemy();

                if (isDead)
                {
                    Console.WriteLine($"Sam died at {rowSam}, {colSam}");
                    break;
                }

                if (currentCommand == 'U')
                {
                    rowSam = (rowSam - 1);
                    CheckEnemyOrNikoladze();
                }

                else if (currentCommand == 'D')
                {
                    rowSam = (rowSam + 1);
                    CheckEnemyOrNikoladze();
                }

                else if (currentCommand == 'L')
                {
                    colSam = (colSam - 1);
                    CheckEnemyOrNikoladze();
                }

                else if (currentCommand == 'R')
                {
                    colSam = (colSam + 1);
                    CheckEnemyOrNikoladze();
                }

                if (isKilled)
                {
                    Console.WriteLine($"Nikoladze killed!");
                    break;
                }
            }

            PrintRoom();
        }

        private static void PrintRoom()
        {
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    Console.Write(room[row][col]);
                }

                Console.WriteLine();
            }
        }

        private static void CheckEnemyOrNikoladze()
        {
            if (room[rowSam][colSam] == 'b' || room[rowSam][colSam] == 'd')
            {
                room[rowSam][colSam] = '.';
            }

            else if (rowSam == rowNikoladze)
            {
                isKilled = true;
                room[rowNikoladze][colNikoladze] = 'X';
                room[rowSam][colSam] = 'S';
            }
        }

        private static void MoveEnemy()
        {
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    if (room[row][col] == 'b')
                    {
                        if (col == room[row].Length - 1)
                        {
                            room[row][col] = 'd';

                            if (rowSam == row && colSam < col)
                            {
                                isDead = true;
                                room[rowSam][colSam] = 'X';
                            }
                        }

                        else if (col < room[row].Length)
                        {
                            room[row][col] = '.';
                            room[row][col + 1] = 'b';
                            col++;

                            if (rowSam == row && colSam > col)
                            {
                                isDead = true;
                                room[rowSam][colSam] = 'X';
                            }
                        }
                    }

                    else if (room[row][col] == 'd')
                    {
                        if (col == 0)
                        {
                            room[row][col] = 'b';

                            if (rowSam == row && colSam > col)
                            {
                                isDead = true;
                                room[rowSam][colSam] = 'X';
                            }
                        }

                        else if (col > 0)
                        {
                            room[row][col] = '.';
                            room[row][col - 1] = 'd';

                            if (rowSam == row && colSam < col)
                            {
                                isDead = true;
                                room[rowSam][colSam] = 'X';
                            }
                        }
                    }
                }
            }
        }

        private static void CreateRoom()
        {
            int rows = int.Parse(Console.ReadLine());

            room = new char[rows][];

            for (int row = 0; row < rows; row++)
            {
                char[] currentRow = Console.ReadLine().Replace(" ", "").ToCharArray();

                room[row] = new char[currentRow.Length];

                for (int col = 0; col < room[row].Length; col++)
                {
                    room[row][col] = currentRow[col];

                    if (room[row][col] == 'S')
                    {
                        rowSam = row;
                        colSam = col;
                    }
                    else if (room[row][col] == 'N')
                    {
                        rowNikoladze = row;
                        colNikoladze = col;
                    }
                }
            }
        }
    }
}
