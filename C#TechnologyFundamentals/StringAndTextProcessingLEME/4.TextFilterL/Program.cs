﻿using System;

namespace _4.TextFilterL
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string text = Console.ReadLine();

            foreach ( var word in words)
            {
                var replacement = new string('*', word.Length);
                text = text.Replace(word, replacement);
            }
            Console.WriteLine(text);
        }
    }
}
