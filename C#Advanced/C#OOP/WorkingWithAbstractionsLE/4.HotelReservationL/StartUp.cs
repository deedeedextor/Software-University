namespace _4.HotelReservationL
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();

            var priceCalculator = new PriceCalculator(input);

            Console.WriteLine(priceCalculator);
        }
    }
}
