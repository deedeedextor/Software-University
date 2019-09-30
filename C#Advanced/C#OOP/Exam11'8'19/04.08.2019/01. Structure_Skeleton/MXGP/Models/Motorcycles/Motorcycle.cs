using MXGP.Models.Motorcycles.Contracts;
using MXGP.Utilities.Messages;
using System;

namespace MXGP.Models.Motorcycles
{
    public abstract class Motorcycle : IMotorcycle
    {
        private string model;

        public Motorcycle(string model, int horsePower, double cubicCentimeter)
        {
            this.model = model;
            this.HorsePower = horsePower;
            this.CubicCentimeters = cubicCentimeter;
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 4)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidModel, value, 4));
                }

                this.model = value;
            }
        }

        public abstract int HorsePower { get; protected set; }

        public double CubicCentimeters { get; private set; }

        public double CalculateRacePoints(int laps)
        {
            return this.CubicCentimeters / this.HorsePower * laps;

        }
    }
}
