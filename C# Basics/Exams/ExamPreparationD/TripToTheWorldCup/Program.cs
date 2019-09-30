using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripToTheWorldCup
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceGoing = double.Parse(Console.ReadLine());
            double priceReturn = double.Parse(Console.ReadLine());
            double priceTicketMatch = double.Parse(Console.ReadLine());
            int numOfMatch = int.Parse(Console.ReadLine());
            int discount = int.Parse(Console.ReadLine());

            double percentDiscount = (100 - discount) / 100.0;
            double planeTicketsDiscount = (6 * (priceGoing + priceReturn)) * percentDiscount;
            double sumOfTicketsMatch = 6 * numOfMatch * priceTicketMatch;

            double totalSum = planeTicketsDiscount + sumOfTicketsMatch;
            double singleAmount = totalSum / 6;
           
            Console.WriteLine($"Total sum: {totalSum:F2} lv.");
            Console.WriteLine($"Each friend has to pay {singleAmount:F2} lv.");
        }
    }
}
