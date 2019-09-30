using System;
using System.Linq;

namespace _2.DungeonestDarkExamsTechModul
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] dungeonRooms = Console.ReadLine().Split("|").ToArray();

            int initialHealth = 100;
            int initialCoins = 0;

            for (int i = 0; i < dungeonRooms.Length; i++)
            {
                string[] currentRoom = dungeonRooms[i].Split();
                string nameRoom = currentRoom[0];
                int healthOrCoins = int.Parse(currentRoom[1]);

                if (nameRoom == "potion")
                {
                    initialHealth += healthOrCoins;

                    if (initialHealth > 100)
                    {
                        healthOrCoins = healthOrCoins - (initialHealth - 100);
                        //healthOrCoins = Math.Abs(initialHealth - 100 - healthOrCoins);
                        initialHealth = 100;
                    }
                    Console.WriteLine($"You healed for {healthOrCoins} hp.");
                    Console.WriteLine($"Current health: {initialHealth} hp.");
                }

                else if (nameRoom == "chest")
                {
                    initialCoins += healthOrCoins;
                    Console.WriteLine($"You found {healthOrCoins} coins.");
                }

                else
                {
                    if (initialHealth - healthOrCoins > 0)
                    {
                        initialHealth -= healthOrCoins;
                        Console.WriteLine($"You slayed {nameRoom}.");
                    }

                    else if (initialHealth - healthOrCoins <= 0)
                    {
                        Console.WriteLine($"You died! Killed by {nameRoom}.");
                        Console.WriteLine($"Best room: {i + 1}");
                        break;
                    }
                }

                if (i + 1 == dungeonRooms.Length)
                {
                    Console.WriteLine($"You've made it!\nCoins: {initialCoins}\nHealth: {initialHealth}");
                }
            }
        }
    }
}