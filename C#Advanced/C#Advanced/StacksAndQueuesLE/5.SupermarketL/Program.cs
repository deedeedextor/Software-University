using System;
using System.Collections.Generic;

namespace _5.SupermarketL
{
    class Program
    {
        static void Main(string[] args)
        {
            var supermarket = new Queue<string>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                if (input == "Paid")
                {
                    while(supermarket.Count != 0)
                    {
                        Console.WriteLine($"{supermarket.Dequeue()}");
                    }
                }

                else
                {
                    supermarket.Enqueue(input);
                }
            }

            Console.WriteLine($"{supermarket.Count} people remaining.");
        }
    }
}
