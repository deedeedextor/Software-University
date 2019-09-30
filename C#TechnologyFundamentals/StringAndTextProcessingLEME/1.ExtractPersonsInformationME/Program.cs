using System;
using System.Text.RegularExpressions;

namespace _1.ExtractPersonsInformationME
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
            {
                string input = Console.ReadLine();

                Regex namePattern = new Regex(@"@(?<name>[\S\s]*?)[|]");
                Regex agePattern = new Regex(@"#(?<age>\d+)[*]");

                if (namePattern.IsMatch(input) && agePattern.IsMatch(input))
                {
                    Console.WriteLine($"{namePattern.Match(input).Groups["name"].ToString()}" +
                        $" is {agePattern.Match(input).Groups["age"].ToString()} years old.");
                }
            }
        }
    }
}
