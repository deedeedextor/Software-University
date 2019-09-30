using System;

namespace _9.GreaterOfTwoValuesL
{
    class Program
    {
        static void Main(string[] args)
        {
            string dataType = Console.ReadLine();

            switch (dataType)
            {
                case "int":
                    int firstNumber = int.Parse(Console.ReadLine());
                    int secondNumber = int.Parse(Console.ReadLine());
                    int resultNumbers = GetMax(firstNumber, secondNumber);
                    Console.WriteLine(resultNumbers);
                    break;
                case "char":
                    char firstSymbol = char.Parse(Console.ReadLine());
                    char secondSymbol = char.Parse(Console.ReadLine());
                    char resultSymbols = GetMax(firstSymbol, secondSymbol);
                    Console.WriteLine(resultSymbols);
                    break;
                case "string":
                    string firstStr = Console.ReadLine();
                    string secondStr = Console.ReadLine();
                    string resultStr = GetMax(firstStr, secondStr);
                    Console.WriteLine(resultStr);
                    break;
            }
        }

        public static int GetMax(int first, int second)
        {
            return Math.Max(first, second);
        }

        public static char GetMax(char first, char second)
        {
            return (char)Math.Max(first, second);
        }

        public static string GetMax(string first, string second)
        {
            int comparison = first.CompareTo(second);

            if (comparison > 0)
            {
                return first;
            }
            else
            {
                return second;
            }
        }
    }
}
