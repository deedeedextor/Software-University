using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyMoon
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string town = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());
            double totalSum = 0;

            if (town == "Cairo")
            {
                totalSum = nights * (250 * 2) + 600;

                if (nights >= 1 && nights < 5)
                {
                    totalSum *= 0.97;
                }
                else if (nights >= 5 && nights < 10)
                {
                    totalSum *= 0.95;
                }
                else if (nights >= 10 && nights <25)
                {
                    totalSum *= 0.90;
                }
                else if (nights >= 25 && nights < 50)
                {
                    totalSum *= 0.83;
                }
                else if (nights >= 50)
                {
                    totalSum *= 0.70;
                }
            }
            else if (town == "Paris")
            {
                 totalSum = nights * (150 * 2) + 350;

                if (nights >= 5 && nights < 10)
                {
                    totalSum *= 0.93;
                }
                else if (nights >= 10 && nights < 25)
                {
                    totalSum *= 0.88;
                }
                else if (nights >= 25 && nights < 50)
                {
                    totalSum *= 0.78;
                }
                else if (nights >= 50)
                {
                    totalSum *= 0.70;
                }
            }
            else if (town == "Lima")
            {
                 totalSum = nights * (400 * 2) + 850;

                if (nights >= 25 && nights < 50)
                {
                    totalSum *= 0.81;
                }
                else if (nights >= 50)
                {
                    totalSum *= 0.70;
                }
            }
            else if (town == "New York")
            {
                 totalSum = nights * (300 * 2) + 650;

                if (nights >= 1 && nights < 5)
                {
                    totalSum *= 0.97;
                }
                else if (nights >= 5 && nights < 10)
                {
                    totalSum *= 0.95;
                }
                else if (nights >= 10 && nights < 25)
                {
                    totalSum *= 0.88;
                }
                else if (nights >= 25 && nights < 50)
                {
                    totalSum *= 0.81;
                }
                else if (nights >= 50)
                {
                    totalSum *= 0.70;
                }
            }
            else if (town == "Tokyo")
            {
                 totalSum = nights * (350 * 2) + 700;

                if (nights >= 10 && nights < 25)
                {
                    totalSum *= 0.88;
                }
                else if (nights >= 25 && nights < 50)
                {
                    totalSum *= 0.83;
                }
                else if (nights >= 50)
                {
                    totalSum *= 0.70;
                }
            }

            if (totalSum <= budget)
            {
                Console.WriteLine($"Yes! You have {(budget-totalSum):F2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {(totalSum-budget):F2} leva.");
            }
        }
    }
}
