using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.AdvertisementMessageE
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfMessages = int.Parse(Console.ReadLine());

            List<string> phrases = new List<string>()
            {
                "Excellent product."
                , "Such a great product."
                , "I always use that product."
                , "Best product of its category."
                , "Exceptional product."
                , "I can’t live without this product."
            };
            List<string> events = new List<string>()
            {
                "Now I feel good."
                , "I have succeeded with this product."
                , "Makes miracles. I am happy of the results!"
                , "I cannot believe but now I feel awesome."
                , "Try it yourself, I am very satisfied."
                , "I feel great!"
            };
            List<string> authors = new List<string>()
            {
                "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva"
            };
            List<string> cities = new List<string>()
            {
                "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse"
            };

            var random = new Random();

            for (int i = 0; i < numberOfMessages; i++)
            {
                var randomPhrase = random.Next(0, phrases.Count);
                phrases[i] = phrases[randomPhrase];
                var randomEvent = random.Next(0, events.Count);
                events[i] = events[randomEvent];
                var randomAuthor = random.Next(0, authors.Count);
                authors[i] = authors[randomAuthor];
                var randomCity = random.Next(0, cities.Count);
                cities[i] = cities[randomCity];

                Console.WriteLine($"{phrases[randomPhrase]} {events[randomEvent]} {authors[randomAuthor]} – {cities[randomCity]}.");
            }
        }
    }
}
