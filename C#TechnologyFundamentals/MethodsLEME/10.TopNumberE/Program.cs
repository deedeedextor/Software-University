using System;

namespace _10.TopNumberE
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            PrintTheTopNumbers(number);
        }

        private static void PrintTheTopNumbers(int number)
        {
            for (int i = 1; i <= number; i++)
            {
                int sumOfDigits = 0;
                int countOfOddDigits = 0;

                int currentNumber = i;
               
                while (currentNumber > 0)
                {
                    int lastDigit = currentNumber % 10;
                    currentNumber /= 10;

                    if (lastDigit % 2 != 0)
                    {
                        countOfOddDigits++;
                    }

                    sumOfDigits += lastDigit;
                }

                if (sumOfDigits % 8 == 0 && countOfOddDigits >= 1)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
