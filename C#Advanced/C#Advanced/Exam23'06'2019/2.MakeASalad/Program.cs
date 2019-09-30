using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.MakeASalad
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputVegetables = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int[] inputCalories = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<string> vegetables = new Queue<string>(inputVegetables);

            Stack<int> calories = new Stack<int>(inputCalories);

            Queue<int> salads = new Queue<int>();

            while (calories.Any() && vegetables.Any())
            {
                int currentCalories = calories.Peek();

                while (currentCalories > 0 && vegetables.Any())
                {
                    string currentVegetable = vegetables.Dequeue();

                    if (currentVegetable == "tomato")
                    {
                        currentCalories -= 80;
                    }

                    else if (currentVegetable == "carrot")
                    {
                        currentCalories -= 136;
                    }

                    else if (currentVegetable == "lettuce")
                    {
                        currentCalories -= 109;
                    }

                    else if (currentVegetable == "potato")
                    {
                        currentCalories -= 215;
                    }
                }

                salads.Enqueue(calories.Pop());
            }

            Console.WriteLine(string.Join(" ", salads));

            if (calories.Any())
            {
                Console.WriteLine(string.Join(" ", calories));
            }

            else if (vegetables.Any())
            {
                Console.WriteLine(string.Join(" ", vegetables));
            }
        }
    }
}
