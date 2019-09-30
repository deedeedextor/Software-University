using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            int months = int.Parse(Console.ReadLine());
            
            double waterSum = months * 20;
            double netSum = months * 15;           

            double ElectricitySum = 0;
            double otherSumTotal = 0;
            double averageAmount = 0;

            for (int i = 1; i <= months; i++)
            {
                double electricity = double.Parse(Console.ReadLine());

                ElectricitySum += electricity;
                double percent = (electricity + 20 + 15) * 0.20;
                double otherSum = (electricity + 20 + 15) + percent;
                otherSumTotal += otherSum;

                averageAmount = (ElectricitySum + waterSum + netSum + otherSumTotal)/ months;
            }

            Console.WriteLine($"Electricity: {ElectricitySum:F2} lv");
            Console.WriteLine($"Water: {waterSum:F2} lv");
            Console.WriteLine($"Internet: {netSum:F2} lv");
            Console.WriteLine($"Other: {otherSumTotal:F2} lv");
            Console.WriteLine($"Average: {averageAmount:F2} lv");
        }
    }
}
