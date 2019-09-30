using System;
using System.Linq;

namespace _7.MaxSequenceOfEqualElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sequence = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int start = 0;
            int count = 0;
            int max = 0;

            for (int i = 0; i < sequence.Length - 1; i++)
            {
                if (sequence[i] == sequence[i + 1])
                {
                    count++;

                    if (count > max)
                    {
                        start = i - count;
                        max = count;
                    }
                }

                else
                {
                    count = 0;
                }
            }

            for (int j = start + 1; j <= start + max + 1 ; j++)
            {
                Console.Write(sequence[j] + " ");
            }
            Console.WriteLine();
        }
    }
}
