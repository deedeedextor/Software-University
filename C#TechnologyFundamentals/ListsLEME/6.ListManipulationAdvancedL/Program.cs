using System;
using System.Collections.Generic;
using System.Linq;

namespace _6.ListManipulationAdvancedL
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> copyNumbers = new List<int>(numbers);

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
                    copyNumbers.Add(numberToAdd);
                }

                else if (command[0] == "Remove")
                {
                    int numberToRemove = int.Parse(command[1]);
                    copyNumbers.Remove(numberToRemove);
                }

                else if (command[0] == "RemoveAt")
                {
                    int indexToRemove = int.Parse(command[1]);
                    copyNumbers.RemoveAt(indexToRemove);
                }

                else if (command[0] == "Insert")
                {
                    int numberToInsert = int.Parse(command[1]);
                    int indexToInsert = int.Parse(command[2]);
                    copyNumbers.Insert(indexToInsert, numberToInsert);
                }

                else if (command[0] == "Contains")
                {
                    int numberToContain = int.Parse(command[1]);

                    PrintContainedNumber(copyNumbers, numberToContain);                     
                }

                else if (command[0] == "PrintEven")
                {
                    PrintEvenNumbers(copyNumbers);
                }

                else if (command[0] == "PrintOdd")
                {
                    PrintOddNumbers(copyNumbers);
                }

                else if (command[0] == "GetSum")
                {
                    PrintSumNumbers(copyNumbers);
                }

                else if (command[0] == "Filter")
                {
                    string symbol = command[1];
                    int numberToCompare = int.Parse(command[2]);

                    Filter(copyNumbers, symbol, numberToCompare);
                }
                command = Console.ReadLine().Split();
            }

            if (copyNumbers.Count != numbers.Count)
            {
                Console.WriteLine(string.Join(" ", copyNumbers));
            }

            else 
            {
                int count = Math.Min(numbers.Count, copyNumbers.Count);

                for (int i = 0; i < count; i++)
                {
                    if (copyNumbers[i] != numbers[i])
                    {
                        Console.WriteLine(string.Join(" ", copyNumbers));
                        break;
                    }
                }
            }
        }

        private static void Filter(List<int> copyNumbers,string symbol, int numberToCompare)
        {
            List<int> filterdNumbers = new List<int>();

            for (int i = 0; i < copyNumbers.Count; i++)
            {
                if (symbol == ">")
                {
                    if (copyNumbers[i] > numberToCompare)
                    {
                        filterdNumbers.Add(copyNumbers[i]);
                    }
                }

                else if (symbol == "<")
                {
                    if (copyNumbers[i] < numberToCompare)
                    {
                        filterdNumbers.Add(copyNumbers[i]);
                    }
                }

                else if (symbol == ">=")
                {
                    if (copyNumbers[i] >= numberToCompare)
                    {
                        filterdNumbers.Add(copyNumbers[i]);
                    }
                }

                else if (symbol == "<=")
                {
                    if (copyNumbers[i] <= numberToCompare)
                    {
                        filterdNumbers.Add(copyNumbers[i]);
                    }
                }
            }
            Console.WriteLine(string.Join(" ", filterdNumbers));
        }

        private static void PrintContainedNumber(List<int> copyNumbers, int numberToContain)
        {
            if (copyNumbers.Contains(numberToContain))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No such number");
            }
        }

        private static void PrintSumNumbers(List<int> copyNumbers)
        {
            int sum = 0;

            for (int i = 0; i < copyNumbers.Count; i++)
            {
                sum = sum + copyNumbers[i];
            }
            Console.WriteLine(string.Join(" ", sum));
        }

        private static void PrintOddNumbers(List<int> copyNumbers)
        {
            List<int> oddNumbers = new List<int>();

            for (int i = 0; i < copyNumbers.Count; i++)
            {
                if (copyNumbers[i] % 2 == 1)
                {
                    oddNumbers.Add(copyNumbers[i]);
                }
            }
            Console.WriteLine(string.Join(" ", oddNumbers));
        }

        private static void PrintEvenNumbers(List<int> copyNumbers)
        {
            List<int> evenNumbers = new List<int>();

            for (int i = 0; i < copyNumbers.Count; i++)
            {
                if (copyNumbers[i] % 2 == 0)
                {
                    evenNumbers.Add(copyNumbers[i]);
                }
            }
            Console.WriteLine(string.Join(" ", evenNumbers));
        }
    }
}
