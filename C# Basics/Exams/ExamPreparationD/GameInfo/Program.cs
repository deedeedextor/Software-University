using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int games = int.Parse(Console.ReadLine());
            double sumMinutes = 0;
            int gamesAdditionalTime = 0;
            int gamesPenalty = 0;

            for (int i = 1; i <= games; i++)
            {
                int gamesTime = int.Parse(Console.ReadLine());

                sumMinutes += gamesTime;

                if (gamesTime > 90 && gamesTime <=120)
                {
                    gamesAdditionalTime++;
                }
                else if (gamesTime > 120)
                {
                    gamesPenalty++;
                }
            }
            double averageMinutes = sumMinutes / games;

            Console.WriteLine($"{name} has played {sumMinutes} minutes. Average minutes per game: {averageMinutes:F2}");
            Console.WriteLine($"Games with penalties: {gamesPenalty}");
            Console.WriteLine($"Games with additional time: {gamesAdditionalTime}");
        }
    }
}
