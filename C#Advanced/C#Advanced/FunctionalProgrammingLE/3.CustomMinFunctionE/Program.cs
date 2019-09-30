using System;
using System.Linq;

namespace _3.CustomMinFunctionE
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int[], int> smallestNumber = GetMinNumber;

            var minimumNumber = smallestNumber(numbers);

            Console.WriteLine(minimumNumber);
        }

        private static int GetMinNumber(int[] numbers)
        {
            var minNumber = int.MaxValue;

            foreach (var number in numbers)
            {
                if (number < minNumber)
                {
                    minNumber = number;
                }
            }

            return minNumber;
        }
    }
}
