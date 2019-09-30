using System;
using System.Collections.Generic;

namespace _6.TrafficLightL
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCar = int.Parse(Console.ReadLine());
            string command = string.Empty;
            int carCount = 0;

            var lightQueue = new Queue<string>();

            while ((command = Console.ReadLine()) != "end")
            {
                if (command != "green")
                {
                    lightQueue.Enqueue(command);
                }

                else if (command == "green")
                {
                    if (lightQueue.Count >= numberOfCar)
                    {
                        for (int i = 1; i <= numberOfCar; i++)
                        {
                            Console.WriteLine($"{lightQueue.Dequeue()} passed!");
                            carCount++;
                        }
                    }

                    else
                    {
                        while (lightQueue.Count != 0)
                        {
                            Console.WriteLine($"{lightQueue.Dequeue()} passed!");
                            carCount++;
                        }
                    }
                    
                }
            }

            Console.WriteLine($"{carCount} cars passed the crossroads.");
        }
    }
}
