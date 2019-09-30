using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charity
{
    class Program
    {
        static void Main(string[] args)
        {
            int numDays = int.Parse(Console.ReadLine());
            int numPastryCookers = int.Parse(Console.ReadLine());
            int numCakes = int.Parse(Console.ReadLine());
            int numWaffles = int.Parse(Console.ReadLine());
            int numPancakes = int.Parse(Console.ReadLine());

            var amountCakes = numCakes * 45;
            var amountWaffles = numWaffles * 5.80;
            var amountPancakes = numPancakes * 3.20;

            var amountPerDAy = (amountCakes + amountWaffles + amountPancakes) * numPastryCookers;
            var amountCharity = amountPerDAy * numDays;
            var amountAfterExpense = amountCharity - (amountCharity/8);

            Console.WriteLine($"{amountAfterExpense:F2}");
        }
    }
}
