using System;
using System.Collections.Generic;
using System.Linq;

namespace _8.RawDataE
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = GetCars();

            Print(cars);
        }

        private static void Print(List<Car> cars)
        {
            string command = Console.ReadLine();

            Console.WriteLine(string.Join(Environment.NewLine, cars
                        .Where(c => c.Cargo.Type == command && command == "fragile"
                            ? c.Tires
                                .Where(t => t.Pressure < 1)
                                .FirstOrDefault() != null
                            : c.Engine.Power > 250)
                        .Select(c => c.Model)));
        }

        private static List<Car> GetCars()
        {
            List<Car> cars = new List<Car>();

            int numberOfCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] carsTokens = Console.ReadLine().Split();

                string model = carsTokens[0];
                var engine = new Engine(int.Parse(carsTokens[1]), int.Parse(carsTokens[2]));
                var cargo = new Cargo(int.Parse(carsTokens[3]), carsTokens[4]);

                Tire[] tires = new Tire[4]
                {
                    new Tire(double.Parse(carsTokens[5]), int.Parse(carsTokens[6])),
                    new Tire(double.Parse(carsTokens[7]), int.Parse(carsTokens[8])),
                    new Tire(double.Parse(carsTokens[9]), int.Parse(carsTokens[10])),
                    new Tire(double.Parse(carsTokens[11]), int.Parse(carsTokens[12])),
                };

                cars.Add(new Car(model, engine, cargo, tires));
            }

            return cars;
        }
    }
}
