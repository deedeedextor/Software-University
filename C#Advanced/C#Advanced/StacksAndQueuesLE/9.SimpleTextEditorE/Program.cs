using System;
using System.Collections.Generic;

namespace _9.SimpleTextEditorE
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfOperations = int.Parse(Console.ReadLine());

            var textStack = new Stack<string>();

            string text = string.Empty;

            for (int i = 0; i < numberOfOperations; i++)
            {
                string[] input = Console.ReadLine().Split();

                string command = input[0];

                if (command == "1")
                {
                    string currentText = input[1];
                    textStack.Push(text);

                    text += currentText;
                }

                else if (command == "2")
                {
                    int count = int.Parse(input[1]);

                    if (count > text.Length)
                    {
                        count = Math.Min(count, text.Length);
                    }

                    textStack.Push(text);
                    text = text.Substring(0, text.Length - count);
                }

                else if (command == "3")
                {
                    int index = int.Parse(input[1]);

                    Console.WriteLine(text[index - 1]);
                }

                else if (command == "4")
                {
                    text = textStack.Pop();
                }
            }
        }
    }
}
