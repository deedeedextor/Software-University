using System;
using System.Collections.Generic;
using System.Text;

namespace _8.RawDataE
{
    public class Tire
    {
        private double pressure;
        private int age;

        public Tire(double pressure, int age)
        {
            this.Pressure = pressure;
            this.Age = age;
        }

        public double Pressure
        {
            get { return this.pressure; }
            set { pressure = value; }
        }

        public int  Age
        {
            get { return this.age; }
            set { age = value; }
        }
    }
}
