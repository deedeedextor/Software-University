using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harvest
{
    class Program
    {
        static void Main(string[] args)
        {
            int vineyard = int.Parse(Console.ReadLine());
            double grapes = double.Parse(Console.ReadLine());
            int wineLiters = int.Parse(Console.ReadLine());
            int numWorkers = int.Parse(Console.ReadLine());

            double totalWineLiters = ((vineyard * grapes) * 0.40) / 2.5;
            double difference = Math.Abs(wineLiters - totalWineLiters);
            double litersPerPerson = difference / numWorkers;


            if (totalWineLiters < wineLiters)
            {     
                Console.WriteLine($"It will be a tough winter! More {Math.Floor(difference)} liters wine needed.");
            }

            else if (totalWineLiters >= wineLiters)
            {
                Console.WriteLine($"Good harvest this year! Total wine: {Math.Floor(totalWineLiters)} liters.");
                Console.WriteLine($"{Math.Ceiling(difference)} liters left -> {Math.Ceiling(litersPerPerson)} liters per person.");
            }
        }
    }
}
