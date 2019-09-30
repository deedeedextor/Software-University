using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.KeyRevolverE
{
    class Program
    {
        static void Main(string[] args)
        {
            int priceForBullet = int.Parse(Console.ReadLine());
            int sizeOfGunBarrel = int.Parse(Console.ReadLine());

            int[] bullets = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var bulletStack = new Stack<int>(bullets);

            int[] locks = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var locksQueue = new Queue<int>(locks);

            int sizeOfIntelligence = int.Parse(Console.ReadLine());
            int usedBullets = 0;

            while (locksQueue.Count != 0)
            {
                if (bulletStack.Count == 0)
                {
                    break;
                }

                int bulletSize = bulletStack.Peek();
                int lockSize = locksQueue.Peek();

                if (bulletSize <= lockSize)
                {
                    Console.WriteLine("Bang!");
                    usedBullets++;
                    locksQueue.Dequeue();
                    bulletStack.Pop();
                }

                else
                {
                    Console.WriteLine("Ping!");
                    usedBullets++;
                    bulletStack.Pop();
                }

                if (usedBullets % sizeOfGunBarrel == 0 && bulletStack.Count != 0)
                {
                    Console.WriteLine("Reloading!");
                }
            }

            if (bulletStack.Count == 0 && locksQueue.Count != 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locksQueue.Count}");
            }

            else if (locksQueue.Count == 0)
            {
                int bulletsCost = usedBullets * priceForBullet;
                Console.WriteLine($"{bulletStack.Count} bullets left. Earned ${sizeOfIntelligence - bulletsCost}");
            }
        }
    }
}
