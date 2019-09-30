using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnBusiness
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());

            string command = Console.ReadLine();
            int commodity = width * length * height;
            int computers = 0;

            while (command != "Done")
            {
                computers += int.Parse(command);

                if (commodity <= computers)
                {
                    Console.WriteLine($"No more free space! You need {Math.Abs(commodity - computers)} Cubic meters more.");
                    return;
                }

                command = Console.ReadLine();

                if (command == "Done")
                {
                    Console.WriteLine($"{commodity - computers} Cubic meters left.");
                    return;
                }
            }
        }
    }
}
