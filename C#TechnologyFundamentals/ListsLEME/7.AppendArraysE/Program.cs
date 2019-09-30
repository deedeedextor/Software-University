using System;
using System.Collections.Generic;
using System.Linq;

namespace _7.AppendArraysE
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> arrayNumbers = Console.ReadLine().Split('|').ToList();
            arrayNumbers.Reverse();

            var result = new List<string>();

            foreach (var item in arrayNumbers)
            {
                List<string> numbers = item.Split(' ').ToList();

                foreach (var num in numbers)
                {
                    if (num != "")
                    {
                        result.Add(num);
                    }
                }
            }
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
