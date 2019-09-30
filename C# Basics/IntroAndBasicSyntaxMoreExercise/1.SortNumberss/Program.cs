using System;

namespace _1.SortNumberss
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());

            int[] numbers = { firstNumber, secondNumber, thirdNumber};

            Array.Sort(numbers);
            Array.Reverse(numbers);

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(numbers[i]);
            }
        }
    }
}
