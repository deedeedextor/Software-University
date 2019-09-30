using System;
using System.Linq;

namespace _9.MinerE
{
    class Program
    {
        static void Main(string[] args)
        {
            int dimensions = int.Parse(Console.ReadLine());

            string[] commands = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            char[][] matrix = new char[dimensions][];

            int minerRow = -1;
            int minerCol = -1;
            int leftCoals = 0;

            for (int row = 0; row < dimensions; row++)
            {
                matrix[row] = Console.ReadLine().Replace(" ", "").ToCharArray();

                if (matrix[row].Contains('s'))
                {
                    minerRow = row;
                    minerCol = Array.IndexOf(matrix[row], 's');
                    matrix[row][minerCol] = '*';
                }

                leftCoals += matrix[row].Where(c => c == 'c').Count();
            }

            foreach (var command in commands)
            {
                switch (command)
                {
                    case "up": minerRow = minerRow - 1 < 0 ? minerRow : minerRow - 1;
                        break;
                    case "down": minerRow = minerRow + 1 >= dimensions ? minerRow : minerRow + 1;
                        break;
                    case "right": minerCol = minerCol + 1 >= dimensions ? minerCol : minerCol + 1;
                        break;
                    case "left": minerCol = minerCol - 1 < 0 ? minerCol : minerCol - 1;
                        break;
                }


                if (matrix[minerRow][minerCol] == 'e')
                {
                    Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
                    return;
                }

                else if (matrix[minerRow][minerCol] == 'c')
                {
                    matrix[minerRow][minerCol] = '*';
                    leftCoals--;

                    if (leftCoals == 0)
                    {
                        Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol})");
                        return;
                    }
                }
            }

            Console.WriteLine($"{leftCoals} coals left. ({minerRow}, {minerCol})");
        }
    }
}
