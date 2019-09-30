namespace CarManufacturer
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;

        /*public Car()
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }*/

        public string Make
        {
            get { return this.make; }
            set { this.make = value; }
        }

        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }

        public int Year
        {
            get { return this.year; }
            set { this.year = value; }
        }

        public double FuelQuantity
        {
            get { return this.fuelQuantity; }
            set { this.fuelQuantity = value; }
        }

        public double FuelConsumption
        {
            get { return this.fuelConsumption; }
            set { this.fuelConsumption = value; }
        }

        public void Drive(double distance)
        {
            var canContinue = this.FuelQuantity - (this.FuelConsumption * distance / 100) >= 0;

            if (canContinue)
            {
                this.FuelQuantity -= (this.FuelConsumption * distance / 100);
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
            information.Append($"Fuel: {this.FuelQuantity:F2}L");

            return information.ToString();
        }
    }
}
