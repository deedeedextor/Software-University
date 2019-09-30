using System;

namespace _2.ASCIISumatorME
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstCharacter = char.Parse(Console.ReadLine());
            char secondCharacter = char.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            int sum = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] > firstCharacter && input[i] < secondCharacter)
                {
                    sum += input[i];
                }
            }
            Console.WriteLine(sum);
        }
    }
}
