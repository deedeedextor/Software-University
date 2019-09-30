using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.SportCards
{
    class Program
    {
        static void Main(string[] args)
        {
            var cards = new Dictionary<string, Dictionary<string, double>>();  //card-sport-price

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                if (input.Contains("check"))
                {
                    string[] tokens = input
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    string cardToCheck = tokens[1];

                    if (cards.ContainsKey(cardToCheck))
                    {
                        Console.WriteLine($"{cardToCheck} is available!");
                    }

                    else
                    {
                        Console.WriteLine($"{cardToCheck} is not available!");
                    }
                }

                else
                {
                    string[] tokens = input
                        .Split(" - ", StringSplitOptions.RemoveEmptyEntries);

                    string card = tokens[0];
                    string sport = tokens[1];
                    double price = double.Parse(tokens[2]);
                    
                    if (!cards.ContainsKey(card))
                    {
                        cards[card] = new Dictionary<string, double>() { { sport, price } };
                    }

                    if (!cards[card].ContainsKey(sport))
                    {
                        cards[card].Add(sport, price);
                    }

                    else
                    {
                        cards[card][sport] = price;
                    }

                }
            }

            foreach (var kvp in cards.OrderByDescending(x => x.Value.Count))
            {
                string card = kvp.Key;
                Dictionary<string, double> sportAndPrice = kvp.Value;

                Console.WriteLine($"{card}:");

                foreach (var nestedKvp in cards[card].OrderBy(x => x.Key))
                {
                    string sport = nestedKvp.Key;
                    double price = nestedKvp.Value;

                    Console.WriteLine($"  -{sport} - {price:F2}");
                }
            }
        }
    }
}
