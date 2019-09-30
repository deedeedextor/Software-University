using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _8.MatchNumbersE
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<string> numbers = new List<string>();

            string regex = @"(^|(?<=\s))-?\d+(\.\d+)?($|(?=\s))";

            MatchCollection matches = Regex.Matches(input, regex);

            foreach (Match match in matches)
            {
                numbers.Add(match.Value);
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
