using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.PeriodicTableE
{
    class Program
    {
        static void Main(string[] args)
        {
            var periodicTable = new HashSet<string>();

            int numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
            {
                string[] input = Console.ReadLine().Split();

                for (int j = 0; j < input.Length; j++)
                {
                    periodicTable.Add(input[j]);
                }
            }

            foreach (var sign in periodicTable.OrderBy(x => x))
            {
                Console.Write(sign + " ");
            }
            Console.WriteLine();
        }
    }
}
