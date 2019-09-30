using System;
using System.Collections.Generic;
using System.Linq;

namespace _4.FastFoodE
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantityOfFood = int.Parse(Console.ReadLine());

            int[] quantityOfOrder = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var orderQueue = new Queue<int>(quantityOfOrder);

            if (orderQueue.Count > 0)
            {
                Console.WriteLine($"{orderQueue.Max()}");
            }

            while (orderQueue.Count != 0)
            {
                int currentOrder = orderQueue.Peek();

                if (currentOrder <= quantityOfFood)
                {
                    quantityOfFood -= currentOrder;
                    orderQueue.Dequeue();
                }

                else if (currentOrder > quantityOfFood)
                {
                    Console.WriteLine($"Orders left: {string.Join(" ", orderQueue)}");
                    break;
                }

                if (orderQueue.Count == 0)
                {
                    Console.WriteLine($"Orders complete");
                }
            }
        }
    }
}
