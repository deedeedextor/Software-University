using System;
using System.Linq;

namespace _2.VowelCountE
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
           
            Console.WriteLine(CountVowels(input));
        }

        public static int CountVowels(string str)
        {            
            int countVowels = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == 'A' || str[i] == 'a' 
                    || str[i] == 'E' || str[i] == 'e'
                    || str[i] == 'I' || str[i] == 'i'
                    || str[i] == 'U' || str[i] == 'u'
                    || str[i] == 'O' || str[i] == 'o'
                    || str[i] == 'Y' || str[i] == 'y')
                {
                    countVowels++;
                }
            }
            return countVowels;
        }
    }
}
