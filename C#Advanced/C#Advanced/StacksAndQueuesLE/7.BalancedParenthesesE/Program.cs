using System;
using System.Collections.Generic;
using System.Linq;

namespace _7.BalancedParenthesesE
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var parenthesesStack = new Stack<char>();

            char[] openBrackets = new char[] { '{', '[', '(' };
            bool isValid = true;

            for (int i = 0; i < input.Length; i++)
            {
                char currentBracket = input[i];

                if (openBrackets.Contains(currentBracket))
                {
                    parenthesesStack.Push(input[i]);
                    continue;
                }

                if (parenthesesStack.Count == 0)
                {
                    isValid = false;
                    break;
                }

                if (parenthesesStack.Peek() == '(' && currentBracket == ')')
                {
                    parenthesesStack.Pop();
                }

                else if (parenthesesStack.Peek() == '[' && currentBracket == ']')
                {
                    parenthesesStack.Pop();
                }

                else if (parenthesesStack.Peek() == '{' && currentBracket == '}')
                {
                    parenthesesStack.Pop();
                }
            }

            if (isValid && parenthesesStack.Count == 0)
            {
                Console.WriteLine("YES");
            }

            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
