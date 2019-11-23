﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Template.Models
{
    public class Sourdough : Bread
    {
        public override void Bake()
        {
            Console.WriteLine("Backing the Sourdough Bread. (20 minutes)");
        }

        public override void MixIngredients()
        {
            Console.WriteLine("Gathering Ingredients for Sourdough Bread.");
        }
    }
}
