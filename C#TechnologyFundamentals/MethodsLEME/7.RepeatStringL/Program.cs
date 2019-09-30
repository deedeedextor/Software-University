using System;

namespace _7.RepeatStringL
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            int number = int.Parse(Console.ReadLine());

            string result = RepeatString(word, number);
            Console.WriteLine(result);
        }

        public static string RepeatString(string str, int count)
        {
            string result = string.Empty;

            for (int i = 0; i < count; i++)
            {
                result += str;
            }

            return result;
        }
    }
}
