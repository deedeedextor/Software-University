using System;

namespace _8.MathPowerL
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            int power = int.Parse(Console.ReadLine());

            double result = MathPower(number, power);
            Console.WriteLine(result);
        }

        public static double MathPower(double number, int power)
        {
            double result = 1;

            for (int i = 0; i < power; i++)
            {
                result = result * number;
            }
            return result;
        }
    }
}
