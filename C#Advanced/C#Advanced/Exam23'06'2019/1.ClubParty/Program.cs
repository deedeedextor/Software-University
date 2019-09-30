using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.ClubParty
{
    class Program
    {
        private static Dictionary<string, List<int>> fullHalls;

        static void Main(string[] args)
        {
            fullHalls = new Dictionary<string, List<int>>();
            
            int hallsCapacity = int.Parse(Console.ReadLine());

            var tokens = new Stack<string>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries));

            var halls = new Queue<string>();

            while (tokens.Any())
            {
                var currentChar = tokens.Peek();

                if (!char.IsDigit(currentChar[0]))
                {
                    fullHalls[currentChar] = new List<int>();
                    halls.Enqueue(currentChar);
                    tokens.Pop();
                    continue;
                }

                if (fullHalls.Count == 0)
                {
                    tokens.Pop();
                    continue;
                }

                foreach (var kvp in fullHalls)
                {

                    if (kvp.Value.Sum() + int.Parse(currentChar) <= hallsCapacity)
                    {
                        fullHalls[kvp.Key].Add(int.Parse(currentChar));
                        tokens.Pop();
                        break;
                    }

                    if (kvp.Value.Sum() + int.Parse(currentChar) >= hallsCapacity && halls.Any())
                    {
                        Console.WriteLine($"{halls.Dequeue()} -> {string.Join(", ", kvp.Value)}");
                        fullHalls.Remove(kvp.Key);
                    }

                    break;

                }
            }
        }
    }
}
