namespace Cars
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Tesla : Icar, IElectricCar
    {
        private string model;
        private string color;
        private int battery;

        public Tesla(string color, string model, int battery)
        {
            this.Color = color;
            this.Model = model;
            this.Battery = battery;
        }

        public string Model { get; private set; }

        public string Color { get; private set; }

        public int Battery { get; private set; }

        public string Start()
        {
            return "Engine start";
        }

        public string Stop()
        {
            return "Breaaak!";
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{this.Color} {this.GetType().Name} {this.Model} with {this.Battery} Batteries")
                .AppendLine(this.Start())
                .AppendLine(this.Stop());

            return sb.ToString().TrimEnd();
        }
    }
}
