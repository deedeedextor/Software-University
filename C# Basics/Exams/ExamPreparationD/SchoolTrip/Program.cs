using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            int daysWitouhAnni = int.Parse(Console.ReadLine());
            int kgFood = int.Parse(Console.ReadLine());
            double firstDogFood = double.Parse(Console.ReadLine());
            double secondDogFood = double.Parse(Console.ReadLine());
            double thirdDogFood = double.Parse(Console.ReadLine());

            double totalFood = firstDogFood * daysWitouhAnni + secondDogFood * daysWitouhAnni + thirdDogFood * daysWitouhAnni;

            if (totalFood <= kgFood)
            {
                Console.WriteLine($"{Math.Floor(kgFood-totalFood)} kilos of food left.");
            }
            else
            {
                Console.WriteLine($"{Math.Ceiling(totalFood - kgFood)} more kilos of food are needed.");
            }
        }
    }
}
