using System;

namespace _5.Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            int tapTimes = int.Parse(Console.ReadLine());
            string message = string.Empty;

            for (int i = 1; i <= tapTimes; i++)
            {
                int input = int.Parse(Console.ReadLine());
                int length = input.ToString().Length;
                int mainDigit = input % 10;
                int offset = (mainDigit - 2) * 3;

                if (mainDigit == 8 || mainDigit == 9)
                {
                    offset++;
                }

                int letterIndex = offset + length - 1;

                if (mainDigit != 0)
                {
                    message += (char)(letterIndex + 97);
                }
                else
                {
                    message += (char)(32);
                }
            }
            Console.WriteLine(message);
        }
    }
}
