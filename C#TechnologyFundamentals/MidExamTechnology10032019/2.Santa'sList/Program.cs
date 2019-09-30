using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.SantasList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> kids = Console.ReadLine().Split("&").ToList();

            string input = Console.ReadLine();

            while (input != "Finished!")
            {
                string[] tokens = input.Split();

                string command = tokens[0];
                string kidName = tokens[1];

                if (command == "Bad")
                {
                    if (!kids.Contains(kidName))
                    {
                        kids.Insert(0, kidName);
                    }
                }

                else if (command == "Good")
                {
                    if (kids.Contains(kidName))
                    {
                        kids.Remove(kidName);
                    }
                }

                else if (command == "Rename")
                {
                    string newName = tokens[2];

                    if (kids.Contains(kidName))
                    {
                        int index = kids.IndexOf(kidName);
                        kids.Remove(kidName);
                        kids.Insert(index, newName);
                    }
                }

                else if (command == "Rearrange")
                {
                    if (kids.Contains(kidName))
                    {
                        int index = kids.IndexOf(kidName);
                        kids.Remove(kidName);
                        kids.Add(kidName);
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(string.Join(", ", kids));
        }
    }
}

