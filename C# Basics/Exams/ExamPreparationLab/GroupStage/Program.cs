using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupStage
{
    class Program
    {
        static void Main(string[] args)
        {
            string team = Console.ReadLine();
            int matches = int.Parse(Console.ReadLine());
            int countMatches = 0;
            int points = 0;
            int diffeerence = 0;

            while (countMatches < matches)
            {
                int scoredGoals = int.Parse(Console.ReadLine());
                int receivedGoals = int.Parse(Console.ReadLine());

                if (scoredGoals > receivedGoals)
                {
                    points += 3;
                }
                else if (scoredGoals == receivedGoals)
                {
                    points++;
                }
                diffeerence += scoredGoals - receivedGoals;
                countMatches++;
            }

            if (diffeerence >= 0)
            {
                Console.WriteLine($"{team} has finished the group phase with {points} points.");
                Console.WriteLine($"Goal difference: {diffeerence}.");
            }
            else
            {
                Console.WriteLine($"{team} has been eliminated from the group phase.");
                Console.WriteLine($"Goal difference: {diffeerence}.");
            }
        }
    }
}
