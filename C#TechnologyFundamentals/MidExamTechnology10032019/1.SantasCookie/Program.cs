using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.SantasCookie
{
    class Program
    {
        static void Main(string[] args)
        {
            int amountOfBatches = int.Parse(Console.ReadLine());
            int totalBoxes = 0;

            for (int i = 0; i < amountOfBatches; i++)
            {
                int flourGrams = int.Parse(Console.ReadLine());
                int sugarGrams = int.Parse(Console.ReadLine());
                int cocoaGrams = int.Parse(Console.ReadLine());

                int flourCups = flourGrams / 140;
                int sugarSpoons = sugarGrams / 20;
                int cocoaSpoons = cocoaGrams / 10;
               

                if (flourCups == 0 || sugarSpoons == 0 || cocoaSpoons == 0)
                {
                    Console.WriteLine($"Ingredients are not enough for a box of cookies.");
                    continue;
                }

                int minOfProducts = Math.Min(flourCups, Math.Min(sugarSpoons, cocoaSpoons));

                int cookies = ((140 + 10 + 20) * minOfProducts) / 25;
                int currentBox = cookies / 5;
                totalBoxes += currentBox;

                Console.WriteLine($"Boxes of cookies: {currentBox}");
            }
            Console.WriteLine($"Total boxes: {totalBoxes}");
        }
    }
}
