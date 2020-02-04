using System;
using System.Collections.Generic;

namespace MUSACA.Models
{
    public class Product
    {
        public Product()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Orders = new HashSet<Order>();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Barcode { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
