using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestPlayer
{
    class Program
    {
        static void Main(string[] args)
        {

            string namePlayerPrint = string.Empty;
            int bestGoals = 0;
            int goals = 0;

            while (true)
            {
                string namePlayer = Console.ReadLine();

                if (namePlayer == "END")
                {
                    break;
                }

                goals = int.Parse(Console.ReadLine());

                if (goals > bestGoals)
                {
                    bestGoals = goals;
                    namePlayerPrint = namePlayer;                    
                }  
                if (bestGoals >= 10)
                {
                    break;
                }
            }
            if (bestGoals >= 3 || bestGoals >= 10)
            {
                Console.WriteLine($"{namePlayerPrint} is the best player!");
                Console.WriteLine($"He has scored {bestGoals} goals and made a hat-trick !!!");
            }         
            else
            {
                Console.WriteLine($"{namePlayerPrint} is the best player!");
                Console.WriteLine($"He has scored {bestGoals} goals.");
            }
        }
    }
}
