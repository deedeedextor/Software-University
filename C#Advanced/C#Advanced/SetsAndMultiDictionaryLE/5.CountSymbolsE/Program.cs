using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.CountSymbolsE
{
    class Program
    {
        static void Main(string[] args)
        {
            var symbols = new Dictionary<char, int>();

            string text = Console.ReadLine();

            for (int i = 0; i < text.Length; i++)
            {
                char currentChar = text[i];

                if (!symbols.ContainsKey(currentChar))
                {
                    symbols[currentChar] = 0;
                }

                symbols[currentChar]++;
            }

            foreach (var symbolKvp in symbols.OrderBy(x => x.Key))
            {
                char symbolToPrint = symbolKvp.Key;
                int symbolCount = symbolKvp.Value;

                Console.WriteLine($"{symbolToPrint}: {symbolCount} time/s");
            }
        }
    }
}
