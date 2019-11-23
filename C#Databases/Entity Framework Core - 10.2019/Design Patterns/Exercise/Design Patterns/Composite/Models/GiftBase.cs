namespace Composite.Models
{
    public abstract class GiftBase
    {
        public GiftBase(string name, int price)
        {
            this.Name = name;
            this.Price = price;
        }

        public abstract int CalculateTotalPrice();

        public string Name { get; set; }

        public int Price { get; set; }
    }
}