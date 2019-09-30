using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.FashionBoutiqueE
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] valueClothes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var clothesStack = new Stack<int>(valueClothes);

            int capacityRack = int.Parse(Console.ReadLine());   

            int sumClothes = 0;
            int countRacks = 1;

            while (clothesStack.Count != 0)
            {
                if (sumClothes + clothesStack.Peek() <= capacityRack)
                {
                    sumClothes += clothesStack.Pop();
                }

                else
                {
                    sumClothes = 0;
                    countRacks++;
                }
            }
            Console.WriteLine($"{countRacks}");
        }
    }
}
