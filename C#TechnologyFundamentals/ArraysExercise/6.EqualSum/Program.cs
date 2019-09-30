using System;
using System.Linq;

namespace _6.EqualSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int leftSum = 0;
            int rightSum = 0;
            bool isFound = false;

            if (numbers.Length == 1)
            {
                Console.WriteLine("0");
                return;
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    leftSum += numbers[j];
                }

                for (int k = i + 1; k < numbers.Length; k++)
                {
                    rightSum += numbers[k];
                }

                if (leftSum == rightSum)
                {
                    isFound = true;
                    Console.WriteLine(i);
                    return;
                }       
                else
                {
                    leftSum = rightSum = 0;
                    
                }
            }

            if (isFound == false)
            {
                Console.WriteLine("no");
            }
        }
    }
}
