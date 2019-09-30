namespace _10.CarSalesmanE
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            int engineLines = int.Parse(Console.ReadLine());

            List<Engine> engines = new List<Engine>();

            for (int i = 0; i < engineLines; i++)
            {
                string[] engineTokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = engineTokens[0];
                int power = int.Parse(engineTokens[1]);

                Engine engine = null;

                if (engineTokens.Length == 4)
                {
                    int displacement = int.Parse(engineTokens[2]);
                    string efficiency = engineTokens[3];

                    engine = new Engine(model, power, displacement, efficiency);
                }

                else if (engineTokens.Length == 3)
                {
                    bool isDisplacement = int.TryParse(engineTokens[2], out int displacement);

                    if (isDisplacement)
                    {
                        engine = new Engine(model, power, displacement);
                    }

                    else
                    {
                        string efficiency = engineTokens[2];
                        engine = new Engine(model, power, efficiency);
                    }
                }

                else
                {
                    engine = new Engine(model, power);
                }

                engines.Add(engine);
            }

            int carLines = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < carLines; i++)
            {
                string[] carTokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = carTokens[0];
                string engineModel = carTokens[1];

                Engine engine = engines.Where(e => e.Model == engineModel).FirstOrDefault();
                Car car = null;

                if (carTokens.Length == 4)
                {
                    double weight = double.Parse(carTokens[2]);
                    string color = carTokens[3];

                    car = new Car(model, engine, weight, color);
                }

                else if (carTokens.Length == 3)
                {
                    bool isWeight = double.TryParse(carTokens[2], out double weight);

                    if (isWeight)
                    {
                        car = new Car(model, engine, weight);
                    }

                    else
                    {
                        string color = carTokens[2];
                        car = new Car(model, engine, color);
                    }
                }

                else
                {
                    car = new Car(model, engine);
                }

                cars.Add(car);
            }

            Console.WriteLine(string.Join(Environment.NewLine, cars));
        }
    }
}
