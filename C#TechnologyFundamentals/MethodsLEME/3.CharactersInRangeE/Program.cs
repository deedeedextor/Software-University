using System;

namespace _3.CharactersInRangeE
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstSymbol = char.Parse(Console.ReadLine());
            char secondSymbol = char.Parse(Console.ReadLine());

            PrintCharactersInRange(firstSymbol, secondSymbol);
        }

        public static void PrintCharactersInRange(char firstChar, char secondChar)
        {
            if (firstChar > secondChar)
            {
                for (char i = (char)(secondChar + 1); i < firstChar; i++)
                {
                    Console.Write(i + " ");
                }
            }

            for (char j = (char)(firstChar + 1); j < secondChar; j++)
            {
                Console.Write(j + " ");
            }
        }
    }
}
