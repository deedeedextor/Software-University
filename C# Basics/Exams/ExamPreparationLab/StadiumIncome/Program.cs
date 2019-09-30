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
            int numOfSeats = int.Parse(Console.ReadLine());
            double priceTicket = double.Parse(Console.ReadLine());

            double totalIncome = numOfSeats * priceTicket;
            double incomeForSector = totalIncome / sectors;
            double moneyForCharity = (totalIncome - (incomeForSector * 0.75)) / 8;

            Console.WriteLine($"Total income - {totalIncome:F2} BGN");
            Console.WriteLine($"Money for charity - {moneyForCharity:F2} BGN");
        }
    }
}
