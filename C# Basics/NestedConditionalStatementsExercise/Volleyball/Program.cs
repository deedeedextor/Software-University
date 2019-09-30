using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volleyball
{
    class Program
    {
        static void Main(string[] args)
        {
            string year = Console.ReadLine();
            int holidaysTroughWeek = int.Parse(Console.ReadLine());
            int weekendsHomeTown = int.Parse(Console.ReadLine());

            int weekends = 48;
            int weekendsInSofia = weekends - weekendsHomeTown;
            double volleyballWeekendsSofia = weekendsInSofia * 3.0 / 4;
            double volleyballHolidaysSofia = holidaysTroughWeek * 2.0 / 3;
            double totalVolleyballGames = volleyballWeekendsSofia + weekendsHomeTown + volleyballHolidaysSofia;

            if (year == "leap")
            {
                double additionalGames = totalVolleyballGames * 0.15;
                double totalGamesLeap = totalVolleyballGames + additionalGames;
                Console.WriteLine(Math.Truncate(totalGamesLeap));
            }
            else if (year == "normal")
            {
                Console.WriteLine(Math.Truncate(totalVolleyballGames));
            }   
        }
    }
}
//double games = (48 - weekendsHomeTown) * 0.75 + weekendsHomeTown + holidaysTroughWeek * 2 / 3;

//if (year == "leap")
//{
// games *= 1.15;
//}

// Console.WriteLine(Math.Floor(games));