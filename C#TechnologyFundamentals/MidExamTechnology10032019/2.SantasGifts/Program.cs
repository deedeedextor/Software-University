using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.SantasGifts
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCommands = int.Parse(Console.ReadLine());

            List<int> houses = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            int currentPosition = 0;

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] commands = Console.ReadLine().Split().ToArray();
            
                string command = commands[0];
                int index = int.Parse(commands[1]);

                if (command == "Forward")
                {
                    if (currentPosition + index < houses.Count)
                    {
                        currentPosition += index;
                        houses.RemoveAt(currentPosition);
                    }
                }

                else if (command == "Back")
                {
                    if (currentPosition - index >= 0)
                    {
                        currentPosition -= index;
                        houses.RemoveAt(currentPosition);
                    }
                }

                else if (command == "Gift")
                {
                    int value = int.Parse(commands[2]);

                    if (index < houses.Count)
                    {
                        houses.Insert(index, value);
                        currentPosition = index;
                    }
                }

                else if (command == "Swap")
                {
                    int value = int.Parse(commands[2]);

                    if (houses.Contains(index) && houses.Contains(value))
                    {
                        int firstIndex = houses.IndexOf(index);
                        int secondIndex = houses.IndexOf(value);

                        int temp = houses[firstIndex];
                        houses[firstIndex] = houses[secondIndex];
                        houses[secondIndex] = temp;
                    }
                }
            }
            Console.WriteLine($"Position: {currentPosition}");
            Console.WriteLine(string.Join(", ", houses));
        }
    }
}
