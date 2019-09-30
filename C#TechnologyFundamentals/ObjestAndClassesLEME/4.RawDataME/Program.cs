using System;
using System.Collections.Generic;
using System.Linq;

namespace _4.RawDataME
{
    class Program
    {
        static void Main(string[] args)
        {
            var cars = GetCars();
            PrintCars(cars);
        }

        private static void PrintCars(Queue<Car> cars)
        {
            var command = Console.ReadLine();

            Console.WriteLine(string.Join(Environment.NewLine, cars
                        .Where(c => c.Cargo.Type == command && command == "fragile"
                            ? c.Tires
                                .Where(t => t.Pressure < 1)
                                .FirstOrDefault() != null
                            : c.Engine.Power > 250)
                        .Select(c => c.Model)));
        }

        private static Queue<Car> GetCars()
        {
            var cars = new Queue<Car>();
            var numberOfCars = int.Parse(Console.ReadLine());

            while (cars.Count < numberOfCars)
            {
                var input = Console.ReadLine().Split();
                
                var engine = new Engine(int.Parse(input[1]), int.Parse(input[2]));
                var cargo = new Cargo(int.Parse(input[3]), input[4]);
                var tires = new Tire[]
                {
                    new Tire(int.Parse(input[6]), double.Parse(input[5])),
                    new Tire(int.Parse(input[8]), double.Parse(input[7])),
                    new Tire(int.Parse(input[10]), double.Parse(input[9])),
                    new Tire(int.Parse(input[12]), double.Parse(input[11])),
                };

                cars.Enqueue(new Car(input[0], engine, cargo, tires));
            }

            return cars;
        }
    }


    class Car
    {
        private string model;
        private Engine engine;
        private Cargo cargo;
        private Tire[] tires;

        public Car(string model, Engine engine, Cargo cargo, Tire[] tires)
        {
            if (tires.Length != 4)
            {
                Console.WriteLine("Tires can not be no more neither less than 4!!!");
            }

            this.model = model;
            this.engine = engine;
            this.cargo = cargo;
            this.tires = tires;
        }

        public string Model
        {
            get { return this.model; }
        }

        public Engine Engine
        {
            get { return this.engine; }
        }

        public Cargo Cargo
        {
            get { return this.cargo; }
        }

        public Tire[] Tires
        {
            get { return this.tires; }
        }
    }

    public class Engine
    {
        private int speed;
        private int power;

        public Engine(int speed, int power)
        {
            this.speed = speed;
            this.power = power;
        }

        public int Power
        {
            get { return this.power; }
        }
    }

    public class Cargo
    {
        private int weight;
        private string type;

        public Cargo(int weight, string type)
        {
            this.weight = weight;
            this.type = type;
        }

        public string Type
        {
            get { return this.type; }
        }
    }

    public class Tire
    {
        private int age;
        private double pressure;

        public Tire(int age, double pressure)
        {
            this.age = age;
            this.pressure = pressure;
        }

        public double Pressure
        {
            get { return this.pressure; }
        }
    }
}

