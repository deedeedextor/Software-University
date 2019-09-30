using System;
using System.Collections.Generic;
using System.Linq;

namespace _4.ListOperationsE
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

            while (command[0] != "End")
            {
                if (command[0] == "End")
                {
                    break;
                }

                if (command[0] == "Add")
                {
                    int numberToAdd = int.Parse(command[1]);
                    numbers.Add(numberToAdd);
                }

                else if (command[0] == "Insert")
                {
                    int numberToInsert = int.Parse(command[1]);
                    int indexToInsert = int.Parse(command[2]);

                    if (indexToInsert >= numbers.Count || indexToInsert < 0)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        numbers.Insert(indexToInsert, numberToInsert);
                    }                   
                }

                else if (command[0] == "Remove")
                {
                    int indexToRemove = int.Parse(command[1]);

                    if (indexToRemove >= numbers.Count || indexToRemove < 0)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        numbers.RemoveAt(indexToRemove);
                    }                    
                }

                else if (command[0] == "Shift")
                {
                    string direction = command[1];
                    int count = int.Parse(command[2]);

                    if (direction == "left")
                    {
                        ShiftNumberLeft(numbers, count);
                    }
                    else if (direction == "right")
                    {
                        ShiftNumberRight(numbers, count);
                    }
                }
                command = Console.ReadLine().Split();
            }
            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void ShiftNumberRight(List<int> numbers, int count)
        {
            for (int i = 0; i < count; i++)
            {
                numbers.Insert(0, numbers[numbers.Count - 1]);
                numbers.RemoveAt(numbers.Count - 1);
            }
        }

        private static void ShiftNumberLeft(List<int> numbers, int count)
        {
            for (int i = 0; i < count; i++)
            {
                numbers.Add(numbers[0]);
                numbers.RemoveAt(0);
            }
        }
    }
}
