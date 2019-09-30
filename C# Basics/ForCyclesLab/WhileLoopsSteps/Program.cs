using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhileLoopsSteps
{
    class Program
    {
        static void Main(string[] args)
        { 
            string command = Console.ReadLine();
            int sum = 0;

            while (command != "Going home")
            {
                sum += int.Parse(command);

                if (sum >= 10000)
                {
                    Console.WriteLine($"Goal reached! Good job!");
                    break;
                }
                command = Console.ReadLine();
            }

            if (command == "Going home")
            {               
                command = Console.ReadLine();
                sum += int.Parse(command);
                if (sum < 10000)
                {
                    Console.WriteLine($"{10000 - sum} more steps to reach goal.");
                }
                else
                {
                    Console.WriteLine($"Goal reached! Good job!");
                }
                
            }
        }
    }
}
