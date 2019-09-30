using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhileLoopsACupOfWater
{
    class Program
    {
        static void Main(string[] args)
        {
            int volumeCup = int.Parse(Console.ReadLine());

            int fill = 0;
            int counter = 0;

            while (true)
            {
                string command = Console.ReadLine();

                if (command != "Easy" && command != "Medium" && command != "Hard")
                {
                    if (fill == volumeCup)
                    {
                        Console.WriteLine($"The dispenser has been tapped {counter} times.");
                        break;
                    }
                    else if (fill > volumeCup)
                    {
                        Console.WriteLine($"{fill - volumeCup}ml has been spilled.");
                        break;
                    }
                }

                if (command == "Easy")
                {
                    fill += 50;
                }
                else if (command == "Medium")
                {
                    fill += 100;
                }
                else if (command == "Hard")
                {
                    fill += 200;
                }

                counter++;
            }           
        }
    }
}
