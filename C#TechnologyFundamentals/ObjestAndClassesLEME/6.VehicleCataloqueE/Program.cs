using System;
using System.Collections.Generic;
using System.Linq;

namespace _6.VehicleCataloqueE
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            List<Truck> trucks = new List<Truck>();

            int sumCars = 0;
            int sumTrucks = 0;

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] tokens = input.Split();

                string type = tokens[0];
                string model = tokens[1];
                string color = tokens[2];
                string horsePower = tokens[3];

                if (type == "car")
                {
                    Car car = new Car(type, model, color, horsePower);
                    cars.Add(car);

                    sumCars += int.Parse(horsePower);
                }
                else if (type == "truck")
                {
                    Truck truck = new Truck(type, model, color, horsePower);
                    trucks.Add(truck);

                    sumTrucks += int.Parse(horsePower);
                }
                input = Console.ReadLine();
            }
            string filterModel = Console.ReadLine();

            while (filterModel != "Close the Catalogue")
            {
                if (filterModel == "Close the catalogue")
                {
                    break;
                }

                List<Car> filteredCars = cars.Where(m => m.Model == filterModel).ToList();

                foreach (Car car in filteredCars)
                {
                    Console.WriteLine($"Type: Car\nModel: {car.Model}\nColor: {car.Color}\nHorsepower: {car.HorsePower}");
                }


                List<Truck> filteredtrucks = trucks.Where(m => m.Model == filterModel).ToList();

                foreach (Truck truck in filteredtrucks)
                {
                    Console.WriteLine($"Type: Truck\nModel: {truck.Model}\nColor: {truck.Color}\nHorsepower: {truck.HorsePower}");
                }
                filterModel = Console.ReadLine();
            }

            if (cars.Count > 0)
            {
                double averageHorseCars = (double)sumCars / cars.Count;
                Console.WriteLine($"Cars have average horsepower of: {averageHorseCars:F2}.");
            }
            else
            {
                Console.WriteLine($"Cars have average horsepower of: {0:F2}.");
            }

            if (trucks.Count > 0)
            {
                double averageHorseTrucks = (double)sumTrucks / trucks.Count;
                Console.WriteLine($"Trucks have average horsepower of: {averageHorseTrucks:F2}.");
            }
            else
            {
                Console.WriteLine($"Trucks have average horsepower of: {0:F2}.");
            }
        }
    }

    class Car
    {
        public Car(string type, string model, string color, string horsePower)
        {
            Type = type;
            Model = model;
            Color = color;
            HorsePower = horsePower;
        }
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string HorsePower { get; set; }
    };
    class Truck
    {
        public Truck(string type, string model, string color, string horsePower)
        {
            Type = type;
            Model = model;
            Color = color;
            HorsePower = horsePower;
        }
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string HorsePower { get; set; }
    };
}
