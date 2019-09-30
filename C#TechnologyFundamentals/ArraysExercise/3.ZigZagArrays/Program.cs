using System;
using System.Linq;

namespace _3.ZigZagArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int[] leftZigZag = new int[number];
            int[] rightZigZag = new int[number];

            for (int i = 0; i < number; i++)
            {
                int[] currentArray = Console.ReadLine().Split().Select(int.Parse).ToArray();

                if (i % 2 == 0)
                {
                    leftZigZag[i] = currentArray[0];
                    rightZigZag[i] = currentArray[1];
                }

                else
                {
                    leftZigZag[i] = currentArray[1];
                    rightZigZag[i] = currentArray[0];
                }
            }
            Console.WriteLine(string.Join(" ", leftZigZag));
            Console.WriteLine(string.Join(" ", rightZigZag));
        }
    }
}
