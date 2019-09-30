using System;
using System.Linq;

namespace _2.KnightsOfHonorE
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> printKnights = k => Console.WriteLine($"Sir {k}");

            string[] knights = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            knights
                .ToList()
                .ForEach(printKnights);
        }
    }
}
