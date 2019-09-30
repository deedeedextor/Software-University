using System;
using System.Collections.Generic;
using System.Linq;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            var advancedMaterials = new SortedDictionary<string, int>();
            {
                advancedMaterials["Glass"] = 0;
                advancedMaterials["Aluminium"] = 0;
                advancedMaterials["Lithium"] = 0;
                advancedMaterials["Carbon fiber"] = 0;
            };

            Queue<int> liquids = new Queue<int>(
                Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Stack<int> physicalItem = new Stack<int>(
                Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());
            string material = string.Empty;

            while (liquids.Any() && physicalItem.Any())
            {
                int currentLiquid = liquids.Dequeue();
                int currentItem = physicalItem.Pop();

                if (currentLiquid + currentItem == 25)
                {
                    material = "Glass";

                    advancedMaterials[material]++;
                }

                else if (currentLiquid + currentItem == 50)
                {
                    material = "Aluminium";

                    advancedMaterials[material]++;
                }

                else if (currentLiquid + currentItem == 75)
                {
                    material = "Lithium";

                    advancedMaterials[material]++;
                }

                else if (currentLiquid + currentItem == 100)
                {
                    material = "Carbon fiber";

                    advancedMaterials[material]++;
                }

                else
                {
                    currentItem += 3;
                    physicalItem.Push(currentItem);
                }
            }

            int countZeros = 0;

            foreach (var kvp in advancedMaterials)
            {
                material = kvp.Key;
                int count = kvp.Value;

                if (count == 0)
                {
                    countZeros++;
                }
            }

            if (countZeros > 0)
            {
                Console.WriteLine($"Ugh, what a pity! You didn't have enough materials to build the spaceship.");
            }

            else
            {
                Console.WriteLine($"Wohoo! You succeeded in building the spaceship!");
            }

            if (liquids.Any())
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", liquids)}");
            }

            else
            {
                Console.WriteLine($"Liquids left: none");
            }

            if (physicalItem.Any())
            {
                Console.WriteLine($"Physical items left: {string.Join(", ", physicalItem)}");
            }

            else
            {
                Console.WriteLine($"Physical items left: none");
            }

            foreach (var kvp in advancedMaterials)
            {
                material = kvp.Key;
                int count = kvp.Value;

                Console.WriteLine($"{material}: {count}");
            }
        }
    }
}
