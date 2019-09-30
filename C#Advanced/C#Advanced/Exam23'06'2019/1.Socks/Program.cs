using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.Socks
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstSocks = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> leftSocks = new Stack<int>(firstSocks);

            int[] secondSocks = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> rightSocks = new Queue<int>(secondSocks);

            Queue<int> pairs = new Queue<int>();

            while (leftSocks.Any() && rightSocks.Any())
            {
                int currentLeft = leftSocks.Peek();
                int currentRight = rightSocks.Peek();

                if (currentLeft > currentRight)
                {
                    currentLeft += currentRight;
                    pairs.Enqueue(currentLeft);
                    leftSocks.Pop();
                    rightSocks.Dequeue();
                }

                else if (currentLeft < currentRight)
                {
                    leftSocks.Pop();
                    continue;
                }

                else
                {
                    rightSocks.Dequeue();
                    currentLeft = leftSocks.Pop();
                    currentLeft++;
                    leftSocks.Push(currentLeft);
                }
            }

            Console.WriteLine(pairs.Max());
            Console.WriteLine(string.Join(" ", pairs));
        }
    }
}
