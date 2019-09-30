using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.GrainsOfSand
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> sequence = Console.ReadLine().Split().Select(int.Parse).ToList();

            string input = Console.ReadLine();

            while (input != "Mort")
            {
                string[] tokens = input.Split();
                string command = tokens[0];
                int value = int.Parse(tokens[1]);

                if (command == "Add")
                {
                    sequence.Add(value);
                }

                else if (command == "Remove")
                {
                    if (sequence.Contains(value))
                    {
                        sequence.Remove(value);
                    }
                    else if (value >= 0 && value < sequence.Count - 1)
                    {
                        sequence.RemoveAt(value);
                    }
                }

                else if (command == "Replace")
                {
                    int replacement = int.Parse(tokens[2]);

                    if (sequence.Contains(value))
                    {
                        int index = sequence.IndexOf(value);
                        sequence.RemoveAt(index);
                        sequence.Insert(index, replacement);
                    }
                }

                else if (command == "Increase")
                {
                    bool isFound = false;

                    foreach (var item in sequence)
                    {
                        if (item >= value)
                        {
                            value = item;
                            isFound = true;
                            break;
                        }
                    }

                    if (isFound == false)
                    {
                        value = sequence.Last();
                    }

                    for (int i = 0; i < sequence.Count; i++)
                    {
                        sequence[i] += value;
                    }
                }

                else if (command == "Collapse")
                {
                    sequence.RemoveAll(x => x < value);
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", sequence));
        }
    }
}
