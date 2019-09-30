using System;
using System.Collections.Generic;
using System.Text;

namespace _8.RawDataE
{
    public class Cargo
    {
        private int weight;
        private string type;

        public Cargo(int weight, string type)
        {
            this.Weight = weight;
            this.Type = type;
        }

        public int Weight
        {
            get { return this.weight; }
            set { weight = value; }
        }

        public string Type
        {
            get { return this.type; }
            set { type = value; }
        }
    }
}
