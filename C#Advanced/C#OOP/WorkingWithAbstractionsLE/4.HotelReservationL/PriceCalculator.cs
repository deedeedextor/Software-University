namespace _4.HotelReservationL
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class PriceCalculator
    {
        private decimal pricePerNight;
        private int nights;
        private SeasonMultiplier seasonMultiplier;
        private Discount discount;

        public PriceCalculator(string[] commandArgs)
        {
            pricePerNight = decimal.Parse(commandArgs[0]);
            nights = int.Parse(commandArgs[1]);
            seasonMultiplier = Enum.Parse<SeasonMultiplier>(commandArgs[2]);
            discount = Discount.None;

            if (commandArgs.Length == 4)
            {
                discount = Enum.Parse<Discount>(commandArgs[3]);
            }
        }

        public decimal GetTotalPrice()
        {
            decimal finalPrice = pricePerNight * nights * (int)seasonMultiplier;

            return finalPrice - finalPrice * (decimal)discount / 100;
        }

        public override string ToString()
        {
            return $"{this.GetTotalPrice():F2}";
        }
    }
}
