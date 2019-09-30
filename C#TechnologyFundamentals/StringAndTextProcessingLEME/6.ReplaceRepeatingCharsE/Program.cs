using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _6.ReplaceRepeatingCharsE
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < input.Length - 1; i++)
            {
                char currentCharacter = input[i];
                char nextCharacter = input[i + 1];

                if (input[i] != input[i + 1])
                {
                    sb.Append(currentCharacter);
                }
                if (i == input.Length - 2)
                {
                    sb.Append(nextCharacter);
                }
            }
            Console.WriteLine(sb);
        }
    }
}
