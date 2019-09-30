using System;

namespace _1.DataTypesME
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
           
            if (input == "int")
            {
                int inputInt = int.Parse(Console.ReadLine());
                PrintMultipliedNumbers(inputInt); 
            }
            else if (input == "real")
            {
                double inputDouble = double.Parse(Console.ReadLine());
                PrintMultipliedNumbers(inputDouble);
            }
            else
            {
                input = Console.ReadLine();
                PrintMultipliedNumbers(input);
            }
            
        }

        private static void PrintMultipliedNumbers(string str)
        {
            Console.WriteLine((char)36 + str + (char)36);
        }

        private static void PrintMultipliedNumbers(double num)
        {
            Console.WriteLine($"{(num * 1.50):F2}"); 
        }

        private static void PrintMultipliedNumbers(int fistInt)
        {
            Console.WriteLine(fistInt * 2);
        }
    }
}
