using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.PresentDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] houses = Console.ReadLine().Split("@").Select(int.Parse).ToArray();

            string input = Console.ReadLine();
            int lastIndex = 0;

            while (input != "Merry Xmas!")
            {
                string[] tokens = input.Split();

                string command = tokens[0];
                int length = int.Parse(tokens[1]);

                for (int i = lastIndex; i < houses.Length; i++)
                {
                    if (lastIndex + length >= houses.Length)
                    {
                        lastIndex = (lastIndex + length) % houses.Length;
                    }

                    else
                    {
                        lastIndex += length;
                    }

                    if (houses[lastIndex] == 0)
                    {
                        Console.WriteLine($"House {lastIndex} will have a Merry Christmas.");
                        break;
                    }

                    else
                    {
                        houses[lastIndex] -= 2;
                        break;
                    }

                }
                input = Console.ReadLine();
            }
            int count = 0;

            for (int i = 0; i < houses.Length; i++)
            {
                if (houses[i] != 0)
                {
                    count++;
                }
            }

            Console.WriteLine($"Santa's last position was {lastIndex}.");

            if (count == 0)
            {
                Console.WriteLine("Mission was successful.");
            }
            else
            {
                Console.WriteLine($"Santa has failed {count} houses.");
            }
        }
    }
}