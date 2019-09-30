using MXGP.Utilities.Messages;
using System;

namespace MXGP.Models.Motorcycles
{
    public class SpeedMotorcycle : Motorcycle
    {
        private const double DefaultCubicCentimeter = 125;
        private const int MinimumHorsePower = 50;
        private const int MaximumHorsePower = 69;

        private int horsePower;

        public SpeedMotorcycle(string model, int horsePower) 
            : base(model, horsePower, DefaultCubicCentimeter)
        {
        }

        public override int HorsePower
        {
            get
            {
                return this.horsePower;
            }
            protected set
            {
                if (value < MinimumHorsePower && value > MaximumHorsePower)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, value, 4));
                }

                this.horsePower = value;
            }
        }
    }
}
