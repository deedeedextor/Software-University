using System;

namespace _12.RefactorSpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            
            for (int num = 1; num <= number; num++)
            {
                int digids = num;
                int sum = 0;

                while (digids > 0)
                {
                    sum += digids % 10;
                    digids = digids / 10;
                }
                bool isSpecialNumber = (sum == 5) || (sum == 7) || (sum == 11);
                Console.WriteLine($"{num} -> {isSpecialNumber}");              
            }
        }
    }
}
