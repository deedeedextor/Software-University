using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time_15Secs
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int mins = int.Parse(Console.ReadLine());

            int totalMins = mins + 15;
            int totalHour = hours + totalMins/60;
            int minsAfterHour = totalMins % 60;

            if (totalHour == 24)
            {
                Console.WriteLine("0:{0:00}", minsAfterHour);
            }
            else
            {
                Console.WriteLine("{0:0}:{1:00}", totalHour, minsAfterHour);
            }
        }
    }
}
