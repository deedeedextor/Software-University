using System;

namespace _5.DecryptingMessages
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int numbersOfLines = int.Parse(Console.ReadLine());
            string message = string.Empty;

            for (int i = 1; i <= numbersOfLines; i++)
            {
                message += ((char)(char.Parse(Console.ReadLine()) + key)).ToString();                
            }
            Console.WriteLine(message);
        }
    }
}
