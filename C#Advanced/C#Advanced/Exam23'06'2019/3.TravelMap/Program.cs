using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.TravelMap
{
    class Program
    {
        static void Main(string[] args)
        {
            //country-town-cost
            var map = new Dictionary<string, Dictionary<string, int>>();
            string input = string.Empty;

            

            while ((input = Console.ReadLine()) != "END")
            {
                string[] data = input.Split(" > ", StringSplitOptions.RemoveEmptyEntries);

                string country = data[0];
                string town = data[1];
                int cost = int.Parse(data[2]);

                if (!map.ContainsKey(country))
                {
                    map[country] = new Dictionary<string, int>() { { town, cost } };
                }

                if (!map[country].ContainsKey(town))
                {
                    map[country].Add(town, cost);
                }

                if (map[country][town] > cost)
                {
                    map[country][town] = cost;
                }
            }

            foreach (var kvp in map.OrderBy(c => c.Key))
            {
                string country = kvp.Key;
                Dictionary<string, int> townsAndCosts = kvp.Value;

                Console.Write($"{country} -> ");

                foreach (var nestedKvp in map[country].OrderBy(t => t.Value))
                {
                    string town = nestedKvp.Key;
                    int cost = nestedKvp.Value;

                    Console.Write($"{town} -> {cost} ");
                }
                Console.WriteLine();
            }
        }
    }
}
