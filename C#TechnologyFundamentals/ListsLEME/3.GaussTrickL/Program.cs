using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.GaussTrickL
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> result = new List<int>();

            for (int i = 0; i < numbers.Count/2; i++)
            {
                int first = numbers[i];
                int last = numbers[numbers.Count - 1 - i];

                int sumNumbers = first + last;
                result.Add(sumNumbers);
            }

            if (numbers.Count % 2 == 1)
            {
                int middle = numbers[numbers.Count / 2];
                result.Add(middle);
            }
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
