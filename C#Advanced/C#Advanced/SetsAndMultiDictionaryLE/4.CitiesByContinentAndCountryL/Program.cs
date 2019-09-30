using System;
using System.Collections.Generic;

namespace _4.CitiesByContinentAndCountryL
{
    class Program
    {
        static void Main(string[] args)
        {
            var continentAndCountry = new Dictionary<string, HashSet<string>>();
            var countryAndCities = new Dictionary<string, List<string>>();

            int numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
            {
                string[] input = Console.ReadLine()
                    .Split();

                string continent = input[0];
                string country = input[1];
                string city = input[2];

                if (!continentAndCountry.ContainsKey(continent))
                {
                    continentAndCountry[continent] = new HashSet<string>();
                }

                continentAndCountry[continent].Add(country);

                if (!countryAndCities.ContainsKey(country))
                {
                    countryAndCities[country] = new List<string>();
                }

                countryAndCities[country].Add(city);
            }

            foreach (var continentKvp in continentAndCountry)
            {
                string continent = continentKvp.Key;
                HashSet<string> allCountries = continentKvp.Value;

                Console.WriteLine($"{continent}:");

                foreach (var country in allCountries)
                {
                    List<string> allCities = countryAndCities[country];

                    Console.WriteLine($"  {country} -> {string.Join(", ", allCities)}");
                }
            }
        }
    }
}
