using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1.ExcelFunctions
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            string[][] table = new string[size][];

            for (int row = 0; row < size; row++)
            {
                string[] input = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                table[row] = new string[input.Length];

                for (int col = 0; col < table[row].Length; col++)
                {
                    table[row][col] = input[col];
                }
            }

            StringBuilder sb = new StringBuilder();

            string[] filterCommands = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string filter = filterCommands[0];

            if (filter == "hide")
            {
                string criteria = filterCommands[1];

                int colIndex = FindCretaria(table, size, criteria);

                //string[][] resultTable = table
                // .Select(arr => arr.Where((item, i) => i != colIndex).ToArray())
                // .ToArray();

                for (int row = 0; row < table.GetLength(0); row++)
                {
                    List<string> line = new List<string>();

                    for (int col = 0; col < table[0].Length; col++)
                    {
                        if (col != colIndex)
                        {
                            line.Add(table[row][col]);
                        }
                    }

                    sb.AppendLine(string.Join(" | ", line));
                }

                PrintTable(sb);
            }

            else if (filter == "sort")
            {
                string criteria = filterCommands[1];

                int colIndex = FindCretaria(table, size, criteria);

                sb.AppendLine(string.Join(" | ", table[0]));

                foreach (var row in table.Skip(1).OrderBy(x => x[colIndex]))
                {
                    sb.AppendLine(string.Join(" | ", row));
                }

                PrintTable(sb);
            }

            else if (filter == "filter")
            {
                string criteria = filterCommands[1];
                string value = filterCommands[2];

                int colIndex = FindCretaria(table, size, criteria);

                sb.AppendLine(string.Join(" | ", table[0]));

                for (int row = 0; row < table.GetLength(0); row++)
                {
                    if (table[row][colIndex] == value)
                    {
                        sb.AppendLine(string.Join(" | ", table[row]));
                    }
                }

                PrintTable(sb);
            }
        }

        private static void PrintTable(StringBuilder sb)
        {
            Console.WriteLine(sb.ToString().TrimEnd()); 
        }

        private static int FindCretaria(string[][] table, int size, string criteria)
        {
            int colIndex = 0;

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < table[row].Length; col++)
                {
                    if (table[row][col] == criteria)
                    {
                        colIndex = col;
                        break;
                    }
                }
                break;
            }

            return colIndex;
        }
    }
}
