using System;
using System.Text.RegularExpressions;

namespace _7.MatchDatesL
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

           string regex = @"\b(?<day>\d{2})(?<separator>[-.\/])(?<month>[A-Z][a-z]{2})\2(?<year>\d{4})\b";

            MatchCollection dates = Regex.Matches(input, regex);

            foreach (Match date in dates)
            {
                var day = date.Groups["day"].Value;
                var month = date.Groups["month"].Value;
                var year = date.Groups["year"].Value;

                Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");
            }
        }
    }
}
