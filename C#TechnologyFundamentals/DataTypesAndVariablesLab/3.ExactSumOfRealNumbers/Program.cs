using System;

namespace _3.ExactSumOfRealNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal numbers = decimal.Parse(Console.ReadLine());                      
            decimal sumNumbers = 0;

            for (int i = 1; i <= numbers; i++)
            {
                sumNumbers += decimal.Parse(Console.ReadLine());               
            }
            Console.WriteLine(sumNumbers);
        }
    }
}
