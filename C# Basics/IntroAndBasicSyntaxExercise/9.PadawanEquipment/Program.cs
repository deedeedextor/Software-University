using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.PadawanEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int numberOfStudents = int.Parse(Console.ReadLine());
            double lightsaberPrice = double.Parse(Console.ReadLine());
            double robePrice = double.Parse(Console.ReadLine());
            double beltPrice = double.Parse(Console.ReadLine());

            double extraLightsabers = Math.Ceiling(numberOfStudents + (numberOfStudents * 0.10));
            double sixthBelts = Math.Ceiling(numberOfStudents-(numberOfStudents/6.0));

            double purchaseSum = lightsaberPrice * extraLightsabers + robePrice * numberOfStudents + beltPrice * sixthBelts;

            if (purchaseSum <= budget)
            {
                Console.WriteLine($"The money is enough - it would cost {purchaseSum:F2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivan Cho will need {(purchaseSum-budget):F2}lv more.");
            }
        }
    }
}
