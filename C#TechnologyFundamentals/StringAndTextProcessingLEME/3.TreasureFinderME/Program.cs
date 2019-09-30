using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _3.TreasureFinderME
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string input = string.Empty;

            while ((input =Console.ReadLine()) != "find")
            {
                StringBuilder sb = new StringBuilder();

                for (int i = 0, j = 0; i < input.Length; i++, j++)
                {
                    char currentCharacter = input[i];
                    int numberToSubtract = numbers[j];

                    currentCharacter = (char)(currentCharacter - numberToSubtract);
                    sb.Append(currentCharacter);

                    if (j == numbers.Length - 1)
                    {
                        j = -1;
                    }

                }

                string pattern = @"&(?<type>[^&]+)&(?:.*)<(?<coordinates>[^<>]+)>";
                MatchCollection matches = Regex.Matches(sb.ToString(), pattern);

                foreach (Match match in matches)
                {
                    var treasure = match.Groups[1].Value;
                    var coordinates = match.Groups[2].Value;

                    Console.WriteLine($"Found {treasure} at {coordinates}");
                }
            }
        }
    }
}
