using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.ChangeListE
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            string[] command = Console.ReadLine().Split();

            while (command[0] != "end")
            {
                if (command[0] == "end")
                {
                    break;
                }

                if (command[0] == "Delete")
                {
                    int numberToRemove = int.Parse(command[1]);
                    numbers.RemoveAll(item => item == numberToRemove);
                }

                else if (command[0] == "Insert")
                {
                    int numberToInsert = int.Parse(command[1]);
                    int indexToInsert = int.Parse(command[2]);
                    numbers.Insert(indexToInsert, numberToInsert);
                }
                command = Console.ReadLine().Split();
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
