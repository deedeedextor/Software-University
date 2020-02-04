using System;
using System.Collections.Generic;

namespace MUSACA.Models
{
    public class Receipt
    {
        public Receipt()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Orders = new HashSet<Order>();
        }

        public string Id { get; set; }

        public DateTime IssuedOn { get; set; }

        public string CashierId { get; set; }

        public User Cashier { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
