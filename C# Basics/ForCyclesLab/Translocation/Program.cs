using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Translocation
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());

            string command = Console.ReadLine();
            int cubicMeter = width * length * height;
            int boxes = 0;

            while (command != "Done")
            {
                boxes += int.Parse(command);

                if (cubicMeter <= boxes)
                {
                    Console.WriteLine($"No more free space! You need {boxes - cubicMeter} Cubic meters more.");
                    break;
                }
                command = Console.ReadLine();
            }

            if (command == "Done")
            {
                Console.WriteLine($"{cubicMeter - boxes} Cubic meters left.");
            }
        }
    }
}
