using System;
using System.Collections.Generic;
using System.Linq;

namespace _6.ReverseAndExcludeE
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int numberToDivide = int.Parse(Console.ReadLine());

            numbers.Reverse();

            Predicate<int> divide = n => n % numberToDivide != 0;

            numbers = numbers.FindAll(divide);

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
