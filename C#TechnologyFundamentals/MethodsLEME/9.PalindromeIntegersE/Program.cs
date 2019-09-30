using System;

namespace _9.PalindromeIntegersE
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            while (command != "END")
            {
                string reversed = ReverseString(command);

                if (command == reversed)
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }
                command = Console.ReadLine();
            }
        }

        private static string ReverseString(string str)
        {
            char[] chars = str.ToCharArray();
            Array.Reverse(chars);
            return new String(chars);
        }
    }
}
