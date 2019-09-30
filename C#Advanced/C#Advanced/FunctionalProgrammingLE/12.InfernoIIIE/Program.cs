using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.InfernoIIIE
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> gems = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string input = string.Empty;

            List<string> filters = new List<string>();

            while ((input = Console.ReadLine()) != "Forge")
            {
                string[] tokens = input.Split(";");

                string command = tokens[0];
                string filter = tokens[1];
                int parameter = int.Parse(tokens[2]);

                if (command == "Exclude")
                {
                    filters.Add(filter + ":" + parameter);
                }

                else if (command == "Reverse")
                {
                    filters.Remove(filter + ":" + parameter);
                }
            }

            Exclude(gems, filters);

            Console.WriteLine(string.Join(" ", gems));
        }

        private static void Exclude(List<int> gems, List<string> filters)
        {
            List<int> indexesGems = new List<int>();

            foreach (var filter in filters)
            {
                string[] tokens = filter.Split(":", StringSplitOptions.RemoveEmptyEntries);

                string filterType = tokens[0];
                int filterParameter = int.Parse(tokens[1]);

                if (filterType == "Sum Left")
                {
                    if (gems[0] == filterParameter)
                    {
                        indexesGems.Add(0);
                    }

                    for (int i = 1; i < gems.Count; i++)
                    {
                        if (i == 0 && gems[i] == filterParameter)
                        {
                            indexesGems.Add(i);
                        }

                        else if (gems[i] + gems[i - 1] == filterParameter)
                        {
                            indexesGems.Add(i);
                        }
                    }
                }

                else if (filterType == "Sum Right")
                {
                    for (int i = 0; i < gems.Count - 1; i++)
                    {
                        if (i == gems.Count - 1 && gems[gems.Count - 1] == filterParameter)
                        {
                            indexesGems.Add(gems.Count - 1);
                        }

                        else if (gems[i] + gems[i + 1] == filterParameter)
                        {
                            indexesGems.Add(i);
                        }
                    }
                }

                else if (filterType == "Sum Left Right")
                {
                    for (int i = 0; i < gems.Count - 1; i++)
                    {
                        if (gems.Count == 1)
                        {
                            indexesGems.Add(0);
                        }

                        else if (i == 0 && gems[i] + gems[i + 1] == filterParameter)
                        {
                            indexesGems.Add(i);
                        }

                        else if (i == gems.Count - 1 && gems[gems.Count - 1] + gems[gems.Count - 2] == filterParameter)
                        {
                            indexesGems.Add(i);
                        }

                        else if (i == gems.Count - 1 && gems[gems.Count - 1] == filterParameter)
                        {
                            indexesGems.Add(i);
                        }

                        else if (i != gems.Count - 1 && i != 0 && gems[i - 1] + gems[i] + gems[i + 1] == filterParameter)
                        {
                            indexesGems.Add(i);
                        }
                    }
                }
            }

            indexesGems = indexesGems.OrderByDescending(g => g).ToList();

            foreach (var index in indexesGems)
            {
                gems.RemoveAt(index);
            }
        }
    }
}
