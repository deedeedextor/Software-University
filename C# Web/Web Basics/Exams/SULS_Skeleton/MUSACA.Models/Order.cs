using MUSACA.Models.Enums;

namespace MUSACA.Models
{
    public class Order
    {
        public string Id { get; set; }

        public OrderStatus Status { get; set; } = OrderStatus.Active;

        public string ProductId { get; set; }

        public Product Product { get; set; }

        public int Quantity { get; set; }

        public string CashierId { get; set; }

        public User Cashier { get; set; }
    }
}
