using System;
using System.Linq;

namespace _5.AppliedArithmeticsE
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string command = Console.ReadLine();

            Action<string> calculateNumbers = operation =>
            {
                switch (operation)
                {
                    case "add":
                        numbers = numbers.Select(n => n + 1).ToArray();
                        break;
                    case "multiply":
                        numbers = numbers.Select(n => n * 2).ToArray();
                        break;
                    case "subtract":
                        numbers = numbers.Select(n => n - 1).ToArray();
                        break;
                    case "print":
                        Console.WriteLine(string.Join(" ", numbers));
                        break;
                }
            };

            while (command != "end")
            {
                calculateNumbers(command);

                command = Console.ReadLine();
            }
        }
    }
}
