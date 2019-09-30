using System;
using System.Collections.Generic;

namespace _6.ParkingLotL
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> parkingLot = new HashSet<string>();

            string input = string.Empty;

            while ((input = Console.ReadLine()).ToUpper() != "END")
            {
                string[] tokens = input.Split(new[] { ',',' '},StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0];
                string carNumber = tokens[1];

                if (command == "IN")
                {
                    parkingLot.Add(carNumber);
                }

                else if (command == "OUT")
                {
                    parkingLot.Remove(carNumber);
                }
            }

            if (parkingLot.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }

            else
            {
                foreach (var carnumber in parkingLot)
                {
                    Console.WriteLine(carnumber);
                }
            }
        }
    }
}
