using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhileLoopsNumberFrom1To100
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number in the range [1...100]:");
            int num = int.Parse(Console.ReadLine());

            while (num < 1 || num > 100)
            {
                Console.WriteLine("Invalid number!");
                Console.Write("Enter a number in the range [1...100]:");
                num = int.Parse(Console.ReadLine());
            }

            Console.WriteLine($"The number is: {num}");
        }
    }
}
