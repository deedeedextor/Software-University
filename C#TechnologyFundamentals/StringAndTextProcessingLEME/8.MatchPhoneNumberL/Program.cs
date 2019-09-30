using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _8.MatchPhoneNumberL
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string regex = @"(?<!\d)[+]359([ -])2\1\d{3}\1\d{4}\b";

            List<string> phones = new List<string>();

            MatchCollection phoneNumbers = Regex.Matches(input, regex);

            foreach  (Match phoneNumber in phoneNumbers)
            {
                phones.Add(phoneNumber.Value);
            }
            Console.WriteLine(string.Join(", ", phones));
        }
    }
}
