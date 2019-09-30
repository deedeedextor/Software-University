using System;
using System.Collections.Generic;
using System.Linq;

namespace _8.VehicleCatalogueL
{
    class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string HorsePower { get; set; }
    };
    class Truck
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Weight { get; set; }
    };
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<Car> cars = new List<Car>();
            List<Truck> trucks = new List<Truck>();

            while (input != "end")
            {
                string[] tokens = input.Split("/");

                string type = tokens[0];
                string brand = tokens[1];
                string model = tokens[2];
                string power = tokens[3];

                if (type == "Car")
                {
                    Car car = new Car()
                    {
                        Brand = brand,
                        Model = model,
                        HorsePower = power
                    };
                    cars.Add(car);
                }
                else if (type == "Truck")
                {
                    Truck truck = new Truck()
                    {
                        Brand = brand,
                        Model = model,
                        Weight = power
                    };
                    trucks.Add(truck);
                }
                input = Console.ReadLine();
            }

             List<Car> orderedCars = cars.OrderBy(o => o.Brand).ToList();
             List<Truck> orderedTrucks = trucks.OrderBy(o => o.Brand).ToList();

            if (orderedCars.Count != 0)
            {
                Console.WriteLine("Cars: ");

                foreach (Car car in orderedCars)
                {
                    Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
                }
            }

            if (orderedTrucks.Count != 0)
            {
                Console.WriteLine($"Trucks: ");

                foreach (Truck truck in orderedTrucks)
                {
                    Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
                }
            }
        }
    }
}
