namespace P06_Sneaking
{
    using System;

    public class Sneaking
    {
        private static char[][] room;
        private static int rowSam;
        private static int colSam;
        private static bool isDead;
        private static int rowNikoladze;
        private static int colNikoladze;

        public static void Main()
        {
            CreateRoom();

            var moves = Console.ReadLine().ToCharArray();

            isDead = false;

            for (int i = 0; i < moves.Length; i++)
            {
                char currentCommand = moves[i];

                room[rowSam][colSam] = '.';

                MoveEnemy();

                if (isDead)
                {
                    break;
                }

                if (currentCommand == 'U')
                {
                    rowSam = (rowSam - 1);
                    MoveSam();
                }

                else if (currentCommand == 'D')
                {
                    rowSam = (rowSam + 1);
                    MoveSam();
                }

                else if (currentCommand == 'L')
                {
                    colSam = (colSam - 1);
                    MoveSam();
                }

                else if (currentCommand == 'R')
                {
                    colSam = (colSam + 1);
                    MoveSam();
                }

                if (isDead)
                {
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

        private static void MoveSam()
        {
            if (room[rowSam][colSam] == 'b' || room[rowSam][colSam] == 'd')
            {
                room[rowSam][colSam] = '.';
            }

            else if (rowSam == rowNikoladze)
            {
                isDead = true;
                room[rowNikoladze][colNikoladze] = 'X';
                room[rowSam][colSam] = 'S';
                Console.WriteLine($"Nikoladze killed!");
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
                                IsDead();
                            }
                        }

                        else if (col < room[row].Length)
                        {
                            room[row][col] = '.';
                            room[row][col + 1] = 'b';
                            col++;

                            if (rowSam == row && colSam > col)
                            {
                                IsDead();
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
                                IsDead();
                            }
                        }

                        else if (col > 0)
                        {
                            room[row][col] = '.';
                            room[row][col - 1] = 'd';

                            if (rowSam == row && colSam < col)
                            {
                                IsDead();
                            }
                        }
                    }
                }
            }
        }

        private static void IsDead()
        {
            isDead = true;
            room[rowSam][colSam] = 'X';
            Console.WriteLine($"Sam died at {rowSam}, {colSam}");
        }

        private static void CreateRoom()
        {
            int rows = int.Parse(Console.ReadLine());

            room = new char[rows][];

            for (int row = 0; row < rows; row++)
            {
                var input = Console.ReadLine().ToCharArray();

                room[row] = new char[input.Length];

                for (int col = 0; col < room[row].Length; col++)
                {
                    room[row][col] = input[col];

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
