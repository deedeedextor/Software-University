using System;
using System.Linq;
using System.Collections.Generic;

namespace _1.SantasSecretHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();
            char[] decryptedMessage = input.ToArray();

            List<string> kidsNames = new List<string>();
            bool isValid = false;
            string name = string.Empty;

            while (input != "end")
            {
                for (int i = 0; i < decryptedMessage.Length; i++)
                {
                    int currentElement = decryptedMessage[i];
                    currentElement -= key;
                    decryptedMessage[i] = (char)currentElement;
                }

                if (decryptedMessage.Contains('G'))
                {
                    isValid = true;

                    for (int i = 0; i < decryptedMessage.Length; i++)
                    {
                        char currentChar = decryptedMessage[i];

                        if (currentChar >= 'A' && currentChar <= 'Z')
                        {
                            name += currentChar;
                        }
                    }
                }
                input = Console.ReadLine();
            }
        }
    }
}
