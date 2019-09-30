namespace BorderConstrol
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Citizen : Buyer
    {
        public Citizen(string name, int age, string id, string birthdate)
            : base(name, birthdate)
        {
            this.Age = age;
            this.Id = id;
        }

        public int Age { get; private set; }

        public string Id { get; private set; }

        public override void BuyFood()
        {
            this.Food += 10;
        }
    }
}
