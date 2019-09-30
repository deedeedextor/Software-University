using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.ListManipulationBasicsL
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

                if (command[0] == "Add")
                {
                    int numberToAdd = int.Parse(command[1]);
                    numbers.Add(numberToAdd);
                }

                else if (command[0] == "Remove")
                {
                    int numberToRemove = int.Parse(command[1]);
                    numbers.Remove(numberToRemove);
                }

                else if (command[0] == "RemoveAt")
                {
                    int indexToRemove = int.Parse(command[1]);
                    numbers.RemoveAt(indexToRemove);
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
