using System;
using System.Collections.Generic;
using System.Linq;

namespace _6.TruckTourE
{
    class Program
    {
        static void Main(string[] args)
        {
            var pumps = new Queue<int[]>();

            int numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
            {
                int[] input = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                pumps.Enqueue(input);
            }

            int index = 0;

            while (true)
            {
                int totalFuel = 0;

                foreach (var currentPetrolPump in pumps)
                {
                    int fuel = currentPetrolPump[0];
                    int distance = currentPetrolPump[1];

                    totalFuel += fuel - distance;

                    if (totalFuel < 0)
                    {
                        index++;    
                        int[] pumpToRemove = pumps.Dequeue();
                        pumps.Enqueue(pumpToRemove);
                        break;
                    }
                }

                if (totalFuel >= 0)
                {
                    break;
                }
            }

            Console.WriteLine(index);
        }
    }
}
