using System;
using System.Linq;

namespace _1._1EncryptSortAndPrintArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int sequenceOfStrings = int.Parse(Console.ReadLine());
            string[] name = new string[sequenceOfStrings];
            int[] result = new int[sequenceOfStrings];
            int sum = 0;

            char[] vowel = new char[] { 'A', 'E', 'I', 'O', 'U', 'a', 'e', 'i', 'o', 'u' };

            for (int i = 0; i < sequenceOfStrings; i++)
            {
                name[i] = Console.ReadLine();

                foreach (var item in name[i])
                {
                    int length = name[i].Length;

                    if (vowel.Contains(item))
                    {
                        sum += item * length;
                    }
                    else
                    {
                        sum += item / length;
                    }
                }
                result[i] += sum;
                sum = 0;                 
            }
            Array.Sort(result);

            for (int i = 0; i < result.Length; i++)
            {
                Console.WriteLine(result[i]);
            }
        }
    }
}
