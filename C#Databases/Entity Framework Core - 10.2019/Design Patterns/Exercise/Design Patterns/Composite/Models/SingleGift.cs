using System;
using System.Collections.Generic;
using System.Text;

namespace Composite.Models
{
    public class SingleGift : GiftBase
    {
        public SingleGift(string name, int price) 
            : base(name, price)
        {
        }

        public override int CalculateTotalPrice()
        {
            Console.WriteLine($"{Name} with the price {Price}");

            return Price;
        }
    }
}
