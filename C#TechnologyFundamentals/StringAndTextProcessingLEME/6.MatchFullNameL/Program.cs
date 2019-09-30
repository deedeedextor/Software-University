using System;
using System.Text.RegularExpressions;

namespace _6.MatchFullNameL
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Regex regex = new Regex(@"\b[A-Z][a-z]+ [A-Z][a-z]+");
            MatchCollection matches = regex.Matches(input);

            foreach (var name in matches)
            {
                Console.Write(name + " ");
            }
            Console.WriteLine();
        }
    }
}
