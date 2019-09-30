using System;
using System.Collections.Generic;
using System.Linq;

namespace _8.CustomComparatorE
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbersToSort = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int, int, int> sortFunc = (x, y) => x.CompareTo(y);

            Action<int[], int[]> printNumbers = (x, y) => Console.WriteLine($"{string.Join(" ", x)} {string.Join(" ", y)}");

            int[] evenNumbers = numbersToSort.Where(x => x % 2 == 0).ToArray();
            int[] oddNumbers = numbersToSort.Where(x => x % 2 != 0).ToArray();

            Array.Sort(evenNumbers, new Comparison<int>(sortFunc));
            Array.Sort(oddNumbers, new Comparison<int>(sortFunc));

            printNumbers(evenNumbers, oddNumbers);
        }
    }
}
