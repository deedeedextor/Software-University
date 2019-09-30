using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipesInPool
{
    class Program
    {
        static void Main(string[] args)
        {
            int volume = int.Parse(Console.ReadLine());
            int pipe1 = int.Parse(Console.ReadLine());
            int pipe2 = int.Parse(Console.ReadLine());
            double hours = double.Parse(Console.ReadLine());

            double water = (pipe1 + pipe2) * hours;
            

            if (water <= volume)
            {
                double volumeFull = Math.Truncate((water / volume) * 100);
                double pipe1Percent = Math.Truncate((pipe1 * hours) / water * 100);
                double pipe2Percent = Math.Truncate((pipe2 * hours) / water * 100);

                Console.WriteLine($"The pool is {volumeFull}% full. Pipe 1: {pipe1Percent}%. Pipe 2: {pipe2Percent}%.");
            }

            else if (water > volume)
            {
                double volumeOverflow = water - volume;

                Console.WriteLine($"For {hours} hours the pool overflows with {volumeOverflow} liters.");
            }


        }
    }
}
