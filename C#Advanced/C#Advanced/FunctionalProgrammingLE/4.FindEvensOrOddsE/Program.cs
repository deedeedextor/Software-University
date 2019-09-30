using System;
using System.Collections.Generic;
using System.Linq;

namespace _4.FindEvensOrOddsE
{
    class Program
    {
        static void Main(string[] args)
        {
            long[] range = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToArray();

            long startPoint = range[0];
            long endPoint = range[1];

            string command = Console.ReadLine();

            List<long> numbers = new List<long>();

            //Predicate<int> filter = x => command == "odd" ? x % 2 !=0 : x % 2 == 0;
            //Func<int, bool> filterFunc = x => command == "odd" ? x % 2 !=0 : x % 2 == 0;

            for (long i = startPoint; i <= endPoint; i++)
            {
                numbers.Add(i);
            }

            //Console.WriteLine(string.Join(" ", numbers.Where(filterFunc)));
            //Console.WriteLine(string.Join(" ", numbers.Where(x => filter(x))));

            Predicate<long> odd = n => n % 2 != 0;
            Predicate<long> even = n => n % 2 == 0;

            if (command == "odd")
            {
                numbers = numbers.FindAll(odd);
            }

            else if (command == "even")
            {
                numbers = numbers.FindAll(even);
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
