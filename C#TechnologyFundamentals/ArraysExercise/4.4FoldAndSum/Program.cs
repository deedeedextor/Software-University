using System;
using System.Linq;

namespace _4._4FoldAndSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sequence = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int k = sequence.Length / 4;
            int[] upperRow = new int[k * 2];
            int[] lowerRow = new int[k * 2];

            for (int i = 0; i < k; i++)
            {
                upperRow[i] = sequence[k - i - 1];
                upperRow[upperRow.Length - i - 1] = sequence[sequence.Length - k + i];

                lowerRow[2 * i] = sequence[2 * i + k];
                lowerRow[2 * i + 1] = sequence[2 * i + k + 1];
            }

            int[] result = new int[sequence.Length / 2];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = upperRow[i] + lowerRow[i];
            }
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
