using System;

namespace _5.OrdersL
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());

            CalculateOrders(product, quantity);
        }

        public static void CalculateOrders(string product, int number)
        {
            if (product == "coffee")
            {
                double price = number * 1.50;
                Console.WriteLine($"{price:F2}");
            }
            else if (product == "water")
            {
                double price = number * 1.00;
                Console.WriteLine($"{price:F2}");
            }
            else if (product == "coke")
            {
                double price = number * 1.40;
                Console.WriteLine($"{price:F2}");
            }
            else if (product == "snacks")
            {
                double price = number * 2.00;
                Console.WriteLine($"{price:F2}");
            }
        }
    }
}
