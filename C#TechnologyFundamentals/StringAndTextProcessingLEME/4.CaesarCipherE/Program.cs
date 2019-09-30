using System;
using System.Text;

namespace _4.CaesarCipherE
{
    class Program
    {
        static void Main(string[] args)
        {
            //char[] input = Console.ReadLine().ToCharArray();
            //int letter = 0;

            //for (int i = 0; i < input.Length; i++)
            //{
            // letter = input[i];
            // letter += 3;
            //input[i] = (char)letter;
            //}
            string input = Console.ReadLine();
            StringBuilder sb = new StringBuilder();

            foreach (var symbol in input)
            {
                char newSymbol = (char)(symbol + 3);
                sb.Append(newSymbol);
            }
            Console.WriteLine(sb);
        }
    }
}
