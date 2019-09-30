using System;

namespace _5.MultiplicationSignME
{
    class Program
    {
        static void Main(string[] args)
        {
            double num1 = double.Parse(Console.ReadLine());
            double num2 = double.Parse(Console.ReadLine());
            double num3 = double.Parse(Console.ReadLine());

            Console.WriteLine(PrintTheSignOfMultiplication(num1, num2, num3));

        }

        private static string PrintTheSignOfMultiplication(double first, double second, double third)
        {
            double[] array = { first, second, third };
            string result;
            int negativeCounter = 0;
            bool zero = false;

            for (int i = 0; i < 3; i++)
            {
                if (array[i] == 0)
                {
                    zero = true;
                }
                else if (array[i] < 0)
                {
                    negativeCounter++;
                }
            }

            if (zero)
            {
                result = "zero";
            }
            else if(negativeCounter % 2 != 0)
            {
                result = "negative";
            }
            else
            {
                result = "positive";
            }
            return result;
        }
    }
}
