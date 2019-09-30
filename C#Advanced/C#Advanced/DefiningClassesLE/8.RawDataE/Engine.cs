using System;
using System.Collections.Generic;
using System.Text;

namespace _8.RawDataE
{
    public class Engine
    {
        private int speed;
        private int power;

        public Engine(int speed, int power)
        {
            this.Speed = speed;
            this.Power = power;
        }

        public int Speed
        {
            get { return this.speed; }
            set { speed = value; }
        }

        public int Power
        {
            get { return this.power; }
            set { power = value; }
        }
    }
}
