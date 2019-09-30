using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhileLoopsRangeOfNumbers
{
    class Program
    {
        static void Main(string[] args)
        {          
            int smallest = int.MaxValue;
            int biggest = int.MinValue;

            while (true)
            {
                string command = Console.ReadLine();
                
                if (command == "END")
                    break;
                int number = int.Parse(command);

                if (number < smallest)
                {
                    smallest = number;
                }
                if (number > biggest)
                {
                    biggest = number;
                }
            }
            Console.WriteLine($"Max number: {biggest}");
            Console.WriteLine($"Min number: {smallest}");   
        }
    }
}
