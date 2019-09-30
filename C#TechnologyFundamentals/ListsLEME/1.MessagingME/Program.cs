using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.MessagingME
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            string inputText = Console.ReadLine();
            List<string> letters = inputText.Select(s => s.ToString()).ToList();

            List<string> result = new List<string>();

            for (int i = 0; i < numbers.Count; i++)
            {
                int currentNumber = numbers[i];
                int sum = 0;

                while (currentNumber != 0)
                {
                    int lastDigit = currentNumber % 10;
                    currentNumber /= 10;
                    sum += lastDigit;
                }

                if (sum > letters.Count)
                {
                    sum = sum % letters.Count;
                }

                result.Add(letters[sum]);
                letters.RemoveAt(sum);
            }
            Console.WriteLine(string.Join("", result));
        }
    }
}
