using System;

namespace _3.CalculationsL
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            switch (command)
            {
                case "add":
                    AddNumbers(firstNumber, secondNumber); break;
                case "subtract":
                    SubtractNumbers(firstNumber, secondNumber); break;
                case "multiply":
                    MultiplyNumbers(firstNumber, secondNumber); break;
                case "divide":
                    DivideNumbers(firstNumber, secondNumber); break;                
            }
        }

        public static void AddNumbers(int firstNumber, int secondNumber)
        {
            Console.WriteLine(firstNumber + secondNumber);
        }

        public static void SubtractNumbers(int firstNumber, int secondNumber)
        {
            Console.WriteLine(firstNumber - secondNumber);
        }

        public static void MultiplyNumbers(int firstNumber, int secondNumber)
        {
            Console.WriteLine(firstNumber * secondNumber);
        }

        public static void DivideNumbers(int firstNumber, int secondNumber)
        {
            Console.WriteLine(firstNumber / secondNumber);
        }
    }
}
