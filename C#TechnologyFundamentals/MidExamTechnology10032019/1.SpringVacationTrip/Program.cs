using System;

namespace _1.SpringVacationTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());
            int groupOfPeople = int.Parse(Console.ReadLine());
            double priceFuelPerKm = double.Parse(Console.ReadLine());
            double foodPerPerson = double.Parse(Console.ReadLine());
            double priceForRoom = double.Parse(Console.ReadLine());
            double expenses = 0;
            double priceHotel = 0;
            double fuel = 0;

            double foodExpenses = days * groupOfPeople * foodPerPerson;

            if (groupOfPeople <= 10)
            {
                priceHotel = days * priceForRoom * groupOfPeople;
            }
            if (groupOfPeople > 10)
            {
                priceHotel = (days * priceForRoom * groupOfPeople) * 0.75;
            }
            expenses += (foodExpenses + priceHotel);

            for (int i = 1; i <= days; i++)
            {
                if (expenses > budget)
                {
                    break;
                }

                double travelledDistance = double.Parse(Console.ReadLine());
                fuel = priceFuelPerKm * travelledDistance;
                expenses += fuel;

                if (i % 3 == 0 || i % 5 == 0)
                {
                    expenses = expenses + (expenses * 0.40);
                }
                if (i % 7 == 0)
                {
                    double receivedMoney = expenses / groupOfPeople;
                    expenses -= receivedMoney;
                }
            }

            if (expenses <= budget)
            {
                Console.WriteLine($"You have reached the destination. You have {(budget - expenses):F2}$ budget left.");
            }
            else
            {
                Console.WriteLine($"Not enough money to continue the trip. You need {(expenses - budget):F2}$ more.");
            }
        }
    }
}
