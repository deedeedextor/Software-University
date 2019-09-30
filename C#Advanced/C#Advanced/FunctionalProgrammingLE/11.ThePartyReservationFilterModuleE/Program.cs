using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.ThePartyReservationFilterModuleE
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var filters = new List<string>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Print")
            {
                string[] tokens = input.Split(";");

                string command = tokens[0];
                string filter = tokens[1];
                string criteria = tokens[2];

                if (command == "Add filter")
                {
                    filters.Add(filter + " " + criteria);
                }

                else if (command == "Remove filter")
                {
                    filters.Remove(filter + " " + criteria);
                }
            }

            foreach (var filter in filters)
            {
                var commands = filter.Split();

                string command = commands[0];

                if (command == "Starts")
                {
                    guests.RemoveAll(n => n.StartsWith(commands[2]));
                }

                else if (command == "Ends")
                {
                    guests.RemoveAll(n => n.EndsWith(commands[2]));
                }

                else if (command == "Length")
                {
                    guests.RemoveAll(n => n.Length == int.Parse(commands[1]));
                }

                else if (command == "Contains")
                {
                    guests.RemoveAll(n => n.Contains(commands[1]));
                }
            }

            if (guests.Any())
            {
                Console.WriteLine(string.Join(" ", guests));
            }
        }
    }
}
