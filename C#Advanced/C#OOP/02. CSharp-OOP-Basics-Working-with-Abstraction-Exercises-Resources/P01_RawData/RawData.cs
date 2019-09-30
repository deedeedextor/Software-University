namespace P01_RawData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class RawData
    {
        static void Main(string[] args)
        {
            List<Car> cars = GetCars();

            PrintCars(cars);

        }

        private static void PrintCars(List<Car> cars)
        {
            string command = Console.ReadLine();

            if (command == "fragile")
            {
                List<string> fragile = cars
                    .Where(x => x.Cargo.Type == "fragile" && x.Tires.Any(y => y.Pressure < 1))
                    .Select(x => x.Model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, fragile));
            }

            else
            {
                List<string> flamable = cars
                    .Where(x => x.Cargo.Type == "flamable" && x.Engine.Power > 250)
                    .Select(x => x.Model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, flamable));
            }
        }

        private static List<Car> GetCars()
        {
            List<Car> cars = new List<Car>();

            var numberOfCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCars; i++)
            {
                var currentCar = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string model = currentCar[0];

                var engine = new Engine(int.Parse(currentCar[1]), int.Parse(currentCar[2]));

                var cargo = new Cargo(int.Parse(currentCar[3]), currentCar[4]);

                Tire[] tires = new Tire[4]
                {
                    new Tire(double.Parse(currentCar[5]), int.Parse(currentCar[6])),
                    new Tire(double.Parse(currentCar[7]), int.Parse(currentCar[8])),
                    new Tire(double.Parse(currentCar[9]), int.Parse(currentCar[10])),
                    new Tire(double.Parse(currentCar[11]), int.Parse(currentCar[12])),

                };

                cars.Add(new Car(model, engine, cargo, tires));
            }

            return cars;
        }
    }
}
