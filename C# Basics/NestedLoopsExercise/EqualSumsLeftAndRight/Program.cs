using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualSumsLeftAndRight
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

                int firstSum = first + second;
                int secondSum = fourth + fifth;

                if (firstSum == secondSum)
                {
                    Console.Write($"{i} ");
                }
                else if (firstSum > secondSum)
                {
                    secondSum += third;

                    if (firstSum == secondSum)
                    {
                        Console.Write($"{i} ");
                    }
                }
                else if (secondSum > firstSum)
                {
                    firstSum += third;
                    if (firstSum == secondSum)
                    {
                        Console.Write($"{i} ");
                    }
                }
            }

        }
    }
}
