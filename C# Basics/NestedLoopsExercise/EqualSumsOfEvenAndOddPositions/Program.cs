using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualSumsOfEvenAndOddPositions
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());

            for (int i = firstNum; i <= secondNum; i++)
            {
                int first = i % 10;
                int second = (i / 10) % 10;
                int third = (i / 100) % 10;
                int fourth = (i / 1000) % 10;
                int fifth = (i / 10000) % 10;
                int sixth = (i / 100000) % 10;

                int firstSum = first + third + fifth;
                int secondSum = second + fourth + sixth;

                if (firstSum == secondSum)
                {
                    Console.Write($"{i} ");
                }             
            }
        }
    }
}
