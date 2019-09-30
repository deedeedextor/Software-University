using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _12.SoftUniBarIncomeE
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double sum = 0;

            while (input != "end of shift")
            {
                string regex = @"%(?<person>[A-Z][a-z]+)%[^|$%.]*<(?<product>\w+)>[^|$%.]*[|](?<count>[\d+])[|][^|$%.]*?(?<price>\d+\.?\d+)[$]";

                MatchCollection matches = Regex.Matches(input, regex);

                foreach (Match match in matches)
                {
                    var personName = match.Groups[1].Value;
                    var product = match.Groups[2].Value;
                    int quantity = int.Parse(match.Groups[3].Value);
                    double price = double.Parse(match.Groups[4].Value);

                    price = quantity * price;
                    sum += price;

                    Console.WriteLine($"{personName}: {product} - {price:F2}");
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"Total income: {sum:F2}");
        }
    }
}
