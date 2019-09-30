using System;
using System.Collections.Generic;

namespace _4.MatchingBracketsL
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var indexes = new Stack<int>();

            var expressions = new List<string>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    indexes.Push(i);
                }

                else if (input[i] == ')')
                {
                    var startIndex = indexes.Pop();

                    var currentExpression = input.Substring(startIndex, i - startIndex + 1);
                    expressions.Add(currentExpression);
                }
            }

            Console.WriteLine(string.Join("\n", expressions));
        }
    }
}
