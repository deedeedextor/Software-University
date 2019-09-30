using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

namespace _11.LettersChangeNumbersE
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            decimal sum = 0M;

            for (int i = 0; i < input.Length; i++)
            {
                string text = input[i].ToString();
                decimal number = decimal.Parse(text.Substring(1, text.Length - 2));

                var firstLetter = text[0];
                var lastLetter = text[text.Length - 1];

                var upperCase = "ABCDEFGHIJKLMNOPQRSTUVWXZ".ToCharArray();
                var lowerCase = "abcdefghijklmnopqrstuvwxz".ToCharArray();

                if (firstLetter < 'a' - 1)
                {
                    decimal divisor = firstLetter - 'A' + 1;
                    sum += number / divisor;
                }
                else
                {
                    decimal multiplier = firstLetter - 'a' + 1;
                    sum += number * multiplier;
                }

                if (lowerCase.Contains(lastLetter))
                {
                    decimal addNumber = lastLetter - 'a' + 1;
                    sum += addNumber;
                }
                else
                {
                    decimal substractNumber = lastLetter - 'A' + 1;
                    sum -= substractNumber;
                }
            }
            Console.WriteLine($"{sum:F2}");
        }
    }
}
