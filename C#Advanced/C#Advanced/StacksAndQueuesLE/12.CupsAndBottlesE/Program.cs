using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.CupsAndBottlesE
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cupsCapacity = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] filledBottles = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var bottlesStack = new Stack<int>(filledBottles); 

            var cupsQueue = new Queue<int>(cupsCapacity);

            int wastedWater = 0;

            while (cupsQueue.Any() && bottlesStack.Any())
            {
                if (bottlesStack.Peek() >= cupsQueue.Peek())
                {
                    int bottleValue = bottlesStack.Pop();
                    int cupValue = cupsQueue.Dequeue();
                    wastedWater += bottleValue - cupValue ;
                    
                }

                else 
                {
                    int remainingWater = 0;
                    int currentCup = cupsQueue.Dequeue();

                    while (currentCup > 0)
                    {
                        int currentBottle = bottlesStack.Pop();
                        currentCup -= currentBottle;
                        remainingWater = currentCup * -1;
                    }
                    wastedWater += remainingWater;
                }
            }

            if (bottlesStack.Count != 0)
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottlesStack)}");
            }

            else if (cupsQueue.Count != 0)
            {
                Console.WriteLine($"Cups: {string.Join(" ", cupsQueue)}");
            }

            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
