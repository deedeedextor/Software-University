using System;
using System.Collections.Generic;
using System.Linq;

namespace _3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split().ToList();

            string commands = Console.ReadLine();

            while (commands != "Stop")
            {
                string[] tokens = commands.Split();

                string command = tokens[0];

                if (command == "Delete")
                {
                    int index = int.Parse(tokens[1]);

                    if (index + 1 > 0 && index + 1 < input.Count)
                    {
                        input.RemoveAt(index + 1);
                    }
                }

                else if (command == "Swap")
                {
                    string wordOne = tokens[1];
                    string wordTwo = tokens[2];

                    if (input.Contains(wordOne) && input.Contains(wordTwo))
                    {
                        int indexOne = input.IndexOf(wordOne);
                        int indexTwo = input.IndexOf(wordTwo);

                        string temp = input[indexOne];
                        input[indexOne] = input[indexTwo];
                        input[indexTwo] = temp;
                    }
                }

                else if (command == "Put")
                {
                    string word = tokens[1];
                    int index = int.Parse(tokens[2]);

                    if (!input.Contains(word))
                    {
                        if (index - 1 > 0 && index - 1 <= input.Count)
                        {
                            input.Insert(index - 1, word);
                        }
                    }
                }

                else if (command == "Sort")
                {
                    input.Sort();
                    input.Reverse();
                }

                else if (command == "Replace")
                {
                    string wordOne = tokens[1];
                    string wordTwo = tokens[2];

                    if (input.Contains(wordTwo))
                    {
                        int indexTwo = input.IndexOf(wordTwo);
                        input[indexTwo] = wordOne;
                    }
                }
                commands = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", input));
        }
    }
}

