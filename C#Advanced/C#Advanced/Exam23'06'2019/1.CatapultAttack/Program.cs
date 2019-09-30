using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.CatapultAttack
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPiles = int.Parse(Console.ReadLine());

            int[] wallsOfSpartans = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            List<int> walls = new List<int>(wallsOfSpartans);

            Stack<int> rocks = null;

            for (int i = 1; i <= numberOfPiles; i++)
            {
                int[] rocksOfTrojans = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

                rocks = new Stack<int>(rocksOfTrojans);

                if (i % 3 == 0)
                {
                    int wallToAdd = int.Parse(Console.ReadLine());

                    walls.Add(wallToAdd);
                }

                while (walls.Any() && rocks.Any())
                {
                    int currentRock = rocks.Pop();

                    if (walls[0] == 0)
                    {
                        walls.RemoveAt(0);
                    }

                    if (currentRock > walls[0])
                    {
                        currentRock -= walls[0];
                        walls.RemoveAt(0);
                        rocks.Push(currentRock);
                    }

                    else if (currentRock < walls[0])
                    {
                        walls[0] -= currentRock;
                    }

                    else
                    {
                        walls.RemoveAt(0);
                    }
                }

                if (i == numberOfPiles || walls.Count == 0)
                {
                    break;
                }
            }

            if (walls.Any())
            {
                Console.WriteLine($"Walls left: {string.Join(", ", walls)}");
            }

            else if (rocks.Any())
            {
                Console.WriteLine($"Rocks left: {string.Join(", ", rocks)}");
            }
        }
    }
}
