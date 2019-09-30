using System;
using System.Linq;

namespace _1.ActionPrintE
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> printNames = n => Console.WriteLine(n);

            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            input
                .ToList()
                .ForEach(printNames);
        }
    }
}
