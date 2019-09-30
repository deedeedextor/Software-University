using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.RandomizeWordsL
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();

            var random = new Random();

            for (int i = 0; i < input.Length; i++)
            {
                var randomIndex = random.Next(0, input.Length);

                var temp = input[i];
                input[i] = input[randomIndex];
                input[randomIndex] = temp;
            }

            for (int i = 0; i < input.Length; i++)
            {
                Console.WriteLine(input[i]);
            }
        }
    }
}
