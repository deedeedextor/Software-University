using System;
using System.Collections.Generic;
using System.Text;

namespace _7.SpeedRacingE
{
    public class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumption;
        private double travelledDistance;

        public Car(string model, double fuelAmount, double fuelConsumption)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumption = fuelConsumption;
            this.travelledDistance = 0.0;
        }

        public string Model
        {
            get { return this.model; }
            set { model = value; }
        }

        public double FuelAmount
        {
            get { return fuelAmount; }
            set { fuelAmount = value; }
        }

        public double FuelConsumption
        {
            get { return fuelConsumption; }
            set { fuelConsumption = value; }
        }

        public double TravelledDistance
        {
            get { return this.travelledDistance; }
            set { travelledDistance = value; }
        }

        public void Distance(int distance)
        {
            if (fuelConsumption * distance <= fuelAmount)
            {
                fuelAmount -= fuelConsumption * distance;
                travelledDistance += distance;
            }

            else
            {
                Console.WriteLine($"Insufficient fuel for the drive");
                return;
            }
        }
    }
}
