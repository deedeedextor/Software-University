using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.TheKitchen
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] knivesCollection = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> knives = new Stack<int>(knivesCollection);

            int[] forksCollection = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            List<int> forks = new List<int>(forksCollection);

            List<int> sets = new List<int>();

            while (knives.Any() && forks.Any())
            {
                int currentKnife = knives.Pop();

                if (currentKnife > forks[0])
                {
                    currentKnife += forks[0];
                    forks.RemoveAt(0);
                    sets.Add(currentKnife);
                }

                else if (currentKnife < forks[0])
                {
                    continue;
                }

                else
                {
                    forks.RemoveAt(0);
                    currentKnife++;
                    knives.Push(currentKnife);
                }
            }

            Console.WriteLine($"The biggest set is: {sets.Max()}");
            Console.WriteLine(string.Join(" ", sets));
        }
    }
}
