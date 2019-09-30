using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPrize
{
    class Program
    {
        static void Main(string[] args)
        {
            int stage = int.Parse(Console.ReadLine());
            double moneyPrize = double.Parse(Console.ReadLine());
            int totalPoints = 0;

            for (int i = 1; i <= stage; i++)
            {
                int points = int.Parse(Console.ReadLine());
                if (i % 2 == 0)
                {
                    points *= 2;                  
                }

                totalPoints += points;
            }

            double prize = moneyPrize * totalPoints;
            Console.WriteLine($"The project prize was {prize:F2} lv.");
        }
    }
}
