namespace P02_CarsSalesman
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class CarSalesman
    {
        static void Main(string[] args)
        {
            List<Engine> engines = GetEngine();

            List<Car> cars = GetCars(engines);

            PrintCars(cars);
        }

        private static void PrintCars(List<Car> cars)
        {
            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }

        private static List<Car> GetCars(List<Engine> engines)
        {
            List<Car> cars = new List<Car>();

            int carCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carCount; i++)
            {
                string[] currentCar = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string model = currentCar[0];
                string engineModel = currentCar[1];
                Engine engine = engines.FirstOrDefault(x => x.Model == engineModel);

                Car car = null;

                if (currentCar.Length == 4)
                {
                    double weight = double.Parse(currentCar[2]);
                    string color = currentCar[3];

                    car = new Car(model, engine, weight, color);
                }

                else if (currentCar.Length == 3)
                {
                    bool isWeight = double.TryParse(currentCar[2], out double weight);

                    if (isWeight)
                    {
                        car = new Car(model, engine, weight);
                    }

                    else
                    {
                        string color = currentCar[2];
                        car = new Car(model, engine, color);
                    }
                }

                else
                {
                    car = new Car(model, engine);
                }

                cars.Add(car);
            }

            return cars;
        }

        private static List<Engine> GetEngine()
        {
            List<Engine> engines = new List<Engine>();

            var engineCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < engineCount; i++)
            {
                var currentEngine = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string model = currentEngine[0];
                int power = int.Parse(currentEngine[1]);

                Engine engine = null;

                if (currentEngine.Length == 4)
                {
                    int displacement = int.Parse(currentEngine[2]);
                    string efficiency = currentEngine[3];

                    engine = new Engine(model, power, displacement, efficiency);
                }

                else if (currentEngine.Length == 3)
                {
                    bool isDisplacement = int.TryParse(currentEngine[2], out int displacement);

                    if (isDisplacement)
                    {
                        engine = new Engine(model, power, displacement);
                    }

                    else
                    {
                        string efficiency = currentEngine[2];
                        engine = new Engine(model, power, efficiency);
                    }
                }

                else
                {
                    engine = new Engine(model, power);
                }

                engines.Add(engine);
            }

            return engines;
        }
    }

}
