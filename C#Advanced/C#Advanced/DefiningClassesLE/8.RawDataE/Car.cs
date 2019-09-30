using System;
using System.Collections.Generic;
using System.Text;

namespace _8.RawDataE
{
    public class Car
    {
        private string model;
        private Engine engine;
        private Cargo cargo;
        private Tire[] tires;

        public Car(string model, Engine engine, Cargo cargo, Tire[] tires)
        {
            if (tires.Length > 4)
            {
                throw new Exception("Tires must be exactly four!");
            }

            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
            this.Tires = tires;
        }

        public string Model
        {
            get { return this.model; }
            set { model = value; }
        }

        public Engine Engine
        {
            get { return this.engine; }
            set { engine = value; }
        }

        public Cargo Cargo
        {
            get { return this.cargo; }
            set { cargo = value; }
        }

        public Tire[] Tires
        {
            get { return this.tires; }
            set { tires = value; }
        }
    }
}
