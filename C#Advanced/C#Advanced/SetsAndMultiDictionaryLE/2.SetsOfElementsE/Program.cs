using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.SetsOfElementsE
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstSet = new HashSet<int>();
            var secondSet = new HashSet<int>();

            int[] numbersLength = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int firstSetLength = numbersLength[0];
            int secondSetLength = numbersLength[1];

            for (int i = 0; i < firstSetLength; i++)
            {
                int number = int.Parse(Console.ReadLine());

                firstSet.Add(number);
            }

            for (int i = 0; i < secondSetLength; i++)
            {
                int number = int.Parse(Console.ReadLine());

                secondSet.Add(number);
            }

            var dublicates = new HashSet<int>(firstSet);
            dublicates.IntersectWith(secondSet);

            Console.WriteLine(string.Join(" ", dublicates));
        }
    }
}
