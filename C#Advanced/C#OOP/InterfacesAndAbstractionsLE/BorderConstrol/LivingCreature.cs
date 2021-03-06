﻿namespace BorderConstrol
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class LivingCreature : IBirthable
    {
        public LivingCreature(string name, string birthdate)
        {
            this.Name = name;
            this.Birthdate = birthdate;
        }

        public string Name { get; private set; }

        public string Birthdate { get; private set; }
    }
}
