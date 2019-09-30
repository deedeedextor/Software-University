using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.BombNumbersE
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> detonationData = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            int bombNumber = detonationData[0];
            int blastPower = detonationData[1];

            while (numbers.Contains(bombNumber))
            {
                for (int i = 0; i < numbers.Count; i++)
                {
                    if (numbers[i] == bombNumber)
                    {
                        int bombIndex = i;

                        int frontIndex = bombIndex - blastPower;
                        if (frontIndex < 0)
                        {
                            frontIndex = 0;
                        }

                        int backIndex = bombIndex + blastPower;
                        if (backIndex >= numbers.Count)
                        {
                            backIndex = numbers.Count - 1;
                        }

                        for (int j = frontIndex; j <= backIndex; j++)
                        {
                            numbers.RemoveAt(frontIndex);
                        }
                    }
                }
            }
            int sum = 0;

            foreach (var number in numbers)
            {
                sum += number;
            }
            Console.WriteLine(sum);
        }
    }
}
