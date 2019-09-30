using System;
using System.Collections.Generic;

namespace _6.WardrobeE
{
    class Program
    {
        static void Main(string[] args)
        {
            var wardrobe = new Dictionary<string, Dictionary<string, int>>();

            int numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                string color = input[0];

                string[] clothes = input[1].Split(",",StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < clothes.Length; j++)
                {
                    string currentCloth = clothes[j];

                    if (!wardrobe.ContainsKey(color))
                    {
                        wardrobe[color] = new Dictionary<string, int>() { { currentCloth, 1 } };
                    }

                    else if (wardrobe.ContainsKey(color))
                    {
                        if (!wardrobe[color].ContainsKey(currentCloth))
                        {
                            wardrobe[color].Add(currentCloth, 0);
                        }

                        wardrobe[color][currentCloth]++;
                    }
                }
            }

            string[] dublicates = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);

            string colorToFind = dublicates[0];
            string clothesToFind = dublicates[1];

            foreach (var colorKvp in wardrobe)
            {
                Console.WriteLine($"{colorKvp.Key} clothes:");

                foreach (var cloth in colorKvp.Value)
                {
                    if (colorKvp.Key == colorToFind && cloth.Key == clothesToFind)
                    {
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value} (found!)");
                    }

                    else
                    {
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value}");
                    }
                }
            }
        }
    }
}
