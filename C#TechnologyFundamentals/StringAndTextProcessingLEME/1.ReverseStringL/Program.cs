using System;

namespace _1.ReverseStringL
{
    class Program
    {
        static void Main(string[] args)
        {
            string reversedWord = string.Empty;

            string word = Console.ReadLine();

            while (word != "end")
            {
                for (int i = word.Length - 1; i >= 0; i--)
                {
                    reversedWord += word[i];
                }

                Console.WriteLine($"{word} = {reversedWord}");
                reversedWord = string.Empty;
                word = Console.ReadLine();
            }

        }
    }
}
