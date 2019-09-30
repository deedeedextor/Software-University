﻿namespace P02_CarsSalesman
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Engine
    {
        public Engine(string model, int power, int displacement, string efficiency)
        {
            this.Model = model;
            this.Power = power;
            this.Displacement = displacement;
            this.Efficiency = efficiency;
        }

        public Engine(string model, int power) :
            this(model, power, -1, "n/a")
        {
        }

        public Engine(string model, int power, int displacement) :
            this(model, power, displacement, "n/a")
        {
        }

        public Engine(string model, int power, string efficiency) :
            this(model, power, -1, efficiency)
        {
        }
       
        public string Model { get; private set; }

        public int Power { get; private set; }

        public int Displacement { get; private set; }

        public string Efficiency { get; private set; }

        public override string ToString()
        {
            StringBuilder printEngine = new StringBuilder();

            printEngine.AppendLine($"  {this.Model}:");
            printEngine.AppendLine($"    Power: {this.Power.ToString()}");

            printEngine.AppendLine(this.Displacement == -1
                ? $"    Displacement: n/a"
                : $"    Displacement: {this.Displacement}");

            printEngine.AppendLine($"    Efficiency: {this.Efficiency}");

            return printEngine.ToString().TrimEnd();
        }
    }
}
