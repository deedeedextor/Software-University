using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.TrainE
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> listOfWagons = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            int maxCapacityOfEachWagon = int.Parse(Console.ReadLine());
            string[] command = Console.ReadLine().Split();

            while (command[0] != "end")
            {
                if (command[0] == "end")
                {
                    break;
                }

                if (command[0] == "Add")
                {
                    int wagonAndPassenger = int.Parse(command[1]);
                    listOfWagons.Add(wagonAndPassenger);
                }

                else 
                {
                    int passengers = int.Parse(command[0]);
                    FitPassengers(listOfWagons, passengers, maxCapacityOfEachWagon);
                }
                command = Console.ReadLine().Split();
            }
            Console.WriteLine(string.Join(" ", listOfWagons));
        }

        private static void FitPassengers(List<int> listOfWagons, int passengers, int maxCapacity)
        {
            for (int i = 0; i < listOfWagons.Count; i++)
            {
                if (listOfWagons[i] + passengers <= maxCapacity)
                {
                    listOfWagons[i] += passengers;
                    break;
                }
            }
        }
    }
}
