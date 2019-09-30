using System;
using System.Collections.Generic;
using System.Linq;

namespace _7.SpeedRacingE
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = GetCars();

            cars = GetDistance(cars);

            PrintCars(cars);
        }

        private static void PrintCars(List<Car> cars)
        {
            Console.WriteLine(string.Join(Environment.NewLine, cars.Select(c => $"{c.Model} {c.FuelAmount:F2} {c.TravelledDistance}")));
        }

        private static List<Car> GetDistance(List<Car> cars)
        {
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] distancePromps = input.Split();

                string modelToDrive = distancePromps[1];
                int distance = int.Parse(distancePromps[2]);

                foreach (Car car in cars)
                {
                    if (car.Model == modelToDrive)
                    {
                        car.Distance(distance);
                    }
                }
            }

            return cars;
        }

        private static List<Car> GetCars()
        {
            List<Car> cars = new List<Car>();

            int numberOfCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] carPromps = Console.ReadLine().Split();

                string model = carPromps[0];
                double fuelAmount = double.Parse(carPromps[1]);
                double fuelConsumption = double.Parse(carPromps[2]);

                cars.Add(new Car(model, fuelAmount, fuelConsumption));
            }

            return cars;
        }
    }
}
