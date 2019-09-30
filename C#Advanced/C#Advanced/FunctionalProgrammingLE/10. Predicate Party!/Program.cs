using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.PredicatePartyE
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string commands = string.Empty;

            while ((commands = Console.ReadLine()) != "Party!")
            {
                string[] commandsProps = commands.Split();

                string command = commandsProps[0];
                string startsEndsLength = commandsProps[1];
                string criteria = commandsProps[2];

                if (command == "Double")
                {
                    List<string> guestsToAdd = new List<string>();

                    if (startsEndsLength == "StartsWith")
                    {
                        guestsToAdd = guests.Where(x => x.StartsWith(criteria)).ToList();
                    }

                    else if (startsEndsLength == "EndsWith")
                    {
                        guestsToAdd = guests.Where(x => x.EndsWith(criteria)).ToList();
                    }

                    else if (startsEndsLength == "Length")
                    {
                        guestsToAdd = guests.Where(x => x.Length == int.Parse(criteria)).ToList();
                    }

                    foreach (var name in guestsToAdd)
                    {
                        int index = guests.IndexOf(name);
                        guests.Insert(index + 1, name);
                    }
                }

                else if (command == "Remove")
                {
                    if (startsEndsLength == "StartsWith")
                    {
                        guests.RemoveAll(x => x.StartsWith(criteria));
                    }

                    else if (startsEndsLength == "EndsWith")
                    {
                        guests.RemoveAll(x => x.EndsWith(criteria));
                    }

                    else if (startsEndsLength == "Length")
                    {
                        guests.RemoveAll(x => x.Length == int.Parse(criteria));
                    }

                }
            }

            Console.WriteLine(guests.Any() ? $"{string.Join(", ", guests)} are going to the party!" : "Nobody is going to the party!");
        }
    }
}
