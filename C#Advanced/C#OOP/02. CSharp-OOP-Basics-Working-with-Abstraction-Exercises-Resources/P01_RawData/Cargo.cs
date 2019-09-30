namespace P01_RawData
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Cargo
    {
        public Cargo(int weight, string type)
        {
            this.Weight = weight;
            this.Type = type;
        }

        public int Weight { get; private set; }

        public string Type { get; private set; }
    }
}
