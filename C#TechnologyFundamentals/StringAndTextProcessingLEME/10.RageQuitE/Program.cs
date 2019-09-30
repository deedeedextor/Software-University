using System;
using System.Text.RegularExpressions;
using System.Text;
using System.Linq;

namespace _10.RageQuitE
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().ToUpper();

            string wordNumberPattern = @"[\D]+[0-9]+";
            string numberPattern = @"[\d]+";
            string wordPattern = @"[\D]+";

            MatchCollection messages = Regex.Matches(input, wordNumberPattern);
            StringBuilder realMessage = new StringBuilder();

            foreach (Match message in messages)
            {
                Match word = Regex.Match(message.ToString(), wordPattern);
                string words = word.ToString();

                Match repetition = Regex.Match(message.ToString(), numberPattern);
                int repetitions = int.Parse(repetition.ToString());

                for (int i = 0; i < repetitions; i++)
                {
                    realMessage.Append(word);
                }
            }
            string outputMessage = realMessage.ToString();
            int uniqueSymbols = outputMessage.Distinct().Count();

            Console.WriteLine($"Unique symbols used: {uniqueSymbols}");
            Console.WriteLine(outputMessage);
        }
    }
}
