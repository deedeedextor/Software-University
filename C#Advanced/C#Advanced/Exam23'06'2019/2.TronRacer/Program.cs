using System;
using System.Linq;

namespace _2.TronRacer
{
    class Program
    {
        private static int rowFirst;
        private static int colFirst;
        private static int rowSecond;
        private static int colSecond;
        private static bool isDead;
        private static string firstCommand;
        private static string secondCommand;
        private static char[,] field;
        private static int size;

        static void Main(string[] args)
        {
            size = int.Parse(Console.ReadLine());

            field = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                char[] input = Console.ReadLine().ToCharArray();

                for (int col = 0; col < size; col++)
                {
                    field[row, col] = input[col];

                    if (field[row, col] == 'f')
                    {
                        rowFirst = row;
                        colFirst = col;
                    }

                    else if (field[row, col] == 's')
                    {
                        rowSecond = row;
                        colSecond = col;
                    }
                }
            }

            isDead = false;

            while (!isDead)
            {
                string[] commands = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                firstCommand = commands[0];
                secondCommand = commands[1];

                FirstPlayerMoves();

                if (isDead)
                {
                    break;
                }

                SecondPlayerMoves();

                if (isDead)
                {
                    break;
                }
            }

            PrintField();
        }

        private static void PrintField()
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(field[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static void SecondPlayerMoves()
        {
            if (secondCommand == "up")
            {
                rowSecond -= 1;

                if (rowSecond >= 0 && rowSecond < field.GetLength(0))
                {
                    EndOfGameSecond();
                }

                else
                {
                    rowSecond = field.GetLength(0) - 1;
                    EndOfGameSecond();
                }
            }

            else if (secondCommand == "down")
            {
                rowSecond += 1;

                if (rowSecond >= 0 && rowSecond < field.GetLength(0))
                {
                    EndOfGameSecond();
                }

                else
                {
                    rowSecond = 0;
                    EndOfGameSecond();
                }
            }

            else if (secondCommand == "left")
            {
                colSecond -= 1;

                if (colSecond >= 0 && colSecond < field.GetLength(1))
                {
                    EndOfGameSecond();
                }

                else
                {
                    colSecond = field.GetLength(1) - 1;
                    EndOfGameSecond();
                }
            }

            else if (secondCommand == "right")
            {
                colSecond += 1;

                if (colSecond >= 0 && colSecond < field.GetLength(1))
                {
                    EndOfGameSecond();
                }

                else
                {
                    colSecond = 0;
                    EndOfGameSecond();
                }
            }
        }


        private static void EndOfGameFirst()
        {
            if (field[rowFirst, colFirst] == 's')
            {
                isDead = true;
                field[rowFirst, colFirst] = 'x';
            }

            else if (field[rowFirst, colFirst] == '*')
            {
                field[rowFirst, colFirst] = 'f';
            }
        }

        private static void EndOfGameSecond()
        {
            if (field[rowSecond, colSecond] == 'f')
            {
                isDead = true;
                field[rowSecond, colSecond] = 'x';
            }

            else if (field[rowSecond, colSecond] == '*')
            {
                field[rowSecond, colSecond] = 's';
            }
        }

        private static void FirstPlayerMoves()
        {
            if (firstCommand == "up")
            {
                rowFirst -= 1;

                if (rowFirst >= 0 && rowFirst < field.GetLength(0))
                {
                    EndOfGameFirst();
                }

                else
                {
                    rowFirst = field.GetLength(0) - 1;
                    EndOfGameFirst();
                }
            }

            else if (firstCommand == "down")
            {
                rowFirst += 1;

                if (rowFirst >= 0 && rowFirst < field.GetLength(0))
                {
                    EndOfGameFirst();
                }

                else
                {
                    rowFirst = 0;
                    EndOfGameFirst();
                }
            }

            else if (firstCommand == "left")
            {
                colFirst -= 1;

                if (colFirst >= 0 && colFirst < field.GetLength(1))
                {
                    EndOfGameFirst();
                }

                else
                {
                    colFirst = field.GetLength(1) - 1;
                    EndOfGameFirst();
                }
            }

            else if (firstCommand == "right")
            {
                colFirst += 1;

                if (colFirst >= 0 && colFirst < field.GetLength(1))
                {
                    EndOfGameFirst();
                }

                else
                {
                    colFirst = 0;
                    EndOfGameFirst();
                }
            }
        }
    }
}
