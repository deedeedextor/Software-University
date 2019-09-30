using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StadiumIncome
{
    class Program
    {
        static void Main(string[] args)
        {
            int sectors = int.Parse(Console.ReadLine());
            int venues = int.Parse(Console.ReadLine());
            double priceTicket = double.Parse(Console.ReadLine());

            double income = venues * priceTicket;
            double incomeFromVenues = income / sectors;
            double charityMoney = (income - (incomeFromVenues * 0.75)) / 8;

            Console.WriteLine($"Total income - {income:F2} BGN");
            Console.WriteLine($"Money for charity - {charityMoney:F2} BGN");
        }
    }
}
