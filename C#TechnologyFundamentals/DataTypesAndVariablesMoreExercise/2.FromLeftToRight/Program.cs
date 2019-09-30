using System;

namespace _2.FromLeftToRight
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            long totalSum = 0;

            for (int i = 0; i < num; i++)
            {
                string numbers = Console.ReadLine();
                string[] splitNumbers = numbers.Split(' ');

                long leftNumber = long.Parse(splitNumbers[0]);
                long rightNumber = long.Parse(splitNumbers[1]);

                long biggerNumber = rightNumber;

                if (leftNumber >= rightNumber)
                {
                    biggerNumber = leftNumber;
                }

                while (biggerNumber != 0)
                {
                    totalSum += biggerNumber % 10;
                    biggerNumber /= 10;
                }
                Console.WriteLine(Math.Abs(totalSum));

                totalSum = 0;
            }
            
        }
    }
}
