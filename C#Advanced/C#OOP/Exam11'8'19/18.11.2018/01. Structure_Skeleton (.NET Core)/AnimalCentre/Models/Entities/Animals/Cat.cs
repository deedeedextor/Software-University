﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Entities.Animals
{
    public class Cat : Animal
    {
        public Cat(string name, int energy, int happiness, int procedureTime) 
            : base(name, energy, happiness, procedureTime)
        {
        }
    }
}
