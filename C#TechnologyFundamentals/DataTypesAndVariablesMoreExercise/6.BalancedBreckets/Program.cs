using System;

namespace _6.BalancedBreckets
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());
            int openingBracketCount = 0;
            int closingBracketCount = 0;
            bool isValid = true;
           
            for (int i = 0; i < numberOfLines; i++)
            {
                string symbol = Console.ReadLine();

                if (symbol.Contains("("))
                {
                    openingBracketCount++;
                }
                else if (symbol.Contains(")"))
                {
                    closingBracketCount++;
                }

                if (Math.Abs(openingBracketCount - closingBracketCount) > 1 || openingBracketCount < closingBracketCount)
                {
                    isValid = false;
                }
            }

            if (openingBracketCount != closingBracketCount || isValid == false)
            {
                Console.WriteLine("UNBALANCED");
            }
            else
            {
                Console.WriteLine("BALANCED");
            }
        }
    }
}
