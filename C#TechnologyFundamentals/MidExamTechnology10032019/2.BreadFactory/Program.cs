using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.BreadFactory
{ 
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split("|").ToArray();
            int initialEnergy = 100;
            int initialCoins = 100;
            bool isFinished = true;

            for (int i = 0; i < input.Length; i++)
            {

                string[] events = input[i].Split("-");
                string eventNameOrIngredient = events[0];
                int energyOrCoins = int.Parse(events[1]);

                if (eventNameOrIngredient == "rest")
                {
                    initialEnergy += energyOrCoins;

                    if (initialEnergy > 100)
                    {
                        energyOrCoins = Math.Abs(initialEnergy - 100 - energyOrCoins);
                        initialEnergy = 100;
                    }
                    else if (initialEnergy == 100)
                    {
                        energyOrCoins = 0;

                    }
                    Console.WriteLine($"You gained {energyOrCoins} energy.");
                    Console.WriteLine($"Current energy: {initialEnergy}.");
                }

                else if (eventNameOrIngredient == "order")
                {
                    if (initialEnergy >= 30)
                    {
                        initialEnergy -= 30;
                        initialCoins += energyOrCoins;
                        Console.WriteLine($"You earned {energyOrCoins} coins.");
                    }
                    else
                    {
                        initialEnergy += 50;
                        Console.WriteLine($"You had to rest!");
                    }
                }

                else
                {
                    if (initialCoins - energyOrCoins > 0 && initialCoins >= energyOrCoins)
                    {
                        initialCoins -= energyOrCoins;
                        Console.WriteLine($"You bought {eventNameOrIngredient}.");
                    }
                    else
                    {
                        isFinished = false;
                        Console.WriteLine($"Closed! Cannot afford {eventNameOrIngredient}.");
                        break;
                    }
                }
            }

            if (isFinished)
            {
                Console.WriteLine($"Day completed!\nCoins: {initialCoins}\nEnergy: {initialEnergy}");
            }
        }
    }
}
