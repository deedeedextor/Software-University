using System;
using System.Collections.Generic;

namespace _6.AutoRepairAndServiceE
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] vehicles = Console.ReadLine().Split();

            var carQueue = new Queue<string>(vehicles);
            var historyStack = new Stack<string>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                if (input.Contains("Service"))
                {
                    if (carQueue.Count > 0)
                    {
                        string carToService = carQueue.Dequeue();
                        Console.WriteLine($"Vehicle {carToService} got served.");
                        historyStack.Push(carToService);
                    }
                }

                else if (input.Contains("CarInfo"))
                {
                    string[] tokens = input.Split('-');
                    string carModel = tokens[1];

                    if (carQueue.Contains(carModel))
                    {
                        Console.WriteLine("Still waiting for service.");
                    }

                    else
                    {
                        Console.WriteLine("Served.");
                    }
                }

                else if (input.Contains("History"))
                {
                    Console.WriteLine(string.Join(", ", historyStack));
                }
            }

            if (carQueue.Count > 0)
            {
                Console.WriteLine($"Vehicles for service: {string.Join(", ", carQueue)}");
            }

            Console.WriteLine($"Served vehicles: {string.Join(", ", historyStack)}");
        }
    }
}
