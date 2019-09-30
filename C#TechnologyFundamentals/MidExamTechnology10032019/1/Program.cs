using System;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int players = int.Parse(Console.ReadLine());
            double groupsEnergy = double.Parse(Console.ReadLine());
            double waterForPerson = double.Parse(Console.ReadLine());
            double foodForPerson = double.Parse(Console.ReadLine());

            double totalWater = days * players * waterForPerson;
            double totalFood = days * players * foodForPerson;

            for (int i = 1; i <= days; i++)
            {
                double energyLoss = double.Parse(Console.ReadLine());

                groupsEnergy -= energyLoss;

                if (groupsEnergy <= 0)
                {
                    break;
                }

                if (i % 2 == 0)
                {
                    groupsEnergy += groupsEnergy * 0.05;
                    totalWater -= (totalWater * 0.30);

                }

                if (i % 3 == 0)
                {
                    groupsEnergy += groupsEnergy * 0.10;
                    totalFood -= (totalFood / players);
                }
            }

            if (groupsEnergy > 0)
            {
                Console.WriteLine($"You are ready for the quest. You will be left with - {groupsEnergy:F2} energy!");
            }
            else
            {
                Console.WriteLine($"You will run out of energy. You will be left with {totalFood:F2} food and {totalWater:F2} water.");
            }

        }
    }
}

