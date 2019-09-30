using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Bags
{
    public class Backpack : IBag
    {
        private List<string> items;

        public Backpack()
        {
            this.Items = new List<string>();
        }

        public ICollection<string> Items { get; private set; }
    }
}
