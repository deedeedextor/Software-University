namespace P02_CarsSalesman
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Car
    {
        public Car(string model, Engine engine, double weight, string color)
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = weight;
            this.Color = color;
        }

        public Car(string model, Engine engine) :
            this(model, engine, -1, "n/a")
        {
        }

        public Car(string model, Engine engine, double weight) :
            this(model, engine, weight, "n/a")
        {
        }

        public Car(string model, Engine engine, string color) :
            this(model, engine, -1, color)
        {
        }

        public string Model { get; private set; }

        public Engine Engine { get; private set; }

        public double Weight { get; private set; }

        public string Color { get; private set; }

        public override string ToString()
        {
            StringBuilder printCar = new StringBuilder();

            printCar.AppendLine($"{this.Model}:");
            printCar.AppendLine( Engine.ToString());

            printCar.AppendLine(this.Weight == -1
                ? $"  Weight: n/a"
                : $"  Weight: {this.Weight}");

            printCar.AppendLine($"  Color: {this.Color}");

            return printCar.ToString().TrimEnd();
        }
    }
}
