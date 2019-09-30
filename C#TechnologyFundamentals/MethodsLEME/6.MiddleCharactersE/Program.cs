using System;

namespace _6.MiddleCharactersE
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            PrintMiddleChars(input);
        }

        public static void PrintMiddleChars(string str)
        {
            if (str.Length % 2 == 0)
            {
                Console.WriteLine($"{str[str.Length/2-1]}{str[str.Length/2]}");               
            }
            else
            {
                Console.WriteLine($"{str[str.Length/2]}");
            }
        }
    }
}
