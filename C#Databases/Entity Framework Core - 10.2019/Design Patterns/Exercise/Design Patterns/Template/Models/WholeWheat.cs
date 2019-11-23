using System;
using System.Collections.Generic;
using System.Text;

namespace Template.Models
{
    public class WholeWheat : Bread
    {
        public override void Bake()
        {
            Console.WriteLine("Backing the WholeWheat Bread. (15 minutes)");
        }

        public override void MixIngredients()
        {
            Console.WriteLine("Gathering Ingredients for WholeWheat Bread.");
        }
    }
}
