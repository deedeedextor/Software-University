using System;

namespace _5.AddAndSubtractE
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());

            int sumOfTwoNumbers = GetSumOfTwoIntegers(firstNumber, secondNumber);
            Console.WriteLine(GetSubtractFromSum(sumOfTwoNumbers, thirdNumber));
        }
      
        public static int GetSubtractFromSum(int sumOfTwoNumbers, int third)
        {
            return sumOfTwoNumbers - third;
        }

        public static int GetSumOfTwoIntegers(int numberOne, int numberTwo)
        {
            int sum = numberOne + numberTwo;
            return sum;
        }
    }
}
