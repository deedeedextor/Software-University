namespace BorderConstrol
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Buyer : LivingCreature, IBuyer
    {
        public Buyer(string birthDate, string name) 
            : base(birthDate, name)
        {
        }

        public int Food { get; protected set; }

        public abstract void BuyFood();
    }
}
