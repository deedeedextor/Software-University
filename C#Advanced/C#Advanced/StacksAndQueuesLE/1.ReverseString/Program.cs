using System;
using System.Collections.Generic;

namespace _1.ReverseStringL
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var stackInput = new Stack<char>();

            foreach (var letter in input)
            {
                stackInput.Push(letter);
            }

            Console.WriteLine(string.Join("", stackInput));
        }
    }
}
