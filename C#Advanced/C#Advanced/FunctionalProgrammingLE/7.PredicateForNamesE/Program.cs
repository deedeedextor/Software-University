using System;
using System.Collections.Generic;
using System.Linq;

namespace _7.PredicateForNamesE
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());

            List<string> names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Predicate<string> filterNames = n => n.Length <= length;

            names
                .FindAll(filterNames)
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}
