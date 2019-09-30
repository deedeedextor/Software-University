using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingTime
{
    class Program
    {
        static void Main(string[] args)
        {
            int breakTime = int.Parse(Console.ReadLine());
            double peripheryPrice = double.Parse(Console.ReadLine());
            double programPrice = double.Parse(Console.ReadLine());
            double frappePrice = double.Parse(Console.ReadLine());

            double totalSpendMoney = (peripheryPrice * 3) + (programPrice * 2) + frappePrice;
            double timeLeft = (breakTime - 5) - (3 * 2) - (2 * 2);

            Console.WriteLine($"{totalSpendMoney:f2}");
            Console.WriteLine($"{timeLeft}");
        }
    }
}
