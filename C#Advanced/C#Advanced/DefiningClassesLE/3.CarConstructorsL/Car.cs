﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    public class Car
    {
        public string Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public double FuelQuantity { get; set; }

        public double FuelConsumption { get; set; }

        public Car()
        {
            this.Make = "VW";
            this.Model = "Golf";
            this.Year = 2025;
            this.FuelQuantity = 200;
            this.FuelConsumption = 10;
        }

        public Car(string make, string model, int year)
            : this()
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption)
            :this(make, model, year)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public void Drive(double distance)
        {
            var canContinue = this.FuelQuantity - this.FuelConsumption * distance >= 0;

            if (canContinue)
            {
                this.FuelQuantity -= this.FuelConsumption * distance;
            }

            else
            {
                throw new Exception("Not enough fuel to perform this trip!");
            }
        }

        public string WhoAmI()
        {
            StringBuilder information = new StringBuilder();

            information.AppendLine($"Make: {this.Make}");
            information.AppendLine($"Model: {this.Model}");
            information.AppendLine($"Year: {this.Year}");
            information.AppendLine($"Fuel: {this.FuelQuantity:F2}L");

            return information.ToString();
        }
    }
}

