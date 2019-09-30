namespace BorderConstrol
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Robot
    {
        public Robot(string model, string Id)
        {
            this.Model = model;
            this.Id = Id;
        }

        public string Model { get; private set; }

        public string Id { get; private set; }
    }
}
