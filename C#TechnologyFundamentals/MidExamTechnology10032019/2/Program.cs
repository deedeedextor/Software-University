using System;
using System.Collections.Generic;
using System.Linq;

namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> fires = Console.ReadLine().Split("#").ToList();
            List<int> cells = new List<int>();

            int amountOfWater = int.Parse(Console.ReadLine());
            double effort = 0;
            int totalFire = 0;

            for (int i = 0; i < fires.Count; i++)
            {
                string[] fire = fires[i].Split(" = ");

                string typeOfFire = fire[0];
                int value = int.Parse(fire[1]);

                if (amountOfWater <= 0 && amountOfWater < value)
                {
                    break;
                }

                else if (amountOfWater >= value)
                {

                    if (typeOfFire == "High")
                    {
                        if (value >= 81 && value <= 125)
                        {
                            amountOfWater -= value;
                            totalFire += value;
                            effort += value * 0.25;
                            cells.Add(value);
                        }
                    }
                    else if (typeOfFire == "Medium")
                    {
                        if (value >= 51 && value <= 80)
                        {
                            amountOfWater -= value;
                            totalFire += value;
                            effort += value * 0.25;
                            cells.Add(value);
                        }
                    }
                    else if (typeOfFire == "Low")
                    {
                        if (value >= 1 && value <= 50)
                        {
                            amountOfWater -= value;
                            totalFire += value;
                            effort += value * 0.25;
                            cells.Add(value);
                        }
                    }
                }

            }
            Console.WriteLine("Cells:");

            foreach (var item in cells)
            {
                Console.WriteLine($"- {item}");
            }
            Console.WriteLine($"Effort: {effort:F2}");
            Console.WriteLine($"Total Fire: {totalFire}");
        }
    }
}

