using System;
using System.Collections.Generic;
using System.Text;

namespace Template.Models
{
    public class TwelveGrain : Bread
    {
        public override void Bake()
        {
            Console.WriteLine("Backing the 12-Grain Bread. (25 minutes)");
        }

        public override void MixIngredients()
        {
            Console.WriteLine("Gathering Ingredients for 12-Graing Bread.");
        }
    }
}
