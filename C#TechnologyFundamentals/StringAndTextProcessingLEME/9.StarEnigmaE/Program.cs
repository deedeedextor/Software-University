using System;
using System.Text.RegularExpressions;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace _9.StarEnigmaE
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());

            List<StringBuilder> decryptedMessages = new List<StringBuilder>();

            List<string> attackedPlanet = new List<string>();
            List<string> destroyedPlanet = new List<string>();

            for (int i = 0; i < numberOfLines; i++)
            {
                string input = Console.ReadLine();

                string regex = @"[sStTaArR]";
                MatchCollection matches = Regex.Matches(input, regex);
                int countKey = matches.Count;

                StringBuilder decryptedMessage = new StringBuilder();

                foreach (var symbol in input)
                {
                    char newSymbol = (char)(symbol - countKey);
                    decryptedMessage.Append(newSymbol);
                }
                decryptedMessages.Add(decryptedMessage);
            }

            foreach (var item in decryptedMessages)
            {
                Regex regexTwo = new Regex(@"@(?<planet>[A-Z][a-z]+)[^@\-!:>]*:(?<soldiers>\d+)[^@\-!:>]*!(?<typeattack>[AD])![^@\-!:>]*->\d+");

                if (regexTwo.IsMatch(item.ToString()))
                {
                    string planetName = regexTwo.Match(item.ToString()).Groups[1].Value;
                    string typeOfAttack = regexTwo.Match(item.ToString()).Groups[3].Value;

                    if (typeOfAttack == "A")
                    {
                        attackedPlanet.Add(planetName);
                    }
                    else if (typeOfAttack == "D")
                    {
                        destroyedPlanet.Add(planetName);
                    }
                }
            }

            if (attackedPlanet.Count == 0)
            {
                Console.WriteLine("Attacked planets: 0");
            }
            else
            {
                Console.WriteLine($"Attacked planets: {attackedPlanet.Count}");

                foreach (var name in attackedPlanet.OrderBy(x => x))
                {
                    Console.WriteLine($"-> {name}");
                }
            }

            if (destroyedPlanet.Count == 0)
            {
                Console.WriteLine("Destroyed planets: 0");
            }
            else
            {
                Console.WriteLine($"Destroyed planets: {destroyedPlanet.Count}");

                foreach (var name in destroyedPlanet.OrderBy(x => x))
                {
                    Console.WriteLine($"-> {name}");
                }
            }
        }
    }
}
