namespace CarManufacturer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Tire
    {
        private int year;
        private double pressure;

        public int Year { get; set; }

        public double Pressure { get; set; }

        public Tire(int year, double pressure)
        {
            this.Year = year;
            this.Pressure = pressure;
        }
    }

    public class Engine
    {
        private int horsePower;
        private double cubicCapacity;

        public Engine(int horsePower, double cubicCapacity)
        {
            this.HorsePower = horsePower;
            this.CubicCapacity = cubicCapacity;
        }

        public int HorsePower { get; set; }

        public double CubicCapacity { get; set; }
    }

    public class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;
        private Engine engine;
        private Tire[] tires;

        public string Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public double FuelQuantity { get; set; }

        public double FuelConsumption { get; set; }

        public Engine Engine { get; set; }

        public Tire[] Tires { get; set; }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption)
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption, Engine engine, Tire[] tires)
            : this(make, model, year, fuelQuantity, fuelConsumption)
        {
            this.Engine = engine;
            this.Tires = tires;
        }

        public void Drive(double distance)
        {
            var canContinue = this.FuelQuantity - ((this.FuelConsumption * distance) / 100) >= 0;

            if (canContinue)
            {
                this.FuelQuantity -= ((this.FuelConsumption * distance) / 100);
            }
        }

        /*public override string ToString()
        {
            StringBuilder information = new StringBuilder();

            information.AppendLine($"Make: {this.Make}");
            information.AppendLine($"Model: {this.Model}");
            information.AppendLine($"Year: {this.Year}");
            information.AppendLine($"HorsePowers: {this.Engine.HorsePower}");
            information.AppendLine($"FuelQuantity: {this.FuelQuantity:F1}");

            return information.ToString();
        }*/
    }

    public class StartUp
    {
        static void Main(string[] args)
        {
            string inputTires = string.Empty;

            List<Tire[]> tires = new List<Tire[]>();

            while ((inputTires = Console.ReadLine()) != "No more tires")
            {
                string[] tiresPromps = inputTires.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var currentTires = new Tire[4]
                {
                    new Tire(int.Parse(tiresPromps[0]), 
                        double.Parse(tiresPromps[1])),
                    new Tire(int.Parse(tiresPromps[2]), 
                        double.Parse(tiresPromps[3])),
                    new Tire(int.Parse(tiresPromps[4]), 
                        double.Parse(tiresPromps[5])),
                    new Tire(int.Parse(tiresPromps[6]), 
                        double.Parse(tiresPromps[7])),
                };

                tires.Add(currentTires);
            }

            string inputEngines = string.Empty;

            List<Engine> engines = new List<Engine>();

            while ((inputEngines = Console.ReadLine()) != "Engines done")
            {
                string[] enginesPromps = inputEngines.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                int horsePower = int.Parse(enginesPromps[0]);
                double cubicCapacity = double.Parse(enginesPromps[1]);

                engines.Add(new Engine(horsePower, cubicCapacity));
            }

            string inputSpecial = string.Empty;

            List<Car> cars = new List<Car>();

            while ((inputSpecial = Console.ReadLine()) != "Show special")
            {
                string[] specialPromps = inputSpecial.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string make = specialPromps[0];
                string model = specialPromps[1];
                int year = int.Parse(specialPromps[2]);
                double fuelQuantity = double.Parse(specialPromps[3]);
                double fuelConsumption = double.Parse(specialPromps[4]);
                var engineIndex = int.Parse(specialPromps[5]);
                var tiresIndex = int.Parse(specialPromps[6]);

                cars.Add(new Car(make, model, year, fuelQuantity, fuelConsumption, engines[engineIndex], tires[tiresIndex]));
            }

            var filteredCars = cars
                .Where(c => c.Year >= 2017)
                .Where(c => c.Engine.HorsePower > 330)
                .Where(c => c.Tires.Sum(p => p.Pressure) >= 9 && c.Tires.Sum(p => p.Pressure) <= 10)
                .ToList();

            foreach (var car in filteredCars)
            {
                car.Drive(20);

                Console.WriteLine($"Make: {car.Make}");
                Console.WriteLine($"Model: {car.Model}");
                Console.WriteLine($"Year: {car.Year}");
                Console.WriteLine($"HorsePowers: {car.Engine.HorsePower}");
                Console.WriteLine($"FuelQuantity: {car.FuelQuantity}");
            }
        }
    }
}
