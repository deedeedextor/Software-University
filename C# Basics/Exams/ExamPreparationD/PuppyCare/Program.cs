using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuppyCare
{
    class Program
    {
        static void Main(string[] args)
        {
            int foodPuppyKg = int.Parse(Console.ReadLine());
            int foodPuppyGr = foodPuppyKg * 1000;
            int food = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Adopted")
                {
                    break;
                }

                food += int.Parse(input);
            }

            if (food <= foodPuppyGr)
            {
                Console.WriteLine($"Food is enough! Leftovers: {foodPuppyGr-food} grams.");
            }
            else
            {
                Console.WriteLine($"Food is not enough. You need {food - foodPuppyGr} grams more.");
            }
        }
    }
}
