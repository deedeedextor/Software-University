using System;

namespace _1.SmallestOfThreeNumbersE
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());

            int smallestNumber = GetTheSmallestNumber(firstNumber, secondNumber, thirdNumber);
            Console.WriteLine(smallestNumber);         
        }

        private static int GetTheSmallestNumber(int first, int second, int third)
        {
            int smallestNumber = first;

            if (second < smallestNumber)
            {
                smallestNumber = second;
            }
            if (third < smallestNumber)
            {
                smallestNumber = third;
            }
            return smallestNumber;
        }
    }
}
