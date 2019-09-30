using System;

namespace _2.CharacterMultiplierE
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            string first = input[0];
            string second = input[1];

            int sum = 0;

            int minLength = Math.Min(first.Length, second.Length);

            for (int i = 0; i < minLength; i++)
            {
                sum += MultiplyASCII(first[i], second[i]);
            }

            string biggestString = string.Empty;

            if (first.Length > second.Length)
            {
                biggestString = first;
            }
            else
            {
                biggestString = second;
            }

            for (int i = minLength; i < biggestString.Length; i++)
            {
                sum += biggestString[i];
            }
            Console.WriteLine(sum);
        }

        private static int MultiplyASCII(char charOne, char charTwo)
        {
            return charOne * charTwo;
        }
    }
}
