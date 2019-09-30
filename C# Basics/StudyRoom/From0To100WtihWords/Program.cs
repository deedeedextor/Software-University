using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace From0To100WtihWords
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            string[] belowTwenty = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten",
            "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            string[] roundNumbers = { "", "", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

            if (number <= 20)
            {
                Console.WriteLine(belowTwenty[number]);
                return;
            }
            else if (number < 0 || number > 100)
            {
                Console.WriteLine("invalid number");
                return;
            }
            else if (number == 100)
            {
                Console.WriteLine("one hundred");
                return;
            }

            int secondDigit = number % 10;
            number = number / 10;

            if (secondDigit == 0)
            {
                Console.WriteLine(roundNumbers[number]);
            }
            else
            {
                Console.WriteLine(roundNumbers[number] + " " + belowTwenty[secondDigit]);
            }
        }
    }
}
