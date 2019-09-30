using System;
using System.Linq;

namespace _8.CondenceArrayToNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int countLength = array.Length;

            while (countLength > 1)
            {
                for (int i = 0; i < array.Length - 1; i++)
                {
                    array[i] = array[i] + array[i + 1];
                }
                countLength--;
            }
            Console.WriteLine(array[0]);
        }
    }
}
