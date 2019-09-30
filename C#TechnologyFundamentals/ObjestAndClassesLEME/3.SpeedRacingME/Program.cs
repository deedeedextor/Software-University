using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.SpeedRacingME
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int numberOfCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] carsProps = Console.ReadLine().Split();

                Car car = new Car(carsProps[0], double.Parse(carsProps[1]), double.Parse(carsProps[2]));
                cars.Add(car);
            }

            string input = Console.ReadLine();

            while (input != "End")
            {
                if (input == "End")
                {
                    break;
                }

                string[] command = input.Split();
                
                string modelcar = command[1];
                int distance = int.Parse(command[2]);

                foreach (Car car in cars)
                {
                    if (car.Model == modelcar)
                    {
                        car.Drive(distance);
                    }
                }
                input = Console.ReadLine();
            }

            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.distanceTraveled}");
            }
        }
    }

    class Car
    {
        public Car(string model, double fuelAmount, double fuelFor1Km)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelFor1Km = fuelFor1Km;
            distanceTraveled = 0;
        }

        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelFor1Km { get; set; }
        public int distanceTraveled;

        public void Drive(int distance)
        {
            if (distance * FuelFor1Km <= FuelAmount)
            {
                FuelAmount -= distance * FuelFor1Km;
                distanceTraveled += distance;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}
