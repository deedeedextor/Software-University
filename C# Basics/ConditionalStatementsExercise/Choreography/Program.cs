using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Choreography
{
    class Program
    {
        static void Main(string[] args)
        {
            int numSteps = int.Parse(Console.ReadLine());
            int numDancers = int.Parse(Console.ReadLine());
            int numDays = int.Parse(Console.ReadLine());

            double stepsPerDay = Math.Ceiling((numSteps / numDays) /(double)numSteps * 100);
            double stepsPerDancer = stepsPerDay / numDancers;

            if (stepsPerDay <= 13)
            {
                Console.WriteLine($"Yes, they will succeed in that goal! {stepsPerDancer:F2}%.");
            }
            else
            {
                Console.WriteLine($"No, they will not succeed in that goal! Required {stepsPerDancer:F2}% steps to be learned per day.");
            }
        }
    }
}
