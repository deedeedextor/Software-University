using System;
using System.Collections.Generic;
using System.Linq;

namespace _9.ListOfPredicatesЕ
{
    class Program
    {
        static void Main(string[] args)
        {
            int endOfRange = int.Parse(Console.ReadLine());

            List<int> dividers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Distinct()
                .ToList();

            List<int> result = GetDivisible(endOfRange, dividers);

            Console.WriteLine(string.Join(" ", result));
        }

        private static List<int> GetDivisible(int endOfrange, List<int> dividers)
        {
            var result = new List<int>();

            for (int i = 1; i <= endOfrange; i++)
            {
                var isDivisble = true;

                foreach (var divider in dividers)
                {
                    Predicate<int> notDivisble = x => i % x != 0;

                    if (notDivisble(divider))
                    {
                        isDivisble = false;
                        break;
                    }
                }

                if (isDivisble)
                {
                    result.Add(i);
                }
            }

            return result;
        }
    }
}
